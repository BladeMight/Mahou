using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Mahou.Resources.Strings;

namespace Mahou
{
	class KMHook // Keyboard & Mouse Hook
	{
		#region Variables
		public enum KMMessages // KMMessages Values
		{
			WM_LBUTTONDOWN = 0x0201,
			WM_LBUTTONUP = 0x0202,
			WM_MOUSEMOVE = 0x0200,
			WM_MOUSEWHEEL = 0x020A,
			WM_RBUTTONDOWN = 0x0204,
			WM_RBUTTONUP = 0x0205,
			WM_MBUTTONDOWN = 0x0207,
			WM_MBUTTONUP = 0x0208,
			WH_KEYBOARD_LL = 13,
			WH_MOUSE_LL = 14,
			WM_KEYDOWN = 0x0100,
			WM_KEYUP = 0x0101,
			WM_SYSKEYDOWN = 0x0104,
			WM_SYSKEYUP = 0x0105
		}
		public static bool self, win, alt, ctrl, shift,
			shiftRP, ctrlRP, altRP, //RP = Re-Press
			awas, swas, cwas, afterEOS, //*was = alt/shift/ctrl was
			keyAfterCTRL, hklOK, hksOK, hklineOK, hkSIOK,
			hotkeywithmodsfired, csdoing, incapt, waitfornum;
		static List<Keys> tempNumpads = new List<Keys>();
		static List<char> c_snip = new List<char>();
		public static System.Windows.Forms.Timer doublekey = new System.Windows.Forms.Timer();
		public delegate IntPtr LowLevelProc(int nCode, IntPtr wParam, IntPtr lParam);
		public static string[] snipps = new []{ "mahou", "eml" };
		public static string[] exps = new [] {
			"Mahou (魔法) - Magical layout switcher.",
			"BladeMight@gmail.com"
		};
		#endregion
		#region Keyboard & Mouse hooks events
		public static IntPtr SetHook(LowLevelProc proc, int type)
		{
			using (Process currProcess = Process.GetCurrentProcess())
			using (ProcessModule currModule = currProcess.MainModule) {
				return SetWindowsHookEx(type, proc,
					GetModuleHandle(currModule.ModuleName), 0);		
			}
		}
		public static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			int vkCode = Marshal.ReadInt32(lParam);
			var Key = (Keys)vkCode; // "Key" will further be used instead of "(Keys)vkCode"
			#region Multiple last words convert
			if (waitfornum && wParam == (IntPtr)(int)KMMessages.WM_KEYUP && !shift && !ctrl && !alt) {
				waitfornum = false;
				if (Key >= Keys.D1 && Key <= Keys.D9) {
					self = true;
					KInputs.MakeInput(new [] { KInputs.AddKey(Keys.Back, true),
						KInputs.AddKey(Keys.Back, false)
					});
					self = false;
					int wordnum = Convert.ToInt32(Key.ToString().Replace("D", ""));
					Logging.Log("Attempt to convert " + wordnum + " word(s).");
					var words = new List<YuKey>();
					try {
						foreach (var word in MMain.c_words.GetRange(MMain.c_words.Count-wordnum,wordnum)) {
							words.AddRange(word);
						}
						Logging.Log("Full character count in all " + wordnum + " last word(s) is " + words.Count + ".");
					} catch {
						Logging.Log("Converting " + wordnum + " word(s) impossible it is bigger that entered words.");
					}
					var t = new Task(new Action(() => ConvertLast(words)));
					t.RunSynchronously();
				}
			}
			if (MMain.c_words.Count == 0) {
				MMain.c_words.Add(new List<YuKey>());
			}
			#endregion
			#region Checks modifiers that are down
			switch (Key) {
				case Keys.LShiftKey:
				case Keys.RShiftKey:
				case Keys.ShiftKey:
					shift = ((wParam == (IntPtr)(int)KMMessages.WM_SYSKEYDOWN) ? true : false) || ((wParam == (IntPtr)(int)KMMessages.WM_KEYDOWN) ? true : false);
					break;
				case Keys.RControlKey:
				case Keys.LControlKey:
				case Keys.ControlKey:
					ctrl = (wParam == (IntPtr)(int)KMMessages.WM_KEYDOWN) ? true : false;
					break;
				case Keys.RMenu:
				case Keys.LMenu:
				case Keys.Menu:
					alt = ((wParam == (IntPtr)(int)KMMessages.WM_SYSKEYDOWN) ? true : false) || ((wParam == (IntPtr)(int)KMMessages.WM_KEYDOWN) ? true : false);
					break;
				case Keys.RWin:
				case Keys.LWin:
					win = (wParam == (IntPtr)(int)KMMessages.WM_KEYDOWN) ? true : false;
					break;
				default:
					Logging.Log("Catched Key=[" + Key + "] with VKCode=[" + vkCode + "] and message=[" + (int)wParam + "], modifiers=[" + (shift ? "Shift" : "") + (alt ? "Alt" : "") + (ctrl ? "Ctrl" : "") + (win ? "Win" : "") + "].");
					break;
			}
			#endregion)
			#region Hotkeys
			switch (vkCode) {
				case 160:
				case 161:
					vkCode = 16;
					break;
				case 162:
				case 163:
					vkCode = 17;
					break;
				case 164:
				case 165:
					vkCode = 18;
					break;
				case 240:
					vkCode = 20;
					break;
			}
			var thishk = new Hotkey(vkCode, new []{ ctrl, shift, alt });
			if (!self && thishk.keyCode == 20 &&
			    (thishk.Equals(MMain.mahou.HKCLast) ||
			    thishk.Equals(MMain.mahou.HKCLine) ||
			    thishk.Equals(MMain.mahou.HKCSelection))) {
				self = true;
				if (Control.IsKeyLocked(Keys.CapsLock)) { // Turn off if alraedy on
					KeybdEvent(Keys.CapsLock, 0);
					KeybdEvent(Keys.CapsLock, 2);
				}
				//Code below removes CapsLock original action, but if hold will not work and will stuck, press again to off.
				KeybdEvent(Keys.CapsLock, 0);
				KeybdEvent(Keys.CapsLock, 2);
				self = false;
			}
			if (!MMain.mahou.Focused && !self &&
			    wParam == (IntPtr)(int)KMMessages.WM_KEYUP) {			
				MMain.mahou.IfNotExist();
				if (!MMain.MyConfs.ReadBool("DoubleKey", "Use"))
					hklOK = hksOK = hklineOK = hkSIOK = true;
				if (!MMain.mahou.Active && !MMain.mahou.moreConfigs.Visible || !MMain.mahou.Active && !MMain.mahou.moreConfigs.Active) {
					if (MMain.MyConfs.ReadBool("EnabledHotkeys", "HKCSEnabled")) {
						if (thishk.Equals(MMain.mahou.HKCSelection) && hksOK) {
							Logging.Log("Hotkey convert selection fired.");
							if (MMain.MyConfs.ReadBool("Functions", "BlockCTRL") &&
							    MMain.MyConfs.Read("Hotkeys", "HKCSMods").Contains("Control")) {
							} else {
								if (Array.Exists(Hotkey.GetMods(MMain.MyConfs.Read("Hotkeys", "HKCSMods")), b => b == true) &&
								    MMain.MyConfs.ReadBool("Functions", "RePress")) {
									hotkeywithmodsfired = true;
									RePressAfter(MMain.MyConfs.Read("Hotkeys", "HKCSMods"));
								}
								SendModsUp(Hotkey.GetMods(MMain.MyConfs.Read("Hotkeys", "HKCSMods")));
								IfKeyIsMod(Key);
								var t = new Task(ConvertSelection);
								t.RunSynchronously();
							}
						}
						if (thishk.Equals(MMain.mahou.HKCSelection) && MMain.MyConfs.ReadBool("DoubleKey", "Use")) {
							Logging.Log("Waiting for second hotkey press of convert selection hotkey.");
							hksOK = true;
							doublekey.Interval = MMain.MyConfs.ReadInt("DoubleKey", "Delay");
							doublekey.Start();
						}
					}
					if (MMain.MyConfs.ReadBool("EnabledHotkeys", "HKCLEnabled")) {
						if (thishk.Equals(MMain.mahou.HKCLast) && hklOK && !csdoing) {
							Logging.Log("Hotkey convert last word fired.");
							if (MMain.MyConfs.ReadBool("Functions", "BlockCTRL") &&
							    MMain.MyConfs.Read("Hotkeys", "HKCLMods").Contains("Control")) {
							} else {
								if (Array.Exists(Hotkey.GetMods(MMain.MyConfs.Read("Hotkeys", "HKCLMods")), b => b == true) &&
								    MMain.MyConfs.ReadBool("Functions", "RePress")) {
									hotkeywithmodsfired = true;
									RePressAfter(MMain.MyConfs.Read("Hotkeys", "HKCLMods"));
								}
								SendModsUp(Hotkey.GetMods(MMain.MyConfs.Read("Hotkeys", "HKCLMods")));
								IfKeyIsMod(Key);
								var t = new Task(new Action(() => ConvertLast(MMain.c_word)));
								t.RunSynchronously();
							}
						}
						if (thishk.Equals(MMain.mahou.HKCLast) && MMain.MyConfs.ReadBool("DoubleKey", "Use")) {
							Logging.Log("Waiting for second hotkey press of convert last word hotkey.");
							hklOK = true;
							doublekey.Interval = MMain.MyConfs.ReadInt("DoubleKey", "Delay");
							doublekey.Start();
						}
					}
					if (MMain.MyConfs.ReadBool("EnabledHotkeys", "HKCLineEnabled")) {
						if (thishk.Equals(MMain.mahou.HKCLine) && hklineOK && !csdoing) {
							Logging.Log("Hotkey convert line fired.");
							if (MMain.MyConfs.ReadBool("Functions", "BlockCTRL") &&
							    MMain.MyConfs.Read("Hotkeys", "HKCLineMods").Contains("Control")) {
							} else {
								if (Array.Exists(Hotkey.GetMods(MMain.MyConfs.Read("Hotkeys", "HKCLineMods")), b => b == true) &&
								    MMain.MyConfs.ReadBool("Functions", "RePress")) {
									hotkeywithmodsfired = true;
									RePressAfter(MMain.MyConfs.Read("Hotkeys", "HKCLineMods"));
								}
								SendModsUp(Hotkey.GetMods(MMain.MyConfs.Read("Hotkeys", "HKCLineMods")));
								IfKeyIsMod(Key);
								var line = new List<YuKey>();
								foreach (var word in MMain.c_words) {
									line.AddRange(word);
								}
								var t = new Task(new Action(() => ConvertLast(line)));
								t.RunSynchronously();
							}
						}
						if (thishk.Equals(MMain.mahou.HKCLine) && MMain.MyConfs.ReadBool("DoubleKey", "Use")) {
							Logging.Log("Waiting for second hotkey press of convert line hotkey.");
							hklineOK = true;
							doublekey.Interval = MMain.MyConfs.ReadInt("DoubleKey", "Delay");
							doublekey.Start();
						}
					}
					csdoing = false;
				}
				if (MMain.MyConfs.ReadBool("EnabledHotkeys", "HKSymIgnEnabled")) {
					if (thishk.Equals(MMain.mahou.HKSymIgn) && hkSIOK) {
						Logging.Log("Hotkey symbol ignore mode fired.");
						if (MMain.MyConfs.ReadBool("Functions", "SymIgnModeEnabled")) {
							MMain.MyConfs.Write("Functions", "SymIgnModeEnabled", "false");
							MMain.mahou.Icon = MMain.mahou.icon.trIcon.Icon = Properties.Resources.MahouTrayHD;
						} else {
							MMain.MyConfs.Write("Functions", "SymIgnModeEnabled", "true");
							MMain.mahou.Icon = MMain.mahou.icon.trIcon.Icon = Properties.Resources.MahouSymbolIgnoreMode;
						}
					}
					if (thishk.Equals(MMain.mahou.HKSymIgn) && MMain.MyConfs.ReadBool("DoubleKey", "Use")) {
						Logging.Log("Waiting for second hotkey press of symbol ignore mode hotkey.");
						hkSIOK = true;
						doublekey.Interval = MMain.MyConfs.ReadInt("DoubleKey", "Delay");
						doublekey.Start();
					}
				}
			}
			//these are global, so they don't need to be stoped when window is visible.
			if (thishk.Equals(MMain.mahou.HKConMorWor) && wParam == (IntPtr)(int)KMMessages.WM_KEYUP)
				waitfornum = true;
			if (thishk.Equals(MMain.mahou.Mainhk) && wParam == (IntPtr)(int)KMMessages.WM_KEYUP)
				MMain.mahou.ToggleVisibility();
			if (thishk.Equals(MMain.mahou.ExitHk) && wParam == (IntPtr)(int)KMMessages.WM_KEYUP)
				MMain.mahou.ExitProgram();
			#endregion
			#region Snippets
			if (MMain.MyConfs.ReadBool("Functions", "Snippets")) {
				if (((Key >= Keys.D0 && Key <= Keys.Z) || // This is 0-9 & A-Z
				    Key >= Keys.Oem1 && Key <= Keys.OemBackslash // All other printables
				    ) && !self && !win && !alt && !ctrl && wParam == (IntPtr)(int)KMMessages.WM_KEYUP) {
					var stb = new StringBuilder(10);
					var by = new byte[256];
					if (shift) {
						by[(int)Keys.ShiftKey] = 0xFF;
					}
					ToUnicodeEx((uint)vkCode, (uint)vkCode, by, stb, stb.Capacity, 0, (IntPtr)Locales.GetCurrentLocale());
					c_snip.Add(stb.ToString()[0]);
				}
				if (wParam == (IntPtr)(int)KMMessages.WM_KEYUP && Key == Keys.Space) {
					var snip = "";
					foreach (var ch in c_snip) {
						snip += ch;
					}
					Logging.Log("Current snippet is [" + snip + "].");
					for (int i = 0; i < snipps.Length; i++) {
						if (snip == snipps[i]) {
							Logging.Log("Current snippet [" + snip + "] matched existing snippet [" + snipps[i] + "].");
							self = true;
							for (int e = -1; e < c_snip.Count; e++) {
								KInputs.MakeInput(new [] { KInputs.AddKey(Keys.Back, true),
									KInputs.AddKey(Keys.Back, false) 
								});
							}
							Logging.Log("Last word, words cleared due to snippet expansion.");
							Logging.Log("Expanding snippet [" + snip + "] to [" + snipps[i] + "].");
							MMain.c_words.Clear();
							MMain.c_word.Clear();
							try {
								KInputs.MakeInput(KInputs.AddString(exps[i]));
							} catch {
								Logging.Log("Some snippets configured wrong, check them.", 1);
								// If not use TASK, form(MessageBox) won't accept the keys(Enter/Escape/Alt+F4).
								var tsk = new Task(() => MessageBox.Show(Strings.SnippetsConfiguredWrong, Strings.MahouSnippetsError, MessageBoxButtons.OK, MessageBoxIcon.Error));
								tsk.Start();
								KInputs.MakeInput(KInputs.AddString(snip));
							}
							self = false;
						}
					}
					c_snip.Clear();
				}
			}
			#endregion
			#region Release Re-Pressed keys
			if (hotkeywithmodsfired && wParam == (IntPtr)(int)KMMessages.WM_KEYUP && !self &&
			    (Key == Keys.LShiftKey || Key == Keys.LMenu || Key == Keys.LControlKey)) {
				self = true;
				hotkeywithmodsfired = false;
				var mods = new bool[3];
				if (cwas) {
					cwas = false;
					mods[0] = true;
				}
				if (swas) {
					swas = false;
					mods[1] = true;
				}
				if (awas) {
					awas = false;
					mods[2] = true;
				}
				SendModsUp(mods);
				self = false;
			}
			#endregion
			#region Switch only key
			if (!self && !shift && MMain.MyConfs.Read("HotKeys", "OnlyKeyLayoutSwicth") == "CapsLock" &&
			    Key == Keys.CapsLock && wParam == (IntPtr)(int)KMMessages.WM_KEYUP) {
				self = true;
				ChangeLayout();
				Logging.Log("Changing layout by CapsLock key.");
				self = false;
			}
			if (!self && !shift && MMain.MyConfs.Read("HotKeys", "OnlyKeyLayoutSwicth") == "CapsLock" &&
			    Key == Keys.CapsLock && wParam == (IntPtr)(int)KMMessages.WM_KEYDOWN) {
				self = true;
				if (Control.IsKeyLocked(Keys.CapsLock)) { // Turn off if alraedy on
					KeybdEvent(Keys.CapsLock, 0);
					KeybdEvent(Keys.CapsLock, 2);
				}
				//Code below removes CapsLock original action, but if hold will not work and will stuck, press again to off.
				KeybdEvent(Keys.CapsLock, 0);
				KeybdEvent(Keys.CapsLock, 2);
				self = false;
			}
			// Additional fix for scroll tip.
			if (!self && MMain.MyConfs.ReadBool("Functions", "ScrollTip") &&
			    Key == Keys.Scroll && wParam == (IntPtr)(int)KMMessages.WM_KEYDOWN) {
				self = true;
				if (Control.IsKeyLocked(Keys.Scroll)) { // Turn off if alraedy on
					KeybdEvent(Keys.Scroll, 0);
					KeybdEvent(Keys.Scroll, 2);
				}
				KeybdEvent(Keys.Scroll, 0);
				KeybdEvent(Keys.Scroll, 2);
				self = false;
			}
			if (!self && MMain.MyConfs.Read("HotKeys", "OnlyKeyLayoutSwicth") == "Left Control" &&
			    Key == Keys.LControlKey && wParam == (IntPtr)(int)KMMessages.WM_KEYUP &&
			    !MMain.MyConfs.ReadBool("ExtCtrls", "UseExtCtrls")) {
				self = true;
				if (MMain.MyConfs.ReadBool("Functions", "EmulateLayoutSwitch")) {
					KeybdEvent(Keys.LControlKey, 2); // Sends it up to make it work when using "EmulateLayoutSwitch" 
				}
				Logging.Log("Changing layout by LCtrl key.");
				ChangeLayout();
				KeybdEvent(Keys.LControlKey, 2); //fix for PostMessage, it somehow o_0 sends another ctrl...

				self = false;
			}
			if (!self && MMain.MyConfs.Read("HotKeys", "OnlyKeyLayoutSwicth") == "Right Control" &&
			    Key == Keys.RControlKey && wParam == (IntPtr)(int)KMMessages.WM_KEYUP &&
			    !MMain.MyConfs.ReadBool("ExtCtrls", "UseExtCtrls")) {
				self = true;
				if (MMain.MyConfs.ReadBool("Functions", "EmulateLayoutSwitch")) {
					KeybdEvent(Keys.RControlKey, 2); // Sends it up to make it work when using "EmulateLayoutSwitch" 
				}
				Logging.Log("Changing layout by RCtrl key.");
				ChangeLayout();
				self = false;
			}
			#endregion
			#region By Ctrls switch
			keyAfterCTRL |= !self && wParam == (IntPtr)(int)KMMessages.WM_KEYUP && ctrl;
			if (!self && MMain.MyConfs.ReadBool("ExtCtrls", "UseExtCtrls") && wParam == (IntPtr)(int)KMMessages.WM_KEYUP && !keyAfterCTRL) {
				if (Key == Keys.RControlKey) {
					Logging.Log("Switching to specific layout by RCtrl key.");
					PostMessage(Locales.ActiveWindow(), KInputs.WM_INPUTLANGCHANGEREQUEST, 0, (uint)MMain.MyConfs.ReadInt("ExtCtrls", "RCLocale"));
				}
				if (Key == Keys.LControlKey) {
					Logging.Log("Switching to specific layout by LCtrl key.");
					PostMessage(Locales.ActiveWindow(), KInputs.WM_INPUTLANGCHANGEREQUEST, 0, (uint)MMain.MyConfs.ReadInt("ExtCtrls", "LCLocale"));
				}
			}
			keyAfterCTRL &= self || wParam != (IntPtr)(int)KMMessages.WM_KEYUP || (Key != Keys.LControlKey && Key != Keys.RControlKey);
			#endregion
			#region Other, when KeyDown
			if (nCode >= 0 && wParam == (IntPtr)(int)KMMessages.WM_KEYDOWN && !self && !waitfornum) {
				if (Key == Keys.Back) { //Removes last item from current word when user press Backspace
					if (MMain.c_word.Count != 0) {
						MMain.c_word.RemoveAt(MMain.c_word.Count - 1);
					}
					if (MMain.c_words.Count > 0) {
						if (MMain.c_words[MMain.c_words.Count - 1].Count - 1 > 0) {
							Logging.Log("Removed key ["+MMain.c_words[MMain.c_words.Count - 1][MMain.c_words[MMain.c_words.Count - 1].Count - 1].key+"] from last word in words.");
							MMain.c_words[MMain.c_words.Count - 1].RemoveAt(MMain.c_words[MMain.c_words.Count - 1].Count - 1);
						} else {
							Logging.Log("Removed one empty word from current words.");
							MMain.c_words.RemoveAt(MMain.c_words.Count - 1);
						}
					}
					if (MMain.MyConfs.ReadBool("Functions", "Snippets")) {
						if (c_snip.Count != 0) {
							c_snip.RemoveAt(c_snip.Count - 1);
							Logging.Log("Removed one character from current snippet.");
						}
					}
				}
				//Pressing any of these Keys will empty current word, and snippet
				if (Key == Keys.Enter || Key == Keys.Home || Key == Keys.End ||
				    Key == Keys.Tab || Key == Keys.PageDown || Key == Keys.PageUp ||
				    Key == Keys.Left || Key == Keys.Right || Key == Keys.Down || Key == Keys.Up ||
				    (ctrl && Key != Keys.None)) { //Ctrl modifier + Any key will clear word too
					Logging.Log("Last word cleared.");
					MMain.c_word.Clear();
					if (MMain.MyConfs.ReadBool("Functions", "Snippets")) {
						c_snip.Clear();
						Logging.Log("Snippet cleared.");
					}
				}
				if (Key == Keys.Enter || Key == Keys.Home || Key == Keys.End ||
				    Key == Keys.Tab || Key == Keys.PageDown || Key == Keys.PageUp ||
				    Key == Keys.Left || Key == Keys.Right || Key == Keys.Down || Key == Keys.Up) {
					Logging.Log("Words cleared.");
					MMain.c_words.Clear();
				}
				if (Key == Keys.Space) {
					Logging.Log("Adding one new empty word to words, and adding to it [Space] key.");
					MMain.c_words.Add(new List<YuKey>());
					MMain.c_words[MMain.c_words.Count - 1].Add(new YuKey() { key = Keys.Space });
					if (MMain.MyConfs.ReadBool("Functions", "EatOneSpace") && MMain.c_word.Count != 0 &&
					    MMain.c_word[MMain.c_word.Count - 1].key != Keys.Space) {
						Logging.Log("Eat one space passed, next space will clear last word.");
						MMain.c_word.Add(new YuKey() { key = Keys.Space });
						afterEOS = true;
					} else {
						MMain.c_word.Clear();
						Logging.Log("Last word cleared.");
						afterEOS = false;
					}
				}
				if (((Key >= Keys.D0 && Key <= Keys.Z) || // This is 0-9 & A-Z
				    Key >= Keys.Oem1 && Key <= Keys.OemBackslash // All other printables
				    ) && !win && !alt && !ctrl) {
					if (afterEOS) { //Clears word after Eat ONE space
						MMain.c_word.Clear();
						afterEOS = false;
					}
					if (!shift) {
						MMain.c_word.Add(new YuKey() {
							key = Key,
							upper = false
						});
						MMain.c_words[MMain.c_words.Count - 1].Add(new YuKey() {
							key = Key,
							upper = false
						});
					} else {
						MMain.c_word.Add(new YuKey() {
							key = Key,
							upper = true
						});
						MMain.c_words[MMain.c_words.Count - 1].Add(new YuKey() {
							key = Key,
							upper = true
						});
					}
				}
			}
			#endregion
			#region Alt+Numpad (fully workable)
			if (!self && incapt &&
			    (Key == Keys.RMenu || Key == Keys.LMenu || Key == Keys.Menu) &&
			    wParam == (IntPtr)(int)KMMessages.WM_KEYUP) {
				Logging.Log("Capture of numpads ended, captured [" + tempNumpads.Count + "] numpads.");
				MMain.c_word.Add(new YuKey() {
					altnum = true,
					numpads = new List<Keys>(tempNumpads)//new List => VERY important here!!!
				});                                      //It prevents pointer to tempNumpads, which is cleared.
				MMain.c_words[MMain.c_words.Count - 1].Add(new YuKey() {
					altnum = true,
					numpads = new List<Keys>(tempNumpads)
				});
				tempNumpads.Clear();
				incapt = false;
			}
			if (!self && !incapt && alt && wParam == (IntPtr)(int)KMMessages.WM_SYSKEYDOWN) {
				Logging.Log("Alt is down, starting capture of Numpads...");
				incapt = true;
			}
			if (!self && alt && incapt) {
				if (Key >= Keys.NumPad0 && Key <= Keys.NumPad9 && wParam == (IntPtr)(int)KMMessages.WM_SYSKEYUP) {
//					Console.WriteLine("Alt is down, and \"" + Key + "\" is released.");
					tempNumpads.Add(Key);
				}
			}
			#endregion
			return CallNextHookEx(MMain._hookID, nCode, wParam, lParam);
		}
		public static IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			if (nCode >= 0) {
				if ((KMMessages.WM_LBUTTONDOWN == (KMMessages)(int)wParam) || KMMessages.WM_RBUTTONDOWN == (KMMessages)(int)wParam) {
					MMain.c_word.Clear();
					MMain.c_words.Clear();
					Logging.Log("Last word & words cleared [with mouse click].");
					if (MMain.MyConfs.ReadBool("Functions", "Snippets")) {
						c_snip.Clear();
						Logging.Log("Current snippet cleared[with mouse click].");
					}
				}
			}
			return CallNextHookEx(MMain._mouse_hookID, nCode, wParam, lParam);
		}
		#endregion
		#region Functions/Struct
		static void ConvertSelection() //Converts selected text
		{
			Locales.IfLessThan2();
			self = true;
			Logging.Log("Starting Convert selection.");
			string ClipStr = "";
			// Backup & Restore feature, now only text supported...
			Logging.Log("Taking backup of clipboard text if possible.");
			var doBackup = false || NativeClipboard.IsClipboardFormatAvailable((uint)NativeClipboard.uFormat.CF_UNICODETEXT);
			var datas = new NativeClipboard.ClipboardData() {
				data = new List<byte[]>(),
				format = new List<uint>()
			};
			if (doBackup) {
				var t = new System.Threading.Tasks.Task(() => {
					datas = NativeClipboard.GetClipboardDatas();
				});
				t.RunSynchronously();
			}
			//This prevents from converting text that alredy exist in Clipboard
			//by pressing "Convert Selection hotkey" without selected text.
			NativeClipboard.Clear();
			Logging.Log("Getting selected text.");
			if (MMain.MyConfs.ReadBool("Functions", "MoreTries"))
				for (int i = 0; i != MMain.MyConfs.ReadInt("Functions", "TriesCount"); i++) {
					ClipStr = MakeCopy();
					if (!String.IsNullOrEmpty(ClipStr))
						break;
				}
			else
				ClipStr = MakeCopy();
			if (!String.IsNullOrEmpty(ClipStr)) {
				csdoing = true;
				Logging.Log("Starting conversion of [" + ClipStr + "].");
				KInputs.MakeInput(new [] {
					KInputs.AddKey(Keys.Back, true),
					KInputs.AddKey(Keys.Back, false)
				});
				var result = "";
				int items = 0;
				if (MMain.MyConfs.ReadBool("Functions", "CSSwitch")) {
					Logging.Log("Using CS-Switch mode.");
					self = true;
					var wasLocale = Locales.GetCurrentLocale();
					var wawasLocale = wasLocale;
					var nowLocale = wasLocale == (uint)MMain.MyConfs.ReadInt("Locales", "locale1uId")
						? (uint)MMain.MyConfs.ReadInt("Locales", "locale2uId")
						: (uint)MMain.MyConfs.ReadInt("Locales", "locale1uId");
					ChangeLayout();
					var index = 0;
					// Don't even think "Regex.Replace(ClipStr, "\r\\D\n?|\n\\D\r?", "\n")" can't be used as variable...
					foreach (char c in Regex.Replace(ClipStr, "\r\\D\n?|\n\\D\r?", "\n")) {
						items++;
						wasLocale = wawasLocale;
						var s = new StringBuilder(10);
						var sb = new StringBuilder(10);
						var yk = new YuKey();
						var scan = VkKeyScanEx(c, (IntPtr)wasLocale);
						var state = ((scan >> 8) & 0xff);
						var bytes = new byte[255];
						if (state == 1)
							bytes[(int)Keys.ShiftKey] = 0xFF;
						var scan2 = VkKeyScanEx(c, (IntPtr)nowLocale);
						var state2 = ((scan2 >> 8) & 0xff);
						var bytes2 = new byte[255];
						if (state2 == 1)
							bytes2[(int)Keys.ShiftKey] = 0xFF;
						if (MMain.MyConfs.ReadBool("Functions", "ExperimentalCSSwitch")) {
							Logging.Log("Using Experimental CS-Switch mode.");
							ToUnicodeEx((uint)scan, (uint)scan, bytes, s, s.Capacity, 0, (IntPtr)wasLocale);
							Logging.Log("Char 1 is [" + s + "] in locale +[" + wasLocale + "].");
							if (ClipStr[index].ToString() == s.ToString()) {
								Logging.Log("Making input of [" + scan + "] in locale +[" + nowLocale + "].");
								KInputs.MakeInput(KInputs.AddString(InAnother(c, wasLocale, nowLocale)));
								index++;
								continue;
							}
							ToUnicodeEx((uint)scan2, (uint)scan2, bytes2, sb, sb.Capacity, 0, (IntPtr)nowLocale);
							Logging.Log("Char 2 is [" + sb + "] in locale +[" + nowLocale + "].");
							if (ClipStr[index].ToString() == sb.ToString()) {
								Logging.Log("Char 1, 2 and origial are equivalent.");
								PostMessage(Locales.ActiveWindow(), KInputs.WM_INPUTLANGCHANGEREQUEST, 0, (uint)wasLocale);
								wasLocale = nowLocale;
								scan = scan2;
								state = state2;
							}
						}
						if (c == '\n') {
							yk.key = Keys.Enter;
							yk.upper = false;
						} else {
							if (scan != -1) {
								var key = (Keys)(scan & 0xff);
								bool upper = false || state == 1;
								yk = new YuKey() { key = key, upper = upper };
								Logging.Log("Key of char [" + c + "] = {" + key + "}, upper = +[" + state + "].");
							} else {
								yk = new YuKey() { key = Keys.None };
							}
						}
						if (yk.key == Keys.None) { // retype unrecognized as unicode
							var unrecognized = ClipStr[items - 1].ToString();
							KInputs.INPUT unr = KInputs.AddString(unrecognized)[0];
							Logging.Log("Key of char [" + c + "] = not exist, using input as string.");
							KInputs.MakeInput(new [] { unr });
						} else {
							if (!SymbolIgnoreRules(yk.key, yk.upper, wasLocale)) {
								Logging.Log("Making input of [" + yk.key + "] key with upper = [" + yk.upper + "].");
								if (yk.upper)
									KInputs.MakeInput(new [] { KInputs.AddKey(Keys.LShiftKey, true) });
								KInputs.MakeInput(new [] { KInputs.AddKey(yk.key, true) });
								KInputs.MakeInput(new [] { KInputs.AddKey(yk.key, false) });
								if (yk.upper)
									KInputs.MakeInput(new [] { KInputs.AddKey(Keys.LShiftKey, false) });
							}
						}
						index++;
					}
				} else {
					Logging.Log("Using default convert selection mode.");
					var l1 = (uint)MMain.MyConfs.ReadInt("Locales", "locale1uId");
					var l2 = (uint)MMain.MyConfs.ReadInt("Locales", "locale2uId");
					var index = 0;
					foreach (char c in ClipStr) {
						var T = InAnother(c, l2, l1);
//						if (T == ClipStr[index].ToString())
//							Console.WriteLine("It is same 1" + T + " == " + ClipStr[index].ToString());
						if (T == "")
							T = InAnother(c, l1, l2);
//						if (T == ClipStr[index].ToString())
//							Console.WriteLine("It is same 2" + T + " == " + ClipStr[index].ToString());
						if (T == "")
							T = ClipStr[index].ToString();							
						result += T;
						index++;
					}
					Logging.Log("Conversion of string [" + ClipStr + "] from locale [" + l1 + "] into locale [" + l2 + "] became [" + result + "].");
					result = Regex.Replace(result, "\r\\D\n?|\n\\D\r?", "\n");
					//Inputs converted text
					Logging.Log("Making input of [" + result + "] as string");
					KInputs.MakeInput(KInputs.AddString(result));
					items = result.Length;
				}
				if (MMain.MyConfs.ReadBool("Functions", "ReSelect")) {
					//reselects text
					Logging.Log("Reselecting text.");
					for (int i = items; i != 0; i--) {
						KInputs.MakeInput(new [] { 
							KInputs.AddKey(Keys.LShiftKey, true),
							KInputs.AddKey(Keys.Left, true),
							KInputs.AddKey(Keys.Left, false),
							KInputs.AddKey(Keys.LShiftKey, false)
						});
					}
				}
			}
			RePress();
			NativeClipboard.Clear();
			if (doBackup) {
				NativeClipboard.RestoreData(datas);
			}
			self = false;
		}
		static string MakeCopy() //Gets text from selection
		{
			KInputs.MakeInput(new [] {
				KInputs.AddKey(Keys.RControlKey, true),
				KInputs.AddKey(Keys.Insert, true),
				KInputs.AddKey(Keys.Insert, false),
				KInputs.AddKey(Keys.RControlKey, false)
			});
			Thread.Sleep(30);
			return NativeClipboard.GetText();
		}
		static void RePress() //Re-presses modifiers you hold when hotkey fired(due to SendModsUp())
		{
			//Console.WriteLine("Going to repress\nct={0}\tsh={1}\tal={2}", ctrlRP, shiftRP, altRP);
			//Repress's modifiers by Press Again variables
			if (shiftRP) {
				KeybdEvent(Keys.LShiftKey, 0);
				swas = true;
				shiftRP = false;
			}
			if (altRP) {
				KeybdEvent(Keys.LMenu, 0);
				awas = true;
				altRP = false;
			}
			if (ctrlRP) {
				KeybdEvent(Keys.LControlKey, 0);
				cwas = true;
				ctrlRP = false;
			}
		}
		static void ConvertLast(List<YuKey> c_) //Converts last word/line
		{
			Locales.IfLessThan2();
			YuKey[] YuKeys = c_.ToArray();
			{
				Logging.Log("Starting to convert word.");
				self = true;
				var wasLocale = Locales.GetCurrentLocale();
				ChangeLayout();
				Logging.Log("Deleting old word, with lenght of [" + YuKeys.Length + "].");
				for (int e = 0; e < YuKeys.Length; e++) {
					KInputs.MakeInput(new [] { KInputs.AddKey(Keys.Back, true),
						KInputs.AddKey(Keys.Back, false) 
					});
				}
				for (int i = 0; i < YuKeys.Length; i++) {
					if (YuKeys[i].altnum) {
						Logging.Log("An YuKey with [" + YuKeys[i].numpads.Count + "] numpad(s) passed.");
						KInputs.MakeInput(new [] { KInputs.AddKey(Keys.LMenu, true) });
						foreach (var numpad in YuKeys[i].numpads) {
							Logging.Log(numpad + " is being inputted.");
							KInputs.MakeInput(new [] { KInputs.AddKey(numpad, true) });
							KInputs.MakeInput(new [] { KInputs.AddKey(numpad, false) });
						}
						KInputs.MakeInput(new [] { KInputs.AddKey(Keys.LMenu, false) });
					} else {
						Logging.Log("An YuKey with state passed, key = {" + YuKeys[i].key + "}, upper = [" + YuKeys[i].upper + "].");
						if (YuKeys[i].upper)
							KInputs.MakeInput(new [] { KInputs.AddKey(Keys.LShiftKey, true) });
						if (!SymbolIgnoreRules(YuKeys[i].key, YuKeys[i].upper, wasLocale)) {
							KInputs.MakeInput(new [] { KInputs.AddKey(YuKeys[i].key, true) });
							KInputs.MakeInput(new [] { KInputs.AddKey(YuKeys[i].key, false) });
						}
						if (YuKeys[i].upper)
							KInputs.MakeInput(new [] { KInputs.AddKey(Keys.LShiftKey, false) });
					}
				}
				RePress();
				self = false;
			}
		}
		static bool SymbolIgnoreRules(Keys key, bool upper, uint wasLocale) //Rules to ignore symbols
		{
			Logging.Log("Passing through symbol ignore rules.");
			if (MMain.MyConfs.ReadBool("EnabledHotkeys", "HKSymIgnEnabled") &&
			    MMain.MyConfs.ReadBool("Functions", "SymIgnModeEnabled") &&
			    (wasLocale == 1033 || wasLocale == 1041) &&
			    ((Locales.AllList().Length < 3 && MMain.MyConfs.ReadBool("Functions", "CycleMode")) ||
			    !MMain.MyConfs.ReadBool("Functions", "CycleMode")) && (
			        key == Keys.Oem5 ||
			        key == Keys.OemOpenBrackets ||
			        key == Keys.Oem6 ||
			        key == Keys.Oem1 ||
			        key == Keys.Oem7 ||
			        key == Keys.Oemcomma ||
			        key == Keys.OemPeriod ||
			        key == Keys.OemQuestion)) {
				if (upper && key == Keys.OemOpenBrackets)
					KInputs.MakeInput(KInputs.AddString("{"));
				if (!upper && key == Keys.OemOpenBrackets)
					KInputs.MakeInput(KInputs.AddString("["));

				if (upper && key == Keys.Oem5)
					KInputs.MakeInput(KInputs.AddString("|"));
				if (!upper && key == Keys.Oem5)
					KInputs.MakeInput(KInputs.AddString("\\"));

				if (upper && key == Keys.Oem6)
					KInputs.MakeInput(KInputs.AddString("}"));
				if (!upper && key == Keys.Oem6)
					KInputs.MakeInput(KInputs.AddString("]"));

				if (upper && key == Keys.Oem1)
					KInputs.MakeInput(KInputs.AddString(":"));
				if (!upper && key == Keys.Oem1)
					KInputs.MakeInput(KInputs.AddString(";"));

				if (upper && key == Keys.Oem7)
					KInputs.MakeInput(KInputs.AddString("\""));
				if (!upper && key == Keys.Oem7)
					KInputs.MakeInput(KInputs.AddString("'"));

				if (upper && key == Keys.Oemcomma)
					KInputs.MakeInput(KInputs.AddString("<"));
				if (!upper && key == Keys.Oemcomma)
					KInputs.MakeInput(KInputs.AddString(","));

				if (upper && key == Keys.OemPeriod)
					KInputs.MakeInput(KInputs.AddString(">"));
				if (!upper && key == Keys.OemPeriod)
					KInputs.MakeInput(KInputs.AddString("."));

				if (upper && key == Keys.OemQuestion)
					KInputs.MakeInput(KInputs.AddString("?"));
				if (!upper && key == Keys.OemQuestion)
					KInputs.MakeInput(KInputs.AddString("/"));

				return true;
			} else
				return false;
		}
		static void ChangeLayout() //Changes current layout
		{
			var nowLocale = Locales.GetCurrentLocale();
			uint notnowLocale = nowLocale == (uint)MMain.MyConfs.ReadInt("Locales", "locale1uId")
                ? (uint)MMain.MyConfs.ReadInt("Locales", "locale2uId")
                : (uint)MMain.MyConfs.ReadInt("Locales", "locale1uId");
			if (!MMain.MyConfs.ReadBool("Functions", "CycleMode")) {
				Logging.Log("Changing layout using normal mode, PostMessage [WM_INPUTLANGCHANGEREQUEST] with LParam ["+notnowLocale+"].");
				int tries = 0;
				//Cycles while layout not changed
				while (Locales.GetCurrentLocale() == nowLocale) {
					PostMessage(Locales.ActiveWindow(), KInputs.WM_INPUTLANGCHANGEREQUEST, 0, notnowLocale);
					Thread.Sleep(30);//Give some time to switch layout
					tries++;
					if (tries == 3)
						break;
				}
			} else
				CycleSwitch();
		}
		static void CycleSwitch() //Switches layout by cycling between installed all in system
		{
			if (MMain.MyConfs.ReadBool("Functions", "EmulateLayoutSwitch")) {
				if (MMain.MyConfs.ReadInt("Functions", "ELSType") == 0) {
					Logging.Log("Changing layout using cycle mode by simulating key press [Alt+Shift].");
					//Emulate Alt+Shift
					KInputs.MakeInput(new [] {
						KInputs.AddKey(Keys.LMenu, true),
						KInputs.AddKey(Keys.LShiftKey, true),
						KInputs.AddKey(Keys.LShiftKey, false),
						KInputs.AddKey(Keys.LMenu, false)
					});
				} else if (MMain.MyConfs.ReadInt("Functions", "ELSType") == 1) {
					Logging.Log("Changing layout using cycle mode by simulating key press [Ctrl+Shift].");
					//Emulate Ctrl+Shift
					KInputs.MakeInput(new [] {
						KInputs.AddKey(Keys.LControlKey, true),
						KInputs.AddKey(Keys.LShiftKey, true),
						KInputs.AddKey(Keys.LShiftKey, false),
						KInputs.AddKey(Keys.LControlKey, false)
					});
				} else {
					Logging.Log("Changing layout using cycle mode by simulating key press [Win+Space].");
					//Emulate Win+Space
					KInputs.MakeInput(new [] {
						KInputs.AddKey(Keys.LWin, true),
						KInputs.AddKey(Keys.Space, true),
						KInputs.AddKey(Keys.Space, false),
						KInputs.AddKey(Keys.LWin, false)
					});
					Thread.Sleep(100); //Important!
				}
			} else {
				Logging.Log("Changing layout using cycle mode by sending Message [WM_INPUTLANGCHANGEREQUEST] with LParam [HKL_NEXT] using PostMessage to ActiveWindow");
				//Use PostMessage to switch to next layout
				PostMessage(Locales.ActiveWindow(), KInputs.WM_INPUTLANGCHANGEREQUEST, 0, KInputs.HKL_NEXT);
			}
		}
		static string InAnother(char c, uint uID1, uint uID2) //Remakes c from uID1  to uID2
		{
			var cc = c;
			var chsc = VkKeyScanEx(cc, (IntPtr)uID1);
			var state = (chsc >> 8) & 0xff;
			var byt = new byte[256];
			//it needs just 1 but,anyway let it be 10, i think that's better
			var s = new StringBuilder(10);
			//Checks if 'chsc' have upper state
			if (state == 1) {
				byt[(int)Keys.ShiftKey] = 0xFF;
			}
			//"Convert magic✩" is the string below
			var ant = ToUnicodeEx((uint)chsc, (uint)chsc, byt, s, s.Capacity, 0, (IntPtr)uID2);
			return chsc != -1 ? s.ToString() : "";
		}
		public static void KeybdEvent(Keys key, int flags) // Simplified keybd_event with exteded recongize feature
		{
			//Do not remove this line, it needed for "Left Control Switch Layout" to work properly
			Thread.Sleep(15);
			keybd_event((byte)key, 0, flags | (KInputs.IsExtended(key) ? 1 : 0), 0);
		}
		static void RePressAfter(string mods) // Sets Press Again variables for modifiers
		{
			shiftRP = mods.Contains("Shift") ? true : false;
			altRP = mods.Contains("Alt") ? true : false;
			ctrlRP = mods.Contains("Control") ? true : false;
		}
		static void SendModsUp(bool[] modstoup) //Sends mods up by modstoup array
		{
			//These three below are needed to release all modifiers, so even if you will still hold any of it
			//it will skip them and do as it must.
			self = true;
			if (modstoup[0]) {
				KMHook.KeybdEvent(Keys.RControlKey, 2); // Right Control Up
				KMHook.KeybdEvent(Keys.LControlKey, 2); // Left Control Up
			}
			if (modstoup[1]) {
				KMHook.KeybdEvent(Keys.RShiftKey, 2); // Right Shift Up
				KMHook.KeybdEvent(Keys.LShiftKey, 2); // Left Shift Up
			}
			if (modstoup[2]) {
				KMHook.KeybdEvent(Keys.RMenu, 2); // Right Alt Up
				KMHook.KeybdEvent(Keys.LMenu, 2); // Left Alt Up
			}
			Logging.Log("All modifiers sended up.");
			self = false;
		}
		static void IfKeyIsMod(Keys key)
		{
			var mods = new bool[3];
			switch (key) {
				case Keys.ControlKey:
				case Keys.LControlKey:
				case Keys.RControlKey:
					mods[0] = true;
					break;
				case Keys.ShiftKey:
				case Keys.LShiftKey:
				case Keys.RShiftKey:
					mods[1] = true;
					break;
				case Keys.Menu:
				case Keys.LMenu:
				case Keys.RMenu:
				case Keys.Alt:
					mods[2] = true;
					break;
			}
			SendModsUp(mods);
		}
		public static void ReInitSnippets()
		{
			if (System.IO.File.Exists(MMain.mahou.moreConfigs.snipfile)) {
				var snippets = System.IO.File.ReadAllText(MMain.mahou.moreConfigs.snipfile);
				var snili = new List<string>();
				var expli = new List<string>();
				var rx = new Regex("->(.*)");
				foreach (Match rema in rx.Matches(snippets)) {
					var noN = Regex.Replace(rema.Groups[1].Value, "(\n|\r)", "");
					snili.Add(noN);
				}
				var rxex = new Regex(@"(?<=====>)(.*?)(?=<====)", RegexOptions.Singleline);
				foreach (Match rema in rxex.Matches(snippets)) {
					var noRN = Regex.Replace(rema.Groups[1].Value, "\r", "");
					expli.Add(noRN);
				}
				snipps = snili.ToArray();
				exps = expli.ToArray();
				Logging.Log("Snippets (re)initialized.");
			}
		}
		public struct YuKey // YuKey is struct of key and it state(upper/lower) AND if it is Alt+[NumPad]
		{
			public Keys key;
			public bool upper;
			public bool altnum;
			public List<Keys> numpads;
		}
		#endregion
		#region DLL imports
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int extraInfo);
		
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SetWindowsHookEx(int idHook,
			LowLevelProc lpfn, IntPtr hMod, uint dwThreadId);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnhookWindowsHookEx(IntPtr hhk);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
			IntPtr wParam, IntPtr lParam);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		[return: MarshalAs(UnmanagedType.Bool)]
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool PostMessage(IntPtr hhwnd, uint msg, uint wparam, uint lparam);

		[DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
		private static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState,
			StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern short VkKeyScanEx(char ch, IntPtr dwhkl);
		#endregion
	}
}