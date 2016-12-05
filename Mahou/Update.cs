using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

using NLog;

namespace Mahou
{
	public partial class Update : Form
	{

        private readonly Logger log = LogManager.GetCurrentClassLogger();
		//Path to now Mahou
		public static string nPath = AppDomain.CurrentDomain.BaseDirectory;
		static string[] UpdInfo;
		static bool updating, was, isold = true, fromStartup;
		static Timer tmr = new Timer();
		static Timer old = new Timer();
		static Timer animate = new Timer();
		static int progress = 0, _progress = 0;
		public Update()
		{
			animate.Interval = 2500;
			tmr.Interval = 3000;
			old.Interval = 7500;
			old.Tick += (_, __) => { //Toggles every 7.5 sec
				//Console.WriteLine(isold);
				isold = !isold;
			};
			InitializeComponent();
		}

		void Update_VisibleChanged(object sender, EventArgs e)
		{
			ActiveControl = lbVer;
//            Console.WriteLine(UpdInfo == null);
//            Console.WriteLine(UpdInfo.Length);
//            foreach (var i in UpdInfo) {
//            	Console.WriteLine(i);
//            }
			try {
				if (UpdInfo != null && UpdInfo[2].Substring(0, 1) == "v") {
					SetUInfo();
					btDMahou.Enabled |= flVersion("v" + Application.ProductVersion) < flVersion(UpdInfo[2]);
					if (fromStartup) {
						btDMahou.PerformClick();
						fromStartup = false;
					}
				}
			} catch {
				SetUInfo();
			}
			if (Visible) {
				tbProxy.Text = MMain.MyConfs.Read("Proxy", "ServerPort");
				tbName.Text = MMain.MyConfs.Read("Proxy", "UserName");
				tbPass.Text = MMain.MyConfs.Read("Proxy", "Password");
			} else {
				MMain.MyConfs.Write("Proxy", "ServerPort", tbProxy.Text);
				MMain.MyConfs.Write("Proxy", "UserName", tbName.Text);
				MMain.MyConfs.Write("Proxy", "Password", tbPass.Text);
			}
		
		}

		void Update_Load(object sender, EventArgs e)
		{
			RefreshLanguage();
		}

		void btDMahou_Click(object sender, EventArgs e)
		{
			if (!updating) {
				updating = true;
				//Downloads latest Mahou
				using (var wc = new WebClient()) {
					wc.DownloadProgressChanged += wc_DownloadProgressChanged;
					// Gets filename from url
					var BDMText = btDMahou.Text;
					var fn = Regex.Match(UpdInfo[3], @"[^\\\/]+$").Groups[0].Value;
					if (!String.IsNullOrEmpty(tbProxy.Text)) {
						wc.Proxy = MakeProxy();
					}
					wc.DownloadFileAsync(new System.Uri(UpdInfo[3]), Path.Combine(new string[] {
						nPath,
						fn
					}));
					lbDownloading.Text = MMain.UI[29] + " " + fn;
					animate.Tick += (_, __) => {
						lbDownloading.Text += ".";
					};
					animate.Start();
					btDMahou.Visible = false;
					lbDownloading.Visible = true;
					tmr.Tick += (_, __) => {
						// Checks if progress changed?
						if (progress == _progress) {
							old.Stop();
							isold = true;
							btDMahou.Visible = true;
							lbDownloading.Visible = false;
							animate.Stop();
							pbStatus.Value = progress = _progress = 0;
							wc.CancelAsync();
							updating = false;
							btDMahou.Text = MMain.UI[30];
							tmr.Tick += (o, oo) => {
								btDMahou.Text = BDMText;
								tmr.Stop();
							};
							tmr.Interval = 3000;
							tmr.Start();
						} else {
							tmr.Stop();
						}
					};
					old.Start();
					tmr.Interval = 15000;
					tmr.Start();
				}
			}
		}

		void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			if (isold)
				_progress = e.ProgressPercentage;
			pbStatus.Value = progress = e.ProgressPercentage;
			//Below in "if" is AUTO-UPDATE feature ;)
			if (e.ProgressPercentage == 100 && !was) {
				int MahouPID = Process.GetCurrentProcess().Id;
				//Downloaded archive
				var arch = Regex.Match(UpdInfo[3], @"[^\\\/]+$").Groups[0].Value;
				//This prevent Mahou icon from stucking in tray
				MMain.mahou.icon.Hide();
				//Batch script to create other script o.0,
				//which shutdown running Mahou,
				//delete old version,
				//unzip downloaded one, and start it.
				var UpdateMahou =
					@"@ECHO OFF
chcp 65001
SET MAHOUDIR=" + nPath + @"
TASKKILL /PID " + MahouPID + @" /F
DEL """ + nPath + @"Mahou.exe""

ECHO With CreateObject(""Shell.Application"") > ""%MAHOUDIR%unzip.vbs""
ECHO    .NameSpace(WScript.Arguments(1)).CopyHere .NameSpace(WScript.Arguments(0) ).items >> ""%MAHOUDIR%unzip.vbs""
ECHO End With >> ""%MAHOUDIR%unzip.vbs""

CSCRIPT ""%MAHOUDIR%unzip.vbs"" ""%MAHOUDIR%" + arch + @""" ""%MAHOUDIR%""

START """" ""%MAHOUDIR%Mahou.exe"" ""_!_updated_!_""

DEL ""%MAHOUDIR%" + arch + @"""
DEL ""%MAHOUDIR%unzip.vbs""
DEL ""%MAHOUDIR%UpdateMahou.cmd""";
				//Save Batch script
				File.WriteAllText(Path.Combine(new string[] {
					nPath,
					"UpdateMahou.cmd"
				}), UpdateMahou);
				var piUpdateMahou = new ProcessStartInfo();
				piUpdateMahou.FileName = Path.Combine(new string[] {
					nPath,
					"UpdateMahou.cmd"
				});
				//Make UpdateMahou.cmd's startup hidden
				piUpdateMahou.WindowStyle = ProcessWindowStyle.Hidden;
				//Start updating(unzipping)
				Process.Start(piUpdateMahou);
				was = true;
			}
		}

		async void btnCheck_Click(object sender, EventArgs e)
		{
			btnCheck.Visible = false;
			lbChecking.Visible = true;
			lbChecking.Text = MMain.UI[23];
			await GetUpdateInfo();
			tmr.Tick += (_, __) => {
				btnCheck.Text = MMain.UI[22];
				lbChecking.Visible = false;
				btnCheck.Visible = true;
				tmr.Stop();
			};
			if (UpdInfo[2] == MMain.UI[31]) {
				lbChecking.Text = MMain.UI[34];
				tmr.Start();
				SetUInfo();
				tmr.Tick += (_, __) => {
					lbVer.Text = MMain.UI[25];
					gpRTitle.Text = MMain.UI[26];
					lbRDesc.Text = MMain.UI[27];
					lbChecking.Visible = false;
					btnCheck.Visible = true;
					tmr.Stop();
				};
				tmr.Start();
			} else {
				if (flVersion("v" + Application.ProductVersion) <
				    flVersion(UpdInfo[2])) {
					lbChecking.Text = MMain.UI[33];
					tmr.Start();
					SetUInfo();
					btDMahou.Text = MMain.UI[28] + UpdInfo[2];
					btDMahou.Enabled = true;
					pbStatus.Enabled = true;
				} else {
					lbChecking.Text = MMain.UI[32];
					tmr.Start();
					SetUInfo();
				}
			}
		}

		async Task GetUpdateInfo() {
		    log.Trace("Getting update info");
			var Info = new List<string>(); // Update info
			try {
				// Latest Mahou release url
				const string url = "https://github.com/BladeMight/Mahou/releases/latest";
				var request = (HttpWebRequest)WebRequest.Create(url);
				// For proxy
				if (!String.IsNullOrEmpty(tbProxy.Text)) {
					request.Proxy = MakeProxy();
				}
				request.ServicePoint.SetTcpKeepAlive(true, 5000, 1000);
				var response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
				//Console.WriteLine(response.StatusCode)
				if (response.StatusCode == HttpStatusCode.OK) {
					var data = new StreamReader(response.GetResponseStream(), true).ReadToEnd();
					response.Close();
					// Below are REGEX HTML PARSES!!
					// I'm not kidding...
					// They really works :)
					var Title = Regex.Match(data,
						            "<h1 class=\"release-title\">\n.*<a href=\".*\">(.*)</a>").Groups[1].Value;
					var Description = Regex.Replace(Regex.Match(data,
                                                //These ↓↓↓↓↓↓↓↓ &&&  ↓↓↓↓↓↓ spaces looks unsafe, but really they works!
						                  "<div class=\"markdown-body\">\n        (.*)\n      </div>",
						                  RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value, "<[^>]*>", "");
					var Version = Regex.Match(data, "<span class=\"css-truncate-target\">(.*)</span>").Groups[1].Value;
					var Link = "https://github.com" + Regex.Match(data,
						           "<ul class=\"release-downloads\">\n.*<li>\n.+href=\"(/.*\\.\\w{3})").Groups[1].Value;
					Info.Add(Title);
					Info.Add(Regex.Replace(Description, "\n", "\r\n")); // Regex needed to properly display new lines.
					Info.Add(Version);
					Info.Add(Link);
				} else {
					response.Close();
				}
			} catch (WebException ex) {
                log.Error(ex);
				Info = new List<string> {
					MMain.UI[31],
					MMain.UI[35],
					MMain.UI[31]
				};
			}
			UpdInfo = Info.ToArray();
		}
		WebProxy MakeProxy()
		{
			var myProxy = new WebProxy();
			try {
				var newUri = new Uri("http://" + tbProxy.Text);
				myProxy.Address = newUri;
			} catch (Exception ex){
                log.Error(ex,"Proxy cannot be created");
				gbProxy.Text = MMain.UI[51];
				tmr.Interval = 3000;
				tmr.Tick += (___, ____) => {
					gbProxy.Text = MMain.UI[48];
					tmr.Stop();
				};
				tmr.Start();
			}
			if (!String.IsNullOrEmpty(tbName.Text) || !String.IsNullOrEmpty(tbPass.Text))
				myProxy.Credentials = new NetworkCredential(tbName.Text, tbPass.Text);
			
			return myProxy;
		}
		public async void StartupCheck()
		{
			await GetUpdateInfo();
			try {
				if (flVersion("v" + Application.ProductVersion) < flVersion(UpdInfo[2])) {
					if (MessageBox.Show(new Form() { TopMost = true },
						     UpdInfo[0] + '\n' + UpdInfo[1], "Mahou - " + MMain.UI[33],
						     MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK) {
						MMain.mahou.update.StartPosition = FormStartPosition.CenterScreen;
						fromStartup = true;
						MMain.mahou.update.ShowDialog();
						MMain.mahou.update.StartPosition = FormStartPosition.CenterParent;
					}
				}
			} catch {
			}
		}

		void SetUInfo()
		{
			gpRTitle.Text = UpdInfo[0];
			lbRDesc.Text = UpdInfo[1];
			lbVer.Text = UpdInfo[2];
		}

		void RefreshLanguage()
		{
			Text = MMain.UI[21];
			btnCheck.Text = MMain.UI[22];
			btDMahou.Text = MMain.UI[28].Remove(MMain.UI[28].Length - 3, 2);
			lbVer.Text = MMain.UI[25];
			gpRTitle.Text = MMain.UI[26];
			lbRDesc.Text = MMain.UI[27];
			gbProxy.Text = MMain.UI[48];
			lbProxy.Text = MMain.UI[49];
			lbNamePass.Text = MMain.UI[50];
		}

		public static float flVersion(string ver) // converts "Mahou version type" to float
		{
			var justdigs = Regex.Replace(ver, "\\D", "");
			return float.Parse(justdigs[0] + "." + justdigs.Substring(1), CultureInfo.InvariantCulture);
		}
		void BtShowProxyClick(object sender, EventArgs e)
		{
			if (Size.Height == 300) {
				btShowProxy.BackgroundImage = Mahou.Properties.Resources.up_arrow;
				Size = new Size(Size.Width, 410);
			} else {
				btShowProxy.BackgroundImage = Mahou.Properties.Resources.down_arrow;
				Size = new Size(Size.Width, 300);
			}
			
		}
	}
}
