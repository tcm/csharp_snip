using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=localhost;Database=PASS;User ID=testuser;Password=testuser;";
        SqlConnection dbcon;
        SqlCommand selectcmd;
        SqlDataAdapter da;
        DataTable data;

        public Form1()
        {
            InitializeComponent();
            Connect();
            Select_Query("SELECT *, VERSANDTEXT + '  -  ' + TEXTE AS DESCRIPTION FROM VERSANDARTEN");
            CloseDB();

            this.comboBox1.DataSource = data;
            this.comboBox1.DisplayMember = "DESCRIPTION";
            
            //this.comboBox1.DisplayMember = "TEXTE";
            this.comboBox1.ValueMember = "VERSANDART";
            
        }

        // Verbinden.
        public bool Connect()
        {
            try
            {
                dbcon = new SqlConnection(connectionString);
                dbcon.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Select_Query(String query)
        {


            selectcmd = new SqlCommand(query, dbcon);
            // create data adapter
            da = new SqlDataAdapter(selectcmd);
            // this will query your database and return the result to your datatable
            data = new DataTable();
            da.Fill(data);


        }

        // Schliessen
        public bool CloseDB()
        {
            try
            {
                dbcon.Close();
                da.Dispose();

            }
            catch
            {
                return false;
            }
            return true;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                textBox1.Text = comboBox1.SelectedValue.ToString();
               
            }
        }
    }
}
