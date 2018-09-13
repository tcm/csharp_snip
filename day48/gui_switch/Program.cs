using System;
using NDesk.Options;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace gui_switch
{
	class MainClass : Form
	{
		public static void Main (string[] args)
		{
			string data = null;
			bool gui = false;

			var p = new OptionSet () {
				{ "file=",      v => data = v },
				{ "gui",   v => gui = v != null }
			};
			List<string> extra = p.Parse (args);

			if (gui == true) {
				Console.WriteLine ("GUI an");
				Console.WriteLine ("file={0}",data);
				Application.Run (new MainClass ());
			} else {
				Console.WriteLine ("GUI aus");
				Console.WriteLine ("file={0}",data);
			}

		}

		public MainClass()
		{
			Button b = new Button ();
			b.Text = "Click Me!";
			b.Click += new EventHandler (Button_Click);
			Controls.Add (b);
		}

		private void Button_Click(object sender, EventArgs e)
		{
			MessageBox.Show ("Button Clicked!");
		}
	}
}
