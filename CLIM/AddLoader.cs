using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CLIM
{
    public partial class AddLoader : Form
    {
        private FormLoader formLoader;
        public AddLoader(FormLoader formLoader)
        {
            InitializeComponent();
            this.formLoader = formLoader;
        }

        int datacount;
        SQLiteConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Key"].ConnectionString);

        private void btnsavelhd_Click(object sender, EventArgs e)
        {

            //using (SqlCommand cmd = new SqlCommand("dbo.SP_InsertLHD", con))
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@no_lhd", tbinputlhd.Text);
            //    cmd.Parameters.Add("@result", SqlDbType.Int);
            //    cmd.Parameters["@result"].Direction = ParameterDirection.Output;
            //    cmd.ExecuteNonQuery();
            //    if ((int)cmd.Parameters["@result"].Value == 1)
            //    {
            //        MessageBox.Show("Loader Already Available");
            //        tbinputlhd.Text = "";
            //    }
            //    else
            //    {
            //        fl.LoadCBLoader();
            //        MessageBox.Show("Data inserted successfully");
            //        tbinputlhd.Text = "";
            //    }
            //}
            LoadAllLoader();
            con.Open();
            if (datacount == 0 && tbinputlhd.Text != "")
            {
                using (SQLiteCommand cmd = new SQLiteCommand("insert into tb_lhd (id_lhd, no_lhd) values (ifnull((select max(id_lhd) from tb_lhd) + 1,1), @no_lhd)", con))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@no_lhd", tbinputlhd.Text);
                    cmd.ExecuteNonQuery();
                    formLoader.LoadCBLoader();
                    MessageBox.Show("Data inserted successfully");
                    tbinputlhd.Text = "";
                }
            }
            else if (datacount > 0)
            {
                MessageBox.Show("Loader Already Available");
                tbinputlhd.Text = "";
            }
            else
            {
                MessageBox.Show("Please Fill the Loader");
                tbinputlhd.Text = "";
            }

            con.Close();
        }

        void LoadAllLoader()
        {
            con.Open();

            using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM tb_lhd WHERE no_lhd = @no_lhd", con))
            {
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@no_lhd", tbinputlhd.Text);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                datacount = dataTable.Rows.Count;
            }

            con.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
