using MetroFramework.Forms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace h2mLauncher
{
	internal class SteamHandler
	{
		public static string gamepath;
		public static uint gameID = 393100; //393080;  //
		public static string username;
		public static void InitializeSteam()
		{

			//Form1.MainForm.Invoke((MethodInvoker)delegate
			//{
			//	//	Form1.MainForm.pictureBox2.Visible = true; //Refresh button
			//	Form1.MainForm.webView21.Visible = true;
			//	Form1.MainForm.metroProgressBar1.Value = 100;
			//	Form1.MainForm.statusLabel.Text = "Finished!";
			//	// Form1.MainForm.pictureBox5.Visible = true;
			//	Form1.MainForm.pictureBox1.Visible = true;
			//	Form1.MainForm.currentlyDownloading.Visible = false;
			//	Form1.MainForm.sizeLeft.Visible = false;
			//	Form1.MainForm.metroProgressBar1.Visible = false;
			//});


			try
			{
				SteamClient.Init(gameID);
				if (!SteamClient.IsValid)
				{
					MessageBox.Show("Steam isn`t running or inactive steam session!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
					SteamClient.Shutdown();
					Form1.MainForm.Close();
				}
				Form1.MainForm.Invoke((MethodInvoker)delegate
				{
					Form1.MainForm.statusLabel.Text = "Initialize steam...";
					Form1.MainForm.Text = "Welcome " + SteamClient.Name;
					Form1.MainForm.statusLabel.Visible = true;
					username = SteamClient.Name;
				});
				gamepath = SteamApps.AppInstallDir(gameID);
				Filesystems.clientpath = gamepath;

				if (!SteamApps.IsAppInstalled(gameID))
				{
					MessageBox.Show("Please install Call of Duty®: Modern Warfare® Remastered (2017) before installing this mod!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Form1.MainForm.Invoke((MethodInvoker)delegate
					{
						Form1.MainForm.Close();
					});
					return;
				}

				using (WebClient wclient = new WebClient())
				{
					JArray files = JArray.Parse(wclient.DownloadString("http://134.255.232.105/h2m/h2m.json"));
					Downloader.startDownload(files);
				}
				return;

			}
			catch (System.Exception ex)
			{
				MessageBox.Show("Steam isnt running or you do not own Call of Duty®: Modern Warfare® Remastered (2017)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Form1.MainForm.Invoke((MethodInvoker)delegate
				{
					Form1.MainForm.Close();
				});
				return;
			}
		}




	}
}
