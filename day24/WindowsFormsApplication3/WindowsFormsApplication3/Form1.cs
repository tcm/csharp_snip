using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        List<Person> employees = new List<Person>()
        {
        new Person { Id=1, FirstName="Georg", LastName="Müller"},
        new Person { Id=2, FirstName="Martin", LastName="Schulze"},
        new Person { Id=3, FirstName="´Dieter", LastName="Bürgy"},
        new Person { Id=4, FirstName="Heinz", LastName="Kowalski"},
        new Person { Id=5, FirstName="Elke", LastName="Schmidt"}
        };

        private void Fill_in_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = employees;
        }
    }
}
