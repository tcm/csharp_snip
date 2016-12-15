/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 15.12.2016
 * Time: 10:08
 * 
 */
using System;
using ReadWriteCsv;
using System.Data.SQLite;

namespace Csv_Bizerba
{
	class Program
	{
		public static void Main(string[] args)
		{
			//CreateSQLiteDatabase();
			//CreateTableSQLiteDatabase();
			FillTableSQLiteDatabase();
			
			// ReadBizerbaFile ();
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		static void CreateSQLiteDatabase()
		{
			SQLiteConnection m_dbConnection;
			SQLiteConnection.CreateFile("Bizerba.sqlite");
			
		}
		
		static void CreateTableSQLiteDatabase()
		{
			SQLiteConnection m_dbConnection;
			string sql;
			
			m_dbConnection = new SQLiteConnection("Data Source=Bizerba.sqlite;Version=3;");
			m_dbConnection.Open();
			
			sql = "CREATE TABLE highscores (name VARCHAR(20), score INT)";
			var command = new SQLiteCommand(sql, m_dbConnection);
			command.ExecuteNonQuery();
		}
		
		static void FillTableSQLiteDatabase()
		{
			SQLiteConnection m_dbConnection;
			string sql;
			
			m_dbConnection = new SQLiteConnection("Data Source=Bizerba.sqlite;Version=3;");
			m_dbConnection.Open();
			
		    sql = "insert into highscores (name, score) values ('Me2', 10001)";
			var command = new SQLiteCommand(sql, m_dbConnection);
			command.ExecuteNonQuery();
		}
		
		static void ReadBizerbaFile()
		{
		try
		{
			// Read data from CSV file
			using (var reader = new CsvFileReader(@"c:\pss\melde_1.txt"))
			{
				var row = new CsvRow();
				while (reader.ReadRow(row))
				{
					foreach (string s in row)
					{
					Console.Write(s);
					Console.Write(" ");
					}
					Console.WriteLine();
				}
			}
		}
		catch (System.IO.FileNotFoundException)
		{
			Console.WriteLine("File not found!");
		}
		catch (System.IO.DirectoryNotFoundException)
		{
			Console.WriteLine("Directory not found!");
		}
		catch (UnauthorizedAccessException)
		{
			Console.WriteLine("Access denied!");
		}
		catch (Exception e)
		{
			Console.WriteLine("General error!");
			Console.WriteLine(e.Message);
		}
		
		}
		
		
		}
		
		
}
