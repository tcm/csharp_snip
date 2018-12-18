using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        // Spaltendefinition festlegen.
        Gtk.TreeViewColumn artistColumn = new Gtk.TreeViewColumn();
        artistColumn.Title = "Artist";

        Gtk.TreeViewColumn songColumn = new Gtk.TreeViewColumn();
        songColumn.Title = "Song Title";

        // Spalten dem Treeview hinzufügen.
        treeview1.AppendColumn(artistColumn);
        treeview1.AppendColumn(songColumn);

        // Ein Model mit zwei Strings anlegen - Artist Name und Song Title
        Gtk.TreeStore musicListStore = new Gtk.TreeStore(typeof(string), typeof(string));

        // Model dem Treeview zuweisen.
        treeview1.Model = musicListStore;

        // **************
        // Daten anzeigen
        // **************

        // Daten im Model speichern.
        Gtk.TreeIter iter = musicListStore.AppendValues("Independent");
        musicListStore.AppendValues(iter, "It smells like teen spirit", "Space Lord");

        iter = musicListStore.AppendValues("Electronic");
        musicListStore.AppendValues(iter, "Ruiner", "Axel F");

        // Zelle die den arstistNamen anzeigen wird erzeugen.
        Gtk.CellRendererText artistNameCell = new CellRendererText();
        // Zelle der Spalte hinzufügen.
        artistColumn.PackEnd(artistNameCell, true);

        // Das gleiche für den songTitle.
        Gtk.CellRendererText songTitleCell = new CellRendererText();
        songColumn.PackEnd(songTitleCell, true);

        // Dem Zellenrenderer sagen, welche Punkte des Models angezeigt werden.
        artistColumn.AddAttribute(artistNameCell, "text", 0);
        songColumn.AddAttribute(songTitleCell, "text", 1);
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
