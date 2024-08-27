using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h2mLauncher
{
    internal class CreateIntro
    {
        public static PictureBox introBox;
        public static PictureBox InitializeIntro()
        {
            introBox = new PictureBox();
            introBox.Size = new Size(1243, 721);
            introBox.Location = new Point(0, 0);
            introBox.SizeMode = PictureBoxSizeMode.StretchImage;
            introBox.Image = h2mLauncher.Properties.Resources.intro_ezgif_com_video_to_gif_converter;
            return introBox;
        }
    }
}
