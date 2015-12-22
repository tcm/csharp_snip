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
                // message_textBox1.Text = "Connected.";

                /* -------------------------------------------------------------*/
                /* DataGrid Uebersicht füllen.                                  */
                /* -------------------------------------------------------------*/
                DataSet myrs = database.QueryMainFormUebersicht();
                MainForm_Uebersicht_dataGridView.DataSource = myrs.Tables[0];


                /* -------------------------------------------------------------*/
                /* Werte der angewählten Zeile ermitteln und ausgeben           */
                /* -------------------------------------------------------------*/
                MainForm_Uebersicht_dataGridView.Rows[0].Selected = true;  //  Ersten Datensatz auswählen. 
                Int32 selectedRowCount = MainForm_Uebersicht_dataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);

                if (selectedRowCount > 0)
                {
                    string RowNumber = MainForm_Uebersicht_dataGridView.SelectedRows[0].Index.ToString();
                    string Cell_Name_ID = MainForm_Uebersicht_dataGridView.Rows[0].Cells["ID"].FormattedValue.ToString();

                    Meldung_textBox.Text = "Datensatz-Nr.:" + RowNumber + "   ID:" + Cell_Name_ID;  
                    /* -------------------------------------------------------------*/
                    /* DataGrid Figuren füllen.                                     */
                    /* -------------------------------------------------------------*/
                    int Material_ID = Int32.Parse(Cell_Name_ID);

                    DataSet myrs2 = database.QueryMainFormFiguren(Material_ID);
                    MainForm_Figuren_dataGridView.DataSource = myrs2.Tables[0];
                }
            }
            else
            {
                // message_textBox1.Text = "Not Connected.";
            }
        }

       

        private void Filter_Entstehungsjahr_textBox_Leave(object sender, EventArgs e)
        {
            GRegex StringIn = new GRegex();

            if (StringIn.Is_Four_Digits(Filter_Entstehungsjahr_textBox.Text) == false)
            {
                // Messagebox-Text festlegen.
                string message = "Jahreszahl muss im Format YYYY eingeben werden." + Environment.NewLine +"Zum Beispiel: 1983";
                string caption = "Fehler bei der Dateneingabe";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Messagebox anzeigen.
                result = MessageBox.Show(message, caption, buttons);

                Filter_Entstehungsjahr_textBox.Focus();
            }
        }

        private void MainForm_Uebersicht_dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           Int32 selectedRowCount = MainForm_Uebersicht_dataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);

          // Für Multiselect = True (default) oder False
          if (selectedRowCount > 0)
            {
                /* for (int i = 0; i < selectedRowCount; i++)
                {
                    string RowNumber = MainForm_Uebersicht_dataGridView.SelectedRows[i].Index.ToString(); */

                   /* -------------------------------------------------------------*/
                   /* Werte der angewählten Zeile ermitteln und ausgeben.          */
                   /* -------------------------------------------------------------*/
                    string RowNumber = MainForm_Uebersicht_dataGridView.SelectedRows[0].Index.ToString();
                    string Cell_Name_ID = MainForm_Uebersicht_dataGridView.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
                    Meldung_textBox.Text = "Datensatz-Nr.:" + RowNumber + "   ID:" + Cell_Name_ID;

                    /* -------------------------------------------------------------*/
                    /* DataGrid Figuren füllen.                                     */
                    /* -------------------------------------------------------------*/
                    int Material_ID = Int32.Parse(Cell_Name_ID);
                    DataSet myrs2 = database.QueryMainFormFiguren(Material_ID);
                    MainForm_Figuren_dataGridView.DataSource = myrs2.Tables[0];
            } 
        }
    }
}
