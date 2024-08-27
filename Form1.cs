using MetroFramework.Drawing.Html;
using MetroFramework.Forms;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace h2mLauncher
{
	public partial class Form1 : MetroFramework.Forms.MetroForm
	{

		public Form1()
		{
			InitializeComponent();
			this.pictureBox1.MouseEnter += PictureBox1_MouseEnter;
			this.pictureBox1.MouseLeave += PictureBox1_MouseLeave;

			//	this.pictureBox5.MouseEnter += PictureBox5_MouseEnter;
			//	this.pictureBox5.MouseLeave += PictureBox5_MouseLeave;

			this.ApplyImageInvert = false;
			this.BackImage = h2mLauncher.Properties.Resources.backHD;
			this.BackMaxSize = 1243;


			//HtmlPanel htmlPanel = new HtmlPanel
			//{
			//   // Dock = DockStyle.Fill,
			//    AutoScroll = true,
			//    Text = @"<script async src=""https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js?client=ca-pub-8807066690665641""
			//        crossorigin=""anonymous""></script>"
			//};
			//htmlPanel.Location = new Point(474, 112);
			//htmlPanel.Size = new Size(324, 393);   
			//this.Controls.Add(htmlPanel);


		}

		public static System.Timers.Timer IntroTimer = new System.Timers.Timer(4000);
		public static Form1 MainForm;


		private void PictureBox1_MouseLeave(object? sender, EventArgs e)
		{
			pictureBox1.Size = new Size(pictureBox1.Width - 8, pictureBox1.Height - 8);
			pictureBox1.Refresh();
		}


		//private void PictureBox5_MouseLeave(object? sender, EventArgs e)
		//{
		//	pictureBox5.Size = new Size(pictureBox5.Width - 8, pictureBox5.Height - 8);
		//	pictureBox5.Refresh();
		//}

		private void PictureBox1_MouseEnter(object? sender, EventArgs e)
		{
			pictureBox1.Size = new Size(pictureBox1.Width + 8, pictureBox1.Height + 8);
			pictureBox1.Refresh();
		}

		//private void PictureBox5_MouseEnter(object? sender, EventArgs e)
		//{
		//	pictureBox5.Size = new Size(pictureBox5.Width + 8, pictureBox5.Height + 8);
		//	pictureBox5.Refresh();
		//}


		private void Form1_Load(object sender, EventArgs e)
		{
			this.Controls.Add(CreateIntro.InitializeIntro());
			MainForm = this;
			Downloader.mf = this;
			IntroTimer.Start();
			IntroTimer.Elapsed += IntroTimer_Elapsed;
		}

		private void IntroTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
		{
			IntroTimer.Dispose();
			this.Invoke((MethodInvoker)delegate
			{
				this.Controls.Remove(CreateIntro.introBox);
			});
			SteamHandler.InitializeSteam();
		}





		public static void unlockControls()
		{
			MainForm.Invoke((MethodInvoker)delegate
			{
				// MainForm.SetStyle(ControlStyles.Opaque, true);
				//  MainForm.currentlyDownloading.Visible = true;

				//    MainForm.metroProgressSpinner1.BackColor = Color.Transparent;
				//   MainForm.sizeLeft.Visible = true;
				//    MainForm.metroProgressBar1.Visible = true;
				//  MainForm.metroProgressSpinner1.Visible = true;
				//  MainForm.pictureBox5.Visible = true;
				//    MainForm.pictureBox1.Visible = true;
				MainForm.statusLabel.Visible = true;
				// MainForm.ApplyImageInvert = false;
				//  MainForm.BackImage = h2mLauncher.Properties.Resources.backHD;
				//  MainForm.BackMaxSize = 1243;
			});
			// SteamHandler.InitializeSteam();
			// MainForm.BackImage = h2mLauncher.Properties.Resources.background;
		}

		private void pictureBox1_Click(object sender, EventArgs e)  //multiplayer
		{

			MainForm.Invoke((MethodInvoker)delegate
			{
				MainForm.webView21.Visible = false;
				MainForm.pictureBox3.Visible = true; //Refresh button
				MainForm.pictureBox2.Visible = true; //Refresh button
				MainForm.BackImage = null;
				MainForm.sizeLeft.Visible = false;
				MainForm.metroProgressBar1.Visible = false;
				//	MainForm.pictureBox5.Visible = false;
				MainForm.pictureBox1.Visible = false;
				MainForm.statusLabel.Visible = false;
				MainForm.listView1.Visible = false;
			});
			Serverbrowser.initializeBrowser();

			//try
			//{
			//   // MessageBox.Show(Filesystems.clientpath + @"\h1_mp64_ship.exe");
			//    var process = new System.Diagnostics.Process();
			//    process.StartInfo.FileName = Filesystems.clientpath + @"\h1_mp64_ship.exe";
			//    process.Start();
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//}
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
			try
			{
				var process = new System.Diagnostics.Process();
				process.StartInfo.FileName = Filesystems.clientpath + @"\h1_sp64_ship.exe";
				process.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void htmlPanel1_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox2_Click(object sender, EventArgs e)  //browser refresh button
		{
			pictureBox2.Enabled = false; //Refresh button
			listView1.Items.Clear();
			Serverbrowser.initializeBrowser();
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			try
			{
				var process = new System.Diagnostics.Process();
				process.StartInfo.FileName = Filesystems.clientpath + @"\h1_mp64_ship.exe";
				process.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}