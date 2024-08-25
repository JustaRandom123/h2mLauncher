
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using Steamworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace h2mLauncher
{
	internal class Downloader
	{
		public static Form1 mf;

		public static string downloadGame { get; set; }
		public static string gamePath;


		public static string downloadcdn = @"http://134.255.232.105/h2m/files/";
		public static System.Timers.Timer timer { get; set; }
		static string currentlyDownloading { get; set; }
		static string currentlyDownloadingKey { get; set; }


		public static Dictionary<string, string> downloads = new Dictionary<string, string>();
		public static int downloadCount { get; set; }

		public static Dictionary<string, string> fileNeedToDownload = new Dictionary<string, string>();

     

        static bool isDownloading = false;


		public static void startDownload(JArray serverjson)
		{
			////////////////////////

			Form1.MainForm.Invoke((MethodInvoker)delegate
			{
				Form1.MainForm.statusLabel.Text = "Get file list from server";
			});

			var clientfiles = Filesystems.getClientFiles();


			for (int i = 0; i < serverjson.Count; i++)
			{
				string convertedValidPath = Filesystems.clientpath + "\\" + serverjson[i][0].ToString();



				if (File.Exists(convertedValidPath))
				{
					string clientByte = "";
					clientfiles.TryGetValue(serverjson[i][0].ToString(), out clientByte);

					

					if (serverjson[i][1].ToString() != clientByte)
					{

						fileNeedToDownload.Add(convertedValidPath, serverjson[i][0].ToString());
					}
					else
					{
					}
				}
				else
				{
					fileNeedToDownload.Add(convertedValidPath, serverjson[i][0].ToString());
				}
			}


			if (fileNeedToDownload != null)
			{
				if (fileNeedToDownload.Count >= 1)
				{


					DialogResult result = MessageBox.Show("Downloading " + fileNeedToDownload.Count + " file(s). Do you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result == DialogResult.No)
					{
						Application.Exit();
						return;
					}

                    //hier

                    Form1.MainForm.Invoke((MethodInvoker)delegate
                    {
						Form1.MainForm.currentlyDownloading.Visible = true;
						Form1.MainForm.metroProgressBar1.Visible = true;
                        Form1.MainForm.sizeLeft.Visible = true;
                    });


                    downloadCount = fileNeedToDownload.Count;
					downloads = fileNeedToDownload;
					downloader();
				
				}
				else
				{
					downloader();			
				}
			}
			else
			{

			}
		}




		public static void downloader()
		{
			isDownloading = true;	
			if (downloadCount > 0)
			{
				var file = downloads.First();

				using (WebClient wc = new WebClient())
				{
					currentlyDownloading = file.Value;
					currentlyDownloadingKey = file.Key;
					Directory.CreateDirectory(Path.GetDirectoryName(file.Key));
                    Form1.MainForm.Invoke((MethodInvoker)delegate
                    {
                        Form1.MainForm.currentlyDownloading.Text = "Downloading: " + gamePath + currentlyDownloading;
                        Form1.MainForm.statusLabel.Text = "Status | " + Downloader.downloadCount + " file(s) left";
                    });
                    //	mf.currentlyDownloading.Text = "Downloading: " + gamePath + currentlyDownloading;
                    //	mf.statusLabel.Text = "Status | " + Downloader.downloadCount + " file(s) left";
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
					wc.DownloadFileCompleted += wc_DownloadFileCompleted;
					wc.DownloadFileAsync(new Uri(downloadcdn + currentlyDownloading), file.Key);

				}
			}
			else
			{
				isDownloading = false;
                //mf.metroLabel2.Visible = false;
                //mf.metroLabel3.Visible = false;
                //mf.metroLabel3.Text = "";
                //mf.metroLabel2.Text = "";
                Form1.MainForm.Invoke((MethodInvoker)delegate
                {
				
					Form1.MainForm.metroProgressBar1.Value = 100;
                    Form1.MainForm.statusLabel.Text = "Finished!";
                   // Form1.MainForm.pictureBox5.Visible = true;
                    Form1.MainForm.pictureBox1.Visible = true;
                    Form1.MainForm.currentlyDownloading.Visible = false;
                    Form1.MainForm.sizeLeft.Visible = false;
                    Form1.MainForm.metroProgressBar1.Visible = false;
                });
            //    mf.statusLabel.Text = "Finished! Loading...";
				//mf.metroProgressBar1.Value = 100;
				//timer = new System.Timers.Timer(3000);
				//timer.Elapsed += Timer_Elapsed;
				//timer.Enabled = true;
				//timer.Start();

			}
		}


		private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
		{
			mf.statusLabel.Invoke((MethodInvoker)delegate { mf.statusLabel.Visible = false; });
			mf.Invoke((MethodInvoker)delegate { mf.BackImage = null; });
			mf.metroProgressBar1.Invoke((MethodInvoker)delegate { mf.metroProgressBar1.Visible = false; });
		//	mf.listView1.Invoke((MethodInvoker)delegate { mf.listView1.Visible = true; });  //serverbrowser
		//	mf.pictureBox4.Invoke((MethodInvoker)delegate { mf.pictureBox4.Visible = true; });

			timer.Enabled = false;
			timer.Dispose();
			timer = null;

		//	Serverbrowser.LoadServerbrowser();
		}




		private static void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
            mf.metroProgressBar1.Invoke((MethodInvoker)delegate { mf.metroProgressBar1.Value = e.ProgressPercentage; });
          //  mf.metroProgressBar1.Value = e.ProgressPercentage;

			long totalbytes = e.TotalBytesToReceive / 1024 / 1024;
			long totalbytesKB = e.TotalBytesToReceive / 1024;
			long bytes = e.BytesReceived / 1024 / 1024;
			long gbbytes = e.BytesReceived / 1024 / 1024 / 1024;
			long totalbytesGB = e.TotalBytesToReceive / 1024 / 1024 / 1024;
			long bytesKB = e.BytesReceived / 1024;
			if (e.BytesReceived >= 999)
			{
                mf.sizeLeft.Invoke((MethodInvoker)delegate { mf.sizeLeft.Text = bytes.ToString() + " / " + totalbytes.ToString() + " MB "; });
                //	mf.sizeLeft.Text = bytes.ToString() + " / " + totalbytes.ToString() + " MB ";
            }
			else if (e.BytesReceived < 999)
			{
                mf.sizeLeft.Invoke((MethodInvoker)delegate { mf.sizeLeft.Text = bytesKB.ToString() + " / " + totalbytesKB.ToString() + " KB "; });
                //mf.sizeLeft.Text = bytesKB.ToString() + " / " + totalbytesKB.ToString() + " KB ";
            }
			else if (e.BytesReceived >= 9999)
			{
                mf.sizeLeft.Invoke((MethodInvoker)delegate { mf.sizeLeft.Text = gbbytes.ToString() + " / " + totalbytesGB.ToString() + " GB "; });
                // mf.sizeLeft.Text = gbbytes.ToString() + " / " + totalbytesGB.ToString() + " GB ";
            }
        }


		private static void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			downloads.Remove(currentlyDownloadingKey);
			downloadCount--;
			downloader();
		}

		
	}
}
