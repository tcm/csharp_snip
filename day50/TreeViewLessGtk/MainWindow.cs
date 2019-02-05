using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        // TreeView mit weniger Code als im Grundbeispiel
        Gtk.ListStore musicListStore = new Gtk.ListStore(typeof(string), typeof(string));

        treeview1.AppendColumn("Artist", new Gtk.CellRendererText(), "text", 0);
        treeview1.AppendColumn("Title", new Gtk.CellRendererText(), "text", 1);

        musicListStore.AppendValues("Garbage", "Dog New Tricks");
        musicListStore.AppendValues("Smashing Pumpkins", "Luna");




        treeview1.Model = musicListStore;
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
