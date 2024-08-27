using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h2mLauncher
{
	internal class Filesystems
	{
		public static string clientpath { get; set; }

		public static Dictionary<string, string> clientFiles { get; set; }

		public static string hashChecker(string filename)
		{
			return FileSystem.FileLen(filename).ToString();
		}

		public static Dictionary<string, string> getClientFiles()
		{
			Dictionary<string, string> files = new Dictionary<string, string>();



			string[] filesFromPath1 = Directory.GetFiles(clientpath, "*.*", SearchOption.AllDirectories);

			Form1.MainForm.Invoke((MethodInvoker)delegate
			{
				Form1.MainForm.statusLabel.Text = "Loading client files";
			});
			foreach (string file in filesFromPath1)
			{

				FileInfo info = new FileInfo(file);
				string hash = hashChecker(file);


				if (!files.ContainsKey(info.Name))
				{
					string path = info.Directory.FullName;
					string newpath = path.Replace(clientpath, "") + "\\" + info.Name;
					files.Add(newpath, hash);
				}
			}
			Form1.MainForm.Invoke((MethodInvoker)delegate
			{
				Form1.MainForm.statusLabel.Text = "Finished loading!";
			});
			//Downloader.mf.statusLabel.Text = "Finished loading!";
			clientFiles = files;
			return files;
		}
	}
}
