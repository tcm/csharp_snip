using System;
using System.Data;
using System.Data.SqlClient;

// Datenbank-Routinen in einer Klasse
// untergebracht.
//
// Compilieren mit:
// mcs DatabaseRoutines.cs -r:System.Data.dll

interface IDatabaseAccess
{
	int Connect();
	void Query();
	void Close();
	
}

namespace DatabaseRoutines
{

public class DatabaseAccess : IDatabaseAccess
{
		private string connectionString = "Server=192.168.0.67;Database=PASS;User ID=xxxxx;Password=xxxxx;";
		private IDbConnection dbcon;


		// Verbinden.
		public int Connect()
		{
			try 
			{
				dbcon = new SqlConnection (connectionString);
				dbcon.Open ();
			} 
			catch 
			{
				Console.WriteLine("DB-Connection-Error!");
				return 0;
			}
			return 1;
		}

		// Eine Abfrage losschicken. :-)
		public void Query ()
		{
			IDbCommand dbcmd = dbcon.CreateCommand();

			string sql = "SELECT land, bezeichnung FROM laender";
			dbcmd.CommandText = sql;
					
			IDataReader reader = dbcmd.ExecuteReader();

				
			while( reader.Read() )
			{
				string land = (string) reader["land"];
				string bezeichnung = (string) reader["bezeichnung"];
				Console.WriteLine("Name: " + land + " " + bezeichnung);
			}
					
			
		}

		public void Close ()
		{
			dbcon.Close();
		}
		

}
}

public class Program
{
	static void Main ()
	{
		DatabaseRoutines.DatabaseAccess myquery;

		myquery = new DatabaseRoutines.DatabaseAccess();
		myquery.Connect();
		myquery.Query();
		myquery.Close();


	}
}