using System;
using System.Data;
using System.Data.SqlClient;

// Datenbank-Routinen in einer Klasse
// untergebracht.
// Zeigt den Umgang mit einer DataTable
//
// Compilieren mit:
// mcs DatabaseRoutines_3.cs -r:System.Data.dll -r:System.Data.DataSetExtensions.dll

interface IDatabaseAccess
{
	bool Connect ();
	void Query (String query);
	bool Close ();
}

namespace DatabaseRoutines
{
	public class DatabaseAccess : IDatabaseAccess
	{
		private string connectionString = "Server=192.168.0.67;Database=PASS;User ID=xxxxx;Password=xxxxx;";
		private SqlConnection dbcon;
		private SqlCommand cmd;
		SqlDataAdapter da;
		public DataTable data;

		// Verbinden.
		public bool Connect ()
		{
			try {
				dbcon = new SqlConnection (connectionString);
				dbcon.Open ();
			} catch {
				return false;
			}
			return true;
		} 

		// Eine Abfrage losschicken. :-)
		public void Query (String query)
		{
			cmd = new SqlCommand (query, dbcon);
			// create data adapter
			da = new SqlDataAdapter (cmd);
			// this will query your database and return the result to your datatable
			data = new DataTable ();
			da.Fill (data);
		}
 
		public bool Close ()
		{
			try {
				dbcon.Close ();
				da.Dispose ();

			} catch {
				return false;
			}
			return true;
		}
	}
}

public class Program
{
	static void Main ()
	{
		DatabaseRoutines.DatabaseAccess myquery;
		myquery = new DatabaseRoutines.DatabaseAccess ();

		if ( myquery.Connect () ) {

			myquery.Query ("SELECT land, bezeichnung FROM laender");

			// Alle Datensätze anzeigen
			foreach (DataRow row in myquery.data.Rows) {
				Console.WriteLine (row.Field<string> (0) + " - " + row.Field<string> (1));
			}

		} else {
			Console.WriteLine ("DB-Connection-Error!");
		}


		if ( myquery.Close () ) {

	    } else {
			Console.WriteLine("DB-Close-Error!");
		}
    }
}