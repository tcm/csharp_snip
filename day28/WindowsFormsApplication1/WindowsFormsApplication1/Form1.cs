using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TelefonNumber_textBox_Leave(object sender, EventArgs e)
        {
            GRegex StringIn = new GRegex();

            if (StringIn.Is_Regex(RegexPattern.PatternTelefonNumber, TelefonNumber_textBox.Text) == false)
            {
                /* --------------------------------------------------------- */
                /*  Messagebox-Text festlegen.                               */
                /*  Messagebox anzeigen.                                     */
                /* --------------------------------------------------------- */
                string message = "Keine gültige Telefonnummer" + Environment.NewLine + "Bsp.: +49 09270-4566";
                ShowMessageBox_Dateneingabe(message);

                TelefonNumber_textBox.Focus();
            }
        }

        private void EmailAddress_textBox_Leave(object sender, EventArgs e)
        {
            GRegex StringIn = new GRegex();

            if (StringIn.Is_Regex(RegexPattern.PatternEmailAddress, EmailAddress_textBox.Text) == false)
            {
                /* --------------------------------------------------------- */
                /*  Messagebox-Text festlegen.                               */
                /*  Messagebox anzeigen.                                     */
                /* --------------------------------------------------------- */
                string message = "Keine gültige Email-Adresse" + Environment.NewLine + "Bsp.: info@mit.edu";
                ShowMessageBox_Dateneingabe(message);

                EmailAddress_textBox.Focus();
            }
        }      

        
        private void VATNumber_textBox_Leave(object sender, EventArgs e)
        {
            GRegex StringIn = new GRegex();

            if (StringIn.Is_Regex(RegexPattern.PatternEuropeanVATNumber, VATNumber_textBox.Text) == false)
            {
                /* --------------------------------------------------------- */
                /*  Messagebox-Text festlegen.                               */
                /*  Messagebox anzeigen.                                     */
                /* --------------------------------------------------------- */
                string message = "Keine gültige UST-Identnummer" + Environment.NewLine + "Bsp.: DE 1234567";
                ShowMessageBox_Dateneingabe(message);

                VATNumber_textBox.Focus();
            }

        }


        private void ShowMessageBox_Dateneingabe(string message)
        {
            string caption = "Fehler bei der Dateneingabe";

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
        }     
    }
}
