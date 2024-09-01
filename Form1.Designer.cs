namespace h2mLauncher
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusLabel = new MetroFramework.Controls.MetroLabel();
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.currentlyDownloading = new MetroFramework.Controls.MetroLabel();
            this.sizeLeft = new MetroFramework.Controls.MetroLabel();
            this.multiplayer = new System.Windows.Forms.PictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.refreshButton = new System.Windows.Forms.PictureBox();
            this.playButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.multiplayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playButton)).BeginInit();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.statusLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(559, 543);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(108, 25);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "statusLabel";
            this.statusLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.statusLabel.UseCustomBackColor = true;
            this.statusLabel.UseCustomForeColor = true;
            this.statusLabel.Visible = false;
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.metroProgressBar1.HideProgressText = false;
            this.metroProgressBar1.Location = new System.Drawing.Point(23, 675);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(1197, 23);
            this.metroProgressBar1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroProgressBar1.TabIndex = 1;
            this.metroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroProgressBar1.UseCustomBackColor = true;
            this.metroProgressBar1.Visible = false;
            // 
            // currentlyDownloading
            // 
            this.currentlyDownloading.AutoSize = true;
            this.currentlyDownloading.BackColor = System.Drawing.Color.Transparent;
            this.currentlyDownloading.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentlyDownloading.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.currentlyDownloading.ForeColor = System.Drawing.Color.White;
            this.currentlyDownloading.Location = new System.Drawing.Point(23, 636);
            this.currentlyDownloading.Name = "currentlyDownloading";
            this.currentlyDownloading.Size = new System.Drawing.Size(122, 19);
            this.currentlyDownloading.TabIndex = 3;
            this.currentlyDownloading.Text = "Downloading: ....";
            this.currentlyDownloading.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.currentlyDownloading.UseCustomBackColor = true;
            this.currentlyDownloading.UseCustomForeColor = true;
            this.currentlyDownloading.Visible = false;
            // 
            // sizeLeft
            // 
            this.sizeLeft.AutoSize = true;
            this.sizeLeft.BackColor = System.Drawing.Color.Transparent;
            this.sizeLeft.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.sizeLeft.ForeColor = System.Drawing.Color.White;
            this.sizeLeft.Location = new System.Drawing.Point(1139, 636);
            this.sizeLeft.Name = "sizeLeft";
            this.sizeLeft.Size = new System.Drawing.Size(57, 19);
            this.sizeLeft.TabIndex = 4;
            this.sizeLeft.Text = "0/0 MB";
            this.sizeLeft.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.sizeLeft.UseCustomBackColor = true;
            this.sizeLeft.UseCustomForeColor = true;
            this.sizeLeft.Visible = false;
            // 
            // multiplayer
            // 
            this.multiplayer.BackColor = System.Drawing.Color.Transparent;
            this.multiplayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.multiplayer.Image = global::h2mLauncher.Properties.Resources.mp1;
            this.multiplayer.Location = new System.Drawing.Point(295, 124);
            this.multiplayer.Name = "multiplayer";
            this.multiplayer.Size = new System.Drawing.Size(650, 418);
            this.multiplayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.multiplayer.TabIndex = 15;
            this.multiplayer.TabStop = false;
            this.multiplayer.Visible = false;
            this.multiplayer.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(2, 52);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(1238, 646);
            this.listView1.TabIndex = 16;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Hostname";
            this.columnHeader1.Width = 630;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Players";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Map";
            this.columnHeader3.Width = 250;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mode";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 50;
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(473, 215);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(300, 300);
            this.metroProgressSpinner1.Speed = 1.5F;
            this.metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroProgressSpinner1.TabIndex = 17;
            this.metroProgressSpinner1.Text = "metroProgressSpinner1";
            this.metroProgressSpinner1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroProgressSpinner1.UseSelectable = true;
            this.metroProgressSpinner1.Visible = false;
            // 
            // refreshButton
            // 
            this.refreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshButton.Enabled = false;
            this.refreshButton.Image = global::h2mLauncher.Properties.Resources.Reset;
            this.refreshButton.Location = new System.Drawing.Point(1139, 16);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(30, 30);
            this.refreshButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.refreshButton.TabIndex = 18;
            this.refreshButton.TabStop = false;
            this.refreshButton.Visible = false;
            this.refreshButton.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // playButton
            // 
            this.playButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playButton.Enabled = false;
            this.playButton.Image = global::h2mLauncher.Properties.Resources.play;
            this.playButton.Location = new System.Drawing.Point(1103, 16);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(30, 30);
            this.playButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playButton.TabIndex = 20;
            this.playButton.TabStop = false;
            this.playButton.Visible = false;
            this.playButton.Click += new System.EventHandler(this.pictureBox3_Click_1);
            // 
            // Form1
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackMaxSize = 1243;
            this.ClientSize = new System.Drawing.Size(1242, 699);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.multiplayer);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.metroProgressSpinner1);
            this.Controls.Add(this.sizeLeft);
            this.Controls.Add(this.currentlyDownloading);
            this.Controls.Add(this.metroProgressBar1);
            this.Controls.Add(this.statusLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "H2M Launcher";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.multiplayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		public MetroFramework.Controls.MetroLabel statusLabel;
		public MetroFramework.Controls.MetroProgressBar metroProgressBar1;
		public MetroFramework.Controls.MetroLabel currentlyDownloading;
		public MetroFramework.Controls.MetroLabel sizeLeft;
		public PictureBox multiplayer;
		public ListView listView1;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private ColumnHeader columnHeader4;
		private ColumnHeader columnHeader5;
		public MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
		public PictureBox refreshButton;
		public PictureBox playButton;
	}
}