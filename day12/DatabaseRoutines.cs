using System;
using System.Data;
using System.Data.SqlClient;

// Datenbank-Routine in einer Klasse
// untergebracht.
//
// Compilieren mit:
// mcs DatabaseRoutines.cs -r:System.Data.dll

interface IDatabaseAccess
{
	void Connect();
	
}

namespace DatabaseRoutines
{

public class DatabaseAccess : IDatabaseAccess
{
		string connectionString = "Server=192.168.0.67;Database=PASS;User ID=xxxxx;Password=xxxxx;";
		IDbConnection dbcon;

		public void Connect()
		{
			using (dbcon = new SqlConnection(connectionString)) 
			{
				dbcon.Open();

				using (IDbCommand dbcmd = dbcon.CreateCommand()) 
				{

					string sql = "SELECT land, bezeichnung FROM laender";
					dbcmd.CommandText = sql;

					using (IDataReader reader = dbcmd.ExecuteReader()) 
					{
						while(reader.Read())
						{
							string land = (string) reader["land"];
							string bezeichnung = (string) reader["bezeichnung"];
							Console.WriteLine("Name: " + land + " " + bezeichnung);
						}
					}
				}
			}
		}
}
}



public class Program
{
	static void Main ()
	{
		DatabaseRoutines.DatabaseAccess con;

		con = new DatabaseRoutines.DatabaseAccess();
		con.Connect();


	}
}