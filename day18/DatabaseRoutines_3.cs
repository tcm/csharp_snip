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
	int Connect ();
	void Query ();
	void Close ();
	void Show_Data ();
}

namespace DatabaseRoutines
{
	public class DatabaseAccess : IDatabaseAccess
	{
		private string connectionString = "Server=192.168.0.67;Database=PASS;User ID=xxxxx;Password=xxxxxx;";
		private SqlConnection dbcon;
		private SqlCommand cmd;
		SqlDataAdapter da;
		private DataTable data;

		// Verbinden.
		public int Connect ()
		{
			try {
				dbcon = new SqlConnection (connectionString);
				dbcon.Open ();
			} catch {
				Console.WriteLine ("DB-Connection-Error!");
				return 0;
			}
			return 1;
		} 

		// Eine Abfrage losschicken. :-)
		public void Query ()
		{
			string query = "SELECT land, bezeichnung FROM laender";

			cmd = new SqlCommand (query, dbcon);
			// create data adapter
			da = new SqlDataAdapter (cmd);
			// this will query your database and return the result to your datatable
			data = new DataTable ();
			da.Fill (data);
		}
 
		public void Close ()
		{
			dbcon.Close ();
			da.Dispose ();
		}

		public void Show_Data ()
		{
			foreach (DataRow row in data.Rows) {
				Console.WriteLine (row.Field<string> (0) + " - " + row.Field<string> (1));
			}
		}


	}
}

public class Program
{
	static void Main ()
	{
		DatabaseRoutines.DatabaseAccess myquery;
		myquery = new DatabaseRoutines.DatabaseAccess ();

		myquery.Connect ();
		myquery.Query ();
		myquery.Show_Data ();
	}
}