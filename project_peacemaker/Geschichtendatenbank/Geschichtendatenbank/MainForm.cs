using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

enum FilterType
{
    Ohne_Filter,
    Titel,
    Entstehungsjahr
}

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
                /* -------------------------------------------------------------*/
                /* Verbindungsstatus anzeigen.                                  */
                /* -------------------------------------------------------------*/
                DBStatus_toolStripLabel.Text = "Verbunden.";
                DBStatus_toolStripLabel.ForeColor = System.Drawing.Color.Green;

                /* -------------------------------------------------------------*/
                /* DataGrid Uebersicht füllen.                                  */
                /* -------------------------------------------------------------*/
                MainForm_Uebersicht_dataGridView_aktualisieren(FilterType.Ohne_Filter);

                /* -------------------------------------------------------------*/
                /* DataGrid Figuren füllen.                                     */
                /* -------------------------------------------------------------*/
                MainForm_Figuren_dataGridView_aktualisieren(0);

            }
            else
            {
                /* -------------------------------------------------------------*/
                /* Verbindungsstatus anzeigen.                                  */
                /* -------------------------------------------------------------*/
                DBStatus_toolStripLabel.Text = "Nicht verbunden.";
                DBStatus_toolStripLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void Filter_Titel_textBox_Leave(object sender, EventArgs e)
        {
            GRegex StringIn = new GRegex();

            if (Filter_Titel_textBox.Text == "")
            {
                /* -------------------------------------------------------------*/
                /* DataGrid Übersicht füllen,                                   */
                /* wenn Datensätze vorhanden.                                   */
                /* -------------------------------------------------------------*/
                if (MainForm_Uebersicht_dataGridView_aktualisieren(FilterType.Ohne_Filter) == true)
                {
                    /* -------------------------------------------------------------*/
                    /* DataGrid Figuren füllen.                                     */
                    /* -------------------------------------------------------------*/
                    MainForm_Figuren_dataGridView_aktualisieren(0);
                }
            }
            else if (StringIn.Is_Titel(Filter_Titel_textBox.Text) == false)
            {
                // Messagebox-Text festlegen.
                string message = "Kein gültiger Titel." + Environment.NewLine + "Verwenden sie nur Buchstaben und Zahlen.";
                // Messagebox anzeigen.
                ShowMessageBox_Dateneingabe(message);
            
                Filter_Entstehungsjahr_textBox.Focus();
            }
            else
            {
                /* -------------------------------------------------------------*/
                /* DataGrid Uebersicht füllen. Filtern nach Titel,              */
                /* wenn Datensätze vorhanden.                                   */
                /* -------------------------------------------------------------*/
                if (MainForm_Uebersicht_dataGridView_aktualisieren(FilterType.Titel) == true)
                {
                    /* -------------------------------------------------------------*/
                    /* DataGrid Figuren füllen.                                     */
                    /* -------------------------------------------------------------*/
                    MainForm_Figuren_dataGridView_aktualisieren(0);
                }
            }

        }

     
        private void Filter_Entstehungsjahr_textBox_Leave(object sender, EventArgs e)
        {
            GRegex StringIn = new GRegex();

            if (Filter_Entstehungsjahr_textBox.Text == "")
            {
                /* -------------------------------------------------------------*/
                /* DataGrid Übersicht füllen,                                   */
                /* wenn Datensätze vorhanden.                                   */
                /* -------------------------------------------------------------*/
                if ( MainForm_Uebersicht_dataGridView_aktualisieren(FilterType.Ohne_Filter) == true )
                { 
                    /* -------------------------------------------------------------*/
                    /* DataGrid Figuren füllen.                                     */
                    /* -------------------------------------------------------------*/
                    MainForm_Figuren_dataGridView_aktualisieren(0);
                }
            }

            else if (StringIn.Is_Four_Digits(Filter_Entstehungsjahr_textBox.Text) == false)
            {
                // Messagebox-Text festlegen.
                string message = "Jahreszahl muss im Format YYYY eingeben werden." + Environment.NewLine +"Zum Beispiel: 1983";
                // Messagebox anzeigen.
                ShowMessageBox_Dateneingabe(message);
            
                Filter_Entstehungsjahr_textBox.Focus();
            }
           
            else
            {
                /* -------------------------------------------------------------*/
                /* DataGrid Uebersicht füllen. Filtern nach Jahr,               */
                /* wenn Datensätze vorhanden.                                   */
                /* -------------------------------------------------------------*/
                if (MainForm_Uebersicht_dataGridView_aktualisieren(FilterType.Entstehungsjahr) == true)
                {
                    /* -------------------------------------------------------------*/
                    /* DataGrid Figuren füllen.                                     */
                    /* -------------------------------------------------------------*/
                    MainForm_Figuren_dataGridView_aktualisieren(0);
                }
            }
        }

        private void MainForm_Uebersicht_dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        
        {
           Int32 selectedRowCount = MainForm_Uebersicht_dataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);

          if (selectedRowCount > 0)
            {
                /* Code für  Multiselect = True (default)
                for (int i = 0; i < selectedRowCount; i++)
                {
                    string RowNumber = MainForm_Uebersicht_dataGridView.SelectedRows[i].Index.ToString(); 
                */

                /* -------------------------------------------------------------*/
                /* DataGrid Figuren füllen.                                     */
                /* -------------------------------------------------------------*/
                MainForm_Figuren_dataGridView_aktualisieren(e.RowIndex);
            } 
        }

        private bool MainForm_Uebersicht_dataGridView_aktualisieren(FilterType filtertype)
        {
            DataSet myrs = null;

            switch (filtertype)
            {
            case FilterType.Ohne_Filter:
            /* -------------------------------------------------------------*/
            /* Kein Filter.                                                 */
            /* -------------------------------------------------------------*/
            myrs = database.QueryMainFormUebersicht();
            break ;

            case FilterType.Titel:
            /* -------------------------------------------------------------*/
            /* Filtern nach Titel                                           */
            /* -------------------------------------------------------------*/
            myrs = database.QueryMainFormUebersicht_Filter_Titel(Filter_Titel_textBox.Text);
            break;

            case FilterType.Entstehungsjahr:
            /* -------------------------------------------------------------*/
            /* Filtern nach Jahr                                            */
            /* -------------------------------------------------------------*/
            myrs = database.QueryMainFormUebersicht_Filter_Jahr(Filter_Entstehungsjahr_textBox.Text);
            break;
            }

            /* -------------------------------------------------------------*/
            /* DataGrid Uebersicht füllen.                                  */
            /* Ersten Datensatz auswählen.                                  */
            /* -------------------------------------------------------------*/
            MainForm_Uebersicht_dataGridView.DataSource = myrs.Tables[0];
            if ( HasRecords(myrs) == true)
            {
                MainForm_Uebersicht_dataGridView.Rows[0].Selected = true;
                return true;
            }
            return false;
        }

        private void MainForm_Figuren_dataGridView_aktualisieren(int tRowIndex)
        {
            /* -------------------------------------------------------------*/
            /* Werte der angewählten Zeile ermitteln und ausgeben.          */
            /* -------------------------------------------------------------*/
            string RowNumber = MainForm_Uebersicht_dataGridView.SelectedRows[0].Index.ToString();
            string Cell_Name_ID = MainForm_Uebersicht_dataGridView.Rows[tRowIndex].Cells["ID"].FormattedValue.ToString();

            Meldung_textBox.Text = "Datensatz-Nr.:" + RowNumber + "   ID:" + Cell_Name_ID;

            /* -------------------------------------------------------------*/
            /* DataGrid Figuren füllen.                                     */
            /* -------------------------------------------------------------*/
            int Material_ID = Int32.Parse(Cell_Name_ID);
            DataSet myrs2 = database.QueryMainFormFiguren(Material_ID);
            MainForm_Figuren_dataGridView.DataSource = myrs2.Tables[0];
        }

        private void neueGeschichteAnlegenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditGeschichteDialog dialog = new EditGeschichteDialog(this.database);
            dialog.Show(this);
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool HasRecords(DataSet dataSet)
        {
            foreach (DataTable dt in dataSet.Tables) if (dt.Rows.Count > 0) return true;
            return false;
        }

        private void ShowMessageBox_Dateneingabe(string message)
        {
            string caption = "Fehler bei der Dateneingabe";

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Messagebox anzeigen.
            result = MessageBox.Show(message, caption, buttons);
        }
    }
}
