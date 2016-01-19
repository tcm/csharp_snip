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
    public partial class EditGeschichteDialog : Form
    {
        private GDatabase database;

        DataSet dsAutorComboBox;
        DataSet dsGenreComboBox;
        DataSet dsLandComboBox;

        public EditGeschichteDialog(GDatabase database)
        {
            this.database = database;
            InitializeComponent();

            /* ComboxBox AUTOR füllen. */
            this.dsAutorComboBox = database.QueryAutorComboBox();
            this.Autor_comboBox.DataSource = dsAutorComboBox.Tables[0];
            this.Autor_comboBox.DisplayMember = "NAME";
            this.Autor_comboBox.ValueMember = "ID";

            /* ComboxBox GENRE füllen. */
            this.dsGenreComboBox = database.QueryGenreComboBox();
            this.Genre_comboBox.DataSource = dsGenreComboBox.Tables[0];
            this.Genre_comboBox.DisplayMember = "BEZEICHNUNG";
            this.Genre_comboBox.ValueMember = "ID";

            /* ComboxBox LAND füllen. */
            this.dsLandComboBox = database.QueryLandComboBox();
            this.Land_comboBox.DataSource = dsLandComboBox.Tables[0];
            this.Land_comboBox.DisplayMember = "BEZEICHNUNG";
            this.Land_comboBox.ValueMember = "ID";
        }

        private void Speichern_button_Click(object sender, EventArgs e)
        {
            int Geschichte_ID;

            string Titel;
            short Entstehungsjahr = short.MinValue;
            int Autor_ID;
            int Genre_ID;
            int Land_ID;

            Titel = Titel_textBox.Text;
            Entstehungsjahr = Convert.ToInt16(Entstehungsjahr_textBox.Text);
            Autor_ID = Convert.ToInt32(Autor_comboBox.SelectedValue);
            Genre_ID = Convert.ToInt32(Genre_comboBox.SelectedValue);
            Land_ID = Convert.ToInt32(Land_comboBox.SelectedValue);

            /* -------------------------------------------------------------------*/
            /* Datensatz speichern.                                               */
            /* -------------------------------------------------------------------*/
            Geschichte_ID = database.InsertGeschichte(Titel, Entstehungsjahr, Autor_ID, Genre_ID, Land_ID);

            if ( Geschichte_ID > 0)
            {
                ID_textBox.Text = Geschichte_ID.ToString();
               
            }
            else
            {
                ShowTextbox();
            }
        }

        private void Neuer_Datensatz_button_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void ShowTextbox()
        {
            // Messagebox-Text festlegen.
            string message = "Datensatz konnte nicht gespeichert werden.";
            string caption = "Fehler bei der Dateneingabe";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Messagebox anzeigen.
            result = MessageBox.Show(message, caption, buttons);
        }

        private void ClearInputFields()
        {
            ID_textBox.Text = "";
            Titel_textBox.Text = "";
            Entstehungsjahr_textBox.Text = "";
        }

      

       

    }
}
