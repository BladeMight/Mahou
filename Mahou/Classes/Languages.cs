using System.Collections.Generic;
public class Languages
{
	public enum Element { 
		#region Tabs
		tab_Functions,
		tab_Layouts,
		tab_Appearence,
		tab_Timings,
		tab_Excluded,
		tab_Snippets,
		tab_AutoSwitch,
		tab_Hotkeys,
		tab_Updates,
		tab_About,
		tab_LangPanel,
		#endregion
		#region Functions
		AutoStart,
		CreateTask,
		CreateShortcut,
		TrayIcon,
		ConvertSelectionLS,
		ReSelect,
		RePress,
		Add1Space,
		Add1NL,
		ConvertSelectionLSPlus,
		HighlightScroll,
		UpdatesCheck,
		SilentUpdate,
		Logging,
		CapsTimer,
		ContryFlags,
		BlockCtrlHKs,
		MCDSSupport,
		OneLayoutWholeWord,
		GuessKeyCodeFix,
		ConfigsInAppData,
		RemapCapslockAsF18,
		#endregion
		#region Layouts
		SwitchBetween,
		EmulateLS,
		EmulateType,
		ChangeLayoutBy1Key,
		OneLayout,
		QWERTZ,
		KeysType,
		SelectKeyType,
		SetHotkeyType,
		#endregion
		#region Persistent Layout
		SwitchOnlyOnWindowChange,
		SwitchOnlyOnce,
		PersistentLayout,
		ActivatePLFP,
		CheckInterval,
		#endregion
		#region Appearence
		LDMouseDisplay,
		LDCaretDisplay,
		LDOnlyOnChange,
		LDDifferentAppearence,
		Language,
		LDAppearence,
		LDAroundMouse,
		LDAroundCaret,
		LDTransparentBG,
		LDFont,
		LDFore,
		LDBack,
		LDText,
		LDSize,
		LDPosition,
		LDWidth,
		LDHeight,
		MCDSTopIndent,
		MCDSBottomIndent,
		UseFlags,
		Always,
		LDUpperArrow,
		LDUseWinMessages,
		#endregion
		#region Timings
		LDForMouseRefreshRate,
		LDForCaretRefreshRate,
		DoubleHKDelay,
		TrayFlagsRefreshRate,
		ScrollLockRefreshRate,
		CapsLockRefreshRate,
		MoreTriesToGetSelectedText,
		LD_MouseSkipMessages,
		UseDelayAfterBackspaces,
		#endregion
		#region Excluded
		ExcludedPrograms,
		Change1KeyLayoutInExcluded,
		#endregion
		#region Snippets
		SnippetsEnabled,
		SnippetSpaceAfter,
		SnippetSwitchToGuessLayout,
		SnippetsCount,
		SnippetsExpandKey,
		#endregion
		#region AutoSwitch
		AutoSwitchEnabled,
		AutoSwitchSpaceAfter,
		AutoSwitchSwitchToGuessLayout,
		AutoSwitchUpdateDictionary,
		AutoSwitchDependsOnSnippets,
		AutoSwitchDictionaryWordsCount,
		DownloadAutoSwitchDictionaryInZip,
		AutoSwitchDictionaryTooBigToDisplay,
		#endregion
		#region Hotkeys
		ToggleMainWnd,
		ConvertLast,
		ConvertSelected,
		ConvertLine,
		ConvertWords,
		ToggleSymbolIgnore,
		SelectedToTitleCase,
		SelectedToRandomCase,
		SelectedToSwapCase,
		SelectedTransliteration,
		ExitMahou,
		RestartMahou,
		Enabled,
		DoubleHK,
		ToggleLangPanel,
		#endregion
		#region LangPanel
		DisplayLangPanel,
		RefreshRate,
		Transparency,
		BorderColor,
		UseAeroColor,
		DisplayUpperArrow,
		#endregion
		#region Updates
		CheckForUpdates,
		Checking,
		YouHaveLatest,
		TimeToUpdate,
		UpdateMahou,
		DownloadUpdate,
		ProxyConfig,
		ProxyServer,
		ProxyLogin,
		ProxyPass,
		Error,
		NetError,
		UpdatesChannel,
		#endregion
		#region About
		DbgInf,
		DbgInf_Copied,
		Site,
		Releases,
		About,
		#endregion
		#region Misc
		Keys,
		Key_Left,
		Key_Right,
		Layouts,
		Plugin,
		Layout,
		Hotkey,
		UpdateFound,
		UpdateComplete,
		ShowHide,
		Mahou,
		Download,
		ConfigsCannot,
		Created,
		Readen,
		RetryInAppData,
		#endregion
		#region Buttons
		ButtonOK,
		ButtonApply,
		ButtonCancel,
		#endregion
		#region Tooltips
		TT_SwitchBetween,
		TT_ConvertSelectionSwitch,
		TT_BlockCtrl,
		TT_CapsDis,
		TT_EmulateLS,
		TT_RePress,
		TT_Add1Space,
		TT_Add1NL,
		TT_ReSelect,
		TT_ScrollTip,
		TT_LDOnlyOnChange,
		TT_ConvertSelectionSwitchPlus,
		TT_LDForMouse,
		TT_LDForCaret,
		TT_Snippets,
		TT_Logging,
		TT_LDDifferentAppearence,
		TT_CountryFlags,
		TT_SymbolIgnore,
		TT_ConvertWords,
		TT_ExcludedPrograms,
		TT_MCDSSupport,
		TT_LDText,
		TT_OneLayoutWholeWordCS,
		TT_PersistentLayout,
		TT_SwitchOnlyOnWindowChange,
		TT_SwitchOnlyOnce,
		TT_OneLayout,
		TT_QWERTZ,
		TT_Change1KeyLayoutInExcluded,
		TT_SnippetsSwitchToGuessLayout,
		TT_SnippetsCount,
		TT_GuessKeyCodeFix,
		TT_ConfigsInAppData,
		TT_KeysType,
		TT_SnippetExpandKey,
		TT_LDUseWinMessages,
		TT_RemapCapslockAsF18,
		TT_UseDelayAfterBackspaces,
		#endregion
		#region Messages
		MSG_SnippetsError
		#endregion
	}
	public static Dictionary<Element, string> English = new Dictionary<Element, string>() { 
		#region Tabs
		{ Element.tab_Functions, "Functions" }, 
		{ Element.tab_Layouts, "Layouts" }, 
		{ Element.tab_Appearence, "Appearence" }, 
		{ Element.tab_Timings, "Timings" }, 
		{ Element.tab_Excluded, "Excluded" }, 
		{ Element.tab_Snippets, "Snippets" }, 
		{ Element.tab_AutoSwitch, "Auto switch" },
		{ Element.tab_Hotkeys, "Hotkeys" }, 
		{ Element.tab_LangPanel, "Language panel" }, 
		{ Element.tab_Updates, "Updates" }, 
		{ Element.tab_About, "About" }, 
		#endregion
		#region Functions
		{ Element.AutoStart, "Start with Windows." }, 
		{ Element.CreateTask, "Create task (will run as Administrator)."},
		{ Element.CreateShortcut, "Create shortcut in startup folder."},
		{ Element.TrayIcon, "Show tray icon." }, 
		{ Element.ConvertSelectionLS, "Convert selection layout switching." }, 
		{ Element.ReSelect, "Re-select text after conversion." }, 
		{ Element.RePress, "Re-press modifiers after hotkey action." }, 
		{ Element.Add1Space, "Consider 1 space as part of last word." }, 
		{ Element.Add1NL, "Consider Enter as part of last word." },
		{ Element.ConvertSelectionLSPlus, "Convert selection layout switching+." }, 
		{ Element.HighlightScroll, "Highlight Scroll-Lock when layout 1 is active." }, 
		{ Element.UpdatesCheck, "Check for updates at startup." }, 
		{ Element.SilentUpdate, "Silent update at startup." }, 
		{ Element.Logging, "Enable logging for debugging." }, 
		{ Element.CapsTimer, "Activate Caps Lock disabler timer." }, 
		{ Element.ContryFlags, "Display country flags in tray icon." }, 
		{ Element.BlockCtrlHKs, "Block Mahou hotkeys with Ctrl." }, 
		{ Element.MCDSSupport, "Enable MCDS support." }, 
		{ Element.OneLayoutWholeWord, "Use layout for whole word in CS." }, 
		{ Element.GuessKeyCodeFix, "Use guess key code fix." }, 
		{ Element.ConfigsInAppData, "Configs in AppData." }, 
		{ Element.RemapCapslockAsF18, "Remap Caps Lock as F18." }, 
		#endregion
		#region Layouts
		{ Element.SwitchBetween, "Switch between layouts" }, 
		{ Element.EmulateLS, "Emulate layout switching." }, 
		{ Element.EmulateType, "Emulation type:" }, 
		{ Element.ChangeLayoutBy1Key, "Change to specific layout by keys:" }, 
		{ Element.OneLayout, "One layout for all programs." }, 
		{ Element.QWERTZ, "Fix for QWERTZ keyboard." }, 
		{ Element.KeysType, "Keys type:" }, 
		{ Element.SelectKeyType, "Select key." }, 
		{ Element.SetHotkeyType, "Set hotkey." }, 
		#endregion
		#region Persistent Layout
		{ Element.PersistentLayout, "Persistent layout" }, 
		{ Element.SwitchOnlyOnWindowChange, "Change only when active window changes." }, 
		{ Element.SwitchOnlyOnce, "Change layout only once per window." }, 
		{ Element.ActivatePLFP, "Activate persistent layout for processes:" }, 
		{ Element.CheckInterval, "Check interval:" }, 
		#endregion
		#region Appearence
		{ Element.LDMouseDisplay, "Display current language tooltip around mouse." }, 
		{ Element.LDCaretDisplay, "Display current language tooltip around caret." }, 
		{ Element.LDOnlyOnChange, "Only on change." }, 
		{ Element.LDDifferentAppearence, "Use different appearence for layouts." }, 
		{ Element.Language, "Language:" }, 
		{ Element.LDAppearence, "Language tooltip appearence:" }, 
		{ Element.LDAroundMouse, "Around mouse" }, 
		{ Element.LDAroundCaret, "Around caret" }, 
		{ Element.LDTransparentBG, "Transparent color." }, 
		{ Element.LDFont, "Font" }, 
		{ Element.LDFore, "Foreground color:" }, 
		{ Element.LDBack, "Background color:" }, 
		{ Element.LDText, "Tooltip text:" }, 
		{ Element.LDSize, "Size" }, 
		{ Element.LDPosition, "Position" }, 
		{ Element.LDWidth, "Width" }, 
		{ Element.LDHeight, "Height" }, 
		{ Element.MCDSTopIndent, "Top" }, 
		{ Element.MCDSBottomIndent, "Bottom" }, 
		{ Element.UseFlags, "Use flags." },
		{ Element.Always, "Always." },
		{ Element.LDUpperArrow, "Arrow when upper case." },
		{ Element.LDUseWinMessages, "Use Windows Messages instead of timers." },
		#endregion
		#region Timings
		{ Element.LDForMouseRefreshRate, "Language tooltip around mouse refresh rate(ms):" }, 
		{ Element.LDForCaretRefreshRate, "Language tooltip around caret refresh rate(ms):" }, 
		{ Element.DoubleHKDelay, "Double hotkey wait time for second press(ms):" }, 
		{ Element.TrayFlagsRefreshRate, "Flags in tray icon refresh rate(ms):" }, 
		{ Element.ScrollLockRefreshRate, "Scroll Lock refresh rate(ms):" }, 
		{ Element.CapsLockRefreshRate, "Caps Lock update rate(ms):" }, 
		{ Element.MoreTriesToGetSelectedText, "Use more tries to get selected text:" }, 
		{ Element.LD_MouseSkipMessages, "Mouse movement Messages to skip before updating language tooltips:" },
		{ Element.UseDelayAfterBackspaces, "Use delay after backspaces in convert last word(ms):" },
		#endregion
		#region Excluded
		{ Element.ExcludedPrograms, "Excluded programs:" }, 
		{ Element.Change1KeyLayoutInExcluded, "Change layout by 1 key even in excluded." }, 
		#endregion
		#region Snippets
		{ Element.SnippetsEnabled, "Enable snippets." }, 
		{ Element.SnippetSpaceAfter, "Add 1 space after snippets." }, 
		{ Element.SnippetSwitchToGuessLayout, "Switch to guess layout after snippet." }, 
		{ Element.SnippetsCount, "Snippets: " }, 
		{ Element.SnippetsExpandKey, "Snippet expand key: " }, 
		#endregion
		#region AutoSwitch
		{ Element.AutoSwitchEnabled, "Enable auto-switch." }, 
		{ Element.AutoSwitchSpaceAfter, "Add 1 space after auto-switch." }, 
		{ Element.AutoSwitchSwitchToGuessLayout, "Switch to guess layout after auto-switch." }, 
		{ Element.AutoSwitchUpdateDictionary, "Update auto-switch dictionary." }, 
		{ Element.AutoSwitchDependsOnSnippets, "To use this feature enable Snippets feature!" },
		{ Element.AutoSwitchDictionaryWordsCount, "Words: " }, 
		{ Element.DownloadAutoSwitchDictionaryInZip, "Download auto-switch dictionary in zip." }, 
		{ Element.AutoSwitchDictionaryTooBigToDisplay, "Too big dictionary, it will take a lot time to display, dictionary display disabled." }, 
		#endregion
		#region Hotkeys
		{ Element.ToggleMainWnd, "Toggle settings window" }, 
		{ Element.ConvertLast, "Convert last word" }, 
		{ Element.ConvertSelected, "Convert selected text" }, 
		{ Element.ConvertLine, "Convert last line" }, 
		{ Element.ConvertWords, "Convert specific last words count" }, 
		{ Element.ToggleSymbolIgnore, "Toggle symbol ignore mode" }, 
		{ Element.SelectedToTitleCase, "Selected text words to Title Case" }, 
		{ Element.SelectedToRandomCase, "Selected text words to RanDoM cASe" }, 
		{ Element.SelectedToSwapCase, "Selected text words to sWAP cASE" }, 
		{ Element.SelectedTransliteration, "Selected text transliteration" }, 
		{ Element.ExitMahou, "Exit" }, 
		{ Element.RestartMahou, "Restart" }, 
		{ Element.Enabled, "Enabled" }, 
		{ Element.DoubleHK, "Double hotkey" }, 
		{ Element.ToggleLangPanel, "Toggle language panel" }, 
		#endregion
		#region LangPanel
		{ Element.DisplayLangPanel, "Display language panel." },
		{ Element.RefreshRate, "Refresh rate(ms):" },
		{ Element.Transparency, "Transparency:" },
		{ Element.BorderColor, "Border color:" },
		{ Element.UseAeroColor, "Use Aero/Accent color." },
		{ Element.DisplayUpperArrow, "Display up arrow icon when input is upper case." },
		#endregion
		#region Updates
		{ Element.CheckForUpdates, "Check for updates:" }, 
		{ Element.YouHaveLatest, "You have latest version." }, 
		{ Element.TimeToUpdate, "I think it is time to update." }, 
		{ Element.UpdateMahou, "Update Mahou to <version>" }, 
		{ Element.DownloadUpdate, "Download update" }, 
		{ Element.ProxyConfig, "Proxy configuration" }, 
		{ Element.ProxyServer, "Server:Port" }, 
		{ Element.ProxyLogin, "Login:" }, 
		{ Element.ProxyPass, "Password:" }, 
		{ Element.Error, "Error..." }, 
		{ Element.NetError, "Connection to github.com can't be established, check your network connection or proxy settings..." },
		{ Element.UpdatesChannel, "Updates channel:" },
		#endregion
		#region About
		{ Element.DbgInf, "Debug info" }, 
		{ Element.DbgInf_Copied, "Copied!" }, 
		{ Element.Site, "Site" }, 
		{ Element.Releases, "Releases" }, 
		{ Element.About, "Hotkeys: you can see them in Hotkeys tab.\r\n\r\n"+
            "*Note that if your typing layout is not selected in settings,"+
			" conversion will switch typed text to Language 1 (Ignored if Switch between layouts is OFF).\r\n\r\n"+
            "**If you have problems with symbols conversion (selection) try enabling function \"Use layout for whole word in CS\", "+
			" or \"switching languages (1=>2 & 2=>1)\""+
			" or \"Convert selection layout switching\" or Plus option." +
			"***If you have problems with selection conversion try inreasing tries to get selected text in Timings tab." +
			"\r\nRead the wiki, or ask me if you have any questions about Mahou(email and links are below)!\r\n\r\nRegards." },
		#endregion
		#region Misc
		{ Element.Checking, "Checking..." }, 
		{ Element.Keys, "Keys" }, 
		{ Element.Key_Left, "Left" }, 
		{ Element.Key_Right, "Right" }, 
		{ Element.Layouts, "Layouts" }, 
		{ Element.Plugin, "plugin" }, 
		{ Element.Layout, "Layout" }, 
		{ Element.Hotkey, "Hotkey" }, 
		{ Element.UpdateFound, "New version avaible!" }, 
		{ Element.UpdateComplete, "Mahou succesfully updated!" }, 
		{ Element.ShowHide, "Show/Hide" }, 
		{ Element.Mahou, "Mahou(魔法) - magic layout switcher." }, 
		{ Element.Download, "Download" }, 
		{ Element.ConfigsCannot, "Configs file Mahou.ini cannot be " },
		{ Element.Created, "created" },
		{ Element.Readen, "readen" },
		{ Element.RetryInAppData, "Retry creating/switching to configs in %AppData%?" },
		#endregion
		#region Buttons
		{ Element.ButtonOK, "OK" }, 
		{ Element.ButtonApply, "Apply" }, 
		{ Element.ButtonCancel, "Cancel" }, 
		#endregion
		#region Tooltips
		{ Element.TT_SwitchBetween, "While this option is disabled, [Convert word], [Convert line] and [Convert selection with \"Convert selection layout switching\" enabled]\n" + 
		                                  "will just cycle between all locales instead of switching between the selected ones in settings."+
		                                  "If there is a program in which [Convert word], [Convert line] or [Convert selection with \"CS-Switch\" enabled] don't work,try with this option enabled.\nThere is also possible now to enable this function with Emulate layout switching, that will fix problems with apps like MSOffice2016.\nThis function is not working in console apps without getconkbl.dll." },
		{ Element.TT_ConvertSelectionSwitch, "If enabled, Convert selection will use layout switching.\nAll symbols will be written as the must(if layout before switching was the one where they are written it).\nThere also a plus version of that function." }, 
		{ Element.TT_BlockCtrl, "Blocks hotkeys that use Control,\nwhen \"Switch layout by key\" is set to Left/Right Control." }, 
		{ Element.TT_CapsDis, "If enabled, timer which disables CapsLock(led) will work." }, 
		{ Element.TT_EmulateLS, "If enabled, layout switching will emulate press of keys selected on right.\nNow it is possible to enable this functin with [Switch between layouts] function." }, 
		{ Element.TT_RePress, "If enabled, modifiers(Ctrl/Alt/Shift/Win) will be pressed again conversion(NOT recommended),\r\n"+
				"although if you release modifiers before conversion action finishes - modifiers may stuck...))." },
		{ Element.TT_Add1Space, "If enabled,  space will be adding to last word." },
		{ Element.TT_Add1NL, "If enabled, ONE Enter(line break) will be adding to last word,\r\n\r\nso the convert last word will work if you accidentally press Enter after the word." }, 
		{ Element.TT_ReSelect, "If enabled, any \"Convert selected\" will select text again after conversion." }, 
		{ Element.TT_ScrollTip, "Highlight Scroll Lock when active language 1, selected in Layouts tab.\nUnnesesary to keep enabled \"Switch between layouts\" function enabled for this function to work, just select layout #1 below it and then disable it if you need to." }, 
		{ Element.TT_LDOnlyOnChange, "Display language tooltip only on layout change.\nDisplay time - 2x[Refresh rate for mouse + for caret]." }, 
		{ Element.TT_ConvertSelectionSwitchPlus, "Combines some abilities of Convert selection with enabled \"Convert selection layout switching\" and when it's disabled." +
										"\nIt can:"+
										"\n1.Convert text from different layouts to different layouts at once."+
										"\n2.Ignore symbols feature work in it."+
										"\n3.Auto get layout of text (symbols, that exist in both layouts are not supported)."+
										"\n4.Convert unsupported symbols differently, if you change layout before conversion." }, 
		{ Element.TT_LDForMouse, "If enabled, when hovering text form with, a language tooltip will be displayed around the mouse." }, 
		{ Element.TT_LDForCaret, "If enabled, a language tooltip will be displayed around the caret." }, 
		{ Element.TT_Snippets, "If enabled, pressing SPACE will expand small (which starts with \"->\") word, to big (which is between \"====>\" and \"<====\") word/text fragment." }, 
		{ Element.TT_Logging, "Designed ONLY to search for errors, BIG PERFORMANCE IMPACT, logs are saved in Mahou's folder, in folder Logs." }, 
		{ Element.TT_LDDifferentAppearence, "If enabled, you can select different appearence for main layouts(1&2), for others will be used from \"around mouse\" or \"around caret\"." }, 
		{ Element.TT_CountryFlags, "If enabled, tray icon will display country flags." }, 
		{ Element.TT_SymbolIgnore, "If enabled, symbols []{};':\"./<>? will be ignored.\nWorks in Convert last word, line, selection with  \"Conver selection layout switching\" enabled or plus.\n" +
										"WON'T WORK IF YOU HAVE MORE THAN 2 LAYOUTS AND FUNCTION \"Switch between layouts\" disabled!" }, 
		{ Element.TT_ConvertWords, "Allow to convert specific last word count by pressing hotkey and then 0-9 (0 = 10) on keyboard." }, 
		{ Element.TT_ExcludedPrograms, "Programs(excluded) in which convert hotkeys won't work.\nSeparators - spaces and new lines.\r\nIf process name has spaces in it replace it with _, if process name has the _ just write it so.\r\nExample: Process Name: foo_bar 2000.exe\r\nIn Mahou: foo_bar_2000.exe." }, 
		{ Element.TT_MCDSSupport, "Add the ability to display language tooltip around caret in Sublime Text 3.\nFor it to work yout need to install a plugin, link on right.\nSettings avaible in appearence tab:\nTop: Your ST3 titlebar + tab bar height,\nBottom: Your y pixels to ST3 console edit box(ctrl+`).\nFor different windows/themes settings will be different!" }, 
		{ Element.TT_LDText, "Leave empty for auto-detect.\r\nEnter Alt+255(Numpad) to disable displaying of this layout, when display flags feature active." }, 
		{ Element.TT_OneLayoutWholeWordCS, "Use one layout for whole word in Convert Selection,\r\n"+
				"this feature uses quantity of rightly recognized chars in two selected layouts to indicate layout of whole word,"+
				"\r\nthis feature works PERFECTLY with words that have symbols around them, but word lenght must be greater that 1 char for this feature to work properly." },
		{ Element.TT_PersistentLayout, "Write here process names in which you want to have persistent layout, separators are spaces and new lines.\r\nIf process name has spaces in it replace it with _, if process name has the _ just write it so.\r\nExample: Process Name: foo_bar 2000.exe\r\nIn Mahou: foo_bar_2000.exe."},
		{ Element.TT_SwitchOnlyOnWindowChange, "Enabling this will disable timers and persistent layout will update only when active window changes(Windows message).\r\nConsumes CPU only when changing windows, i.e. way less CPU usage than timers."},
		{ Element.TT_SwitchOnlyOnce, "If enabled switching layout will be only once per window,\r\ne.g. it will switch window's layout on activation if its process name matches selected only once.\r\nList of windows for which layout already been changed clears when clicked on Apply or OK."},
		{ Element.TT_OneLayout, "Allows to store global layout in Mahou, insted of layout per window/program.\r\n(if You have Windows 8 or greater this feature is built in Windows, so you don't need to use enable it in Mahou)"},
		{ Element.TT_QWERTZ, "Makes right substitutes in QWERTZ keyboards for chars: ß, ä, ö, ü, Ä, Ö, Ü, Y, Z in Convert Selection\r\n(!! but convert selection layout switching(or +) not supported)." },
		{ Element.TT_Change1KeyLayoutInExcluded, "Function is in Layouts tab -> [Change to specific layout by keys]." },
		{ Element.TT_SnippetsSwitchToGuessLayout, "Switches to *guessed* layout after snippet expanded.\r\nGuess works like in whole \"One Layout for whole word in Convert Selection\" function."},
		{ Element.TT_SnippetsCount,	"If ORANGE snippets are OK.\r\nIf RED snippets has errors, maybe its unfinished etc.\r\nIn brackets are displayed count of commented lines(they are ignored by Mahou),\r\nvalid comment characters: # and // and only at start of line." },
		{ Element.TT_GuessKeyCodeFix, "Enabling this will make snippets, convert selection, auto-switch to send real virtual key codes instead of unicode chars,\r\nbut that will cause that all characters will be in your current layout.\r\nUseful in programs virtual machines.(BlueStacks, VirtualBox etc.)" },
		{ Element.TT_ConfigsInAppData, "If enabled Mahou will copy current configs to AppData, and will use them.\r\nAlso logs and snippets will be stored in %AppData%\\Mahou.\r\nAfter this checkbox state changed other checkboxes/datas configurations from user interface will not be saved, because they will be loaded from another configs(if switched, from Mahou's directory or from %AppData%\\Mahou).\r\nUseful if you need to run Mahou from Program Files directory by multiple users, and while some of them have no write access to it,\r\nalso it makes possible to have different configurations for each user." },		
		{ Element.TT_KeysType, "Select which keys type to display in Mahou user interface, they are both working at same time,\r\nso try not to set same keys/hotkeys to avoid double layout switching."},
		{ Element.TT_SnippetExpandKey, "Select custom snippet expand key,\r\nworks only for snippets, auto-switch will still expand only on space." },
		{ Element.TT_LDUseWinMessages, "If enabled, timers will not be used to update language tooltips,\r\ninstead they will be updated on appropriate Windows Messages.\r\nLess CPU hungry than timers.\r\nMost CPU hungry is mouse tooltip with always enabled,\r\nconsumes CPU only on mouse move/clicks,\r\nto decrease its CPU usage, there will be 1 new config in Timings tab.\r\nSkip x Windows Messages(mouse movement) before updating tooltip." },
		{ Element.TT_RemapCapslockAsF18, "Remaps Caps Lock as F18, after this CapsLock will be disabled.\r\nTo toggle its state use Ctrl/Alt/Shift/Win + Caps Lock key.\r\n! Mahou window excluded from remap!\r\nIn Mahou you should set hotkeys as Caps Lock key, in other programs they will be remapped as F18.\r\nAfter changing hotkey don't forget to press Apply or OK." }, 
		{ Element.TT_UseDelayAfterBackspaces, "If enabled Mahou will wait some time after deleting old word and before inputting converted word.\r\nUseful if in some apps Mahou's function to convert last word doesn't work properly." },
		#endregion
		#region Messages
		{ Element.MSG_SnippetsError, "Snippets contains error in syntax, check if there are errors, details on snippets syntax you can find on Wiki." }
		#endregion
	};
	/// <summary>
	/// Russian language for MahouUI.
	/// </summary>
	public static Dictionary<Element, string> Russian = new Dictionary<Element, string>() {
		#region Tabs
		{ Element.tab_Functions, "Функции" }, 
		{ Element.tab_Layouts, "Раскладки" }, 
		{ Element.tab_Appearence, "Вид" }, 
		{ Element.tab_Timings, "Тайминги" }, 
		{ Element.tab_Excluded, "Исключения" }, 
		{ Element.tab_Snippets, "Сниппеты" }, 
		{ Element.tab_AutoSwitch, "Автозамена" }, 
		{ Element.tab_Hotkeys, "Горячие клавиши" }, 
		{ Element.tab_LangPanel, "Языковая панель" }, 
		{ Element.tab_Updates, "Обновления" }, 
		{ Element.tab_About, "О..." }, 
		#endregion
		#region Functions
		{ Element.AutoStart, "Запускать с Windows." }, 
		{ Element.CreateTask, "Создать задачу (от Администратора)."},
		{ Element.CreateShortcut, "Создать ярлык в папке автозапуска."},
		{ Element.TrayIcon, "Показывать иконку в трее." }, 
		{ Element.ConvertSelectionLS, "Конвертировать раскладку выделенного текста" }, 
		{ Element.ReSelect, "Выделять заново текст после конвертации." }, 
		{ Element.RePress, "Нажимать снова модификаторы горячих клавиш." }, 
		{ Element.Add1Space, "Считать пробел частью последнего слова." }, 
		{ Element.Add1NL, "Считать Enter частью последнего слова." },
		{ Element.ConvertSelectionLSPlus, "Расширенная смена раскладки выделенного текста." }, 
		{ Element.HighlightScroll, "Включать Scroll Lock когда раскладка 1 активна." }, 
		{ Element.UpdatesCheck, "Проверять обновления при запуске." }, 
		{ Element.SilentUpdate, "Тихо обновлять при запуске." }, 
		{ Element.Logging, "Включить журналирование действий." }, 
		{ Element.CapsTimer, "Включить таймер отключения Caps Lock." }, 
		{ Element.ContryFlags, "Отображать флаги стран в трее." }, 
		{ Element.BlockCtrlHKs, "Блокировать горячие клавиши содержащие Ctrl." }, 
		{ Element.MCDSSupport, "Включить поддержку MCDS." }, 
		{ Element.OneLayoutWholeWord, "Считать раскладку для всего слова в КВ." }, 
		{ Element.GuessKeyCodeFix, "Исправлять коды клавиш." }, 
		{ Element.ConfigsInAppData, "Хранить настройки в %AppData%." }, 
		{ Element.RemapCapslockAsF18, "Переопределить Caps Lock как F18." }, 
		#endregion
		#region Layouts
		{ Element.SwitchBetween, "Переключать между раскладками." }, 
		{ Element.EmulateLS, "Эмулировать переключение раскладки." }, 
		{ Element.EmulateType, "Тип эмуляции:" }, 
		{ Element.ChangeLayoutBy1Key, "Переключать раскладки по клавишам:" }, 
		#endregion
		#region Persistent Layout
		{ Element.PersistentLayout, "Постоянная раскладка" }, 
		{ Element.SwitchOnlyOnWindowChange, "Менять только когда меняются окна." }, 
		{ Element.SwitchOnlyOnce, "Менять 1 раз для окна." }, 
		{ Element.ActivatePLFP, "Постоянная раскладка для процессов:" }, 
		{ Element.CheckInterval, "Интервал проверки:" }, 
		{ Element.OneLayout, "Единая раскладка для всех программ." }, 
		{ Element.QWERTZ, "Исправление для QWERTZ клавиатур." }, 
		{ Element.KeysType, "Тип клавиш:" }, 
		{ Element.SelectKeyType, "Выбирать клавиши." }, 
		{ Element.SetHotkeyType, "Назначить гор. клавишу." }, 
		#endregion
		#region Appearence
		{ Element.LDMouseDisplay, "Отображать подсказку текущего языка рядом с мышью." }, 
		{ Element.LDCaretDisplay, "Отображать подсказку текущего языка рядом с кареткой." }, 
		{ Element.LDOnlyOnChange, "Только при смене." }, 
		{ Element.LDDifferentAppearence, "Использовать разный вид для раскладок." }, 
		{ Element.Language, "Язык:" }, 
		{ Element.LDAppearence, "Вид подсказки языка:" }, 
		{ Element.LDAroundMouse, "Возле мыши" }, 
		{ Element.LDAroundCaret, "Возле каретки" }, 
		{ Element.LDTransparentBG, "Прозрачный цвет." }, 
		{ Element.LDFont, "Шрифт" }, 
		{ Element.LDFore, "Цвет текста:" }, 
		{ Element.LDBack, "Цвет фона:" }, 
		{ Element.LDText, "Текст подсказки:" }, 
		{ Element.LDSize, "Размер" }, 
		{ Element.LDPosition, "Позиция" }, 
		{ Element.LDWidth, "Ширина" }, 
		{ Element.LDHeight, "Высота" }, 
		{ Element.MCDSTopIndent, "Сверху" }, 
		{ Element.MCDSBottomIndent, "Снизу" }, 
		{ Element.UseFlags, "Использовать флаги." }, 
		{ Element.Always, "Всегда." },
		{ Element.LDUpperArrow, "Стрелка при верхнем регистре." },
		{ Element.LDUseWinMessages, "Использовать сообщения Windows вместо таймеров." },
		#endregion
		#region Timings
		{ Element.LDForMouseRefreshRate, "Скорость обновления подсказки языка возле мыши (мс):" }, 
		{ Element.LDForCaretRefreshRate, "Скорость обновления подсказки языка возле каретки (мс):" }, 
		{ Element.DoubleHKDelay, "Время ожидания следующего нажатия двойных горячих клавиш (мс):" }, 
		{ Element.TrayFlagsRefreshRate, "Скорость обновления флагов в трее (мс):" }, 
		{ Element.ScrollLockRefreshRate, "Скорость обновления Scroll Lock (мс):" }, 
		{ Element.CapsLockRefreshRate, "Скорость обновления Caps Lock (мс):" }, 
		{ Element.MoreTriesToGetSelectedText, "Число дополнительных попыток взятия текста:" }, 
		{ Element.LD_MouseSkipMessages, "Пропуск x сообщений движения мыши перед обновлением подсказок:" },
		{ Element.UseDelayAfterBackspaces, "Использовать задержку после удаления слова в конвертации слов (мс):" },
		#endregion
		#region Excluded
		{ Element.ExcludedPrograms, "Программы-исключения:" }, 
		{ Element.Change1KeyLayoutInExcluded, "Менять раскладку 1 клавишей даже в исключениях." }, 
		#endregion
		#region Snippets
		{ Element.SnippetsEnabled, "Включить сниппеты." }, 
		{ Element.SnippetSpaceAfter, "Добавлять 1 пробел после сниппетов." },
		{ Element.SnippetSwitchToGuessLayout, "Переключать на предполагаемую раскладку сниппетов." }, 
		{ Element.SnippetsCount, "Сниппетов: " }, 
		{ Element.SnippetsExpandKey, "Клавшиа развертывания:" }, 
		#region AutoSwitch
		{ Element.AutoSwitchEnabled, "Включить автозамену." }, 
		{ Element.AutoSwitchSpaceAfter, "Добавлять 1 пробел после автозамены." }, 
		{ Element.AutoSwitchSwitchToGuessLayout, "Переключать на предполагаемую раскладку автозамены." }, 
		{ Element.AutoSwitchUpdateDictionary, "Обновить словарь автозамены." }, 
		{ Element.AutoSwitchDependsOnSnippets, "Чтобы использовать эту функцию включите функцию сниппетов!" },
		{ Element.AutoSwitchDictionaryWordsCount, "Слов: " }, 
		{ Element.DownloadAutoSwitchDictionaryInZip, "Скачивать словарь автозамены в zip архиве." }, 
		{ Element.AutoSwitchDictionaryTooBigToDisplay, "Слишком большой словарь, займет много времени чтобы отобразить, отображение словаря отключено." }, 
		#endregion
		#endregion
		#region Hotkeys
		{ Element.ToggleMainWnd, "Переключить видимость главного окна" }, 
		{ Element.ConvertLast, "Смена раскладки последнего слова" }, 
		{ Element.ConvertSelected, "Смена раскладки выделенного текста" }, 
		{ Element.ConvertLine, "Смена раскладки последней линии" }, 
		{ Element.ConvertWords, "Смена раскладки нескольких слов" }, 
		{ Element.ToggleSymbolIgnore, "Переключить игнорование символов" }, 
		{ Element.SelectedToTitleCase, "Регистр выделения как в предложении" }, 
		{ Element.SelectedToRandomCase, "СЛУчАйнЫй регистр выделения" }, 
		{ Element.SelectedToSwapCase, "Выделенные слова в оБРАТНЫЙ регистр" }, 
		{ Element.SelectedTransliteration, "Транслитерация выделенного текста" }, 
		{ Element.ExitMahou, "Выход" }, 
		{ Element.RestartMahou, "Перезапуск" }, 
		{ Element.Enabled, "Включена" }, 
		{ Element.DoubleHK, "Двойная горячая клавиша" }, 
		{ Element.ToggleLangPanel, "Переключить видимость панели языка" }, 
		#endregion
		#region LangPanel
		{ Element.DisplayLangPanel, "Отображать языковую панель." },
		{ Element.RefreshRate, "Скорость обновления (мс):" },
		{ Element.Transparency, "Прозрачность:" },
		{ Element.BorderColor, "Цвет рамки:" },
		{ Element.UseAeroColor, "Использовать Аэро/Главный цвет." },
		{ Element.DisplayUpperArrow, "Отображать стрелку когда ввод верхнего регистра." },
		#endregion
		#region Updates
		{ Element.CheckForUpdates, "Проверить обновления:" }, 
		{ Element.Checking, "Проверка обновления..." }, 
		{ Element.YouHaveLatest, "У Вас последняя версия." }, 
		{ Element.TimeToUpdate, "Доступна новая версия." }, 
		{ Element.UpdateMahou, "Обновить Mahou до <версии>" }, 
		{ Element.DownloadUpdate, "Скачать обновление" }, 
		{ Element.ProxyConfig, "Настройки прокси" }, 
		{ Element.ProxyServer, "Сервер:порт" }, 
		{ Element.ProxyLogin, "Логин:" }, 
		{ Element.ProxyPass, "Пароль:" }, 
		{ Element.Error, "Ошибка..." }, 
		{ Element.NetError, "Соединение с github.com не может быть установлено, " +
			"проверьте подключение к интернету или настройки прокси..."}, 
		{ Element.UpdatesChannel, "Канал обновлений:" },
		#endregion
		#region About
		{ Element.DbgInf, "Отладочная информация" }, 
		{ Element.DbgInf_Copied, "Скопировано" }, 
		{ Element.Site, "Сайт" }, 
		{ Element.Releases, "Релизы" }, 
		{ Element.About, "Горячие клавиши: Вы можете посмотреть их во вкладке горячие клавиши.\r\n"+
			"\r\n*Если текст набирается в раскладке, которой нет в настройках, то текст конвертируется в Язык 1 (ее актуально если включён циклич. режим).\r\n\r\n"+
            "**Если у Вас проблемы с символами при конвертации выделения, рекомендуется включить функцию \"Считать раскладку для всего слова в КВ\". Также можно попробовать \"переключить языки местами (1=>2 & 2=>1)\" или включить \"Смена раскладки в конверт выделенния\" или плюс.\r\n"+
			"***Если у Вас проблемы при конвертации выделения, попробуйте увеличить число попыток взятия текста во вкладке Тайминги." +
			"\r\nЕсли остались вопросы по поводу Mahou, обратитесь к вики или напишите к разработчику (эл. почта и ссылка на wiki ниже).\r\nУдачи."}, 
		#endregion
		#region Misc
		{ Element.Keys, "Клавиши" }, 
		{ Element.Key_Left, "Левый" }, 
		{ Element.Key_Right, "Правый" }, 
		{ Element.Layouts, "Раскладки" }, 
		{ Element.Layout, "Раскладка" }, 
		{ Element.Plugin, "плагин" }, 
		{ Element.Hotkey, "Горячая клавиша" }, 
		{ Element.UpdateFound, "Доступна новая версия!" }, 
		{ Element.UpdateComplete, "Mahou успешно обновлен!" }, 
		{ Element.ShowHide, "Показать/Скрыть" }, 
		{ Element.Mahou, "Mahou(魔法) - волшебный переключатель раскладок." }, 
		{ Element.Download, "Скачать" }, 
		{ Element.ConfigsCannot, "Файл настроек Mahou.ini не может быть " },
		{ Element.Created, "создан" },
		{ Element.Readen, "прочитан" },
		{ Element.RetryInAppData, "Попробовать создать/переключится на настройки в %AppData%?" },
		#endregion
		#region Buttons
		{ Element.ButtonOK, "ОК" }, 
		{ Element.ButtonApply, "Применить" }, 
		{ Element.ButtonCancel, "Отмена" }, 
		#endregion
		#region Tooltips
		{ Element.TT_SwitchBetween, "Пока включена, [Конверт слова] и [Конверт линии] и [Конверт выделения с \"Смена раскладки в конверт выделенния\" включённой]\n" +
		                                  "будет переключать раскладку циклично, вместо переключения между выбранными в настройках." +
		                                  "Если есть программа в которой [Конверт слова] или [Конверт линии] или [Конверт выделения с \"Смена раскладки в конверт выделенния\" включённой] не работают,то попробуйте включить эту функцию.\nТакже теперь можно включать эту функцию *вместе* с эмуляцией переключения раскладку,\nэто исправляет проблемы в программах типа MSOffice2016, функция не работает в консольных приложениях без getconbl.dll." }, 
		{ Element.TT_ConvertSelectionSwitch, "Если включена, Конверт выделения Будет использовать переключение раскладки.\nВсе символы будут напечатаны правильно, если перед переключением стояла раскладка в которой они были написаны.\nТакже есть улучшение функции, \"плюс\"." }, 
		{ Element.TT_BlockCtrl, "Блокирует горячие клавиши содержащие Control,\nможет быть полезно если \"Переключать язык клавишей\" установлен на Left/Right Control." }, 
		{ Element.TT_CapsDis, "Если включено, то будет работать таймер который будет выключать CapsLock(лампочку)." }, 
		{ Element.TT_EmulateLS, "Если включено, переключение раскладку будет эмулировать нажатие клавиш выбранных правее для переключения раскладки.\nЭту функцию теперь можно включать вместе с функцией [Переключать между раскладками]." }, 
		{ Element.TT_RePress, "Если включено, то модификаторы(Ctrl/Alt/Shift/Win) будут нажаты заново после действия горячей клавиши (НЕ рекомендуется).\r\n"+
							  "Если вы отпустите модификаторы до того, как завершится действие конвертации - могут залипнуть модификаторы...)." },
		{ Element.TT_Add1Space, "Если включено, то ОДИН пробел будет добавлятся в последнее слово." },
		{ Element.TT_Add1NL, "Если включено, то к последнему введенному слову будет добавляться ОДИН перевод строки,\r\nблагодаря чему конвертация последнего слова будет работать, если вы случайно нажали Enter после слова." }, 
		{ Element.TT_ReSelect, "Если включено, любые \"Конверт выделения\" будут выделять текcт заново." }, 
		{ Element.TT_ScrollTip, "Подсвечивать лампочку Scroll Lock когда активна раскладка 1, выбранная во вкладке Раскладки.\nНе обязательно оставлять включенным функцию \"Переключать между раскладками\", нужно просто выбрать раскладку #1 ниже неё." }, 
		{ Element.TT_LDOnlyOnChange, "Отображать подсказку языка только при смене раскладки.\nВремя отображения - 2x[Скорость обновления возле каретки + возле мыши]." }, 
		{ Element.TT_ConvertSelectionSwitchPlus, "Совмещает работу Конверт выделения с включенным \"Смена раскладки в Конверт выделения\" и когда она выключена." +
										"\nВозможности:"+
										"\n1.Конвертировать текст с разных языков на разные языки за 1 конвертацию."+
										"\n2.Игнорирование символов работает здесь."+
										"\n3.Авто-распознавание раскладки текста (символы, которые есть в обоих раскладках, не поддерживаются)"+
										"\n4.Конвертировать неподдерживаемые символы по-разному, если менять раскладку перед конвертацией." }, 
		{ Element.TT_LDForMouse, "Если включена, то при наведении на текстовую форму рядом с мышью будет отображаться подсказка языка." }, 
		{ Element.TT_LDForCaret, "Если включена, то возле текстового курсора будет отображаться подсказка языка." }, 
		{ Element.TT_Snippets, "Если включено, нажатие ПРОБЕЛА увеличит маленькое слово(которое имеет суффикс \"->\"), в большой кусок текста(который между \"====>\" и \"<====\")." }, 
		{ Element.TT_Logging, "Создано ТОЛЬКО для поиска ошибок, журналы сохраняются в папке \"Logs\"." }, 
		{ Element.TT_LDDifferentAppearence, "Если включено, то вы сможете выбрать разный вид для двух раскладок(1&2). Для других будут использоваться стандартные из \"возле мыши\" или \"возле каретки\"." }, 
		{ Element.TT_CountryFlags, "Если включено, иконка в трее будет показывать флаги стран." }, 
		{ Element.TT_SymbolIgnore, "Если включено, символы []{};':\"./<>? будут проигнорированы.\nРаботает в Конверт слова, строки, выделения с включенным \"Смена раскладки в Конверт выделения\" или плюс.\n" +
										"НЕ БУДЕТ РАБОТАТЬ, если у Вас больше 2 раскладок, и функция \"Преключать между раскладками\" выключена!" }, 
		{ Element.TT_ConvertWords, "Дает возможность конвертировать конкретное количество последних слов. После горячей клавиши нажмите 0-9(0 = 10) на клавиатуре." }, 
		{ Element.TT_ExcludedPrograms, "Программы-исключения, в которых горячие клавиши смены раскладки не будут работать.\nРазделители, пробелы и новые строки.\r\nЕсли в именах процессов есть пробел, замените его на _ , сам _ тоже можно заменять на _ .\r\nПример: Имя процесса: mon_hun online.exe\r\nВ Mahou: mon_hun_online.exe." }, 
		{ Element.TT_MCDSSupport, "Дает возможность отображать подсказки текущего языка возле каретки в Sublime Text 3.\nДля его работы нужно установить плагин (ссылка справа).\nНастройки во вкладке Вид.\nСверху: Высота заголовка окна + высота панели вкладок ST3,\nСнизу: Отступ от края окна до строки ввода консоли ST3 (ctrl+`).\nДля разных тем Windows требуются разные настройки!" }, 
		{ Element.TT_LDText, "Оставьте пустым для авто-определения.\r\nВведите Alt+255 (NumPad) для отключения отображения подсказки для этой раскладки при активной функции отображении флагов." }, 
		{ Element.TT_OneLayoutWholeWordCS, "Использовать одну раскладку для целого слова в Конверт Выделении.\r\n"+
				"Эта функция использует количество правильно распознанных букв в двух раскладках, чтобы определить раскладку слова,\r\n"+
				"Эта функция ПРЕКРАСНО работает с словами, которые имеют рядом символы, но длина слова должна быть больше 1 без учёта символов, чтобы функция нормально работала." },
		{ Element.TT_PersistentLayout, "Напишите здесь названия процессов, в которых вы бы хотели иметь постоянную раскладку, разделитель - пробел или новая строка.\r\nЕсли в именах процессах есть пробел заменяйте его на _ , сам _ тоже можно заменять на _ .\r\nПример: Имя процесса: mon_hun online.exe\r\nВ Mahou: mon_hun_online.exe."},
		{ Element.TT_SwitchOnlyOnWindowChange, "Если включено, то функция постоянной раскладки не будет обновляться через таймеры, а будет обновляться только при смене окон (Сообщения Windows).\r\nПотребляет ЦП только при смене окон, в итоге НАМНОГО меньше, чем таймеры."},
		{ Element.TT_SwitchOnlyOnce, "Если включено, смена раскладки будет происходить только ОДИН раз для каждого окна выбранных процессов.\r\nСписок окон, для которых уже менялась раскладка, очищается при нажатии \"Применить\" или \"ОК\"."},
		{ Element.TT_OneLayout, "Позволяет хранить раскладку в Mahou, вместо раскладки для каждого окна/программы.\r\n(Если у Вас Windows 8 и выше, то там уже стоит данная функция по умолчанию, нет необходимости включать её в Mahou)"},
		{ Element.TT_QWERTZ, "Исправляет замену для QWERTZ клавиатур для букв: ß, ä, ö, ü, Ä, Ö, Ü, Y, Z в Конверт выделении\r\n(НЕ СОВМЕСТИМО со сменой раскладки в конверт выделении (или +))." },
		{ Element.TT_Change1KeyLayoutInExcluded, "Функция находится во вкладке \"Раскладки\" -> [Переключать раскладки по клавишам]." },
		{ Element.TT_SnippetsSwitchToGuessLayout, "Меняет раскладку в *угаданную* после того, как сниипет конвертировался.\r\nУгадывание работает так же, как в функции \"Одна раскладка для целого слова в Конверт Выделения\"."},
		{ Element.TT_SnippetsCount, "Если ОРАНЖЕВЫЙ, то со сниппетами все OK.\r\nЕсли КРАСНЫЙ, то в сниппетах есть ошибка (сниппет может быть не завершён и т.д.).\r\nВ скобках отображается количество закоментированых линий (игнорируются Mahou),\r\nдоступные символы для комментирования линий: # или // и только в начале линии." },
		{ Element.TT_GuessKeyCodeFix, "Включая это, сниппеты, конвертация выделения, автозамена будут отправлять реальные коды клавиш вместо юникод символов,\r\nно это сделает так, что все символы будут в вашей текущей раскладке.\r\nПолезно в приложениях внутри виртуальных машин (BlueStacks, VirtualBox, etc)." },
		{ Element.TT_ConfigsInAppData, "Если включено, Mahou скопирует текущую конфигурацию (Mahou.ini) в %AppData% и будет использовать их.\r\nТакже логи и сниппеты будут храниться в %AppData%\\Mahou.\r\nКогда состояние этой галочки изменено, все другие галочки/данные конфигурации, измененные в пользовательском интерфейсе не будут сохранены,\r\nт.к. произойдет смена конфигурации и загрузка выбранной из папки Mahou или из %AppData%\\Mahou.\r\nПолезно, если нужно запускать Mahou в папке Program files, а прав на запись у всех пользователей нет,\r\nТакже даёт возможность иметь разные настройки для каждого пользователя." },		
		{ Element.TT_KeysType, "Выбирите, какой тип клавиш отображать в Mahou. Оба типа работают ВМЕСТЕ,\r\nтак что лучше не назначайте одиннаковые клавиши/гор. клавиши во избежание двойного переключения раскладки."},
		{ Element.TT_SnippetExpandKey, "Выберите, какой клавишей развертывать (увеличивать/превращать) сниппеты.\r\nРаботает только для сниппетов. Автозамена, как и раньше, будет работать только при Space." },
		{ Element.TT_LDUseWinMessages, "Если включено, подсказки будут обновлятся не через таймеры,\r\nвместо этого они будут обновлятся на соответствующих Сообщениях Windows.\r\nПотребляет меньше ЦП.\r\nСамая требовательная к ЦП функция - подсказка возле мыши при всегда включенной,\r\nпотребляет ЦП только при движении/кликах мыши,\r\nчтобы уменьшить потребление ею ЦП, есть новая конфигурация во вкладке Тайминги.\r\nПропуск х сообщений Windows движения мыши перед обновлением подсказки." },
		{ Element.TT_RemapCapslockAsF18, "Переопределяет клавишу Caps Lock как F18. После этого функция клавиши CapsLock будет отключена.\r\nЧтобы переключить состояние Caps Lock, нажмите её вместе с одной из клавиш модификаторов: Ctrl/Alt/Shift/Win.\r\n! Окно Mahou исключено из переопределения!\r\nВ Mahou назначайте гор. клавиши на Caps Lock, в других программах она будет переопределена как F18.\r\nПосле смены гор. клавиш не забудьте нажать Применить или ОК." },
		{ Element.TT_UseDelayAfterBackspaces, "Если включено, Mahou будет ждать некоторое время после удаления старого слова и перед вводом конвертированного слова.\r\nПолезно, если в некоторых программах функция Mahou Конверт последнего слова не работает нормально." },
		#endregion
		#region Messages
		{ Element.MSG_SnippetsError, "Ошибки в синтаксисе сниппета. Детали синтаксиса представлены на странице Wiki." }
		#endregion
	};
}
