// Compilieren mit : mcs DatabaseDemo_2.cs -r:System.Data.dll

using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace TestSqlClientAdapter {
	public class Test {
		static SqlConnection con;
		static SqlTransaction trans;
		
		public static void Main (string[] args)
		{
			Console.WriteLine("Apapter Test Begin...");
			using (con = new SqlConnection(
				"server=192.168.0.67;" +
				"database=TESTDATENBANK;" +
				"user id=xxxx;" +
				"password=xxxxxxxxxx")) {
				con.Open();
				
				Setup();
				
				trans = con.BeginTransaction();
				Insert();
				trans.Commit();
				
				trans = con.BeginTransaction();
				Update();
				trans.Commit();
				
				trans = con.BeginTransaction();
				Delete();
				trans.Commit();
				
			}
			Console.WriteLine("Done.");
		}
		
		static void Setup()
		{
			using (SqlCommand cmd = con.CreateCommand()) {
				cmd.Transaction = trans;
				cmd.CommandText =
					"DROP TABLE MONO_TEST_ADAPTER1";
				
				try { cmd.ExecuteNonQuery();
				} catch(SqlException e) { }
				
				cmd.CommandText =
					"CREATE TABLE MONO_TEST_ADAPTER1 (" +
						" num_value int primary key," +
						" txt_value varchar(64))";
				cmd.ExecuteNonQuery();
			}
		}
		
		static void Insert()
		{
			Console.WriteLine("Insert...");
			
			SqlDataAdapter adapter = new SqlDataAdapter(
				"SELECT * FROM MONO_TEST_ADAPTER1", con);
			adapter.MissingSchemaAction  = MissingSchemaAction.AddWithKey;
			adapter.SelectCommand.Transaction = trans;
			SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
			
			DataSet ds = new DataSet();
			adapter.Fill(ds,"MONO_TEST_ADAPTER1");
			
			DataRow row = ds.Tables["MONO_TEST_ADAPTER1"].NewRow();
			row["num_value"] = 3;
			row["txt_value"] = "Value inserted";
			
			ds.Tables["MONO_TEST_ADAPTER1"].Rows.Add(row);
			
			adapter.Update(ds, "MONO_TEST_ADAPTER1");
			
			row = null;
			builder = null;
			adapter = null;
			ds = null;
			
			ReadData(con, "SELECT * FROM MONO_TEST_ADAPTER1");
		}
		
		static void Update()
		{
			Console.WriteLine("Update...");
			
			SqlDataAdapter adapter = new SqlDataAdapter(
				"SELECT * FROM MONO_TEST_ADAPTER1", con);
			adapter.SelectCommand.Transaction = trans;
			SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
			
			DataSet ds = new DataSet();
			adapter.Fill(ds,"MONO_TEST_ADAPTER1");
			
			DataRow row = ds.Tables["MONO_TEST_ADAPTER1"].Rows[0];
			row["txt_value"] = "Value updated";
			
			adapter.Update(ds, "MONO_TEST_ADAPTER1");
			
			row = null;
			builder = null;
			adapter = null;
			ds = null;
			
			ReadData(con, "SELECT * FROM MONO_TEST_ADAPTER1");
			
		}
		
		static void Delete()
		{
			Console.WriteLine("Delete...");
			
			SqlDataAdapter adapter = new SqlDataAdapter(
				"SELECT * FROM MONO_TEST_ADAPTER1", con);
			adapter.SelectCommand.Transaction = trans;
			SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
			
			DataSet ds = new DataSet();
			adapter.Fill(ds,"MONO_TEST_ADAPTER1");
			
			ds.Tables["MONO_TEST_ADAPTER1"].Rows[0].Delete();
			
			adapter.Update(ds, "MONO_TEST_ADAPTER1");
			
			builder = null;
			adapter = null;
			ds = null;
			
			ReadData(con, "SELECT * FROM MONO_TEST_ADAPTER1");
			
		}
		
		private static void ReadData(IDbConnection con, string sql)
		{
			using (IDbCommand cmd = con.CreateCommand()) {
				cmd.Transaction = trans;
				cmd.CommandText = sql;
				using (IDataReader reader = cmd.ExecuteReader()) {
					int rows = 0;
					while(reader.Read()) {
						Console.WriteLine("Value 0: {0}", reader[0]);
						Console.WriteLine("Value 0: {0}", reader[1]);
						rows++;
					}
					Console.WriteLine("Rows retrieved: {0}", rows);
				}
			}
		}
	}
}
