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
using Mahou.Resources.Strings;

namespace Mahou
{
	public partial class Update : Form
	{
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
            btShowProxy.BackgroundImage = recolorImg(SystemColors.WindowText, (Bitmap)Mahou.Properties.Resources.down_arrow);
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
					Logging.Log("Downloding Mahou update: "+UpdInfo[3]);
					wc.DownloadFileAsync(new System.Uri(UpdInfo[3]), Path.Combine(new string[] {
						nPath,
						fn
					}));
					lbDownloading.Text = $"{Strings.Downloading} {fn}";
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
							btDMahou.Text = Strings.TimedOut;
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
				Logging.Log("Download of Mahou update [" + UpdInfo[3] +"] finished.");
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
DEL /Q /F12:/2:56.98/ """ + nPath + @"Mahou.exe""

ECHO With CreateObject(""Shell.Application"") > ""%MAHOUDIR%unzip.vbs""
ECHO    .NameSpace(WScript.Arguments(1)).CopyHere .NameSpace(WScript.Arguments(0) ).items >> ""%MAHOUDIR%unzip.vbs""
ECHO End With >> ""%MAHOUDIR%unzip.vbs""

CSCRIPT ""%MAHOUDIR%unzip.vbs"" ""%MAHOUDIR%" + arch + @""" ""%MAHOUDIR%""

START """" ""%MAHOUDIR%Mahou.exe"" ""_!_updated_!_""

DEL ""%MAHOUDIR%" + arch + @"""
DEL ""%MAHOUDIR%unzip.vbs""
DEL ""%MAHOUDIR%UpdateMahou.cmd""";
				//Save Batch script
				Logging.Log("Writing update script.");
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
				Logging.Log("Starting update script.");
				Process.Start(piUpdateMahou);
				was = true;
			}
		}

		void btnCheck_Click(object sender, EventArgs e)
		{
			btnCheck.Visible = false;
			lbChecking.Visible = true;
			lbChecking.Text = Strings.Checking;
			Task.Factory.StartNew(GetUpdateInfo);
			tmr.Tick += (_, __) => {
				btnCheck.Text = Strings.CheckForUpdates;
				lbChecking.Visible = false;
				btnCheck.Visible = true;
				tmr.Stop();
			};
			if (UpdInfo[2] == Strings.Error) {
				lbChecking.Text = Strings.ErrorOccuredDuringCheck;
				tmr.Start();
				SetUInfo();
				tmr.Tick += (_, __) => {
					lbVer.Text = Strings.Version;
					gpRTitle.Text = Strings.Title;
					lbRDesc.Text = Strings.Description;
					lbChecking.Visible = false;
					btnCheck.Visible = true;
					tmr.Stop();
				};
				tmr.Start();
			} else {
				if (flVersion("v" + Application.ProductVersion) <
				    flVersion(UpdInfo[2])) {
					lbChecking.Text = Strings.YouNeedToUpdate;
					tmr.Start();
					SetUInfo();
					btDMahou.Text = Strings.UpdateMahouTo + UpdInfo[2];
					btDMahou.Enabled = true;
					pbStatus.Enabled = true;
				} else {
					lbChecking.Text = Strings.YouHaveLatestVersion;
					tmr.Start();
					SetUInfo();
				}
			}
		}

		void GetUpdateInfo()
		{
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
                var response = (HttpWebResponse)Task.Factory
                    .FromAsync<WebResponse>(request.BeginGetResponse,request.EndGetResponse, null).Result;
				//Console.WriteLine(response.StatusCode)
                if (response.StatusCode == HttpStatusCode.OK)
                {
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
					Logging.Log("Check for updates succeded, GitHub version: "+ Version + ".");
				} else {
				   response.Close();
				}
			} catch {
				Logging.Log("Check for updates failed, error message:", 1);
				Info = new List<string> {
					Strings.Error,
					Strings.FailedToGetUpdate,
					Strings.Error
				};
			}
			UpdInfo = Info.ToArray();
		}
		WebProxy MakeProxy()
		{
			Logging.Log("Creating proxy...");
			var myProxy = new WebProxy();
			try {
				var newUri = new Uri("http://" + tbProxy.Text);
				Logging.Log("Proxy is " + newUri);
				myProxy.Address = newUri;
			} catch {
				gbProxy.Text = Strings.YourProxyNotWorking;
				tmr.Interval = 3000;
				tmr.Tick += (___, ____) => {
					gbProxy.Text = Strings.Proxy;
					tmr.Stop();
				};
				tmr.Start();
			}
			if (!String.IsNullOrEmpty(tbName.Text) || !String.IsNullOrEmpty(tbPass.Text))
				myProxy.Credentials = new NetworkCredential(tbName.Text, tbPass.Text);
			
			return myProxy;
		}
		public void StartupCheck()
		{
			Logging.Log("Startup check for updates.");
			Task.Factory.StartNew(GetUpdateInfo);
			try {
				if (flVersion("v" + Application.ProductVersion) < flVersion(UpdInfo[2])) {
					if (MessageBox.Show(new Form() { TopMost = true }, 
                        $"{UpdInfo[0]} '\n' {UpdInfo[1]}", $"Mahou - {Strings.YouNeedToUpdate}",
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
			Text = Strings.MahouUpdate;
			btnCheck.Text = Strings.CheckForUpdates;
			btDMahou.Text = Strings.UpdateMahouTo.Remove(Strings.UpdateMahouTo.Length - 3, 2);
			lbVer.Text = Strings.Version;
			gpRTitle.Text = Strings.Title;
			lbRDesc.Text = Strings.Description;
			gbProxy.Text = Strings.Proxy;
			lbProxy.Text = Strings.Serverport;
			lbNamePass.Text = Strings.NamePassword;
			Logging.Log("Update UI Language refreshed.");
		}

		public static float flVersion(string ver) // converts "Mahou version type" to float
		{
			var justdigs = Regex.Replace(ver, "\\D", "");
			return float.Parse(justdigs[0] + "." + justdigs.Substring(1), CultureInfo.InvariantCulture);
		}
		void BtShowProxyClick(object sender, EventArgs e)
		{
            if (Size.Height == 300)
            {
                btShowProxy.BackgroundImage = recolorImg(SystemColors.WindowText, (Bitmap)Mahou.Properties.Resources.up_arrow);
				Size = new Size(Size.Width, 410);
            }
            else
            {
                btShowProxy.BackgroundImage = recolorImg(SystemColors.WindowText, (Bitmap)Mahou.Properties.Resources.down_arrow);
				Size = new Size(Size.Width, 300);
			}
		}
        Bitmap recolorImg(Color col, Bitmap img) // Recolors image, useful for dark(classic) themes.
        {
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    if ((img.GetPixel(x, y)).ToArgb() + 1 != (Color.Black.ToArgb() * -1))
                    {
                        img.SetPixel(x, y, col);
                    }
                }
            }
            return img;
        }
	}
}
