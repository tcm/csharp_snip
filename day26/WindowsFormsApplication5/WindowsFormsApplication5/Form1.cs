using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        private LVDatabase database = new LVDatabase();
       
        
        public Form1()
        {
            InitializeComponent();
        }

       

        private bool ConnectDatabase()
        {
            bool result = false;


            if (database.Connect() == true)
            {
               
                result = true;
            }
            else
            {
              
                string msg = string.Format("{0}\n\nBitte prüfen Sie die Verbindungsdaten (-> PASSLagerverwaltung.xml) und den Status des Datenbank-Servers.\n\nDie Anwendung wird beendet.", this.database.LastError);
                MessageBox.Show(this, msg, "Fehler beim Verbindungsaufbau zur Datenbank.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
            }

            return result;
        }


        private bool DiconnectDatabase()
        {
            bool result = false;


            if (database.Disconnect() == true)
            {
                result = true;
            }
          
           

            return result;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            if (ConnectDatabase() == true)
            {
                message_textBox1.Text = "Connected.";
                // LoginUser();
                
            }
            else
            {
                message_textBox1.Text = "Not Connected.";
            }

        }

        private void button1_query_Click(object sender, EventArgs e)
        {

            DataSet data = database.QueryMaterial();
            dataGridView1.DataSource = data.Tables[0];

        }

        private void disconnect_button1_Click(object sender, EventArgs e)
        {
            if (DiconnectDatabase() == true)
            {
                message_textBox1.Text = "Not Connected.";
                // LoginUser();
            }
         
        }

       
    }
}
