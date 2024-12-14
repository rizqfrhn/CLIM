using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Net;
using System.Text.RegularExpressions;
using System.Buffers.Text;

namespace CLIM
{
    public partial class FormLoader : Form
    {

        private SQLiteConnection conn;
        private DataTable dt;
        int datacount;

        public FormLoader()
        {
            InitializeComponent();
            conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Key"].ConnectionString);
            cbloader.Items.Clear();
            cbloader.DataSource = null;
            LoadCBLoader();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnping_Click(object sender, EventArgs e)
        {
            Process p = new Process();

            if (tbdatabsm.Text == "" && tbdatarsm.Text == ""
                && tbdataoru.Text == "" && tbdatarouter.Text == "")
            {
                //do nothing
            }
            else
            {
                string cmdbsm = @"/K ping -t " + tbdatabsm.Text;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = cmdbsm;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = false;
                p.Start();
                string cmdrsm = @"/K ping -t " + tbdatarsm.Text;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = cmdrsm;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = false;
                p.Start();
                string cmdoru = @"/K ping -t " + tbdataoru.Text;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = cmdoru;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = false;
                p.Start();
                string cmdrouter = @"/K ping -t " + tbdatarouter.Text;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = cmdrouter;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = false;
                p.Start();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (cbloader.Text == "Select Loader")
            {
                MessageBox.Show("Select the Loader First!");
            }
            else
            {
                if (datacount == 0)
                {
                    //using (SqlCommand cmd = new SqlCommand("dbo.SP_InsertIP", con))
                    using (SQLiteCommand cmd = new SQLiteCommand("insert into tb_list (id_list, no_lhd, bsm, rsm, oru, router) values (ifnull((select max(id_list) from tb_list) + 1,1), @no_lhd, @bsm, @rsm, @oru, @router)", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@no_lhd", cbloader.Text);
                        cmd.Parameters.AddWithValue("@bsm", tbinputbsm.Text);
                        cmd.Parameters.AddWithValue("@rsm", tbinputrsm.Text);
                        cmd.Parameters.AddWithValue("@oru", tbinputoru.Text);
                        cmd.Parameters.AddWithValue("@router", tbinputrouter.Text);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data inserted successfully");
                }
                else
                {
                    //using (SqlCommand cmd = new SqlCommand("dbo.SP_UpdateIP", con))
                    using (SQLiteCommand cmd = new SQLiteCommand("update tb_list set bsm = @bsm, rsm = @rsm, oru = @oru, router = @router where no_lhd = @no_lhd", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@no_lhd", cbloader.Text);
                        cmd.Parameters.AddWithValue("@bsm", tbinputbsm.Text == "" ? tbdatabsm.Text : tbinputbsm.Text);
                        cmd.Parameters.AddWithValue("@rsm", tbinputrsm.Text == "" ? tbdatarsm.Text : tbinputrsm.Text);
                        cmd.Parameters.AddWithValue("@oru", tbinputoru.Text == "" ? tbdataoru.Text : tbinputoru.Text);
                        cmd.Parameters.AddWithValue("@router", tbinputrouter.Text == "" ? tbdatarouter.Text : tbinputrouter.Text);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data Updated successfully");
                }
            }

            conn.Close();

            LoadAllRecords();

        }

        public void LoadCBLoader()
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Key"].ConnectionString))
            {
                conn.Open();
                try
                {
                    SQLiteDataAdapter da = new SQLiteDataAdapter("select id_lhd, no_lhd from tb_lhd order by no_lhd", conn);
                    dt = new DataTable();
                    dt.Clear();
                    da.Fill(dt);

                    DataRow select = dt.NewRow();
                    select[1] = "Select Loader";
                    dt.Rows.InsertAt(select, 0);

                    cbloader.DisplayMember = "no_lhd";
                    cbloader.ValueMember = "no_lhd";
                    cbloader.DataSource = dt;

                    cbloader.Refresh();
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
                conn.Close();
            }
        }

        void LoadAllRecords()
        {
            conn.Open();

            //using (SqlCommand cmd = new SqlCommand("dbo.SP_ListIPView", con))
            using (SQLiteCommand cmd = new SQLiteCommand("select* from tb_list where no_lhd = @no_lhd", conn))
            {
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@no_lhd", cbloader.Text);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                datacount = dataTable.Rows.Count;
                if (dataTable.Rows.Count != 0)
                {
                    tbdatabsm.Text = dataTable.Rows[0].Field<string>("bsm");
                    tbdatarsm.Text = dataTable.Rows[0].Field<string>("rsm");
                    tbdataoru.Text = dataTable.Rows[0].Field<string>("oru");
                    tbdatarouter.Text = dataTable.Rows[0].Field<string>("router");
                }
                else
                {
                    tbdatabsm.Text = "";
                    tbdatarsm.Text = "";
                    tbdataoru.Text = "";
                    tbdatarouter.Text = "";
                    tbinputbsm.Text = "";
                    tbinputrsm.Text = "";
                    tbinputoru.Text = "";
                    tbinputrouter.Text = "";
                }
            }

            conn.Close();
        }

        private void cbloader_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllRecords();
        }

        private void cbloader_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void addLoaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLoader addloader = new AddLoader(this);
            addloader.Show();
        }

        private void scanIPLoaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Start the scan in a background task
            Task.Run(() => StartScanAsyncORU());

            // Notify user that scan has started
            MessageBox.Show("Scan started in the background.");
        }

        private async Task StartScanAsyncORU()
        {
            // Scan the IP range from 10.10.10.0 to 10.10.10.225
            string baseIP = "10.10.10.";

            for (int i = 10; i < 256; i++)
            {
                string loaderip = baseIP + i;

                // Check if the IP is reachable
                if (IsORUReachable(loaderip))
                {
                    // Get the MAC address for the reachable IP
                    string macORU = GetMacAddress(loaderip);
                    Console.WriteLine($"{macORU}");
                    if (!string.IsNullOrEmpty(macORU))
                    {
                        string[] parts = loaderip.Split('.');

                        // Get the last octet
                        string lastOctet = parts[3];

                        // Check if the last octet has two digits (between 10 and 99)
                        if (lastOctet.Length == 2)
                        {
                            // Add "6" in front of the last octet
                            lastOctet = "6" + lastOctet;
                        }
                        else if (lastOctet.Length == 3 && Convert.ToInt32(lastOctet) > 150)
                        {
                            // Get the last part and replace the first digit with '8'
                            lastOctet = "8" + lastOctet.Substring(1);
                        }
                        else
                        {
                            lastOctet = "8" + lastOctet;
                        }

                        // Update the last octet in the parts array
                        string nolhd = lastOctet;
                        
                        InsertIpORU(loaderip, nolhd, macORU);
                        Console.WriteLine($"Inserted IP: {loaderip}, MAC Address: {macORU}");
                        Invoke((Action)(() =>
                        {
                            LoadCBLoader();
                        }));
                    }
                    else
                    {
                        Console.WriteLine($"MAC address for {loaderip} could not be retrieved.");
                    }
                }
                else
                {
                    Console.WriteLine($"IP {loaderip} is not reachable.");
                }
            }

            // Notify user that scan is completed
            Invoke((Action)(() =>
            {
                MessageBox.Show("Scan IP Loader Completed.");
                LoadCBLoader();
            }));
        }

        // Get the MAC address of the IP address using ARP
        private static string GetMacAddress(string ipAddress)
        {
            try
            {
                // Run the ARP command to retrieve the MAC address for the given IP
                Process process = new Process();
                process.StartInfo.FileName = "arp";
                process.StartInfo.Arguments = "-a " + ipAddress;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                Console.WriteLine($"{output}");
                // Use regex to extract the MAC address from the ARP output
                Regex macRegex = new Regex(@"(?:[0-9a-fA-F]{2}-){5}[0-9a-fA-F]{2}");
                Match match = macRegex.Match(output);
                return match.Value;
            }
            catch (Exception)
            {
                return string.Empty; // If there's an error, return an empty string
            }
        }

        // Check if IP exists in the database
        private static bool IsORUInDatabase(string ip)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Key"].ConnectionString))
            {
                conn.Open();
                string checkIpQuery = "SELECT COUNT(*) FROM tb_list WHERE oru = @oru;";
                SQLiteCommand command = new SQLiteCommand(checkIpQuery, conn);
                command.Parameters.AddWithValue("@oru", ip);
                long count = (long)command.ExecuteScalar();
                return count > 0;
            }
        }

        // Check if Loader exists in the database
        private static bool IsLHDInDatabase(string nolhd)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Key"].ConnectionString))
            {
                conn.Open();
                string checkIpQuery = "SELECT COUNT(*) FROM tb_lhd WHERE no_lhd = @nolhd;";
                SQLiteCommand command = new SQLiteCommand(checkIpQuery, conn);
                command.Parameters.AddWithValue("@nolhd", nolhd);
                long count = (long)command.ExecuteScalar();
                return count > 0;
            }
        }

        // Check if there's Loader in the database
        private static bool LoaderAvailable()
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Key"].ConnectionString))
            {
                conn.Open();
                string checkIpQuery = "SELECT COUNT(*) FROM tb_lhd";
                SQLiteCommand command = new SQLiteCommand(checkIpQuery, conn);
                long count = (long)command.ExecuteScalar();
                return count > 0;
            }
        }

        // Insert the IP into the database if it does not exist
        private static void InsertIpORU(string ip, string nolhd, string macORU)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Key"].ConnectionString))
            {
                conn.Open();
                
                // Split the IP address into parts using dot as delimiter
                string[] parts = ip.Split('.');

                // Convert the second-to-last octet (the second part) to an integer and subtract 1
                int thirdOctet = int.Parse(parts[2]);
                thirdOctet = Math.Max(0, thirdOctet + 40); // Ensure it doesn't go below 0

                // Update the second octet in the parts array
                parts[2] = thirdOctet.ToString();

                // Reassemble the IP address with the modified second octet
                string router = string.Join('.', parts);

                // If the IP is reachable, check if it's in the database
                if (!IsORUInDatabase(ip))
                {
                    string insertIpQuery = "INSERT INTO tb_list (id_list, oru, no_lhd, mac, router) VALUES (ifnull((select max(id_list) from tb_list) + 1,1), @oru, @nolhd, @macORU, @router);";
                    SQLiteCommand command = new SQLiteCommand(insertIpQuery, conn);
                    command.Parameters.AddWithValue("@oru", ip);
                    command.Parameters.AddWithValue("@nolhd", nolhd);
                    command.Parameters.AddWithValue("@macORU", macORU);
                    command.Parameters.AddWithValue("@router", router);
                    command.ExecuteNonQuery();
                }
                else
                {
                    string insertIpQuery = "UPDATE tb_list SET mac = @macORU where no_lhd = @nolhd;";
                    SQLiteCommand command = new SQLiteCommand(insertIpQuery, conn);
                    command.Parameters.AddWithValue("@nolhd", nolhd);
                    command.Parameters.AddWithValue("@macORU", macORU);
                    command.ExecuteNonQuery();
                }
                if (!IsLHDInDatabase(nolhd)) {
                    string insertLHDQuery = "insert into tb_lhd (id_lhd, no_lhd) values (ifnull((select max(id_lhd) from tb_lhd) + 1,1), @nolhd);";
                    SQLiteCommand commandLHD = new SQLiteCommand(insertLHDQuery, conn);
                    commandLHD.Parameters.AddWithValue("@nolhd", nolhd);
                    commandLHD.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine($"Loader already exist: {nolhd}");
                }
            }
        }

        // Ping the IP address to check if it is reachable
        private static bool IsORUReachable(string ip)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send(ip, 1); // Timeout of 1000 ms (1 second)
                    return reply.Status == IPStatus.Success;
                }
            }
            catch (PingException)
            {
                return false; // If there is a PingException, we consider the IP unreachable
            }
        }

        private void scanningIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!LoaderAvailable())
            {
                MessageBox.Show("No Loader Recorded, Need to Scan Loader First!");
            }
            else
            {
                // Start the scan in a background task
                Task.Run(() => StartScanAsyncRSMBSM22());
                Task.Run(() => StartScanAsyncRSMBSM24());
                Task.Run(() => StartScanAsyncRSMBSM26());

                // Notify user that scan has started
                MessageBox.Show("Scan started in the background.");
            }
        }

        private async Task StartScanAsyncRSMBSM22()
        {
            // Scan the IP range from 10.10.22.0 to 10.10.22.225
            string baseIP = "10.10.22.";

            for (int i = 0; i <= 255; i++)
            {
                string ipAddress = baseIP + i;

                // Check if the IP is reachable
                if (IsRSMReachable(ipAddress))
                {
                    
                    string macAddress = GetMacAddress(ipAddress);
                    InsertIpMacAddressRSM(ipAddress, macAddress);
                }
                else
                {
                    Console.WriteLine($"IP {ipAddress} is not reachable.");
                }
            }
            // Notify user that scan is completed
            Invoke((Action)(() =>
            {
            }));
        }
            
        private async Task StartScanAsyncRSMBSM24()
        {
            // Scan the IP range from 10.10.24.0 to 10.10.24.225
            string baseIP = "10.10.24.";

            for (int i = 0; i <= 255; i++)
            {
                string ipAddress = baseIP + i;

                // Check if the IP is reachable
                if (IsRSMReachable(ipAddress))
                {
                    
                    string macAddress = GetMacAddress(ipAddress);
                    InsertIpMacAddressRSM(ipAddress, macAddress);
                }
                else
                {
                    Console.WriteLine($"IP {ipAddress} is not reachable.");
                }
            }
            // Notify user that scan is completed
            Invoke((Action)(() =>
            {
            }));
        }

        private async Task StartScanAsyncRSMBSM26()
        {
            // Scan the IP range from 10.10.26.0 to 10.10.26.225
            string baseIP = "10.10.26.";

            for (int i = 0; i <= 255; i++)
            {
                string ipAddress = baseIP + i;

                // Check if the IP is reachable
                if (IsRSMReachable(ipAddress))
                {
                    
                    string macAddress = GetMacAddress(ipAddress);
                    InsertIpMacAddressRSM(ipAddress, macAddress);
                }
                else
                {
                    Console.WriteLine($"IP {ipAddress} is not reachable.");
                }
            }
            
            // Notify user that scan is completed
            Invoke((Action)(() =>
            {
                MessageBox.Show("Scan IP RSM & BSM Completed.");
            }));
        }

        private static bool IsRSMReachable(string ip)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send(ip, 1); // Timeout of 1000 ms (1 second)
                    return reply.Status == IPStatus.Success;
                }
            }
            catch (PingException)
            {
                return false; // If there is a PingException, we consider the IP unreachable
            }
        }

        // Method to insert or update active IP and MAC address into the database
        static void InsertIpMacAddressRSM(string rsm, string macAddress)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Key"].ConnectionString))
            {
                conn.Open();

                // Split the IP address into parts using dot as delimiter
                string[] parts = rsm.Split('.');

                // Convert the second-to-last octet (the second part) to an integer and subtract 1
                int thirdOctet = int.Parse(parts[2]);
                thirdOctet = Math.Max(0, thirdOctet - 1); // Ensure it doesn't go below 0

                // Update the second octet in the parts array
                parts[2] = thirdOctet.ToString();

                // Reassemble the IP address with the modified second octet
                string bsm = string.Join('.', parts);

                // First, try to update the record if the IP address exists
                string updateQuery = "UPDATE tb_list SET rsm = @rsm, bsm = @bsm WHERE mac = @mac";
                using (var command = new SQLiteCommand(updateQuery, conn))
                {
                    command.Parameters.AddWithValue("@rsm", rsm);
                    command.Parameters.AddWithValue("@mac", macAddress);
                    command.Parameters.AddWithValue("@bsm", bsm);
                    int rowsAffected = command.ExecuteNonQuery();

                    // If no rows were updated (meaning the IP doesn't exist)
                    if (rowsAffected == 0)
                    {
                        Console.WriteLine($"Mac Addrees {macAddress} Doesn't Match, No Rows Were Updated!");
                    }
                }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadCBLoader();
        }
    }
}
