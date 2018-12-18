using System;
using Gtk;
using System.IO;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnButtonClearClicked(object sender, EventArgs e)
    {
        textview1.Buffer.Text = "";
    }

    protected void OnButtonUpperCaseClicked(object sender, EventArgs e)
    {
        textview1.Buffer.Text = textview1.Buffer.Text.ToUpper();
    }

    protected void OnButtonLowerCaseClicked(object sender, EventArgs e)
    {
        textview1.Buffer.Text = textview1.Buffer.Text.ToLower();
    }

    protected void OnButtonSaveClicked(object sender, EventArgs e)
    {
        // Save the text in textview1.
        StreamWriter sw = new StreamWriter("Test.txt");
        sw.Write(textview1.Buffer.Text); //Write textview1 text to file
        textview1.Buffer.Text = "Saved to file !"; //Notify user
        sw.Close();
    }
}
