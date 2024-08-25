using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace h2mLauncher
{
    internal class Serverbrowser
    {
        public static async void initializeBrowser()
        {
            int playercount = 0;
            int servercount = 0;
            Form1.MainForm.metroProgressSpinner1.Invoke((MethodInvoker)delegate { Form1.MainForm.metroProgressSpinner1.Visible = true; Form1.MainForm.metroProgressSpinner1.BringToFront(); });  //progess spinner
            using (WebClient client = new WebClient())
            {            
                try
                {           
                    string json = await client.DownloadStringTaskAsync(new Uri("https://master.iw4.zip/instance/"));                
                    JArray jsonArray = JArray.Parse(json);              
                    var filteredServers = jsonArray.SelectMany(obj => obj["servers"]
                                            .Where(server => server["game"]?.ToString().ToUpper() == "H2M"));
                    

                    foreach (var server in filteredServers)
                    {
                        ListViewItem item = new ListViewItem(server["hostname"].ToString());
                        //  ListViewItem item = new ListViewItem(CreateListViewItem(server["hostname"].ToString()));
                        item.Tag = $"{server["ip"].ToString()}:{server["port"].ToString()}";
                        item.SubItems.Add($"{server["clientnum"].ToString()} / {server["maxclientnum"].ToString()}");
                        item.SubItems.Add($"{server["map"].ToString()}");
                        item.SubItems.Add($"{server["gametype"].ToString()}");
                        item.SubItems.Add("");
                        Form1.MainForm.listView1.Items.Add(item);

                        servercount = servercount + 1;  
                        playercount = playercount + Convert.ToInt32(server["clientnum"].ToString());
                    }
                }
                catch (WebException ex)
                {
                    Console.WriteLine($"Error fetching json: {ex.Message}");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error reading json: {ex.Message}");
                }
            }


            Form1.MainForm.Text = Form1.MainForm.Text + $" | Total Players: {playercount} | Total Servers: {servercount}";
            Form1.MainForm.listView1.Activation = System.Windows.Forms.ItemActivation.Standard;
            Form1.MainForm.listView1.ItemActivate += ListView1_ItemActivate;
            Form1.MainForm.listView1.DrawItem += ListView_DrawItem;
            Form1.MainForm.listView1.DrawSubItem += ListView_DrawSubItem;
            Form1.MainForm.listView1.DrawColumnHeader += ListView_DrawColumnHeader;
            Form1.MainForm.metroProgressSpinner1.Invoke((MethodInvoker)delegate { Form1.MainForm.metroProgressSpinner1.Visible = false; });  //progess spinner deaktiviert


            Form1.MainForm.listView1.Visible = true;
            Form1.MainForm.Refresh();
        }

  
        private static void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private static void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // We don't draw the item here since we use DrawSubItem instead
        }

        private static void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 0) // Custom draw only for the first column (hostname)
            {
                // Prüfen, ob der Text Farbcodes enthält
                if (e.SubItem.Text.Contains('^'))
                {
                    // Zeichne den Text mit Farbcodes
                    DrawColoredText(e.Graphics, e.SubItem.Text, e.Bounds, e.Item.Font);
                }
                else
                {
                    // Zeichne den Text standardmäßig
                    e.DrawDefault = true;
                }
            }
            else
            {
                e.DrawDefault = true; // Default draw for other columns
            }
            //if (e.ColumnIndex == 0) // Only custom draw the first column
            //{
            //    DrawColoredText(e.Graphics, e.SubItem.Text, e.Bounds, e.Item.Font);
            //}
            //else
            //{
            //    e.DrawDefault = true; // Default draw for other columns
            //}

            //   DrawColoredText(e.Graphics, e.SubItem.Text, e.Bounds, e.Item.Font);

        }


        private static void DrawColoredText(Graphics graphics, string text, Rectangle bounds, Font font)
        {
            // Mapping of color codes to Brushes
            Dictionary<char, Brush> colorMap = new Dictionary<char, Brush>
        {
            {'0', Brushes.Black},
            {'1', Brushes.OrangeRed},
            {'2', Brushes.Lime},
            {'3', Brushes.Yellow},
            {'4', Brushes.Navy},
            {'5', Brushes.LightBlue},
            {'6', Brushes.Purple},
            {'7', Brushes.White},
            {'8', Brushes.Gray},
            {'9', Brushes.DarkGray}
        };

            float x = bounds.X;

            for (int i = 0; i < text.Length;)
            {
                if (text[i] == '^' && i + 1 < text.Length && colorMap.ContainsKey(text[i + 1]))
                {
                    Brush brush = colorMap[text[i + 1]];
                    i += 2; // Skip the color code

                    // Collect text to draw
                    string subText = "";
                    while (i < text.Length && text[i] != '^')
                    {
                        subText += text[i];
                        i++;
                    }

                    // Measure and draw the text
                    SizeF size = TextRenderer.MeasureText(subText, font);
                    graphics.DrawString(subText, font, brush, x, bounds.Y);
                    x += size.Width;
                }
                else
                {
                    i++;
                }
            }
        }

        private async static void ListView1_ItemActivate(object? sender, EventArgs e)
        {
            if (Form1.MainForm.listView1.SelectedItems.Count == 1)
            {
                var selectedServer = Form1.MainForm.listView1.SelectedItems[0].Tag.ToString();
                //MessageBox.Show(selectedServer);
                try
                {
                    // MessageBox.Show(Filesystems.clientpath + @"\h1_mp64_ship.exe");
                    var process = new System.Diagnostics.Process();
                    process.StartInfo.WorkingDirectory = Filesystems.clientpath;
                    process.StartInfo.FileName = Filesystems.clientpath + $@"\h2m-mod.exe";
                   // process.StartInfo.Arguments = $"+connect {selectedServer}";
                    process.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            else
            {
                MessageBox.Show("Error selecting a server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
