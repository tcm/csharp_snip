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
        string connectionString = "Server=192.168.0.67;Database=PASS;User ID=testuser;Password=testuser;";
        SqlConnection dbcon;
        SqlCommand selectcmd;
        SqlCommand updatecmd;
        SqlCommand insertcmd;
        SqlCommand deletecmd;
        SqlDataAdapter da;
        DataTable data;


        public Form1()
        {
            InitializeComponent();

           Connect();
           Select_Query("SELECT VERSANDART,VERSANDTEXT, TEXTE, FREI, VERSANDTEXT_ENG, KF, VERSANDCODE, VERSANDCODE2 FROM VERSANDARTEN");
           CloseDB();

            // DataGridView anzeigen.
            dataGridView1.DataSource = data;
        }

        // Verbinden.
        public bool Connect()
        {
            /* using (SqlConnection dbcon= new SqlConnection(connectionString))
            {
            dbcon.Open();

            } */
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
        public void Select_Query(String query)
        {


            selectcmd = new SqlCommand(query, dbcon);
            // create data adapter
            da = new SqlDataAdapter(selectcmd);
            // this will query your database and return the result to your datatable
            data = new DataTable();
            da.Fill(data);

         
        }

        public void Update_Query()
        {
            // Update-Command definieren
            updatecmd = new SqlCommand("UPDATE VERSANDARTEN SET VERSANDTEXT = @VERSANDTEXT WHERE  VERSANDART= @VERSANDART", dbcon);
            updatecmd.Parameters.Add("VERSANDART", SqlDbType.Int, 0, "VERSANDART");
            updatecmd.Parameters.Add("VERSANDTEXT", SqlDbType.VarChar, 50, "VERSANDTEXT");

            // Änderungen speichern
            DataTable changes = data.GetChanges(DataRowState.Modified);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = updatecmd;
            
            int count = adapter.Update(data);
            Status.Text = count + " Datensätze geändert.";
        }

        public void Insert_Query()
        {
            // Insert-Command definieren
            insertcmd = new SqlCommand("INSERT INTO VERSANDARTEN (VERSANDART, VERSANDTEXT,FREI) VALUES (@VERSANDART, @VERSANDTEXT, @FREI)", dbcon);
            insertcmd.Parameters.Add("VERSANDART", SqlDbType.Int, 0, "VERSANDART");
            insertcmd.Parameters.Add("VERSANDTEXT", SqlDbType.VarChar, 50, "VERSANDTEXT");
            insertcmd.Parameters.Add("FREI", SqlDbType.Bit, 0, "FREI");

            // Inserts speichern.
            DataTable changes = data.GetChanges(DataRowState.Added);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = insertcmd;

            int count = adapter.Update(data);
            Status.Text = count + " Datensätze eingefügt.";

        }


        public void Delete_Query()
        {
            // Insert-Command definieren
            deletecmd = new SqlCommand("DELETE FROM VERSANDARTEN WHERE VERSANDART = @VERSANDART", dbcon);
            deletecmd.Parameters.Add("VERSANDART", SqlDbType.Int, 0, "VERSANDART");
            

            // Inserts speichern.
            DataTable changes = data.GetChanges(DataRowState.Deleted);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.DeleteCommand = deletecmd;

            int count = adapter.Update(data);
            Status.Text = count + " Datensätze gelöscht.";

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

        private void Update_Click(object sender, EventArgs e)
        {
            Update_Query();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            Insert_Query();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Delete_Query();
        }

        

        

      
    }
}
