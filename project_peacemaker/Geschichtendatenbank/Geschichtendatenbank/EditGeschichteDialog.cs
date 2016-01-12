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

        public EditGeschichteDialog(GDatabase database)
        {
            this.database = database;
            InitializeComponent();
        }

        private void Speichern_button_Click(object sender, EventArgs e)
        {
            int Geschichte_ID;

            string titel;
            short entstehungsjahr = short.MinValue;

            titel = Titel_textBox.Text;
            entstehungsjahr = Convert.ToInt16(Entstehungsjahr_textBox.Text);

            /* -------------------------------------------------------------------*/
            /* Datensatz speichern.                                               */
            /* -------------------------------------------------------------------*/
            Geschichte_ID = database.InsertGeschichte(titel, entstehungsjahr);
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
