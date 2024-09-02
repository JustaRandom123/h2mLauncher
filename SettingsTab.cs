using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace h2mLauncher
{
    internal class SettingsTab
    {

        private static Panel slidingPanel;
        private static System.Windows.Forms.Timer animationTimer;
        private static MetroButton closeButton;
        private static bool isPanelOpen = false; // Flag für Öffnen oder Schließen des Panels

        public static void drawSettings()
        {
            // Panel erstellen
            slidingPanel = new Panel();
            slidingPanel.Size = new Size(300, Form1.MainForm.Height);
            slidingPanel.BackColor = Color.FromArgb(30, 30, 30); // Dunkler Hintergrund
            slidingPanel.Location = new Point(Form1.MainForm.Width, 0); // Startposition: rechts außerhalb der Form
            slidingPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;


            // Schließen-Button (MetroButton) erstellen
            closeButton = new MetroButton();
            closeButton.Text = "X"; // Text des Buttons
            closeButton.Size = new Size(35, 35);
            closeButton.Location = new Point(5, 5); // Position oben links im Panel
            closeButton.Theme = MetroFramework.MetroThemeStyle.Dark; // Dark Theme für den Button
            closeButton.Click += new EventHandler(CloseButton_Click);

            // Schließen-Button zum Panel hinzufügen
            slidingPanel.Controls.Add(closeButton);

            // Panel zur Form hinzufügen
            Form1.MainForm.Controls.Add(slidingPanel);

            slidingPanel.BringToFront();


            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 15; // Animation-Geschwindigkeit (10 ms)
            animationTimer.Tick += new EventHandler(AnimationTimer_Tick);
            animationTimer.Start();
        }

        private static void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (!isPanelOpen)
            {
                if (slidingPanel.Right > Form1.MainForm.Width)
                {
                    slidingPanel.Left -= 10; // Geschwindigkeit der Animation (10px pro Tick)
                }
                else
                {
                    // Stoppt den Timer, wenn das Panel die gewünschte Position erreicht hat
                    animationTimer.Stop();
                }
            }
            else
            {
                if (slidingPanel.Left < Form1.MainForm.Width)
                {
                    slidingPanel.Left += 10; // Geschwindigkeit der Animation (10px pro Tick)
                }
                else
                {
                    // Stoppt den Timer, wenn das Panel die gewünschte Position erreicht hat
                    animationTimer.Stop();
                    Form1.MainForm.Controls.Remove(slidingPanel);
                    Form1.setControlState(true);
                    isPanelOpen = false;
                }
            }
        }


        private static void CloseButton_Click(object sender, EventArgs e)
        {
            isPanelOpen = true;
            animationTimer.Start();
        }
    }
}
