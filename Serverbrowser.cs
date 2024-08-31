using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Steamworks.ServerList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
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

            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(10); // Timeout auf 10 Sekunden setzen

                try
                {
                    string json = await client.GetStringAsync("https://master.iw4.zip/instance/");
                    JArray jsonArray = JArray.Parse(json);
                    var filteredServers = jsonArray.SelectMany(obj => obj["servers"]
                                                .Where(server => server["game"]?.ToString().ToUpper() == "H2M"));

                    foreach (var server in filteredServers)
                    {
                        ListViewItem item = new ListViewItem(server["hostname"].ToString());
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
                catch (TaskCanceledException ex)
                {
                    if (ex.CancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine("Operation cancelled.");
                    }
                    else
                    {
                        MessageBox.Show("Timeout occured during fetching the serverlist! Use the refresh button to try it again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error fetching json: {ex.Message}");
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    Console.WriteLine($"Error reading json: {ex.Message}");
                }
            }



     
            Form1.MainForm.refreshButton.Enabled = true; //Refresh button
            Form1.MainForm.playButton.Enabled = true; //play button

            Form1.MainForm.Text = $"Welcome {SteamHandler.username} | Total Players: {playercount} | Total Servers: {servercount}";
          //  Form1.MainForm.listView1.Activation = System.Windows.Forms.ItemActivation.Standard;
            Form1.MainForm.listView1.ItemActivate += ListView1_ItemActivate;
           // Form1.MainForm.listView1.ItemCheck += ListView1_ItemCheck;
            Form1.MainForm.listView1.DrawItem += ListView_DrawItem;
            Form1.MainForm.listView1.DrawSubItem += ListView_DrawSubItem;
            Form1.MainForm.listView1.DrawColumnHeader += ListView_DrawColumnHeader;
         //   Form1.MainForm.listView1.MouseClick += ListView1_MouseClick; ;


            Form1.MainForm.metroProgressSpinner1.Invoke((MethodInvoker)delegate { Form1.MainForm.metroProgressSpinner1.Visible = false; });  //progess spinner deaktiviert


            Form1.MainForm.listView1.Visible = true;
            Form1.MainForm.Refresh();
        }

        //private static void ListView1_MouseClick(object? sender, MouseEventArgs e)
        //{
        //    var hitTest = Form1.MainForm.listView1.HitTest(e.Location);

        //    // Überprüfen, ob auf den "Favorite"-Button geklickt wurde
        //    if (hitTest.Item != null && hitTest.SubItem != null && hitTest.Item.SubItems.IndexOf(hitTest.SubItem) == 4)
        //    {
        //        // Favoritenstatus umschalten
        //        var isFavorite = hitTest.Item.Tag as bool? == true;
        //        hitTest.Item.Tag = !isFavorite;

        //        // ListView neu zeichnen
        //        Form1.MainForm.listView1.Invalidate(hitTest.SubItem.Bounds);
        //    }
        //}

        private static void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private static void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // We don't draw the item here since we use DrawSubItem instead
        }

        private static HashSet<string> favorites = LoadFavoritesFromJson("favorites.json"); // Favoriten einmal laden und speichern

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
            else if (e.ColumnIndex == 4) // "Favorite"-Button zeichnen
            {
                // Definiere den Buttonbereich
                Rectangle buttonRect = e.Bounds;
                buttonRect.Inflate(0, 0);

                // Überprüfe den Favoritenstatus basierend auf der JSON-Datei
                var serverAddress = e.Item.Tag.ToString();
                var isFavorite = favorites.Contains(serverAddress); // Überprüfen, ob der Server in der Favoritenliste ist

                // Setze die Farbe des Sternsymbols je nach Favoritenstatus
                var starColor = isFavorite ? Brushes.Gold : Brushes.Gray;

                // Zeichne einen Sternsymbol als "Favorite"-Button
                e.Graphics.DrawString("★", new Font("Arial", 16), starColor, buttonRect);
            }
            else
            {
                e.DrawDefault = true; // Default draw for other columns
            }
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

        public async static void ListView1_ItemActivate(object? sender, EventArgs e)
        {
            // Sicherstellen, dass genau ein Item ausgewählt ist
            if (Form1.MainForm.listView1.SelectedItems.Count == 1)
            {
                var selectedItem = Form1.MainForm.listView1.SelectedItems[0];             
                var selectedTag = selectedItem.Tag.ToString();           
                var clickedPoint = Form1.MainForm.listView1.PointToClient(Control.MousePosition);
                var hitTest = Form1.MainForm.listView1.HitTest(clickedPoint);

                if (hitTest.Item != null && hitTest.SubItem != null && hitTest.Item.SubItems.IndexOf(hitTest.SubItem) == 4)
                {                 
                  //  var isFavorite = selectedItem.Tag as bool? == true;
                    // selectedItem.Tag = !isFavorite;
                    ToggleFavoriteStatus(selectedTag);
                    Form1.MainForm.listView1.Invalidate(selectedItem.Bounds);
                    return; // Die Funktion hier beenden, da wir den Favoriten-Button verarbeitet haben
                }

                // Wenn nicht der "Favorite"-Button geklickt wurde, führe die ursprüngliche Logik aus
                Clipboard.SetText($"connect {selectedTag}");
                MessageBox.Show($"connect {selectedTag}\n\nLaunch the game, open the console in the main menu, and paste the copied text to join the server!",
                                "Server copied to clipboard!",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error selecting a server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Favoritenstatus umschalten und in JSON-Datei speichern
        private static void ToggleFavoriteStatus(string serverAddress)
        {
            if (favorites.Contains(serverAddress))
            {
                favorites.Remove(serverAddress); // Entferne den Server aus den Favoriten
            }
            else
            {
                favorites.Add(serverAddress); // Füge den Server zu den Favoriten hinzu
            }

            UpdateFavoritesJson("favorites.json", favorites);
        }

        // Favoriten aus der JSON-Datei laden
        private static HashSet<string> LoadFavoritesFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new HashSet<string>();
            }

            string json = File.ReadAllText(filePath);
            return System.Text.Json.JsonSerializer.Deserialize<HashSet<string>>(json) ?? new HashSet<string>();
        }

        // Favoritenstatus in JSON-Datei aktualisieren
        private static void UpdateFavoritesJson(string filePath, HashSet<string> favorites)
        {
            string updatedJson = System.Text.Json.JsonSerializer.Serialize(favorites, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, updatedJson);
        }

        // Update-Methode für die Favoritenliste
        public static void UpdateFavorites()
        {
            favorites = LoadFavoritesFromJson("favorites.json");
        }


        //public async static void ListView1_ItemActivate(object? sender, EventArgs e)
        //{


        //    if (Form1.MainForm.listView1.SelectedItems.Count == 1)
        //    {
        //       // var servername = Form1.MainForm.listView1.SelectedItems[0].ToString();
        //        var selectedServer = Form1.MainForm.listView1.SelectedItems[0].Tag.ToString();
        //        Clipboard.SetText($"connect {selectedServer}");
        //        MessageBox.Show($"connect {selectedServer}\n\nLaunch the game open the console in main menu and paste the copied text to join the server!", "Server copied to clipboard!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //      //  return;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Error selecting a server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //}
    }
}
