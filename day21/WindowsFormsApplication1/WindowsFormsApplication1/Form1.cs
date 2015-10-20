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

        // Liste fuer Feldnamen.
        List<string> _names = new List<string>();
        // Liste fuer Datenwerte.
        List<double[]> _dataArray = new List<double[]>();


        public Form1()
        {
            InitializeComponent();

            // Column1
            _names.Add("Cat");
            _dataArray.Add(new double[] { 1.0, 3.5, 0.9 } );

            // Column2
            _names.Add("Dog");
            _dataArray.Add(new double[] { 1.8, 2.5, 4.9 , 3.9});

            // Column3
            _names.Add("Bee");
            _dataArray.Add(new double[] { 3.8, 2.9, 0.45 });

            // Column4
            _names.Add("Elephant");
            _dataArray.Add(new double[] { 2.8 });
           

            // DataGridView anzeigen.
            dataGridView1.DataSource = GetResultsTable();
        }

        public DataTable GetResultsTable()
        {
            DataTable d = new DataTable();

            // Anzahl der der Spalten.
            // In unserem Fall 0..3
            for (int i = 0; i < this._dataArray.Count; i++ )
            {
                // Spaltennamen auf der Liste lesen 
                // und in der DataTable festlegen.
                string name = this._names[i];
                d.Columns.Add(name);

                // Bei jedem Durchlauf 
                // leere Objekt-Liste anlegen.
                List<object> objectNumbers = new List<object>();

                // Jeden Zahlenwert in dieser Liste speichern.
                foreach (double number in this._dataArray[i])
                {
                    objectNumbers.Add((object)number);
                }

                // Für jeden Wert aus der Objekt-Liste eine
                // Zeile in der DataTable anlegen.
                while (d.Rows.Count < objectNumbers.Count)
                {
                    d.Rows.Add();
                }

                
                // Jeden Wert in den Zellen der Spalten speichern.
                for (int a = 0; a < objectNumbers.Count; a++)
                {
                    d.Rows[a][i] = objectNumbers[a];
                }
            }
            return d;
        }

    }
}
