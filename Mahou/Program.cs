using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using NLog;

namespace Mahou {
	class MMain {

		private static readonly Logger log = LogManager.GetCurrentClassLogger();
		#region DLLs
		[DllImport("user32.dll")]
		public static extern uint RegisterWindowMessage(string message);
		#endregion
		#region Prevent another instance variables
		public const string appGUid = "ec511418-1d57-4dbe-a0c3-c6022b33735b";
		public static uint ao = RegisterWindowMessage("AlderyOpenedMahou!");
		#endregion
		#region All Main variables, arrays etc.
		public static List<KMHook.YuKey> c_word = new List<KMHook.YuKey>();
		public static List<List<KMHook.YuKey>> c_words = new List<List<KMHook.YuKey>>();
		public static IntPtr _hookID = IntPtr.Zero;
		public static IntPtr _mouse_hookID = IntPtr.Zero;
		public static KMHook.LowLevelProc _proc = KMHook.HookCallback;
		public static KMHook.LowLevelProc _mouse_proc = KMHook.MouseHookCallback;
		public static Locales.Locale[] locales = Locales.AllList();
		public static Configs MyConfs = new Configs();
		public static MahouForm mahou;
		public static List<string> lcnmid = new List<string>();
		public static string[] UI = { };
		public static string[] TTips = { };
		public static string[] Msgs = { };
		#endregion
		[STAThread] //DO NOT REMOVE THIS
		public static void Main(string[] args) {
			LogHelper.ConfigureNlog();
			log.Trace("Program start");
			using(var mutex = new Mutex(false, "Global\\" + appGUid)) {
				log.Trace("Mutex created");
				if(!mutex.WaitOne(0, false)) {
					KMHook.PostMessage((IntPtr)0xffff, ao, 0, 0);
					return;
				}
				if(locales.Length < 2) {
					Locales.IfLessThan2();
				} else {
					mahou = new MahouForm();
					InitLanguage();
					//Refreshes icon text language at startup
					mahou.icon.RefreshText(MMain.UI[44], MMain.UI[42], MMain.UI[43]);
					KMHook.ReInitSnippets();
					Application.EnableVisualStyles(); // Huh i did not noticed that it was missing... '~'
					if(args.Length != 0)
						if(args[0] == "_!_updated_!_") {
							mahou.ToggleVisibility();
							MessageBox.Show(Msgs[0], Msgs[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					StartHook();
					//for first run, add your locale 1 & locale 2 to settings
					if(MyConfs.Read("Locales", "locale1Lang") == "" && MyConfs.Read("Locales", "locale2Lang") == "") {
						MyConfs.Write("Locales", "locale1uId", locales[0].uId.ToString());
						MyConfs.Write("Locales", "locale2uId", locales[1].uId.ToString());
						MyConfs.Write("Locales", "locale1Lang", locales[0].Lang);
						MyConfs.Write("Locales", "locale2Lang", locales[1].Lang);
					}
					try {
						Application.Run();

					} catch(Exception ex) {
						log.Fatal(ex, "Global error handler caught the exception in app");
					}
					StopHook();
				}
			}
		}
		public static void InitLanguage() {
			if(MyConfs.Read("Locales", "LANGUAGE") == "RU") {
				UI = Translation.UIRU;
				TTips = Translation.ToolTipsRU;
				Msgs = Translation.MessagesRU;
			} else if(MyConfs.Read("Locales", "LANGUAGE") == "EN") {
				UI = Translation.UIEN;
				TTips = Translation.ToolTipsEN;
				Msgs = Translation.MessagesEN;
			}
		}
		#region Actions with hooks
		public static void StartHook() {
			if(!CheckHook()) {
				return;
			}
			log.Trace("Set hook");
			_mouse_hookID = KMHook.SetHook(_mouse_proc, (int)KMHook.KMMessages.WH_MOUSE_LL);
			_hookID = KMHook.SetHook(_proc, (int)KMHook.KMMessages.WH_KEYBOARD_LL);
			Thread.Sleep(10); //Give some time for it to apply
		}
		public static void StopHook() {
			if(CheckHook()) {
				return;
			}
			KMHook.UnhookWindowsHookEx(_hookID);
			KMHook.UnhookWindowsHookEx(_mouse_hookID);
			_hookID = _mouse_hookID = IntPtr.Zero;
			Thread.Sleep(10); //Give some time for it to apply
		}
		public static bool CheckHook() {
			return _hookID == IntPtr.Zero;
		}
		#endregion
	}
}