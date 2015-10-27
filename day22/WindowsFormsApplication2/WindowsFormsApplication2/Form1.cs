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


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=192.168.0.67;Database=PASS;User ID=xxxxxxx;Password=xxxxxxx;";
        SqlConnection dbcon;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable data;


        public Form1()
        {
            InitializeComponent();

           Connect();
           Query("SELECT VERSANDART,VERSANDTEXT, TEXTE, FREI, VERSANDTEXT_ENG, KF, VERSANDCODE, VERSANDCODE2 FROM VERSANDARTEN");
           CloseDB();

            // DataGridView anzeigen.
            dataGridView1.DataSource = data;
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

        // Eine Abfrage losschicken. :-)
        public void Query(String query)
        {
           

            cmd = new SqlCommand(query, dbcon);
            // create data adapter
            da = new SqlDataAdapter(cmd);
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

      
    }
}
