using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geschichtendatenbank
{
    public partial class MainForm : Form
    {
        private GDatabase database = new GDatabase();

        public MainForm()
        {
            InitializeComponent();
        }

        private bool ConnectDatabase()
        {
            bool result = false;

            if ( database.Connect() == true )
            {
                result = true;
            }
            else
            {
                string msg = string.Format("{0}\n\nBitte prüfen Sie die Verbindungsdaten (-> Verbindung.xml) und den Status des Datenbank-Servers.\n\nDie Anwendung wird beendet.", this.database.LastError);
                MessageBox.Show(this, msg, "Fehler beim Verbindungsaufbau zur Datenbank.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            return result;
        }

        private bool DiconnectDatabase()
        {
            bool result = false;

            if ( database.Disconnect() == true )
            {
                result = true;
            }
            return result;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            
            if (ConnectDatabase() == true)
            {
              
                DataSet myrs = database.QueryMainFormUebersicht();
                MainForm_Uebersicht_dataGridView.DataSource = myrs.Tables[0];
                // message_textBox1.Text = "Connected.";
               

            }
            else
            {
                // message_textBox1.Text = "Not Connected.";

            }
        }

        
      

       

        
    }
}
