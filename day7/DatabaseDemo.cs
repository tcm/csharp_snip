using System;
using System.Data;
using System.Data.SqlClient;


public class DatabaseDemo
{
		static void Main()
		{

		string connectionString =
			"Server=192.168.0.67;" +
				"Database=PASS;" +
				"User ID=xxxx;" +
				"Password=xxxxxxx;";

		IDbConnection dbcon;

		using (dbcon = new SqlConnection(connectionString)) {
			dbcon.Open();
			using (IDbCommand dbcmd = dbcon.CreateCommand()) {

				string sql = "SELECT land, bezeichnung FROM laender";
				dbcmd.CommandText = sql;

				using (IDataReader reader = dbcmd.ExecuteReader()) {
					while(reader.Read()) {
						string land = (string) reader["land"];

						string bezeichnung = (string) reader["bezeichnung"];
						Console.WriteLine("Name: " +
						                  land + " " + bezeichnung);
					}
				}
			}
		}

		}
}


