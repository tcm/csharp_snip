using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    //Gtk.Entry filterEntry;
    Gtk.TreeModelFilter filter;


    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();


        //Gtk.Entry filterEntry;
        //Gtk.TreeModelFilter filter;

        // Create a column for the artist name
        Gtk.TreeViewColumn artistColumn = new Gtk.TreeViewColumn();
        artistColumn.Title = "Artist";
        // Create the text cell that will display the artist name
        Gtk.CellRendererText artistNameCell = new Gtk.CellRendererText();
        // Add the cell to the column
        artistColumn.PackStart(artistNameCell, true);

        // Create a column for the song title
        Gtk.TreeViewColumn songColumn = new Gtk.TreeViewColumn();
        songColumn.Title = "Song Title";
        // Do the same for the song title column
        Gtk.CellRendererText songTitleCell = new Gtk.CellRendererText();
        songColumn.PackStart(songTitleCell, true);

        // Add the columns to the TreeView
        treeview1.AppendColumn(artistColumn);
        treeview1.AppendColumn(songColumn);

        // Tell the Cell Renderers which items in the model to display
        artistColumn.AddAttribute(artistNameCell, "text", 0);
        songColumn.AddAttribute(songTitleCell, "text", 1);
        // Create a model that will hold two strings - Artist Name and Song Title
        Gtk.ListStore musicListStore = new Gtk.ListStore(typeof(string), typeof(string));

        // Add some data to the store
        musicListStore.AppendValues("BT", "Circles");
        musicListStore.AppendValues("Daft Punk", "Technologic");
        musicListStore.AppendValues("Daft Punk", "Digital Love");
        musicListStore.AppendValues("The Crystal Method", "PHD");
        musicListStore.AppendValues("The Crystal Method", "Name of the game");
        musicListStore.AppendValues("The Chemical Brothers", "Galvanize");

        // Without Filter
        //treeview1.Model = musicListStore;

        // Instead of assigning the ListStore model directly to the TreeStore, we create a TreeModelFilter
        // which sits between the Model (the ListStore) and the View (the TreeView) filtering what the model sees.
        // Some may say that this is a "Controller", even though the name and usage suggests that it is still part of
        // the Model.
        filter = new Gtk.TreeModelFilter(musicListStore, null);

        // Specify the function that determines which rows to filter out and which ones to display
        filter.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc(FilterTree);

        // Assign the filter as our tree's model
        treeview1.Model = filter;

    }

    private bool FilterTree(Gtk.TreeModel model, Gtk.TreeIter iter)
    {
        string artistName = model.GetValue(iter, 0).ToString();


        if (this.entry2.Text == "")
            return true;

        if (artistName.IndexOf(this.entry2.Text) > -1)
            return true;
        else
            return false; 

        // Static Filter
        /* string artistName = model.GetValue(iter, 0).ToString();
        if (artistName == "BT")
            return true;
        else
            return false; */
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnEntry2Changed(object sender, EventArgs e)
    {
        
        // Since the filter text changed, tell the filter to re-determine which rows to display
        filter.Refilter();
    }
}
