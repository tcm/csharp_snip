using System;
using System.Data;

// DataTable-Beispiel mit using

class Program
{
	static void Main()
	{

		// Die DataTable erzeugen und mit anschließendem
		// dispose.
		using (DataTable table = new DataTable())
		{
			// 2 Spalten
			table.Columns.Add("Name", typeof(string));
			table.Columns.Add("Date", typeof(DateTime));
			
			// 2 Datensätze hinzufügen.
			table.Rows.Add("cat", DateTime.Now);
			table.Rows.Add("dog", DateTime.Today);
			
			// Ersten Datensatz mit erster Spalte hinzufügen.
			Console.WriteLine(table.Rows[0].Field<string>(0));
		}
	}
}
