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
                        item.Tag = $"{server["ip"].ToString()}:{server["port"].ToString()}";
                        item.SubItems.Add($"{server["clientnum"].ToString()} / {server["maxclientnum"].ToString()}");
                        item.SubItems.Add($"{server["map"].ToString()}");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        Form1.MainForm.listView1.Items.Add(item);                      
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
        


            Form1.MainForm.listView1.Activation = System.Windows.Forms.ItemActivation.Standard;
            Form1.MainForm.listView1.ItemActivate += ListView1_ItemActivate;
            Form1.MainForm.metroProgressSpinner1.Invoke((MethodInvoker)delegate { Form1.MainForm.metroProgressSpinner1.Visible = false; });  //progess spinner deaktiviert

            //mf.listView1.Invoke((MethodInvoker)delegate { mf.listView1.Enabled = false; });  
        }

        private async static void ListView1_ItemActivate(object? sender, EventArgs e)
        {
            if (Form1.MainForm.listView1.SelectedItems.Count == 1)
            {
                var selectedServer = Form1.MainForm.listView1.SelectedItems[0].Tag.ToString();
                MessageBox.Show(selectedServer);
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
