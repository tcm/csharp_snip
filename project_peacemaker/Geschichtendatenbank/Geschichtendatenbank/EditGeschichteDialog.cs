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

        DataSet dsGeschichte;

        DataSet dsAutorComboBox;
        DataSet dsGenreComboBox;
        DataSet dsLandComboBox;

        public EditGeschichteDialog(GDatabase database, int Geschichte_ID)
        {
            this.database = database;
            InitializeComponent();

            /* Datensatz lesen */
            this.dsGeschichte = database.QueryEditGeschichteDialog(Geschichte_ID);

            /* Textboxen füllen */
            ID_textBox.Text = dsGeschichte.Tables[0].Rows[0]["ID"].ToString();
            Titel_textBox.Text = dsGeschichte.Tables[0].Rows[0]["BEZEICHNUNG"].ToString();
            Entstehungsjahr_textBox.Text = dsGeschichte.Tables[0].Rows[0]["ENTSTEHUNGSJAHR"].ToString();
            Text_richTextBox.Text = dsGeschichte.Tables[0].Rows[0]["TEXT"].ToString();

            /* ComboxBox AUTOR füllen. */
            this.dsAutorComboBox = database.QueryAutorComboBox();
            this.Autor_comboBox.DataSource = dsAutorComboBox.Tables[0];
            this.Autor_comboBox.DisplayMember = "NAME";
            this.Autor_comboBox.ValueMember = "ID";
            this.Autor_comboBox.SelectedValue = dsGeschichte.Tables[0].Rows[0]["AUTOR_ID"];

            /* ComboxBox GENRE füllen. */
            this.dsGenreComboBox = database.QueryGenreComboBox();
            this.Genre_comboBox.DataSource = dsGenreComboBox.Tables[0];
            this.Genre_comboBox.DisplayMember = "BEZEICHNUNG";
            this.Genre_comboBox.ValueMember = "ID";
            this.Genre_comboBox.SelectedValue = dsGeschichte.Tables[0].Rows[0]["GENRE_ID"];

            /* ComboxBox LAND füllen. */
            this.dsLandComboBox = database.QueryLandComboBox();
            this.Land_comboBox.DataSource = dsLandComboBox.Tables[0];
            this.Land_comboBox.DisplayMember = "BEZEICHNUNG";
            this.Land_comboBox.ValueMember = "ID";
            this.Land_comboBox.SelectedValue = dsGeschichte.Tables[0].Rows[0]["LAND_ID"];
        }

        private void Speichern_button_Click(object sender, EventArgs e)
        {
            int Geschichte_ID;

            string Titel;
            short Entstehungsjahr = short.MinValue;
            int Autor_ID;
            int Genre_ID;
            int Land_ID;
            string Text;

            Titel = Titel_textBox.Text;
            Entstehungsjahr = Convert.ToInt16(Entstehungsjahr_textBox.Text);
            Autor_ID = Convert.ToInt32(Autor_comboBox.SelectedValue);
            Genre_ID = Convert.ToInt32(Genre_comboBox.SelectedValue);
            Land_ID = Convert.ToInt32(Land_comboBox.SelectedValue);
            Text = Text_richTextBox.Text;


            /* -------------------------------------------------------------------*/
            /* Datensatz speichern.                                               */
            /* -------------------------------------------------------------------*/
            Geschichte_ID = database.InsertGeschichte(Titel, Entstehungsjahr, Autor_ID, Genre_ID, Land_ID, Text);

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
            Text_richTextBox.Text = "";
        }  
    }
}
