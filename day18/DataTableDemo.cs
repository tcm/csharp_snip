using System;
using System.Data;

// Compilieren mit:
// mcs DataTableDemo.cs -r:System.Data.dll -r:System.Data.DataSetExtensions.dll


class DataTableDemo
{
	static void Main ()
	{
		// DataTable holen.
		DataTable data = GetTable ();

		// Schleife um alle Datensätze zurückzugeben.
		foreach (DataRow row in data.Rows) 
		{
			Console.WriteLine(row.Field<int>(0));
		}
	}

	static DataTable GetTable ()
	{
		DataTable table = new DataTable();

		// Tabelle mit 4 Feldern anlegen.
		table.Columns.Add("Dosage", typeof(int));
		table.Columns.Add("Drug", typeof(string));
		table.Columns.Add("Patient", typeof(string));
		table.Columns.Add("Date", typeof(DateTime));

		// 5 Datensätze hinzufügen.
		table.Rows.Add(25, "Indocin", "David", DateTime.Now);
		table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
		table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
		table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
		table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
		return table;
	}
}
