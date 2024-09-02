using h2mLauncher.Properties;
using MetroFramework.Drawing.Html;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;

namespace h2mLauncher
{
	public partial class Form1 : MetroFramework.Forms.MetroForm
	{
        public static System.Timers.Timer IntroTimer = new System.Timers.Timer(4000);
        public static Form1 MainForm;
        public Form1()
		{
			InitializeComponent();
            this.multiplayer.MouseEnter += PictureBox1_MouseEnter;
            this.multiplayer.MouseLeave += PictureBox1_MouseLeave;

 

            this.ApplyImageInvert = false;
			this.BackImage = h2mLauncher.Properties.Resources.backHD;
			this.BackMaxSize = 1243;




		}

     
        private void Form1_Load_1(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                string sv = wc.DownloadString("http://www.gaming-coding.de:9660/updater/version.json");
                JObject json = JObject.Parse(sv);
                if (Settings.Default.version != json["version"].ToString())
                {
                    MessageBox.Show($"New H2M Launcher update v{json["version"].ToString()} required", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    string exeDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    Application.Exit();
                    Process.Start(exeDirectory + @"\UpdaterSystem.exe");
                    return;
                }
            }


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
   


        private void PictureBox1_MouseLeave(object? sender, EventArgs e)
        {
            multiplayer.Size = new Size(multiplayer.Width - 8, multiplayer.Height - 8);
            multiplayer.Refresh();
        }


        private void PictureBox1_MouseEnter(object? sender, EventArgs e)
        {
            multiplayer.Size = new Size(multiplayer.Width + 8, multiplayer.Height + 8);
            multiplayer.Refresh();
        }


        public static void unlockControls()
        {
            MainForm.Invoke((MethodInvoker)delegate
            {          
                MainForm.statusLabel.Visible = true;         
            });        
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
    

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            MainForm.Invoke((MethodInvoker)delegate
            {
                //	MainForm.webView21.Visible = false;
                MainForm.playButton.Visible = true; //Refresh
             //   MainForm.settingsButton.Visible = true; //Refresh button
                MainForm.refreshButton.Visible = true; //Refresh button
                MainForm.BackImage = null;
                MainForm.sizeLeft.Visible = false;
                MainForm.metroProgressBar1.Visible = false;
                //	MainForm.pictureBox5.Visible = false;
                MainForm.multiplayer.Visible = false;
                MainForm.statusLabel.Visible = false;
                MainForm.listView1.Visible = false;
            });
            Serverbrowser.initializeBrowser();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            try
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo.WorkingDirectory = Filesystems.clientpath;
                process.StartInfo.FileName = Filesystems.clientpath + @"\h2m-mod.exe";
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Serverbrowser.UpdateFavorites();
            refreshButton.Enabled = false; //Refresh button
            listView1.ItemActivate -= new EventHandler(Serverbrowser.ListView1_ItemActivate);
            listView1.Items.Clear();
            Serverbrowser.initializeBrowser();
        }

        public static void setControlState(bool state)
        {           
            Form1.MainForm.listView1.Enabled = state;             
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SettingsTab.drawSettings();
            setControlState(false);
        }
    }
}