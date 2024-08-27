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
			statusLabel = new MetroFramework.Controls.MetroLabel();
			metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
			currentlyDownloading = new MetroFramework.Controls.MetroLabel();
			sizeLeft = new MetroFramework.Controls.MetroLabel();
			pictureBox1 = new PictureBox();
			listView1 = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			columnHeader3 = new ColumnHeader();
			columnHeader4 = new ColumnHeader();
			columnHeader5 = new ColumnHeader();
			metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
			pictureBox2 = new PictureBox();
			pictureBox3 = new PictureBox();
			webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
			SuspendLayout();
			// 
			// statusLabel
			// 
			statusLabel.AutoSize = true;
			statusLabel.BackColor = Color.Transparent;
			statusLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
			statusLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			statusLabel.ForeColor = Color.White;
			statusLabel.Location = new Point(559, 527);
			statusLabel.Name = "statusLabel";
			statusLabel.Size = new Size(108, 25);
			statusLabel.TabIndex = 0;
			statusLabel.Text = "statusLabel";
			statusLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
			statusLabel.UseCustomBackColor = true;
			statusLabel.UseCustomForeColor = true;
			statusLabel.Visible = false;
			// 
			// metroProgressBar1
			// 
			metroProgressBar1.BackColor = Color.Transparent;
			metroProgressBar1.HideProgressText = false;
			metroProgressBar1.Location = new Point(23, 675);
			metroProgressBar1.Name = "metroProgressBar1";
			metroProgressBar1.Size = new Size(1197, 23);
			metroProgressBar1.Style = MetroFramework.MetroColorStyle.Green;
			metroProgressBar1.TabIndex = 1;
			metroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
			metroProgressBar1.UseCustomBackColor = true;
			metroProgressBar1.Visible = false;
			// 
			// currentlyDownloading
			// 
			currentlyDownloading.AutoSize = true;
			currentlyDownloading.BackColor = Color.Transparent;
			currentlyDownloading.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			currentlyDownloading.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			currentlyDownloading.ForeColor = Color.White;
			currentlyDownloading.Location = new Point(23, 636);
			currentlyDownloading.Name = "currentlyDownloading";
			currentlyDownloading.Size = new Size(122, 19);
			currentlyDownloading.TabIndex = 3;
			currentlyDownloading.Text = "Downloading: ....";
			currentlyDownloading.Theme = MetroFramework.MetroThemeStyle.Dark;
			currentlyDownloading.UseCustomBackColor = true;
			currentlyDownloading.UseCustomForeColor = true;
			currentlyDownloading.Visible = false;
			// 
			// sizeLeft
			// 
			sizeLeft.AutoSize = true;
			sizeLeft.BackColor = Color.Transparent;
			sizeLeft.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			sizeLeft.ForeColor = Color.White;
			sizeLeft.Location = new Point(1139, 636);
			sizeLeft.Name = "sizeLeft";
			sizeLeft.Size = new Size(57, 19);
			sizeLeft.TabIndex = 4;
			sizeLeft.Text = "0/0 MB";
			sizeLeft.Theme = MetroFramework.MetroThemeStyle.Dark;
			sizeLeft.UseCustomBackColor = true;
			sizeLeft.UseCustomForeColor = true;
			sizeLeft.Visible = false;
			// 
			// pictureBox1
			// 
			pictureBox1.BackColor = Color.Transparent;
			pictureBox1.Cursor = Cursors.Hand;
			pictureBox1.Image = Properties.Resources.mp;
			pictureBox1.Location = new Point(473, 112);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(320, 440);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 15;
			pictureBox1.TabStop = false;
			pictureBox1.Visible = false;
			pictureBox1.Click += pictureBox1_Click;
			// 
			// listView1
			// 
			listView1.BackColor = Color.FromArgb(17, 17, 17);
			listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
			listView1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
			listView1.ForeColor = Color.White;
			listView1.FullRowSelect = true;
			listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			listView1.Location = new Point(2, 52);
			listView1.MultiSelect = false;
			listView1.Name = "listView1";
			listView1.OwnerDraw = true;
			listView1.Size = new Size(1238, 646);
			listView1.TabIndex = 16;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = View.Details;
			listView1.Visible = false;
			listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Servername";
			columnHeader1.Width = 630;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Players";
			columnHeader2.Width = 150;
			// 
			// columnHeader3
			// 
			columnHeader3.Text = "Map";
			columnHeader3.Width = 250;
			// 
			// columnHeader4
			// 
			columnHeader4.Text = "Gametype";
			columnHeader4.Width = 150;
			// 
			// columnHeader5
			// 
			columnHeader5.Text = "";
			columnHeader5.Width = 25;
			// 
			// metroProgressSpinner1
			// 
			metroProgressSpinner1.Location = new Point(473, 215);
			metroProgressSpinner1.Maximum = 100;
			metroProgressSpinner1.Name = "metroProgressSpinner1";
			metroProgressSpinner1.Size = new Size(300, 300);
			metroProgressSpinner1.Speed = 1.5F;
			metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Blue;
			metroProgressSpinner1.TabIndex = 17;
			metroProgressSpinner1.Text = "metroProgressSpinner1";
			metroProgressSpinner1.Theme = MetroFramework.MetroThemeStyle.Dark;
			metroProgressSpinner1.UseSelectable = true;
			metroProgressSpinner1.Visible = false;
			// 
			// pictureBox2
			// 
			pictureBox2.Cursor = Cursors.Hand;
			pictureBox2.Enabled = false;
			pictureBox2.Image = Properties.Resources.Reset;
			pictureBox2.Location = new Point(1139, 16);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(30, 30);
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 18;
			pictureBox2.TabStop = false;
			pictureBox2.Visible = false;
			pictureBox2.Click += pictureBox2_Click;
			// 
			// pictureBox3
			// 
			pictureBox3.Cursor = Cursors.Hand;
			pictureBox3.Enabled = false;
			pictureBox3.Image = Properties.Resources.play;
			pictureBox3.Location = new Point(1103, 16);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new Size(30, 30);
			pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox3.TabIndex = 20;
			pictureBox3.TabStop = false;
			pictureBox3.Visible = false;
			pictureBox3.Click += pictureBox3_Click;
			// 
			// webView21
			// 
			webView21.AllowExternalDrop = true;
			webView21.CreationProperties = null;
			webView21.DefaultBackgroundColor = Color.White;
			webView21.Location = new Point(867, 112);
			webView21.Name = "webView21";
			webView21.Size = new Size(320, 440);
			webView21.Source = new Uri("http://134.255.232.105/ad.html", UriKind.Absolute);
			webView21.TabIndex = 21;
			webView21.Visible = false;
			webView21.ZoomFactor = 1D;
			// 
			// Form1
			// 
			ApplyImageInvert = true;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackgroundImageLayout = ImageLayout.Stretch;
			BackMaxSize = 1243;
			ClientSize = new Size(1242, 699);
			Controls.Add(pictureBox3);
			Controls.Add(pictureBox2);
			Controls.Add(metroProgressSpinner1);
			Controls.Add(listView1);
			Controls.Add(pictureBox1);
			Controls.Add(sizeLeft);
			Controls.Add(currentlyDownloading);
			Controls.Add(metroProgressBar1);
			Controls.Add(statusLabel);
			Controls.Add(webView21);
			MaximizeBox = false;
			Name = "Form1";
			Resizable = false;
			Style = MetroFramework.MetroColorStyle.Green;
			Text = "H2M Launcher";
			Theme = MetroFramework.MetroThemeStyle.Dark;
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)webView21).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public MetroFramework.Controls.MetroLabel statusLabel;
		public MetroFramework.Controls.MetroProgressBar metroProgressBar1;
		public MetroFramework.Controls.MetroLabel currentlyDownloading;
		public MetroFramework.Controls.MetroLabel sizeLeft;
		public PictureBox pictureBox1;
		public ListView listView1;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private ColumnHeader columnHeader4;
		private ColumnHeader columnHeader5;
		public MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
		public PictureBox pictureBox2;
		public PictureBox pictureBox3;
		public Microsoft.Web.WebView2.WinForms.WebView2 webView21;
	}
}