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
			// CreateSQLiteDatabase();
			// CreateTableSQLiteDatabase();
			// FillTableSQLiteDatabase();
			
			ReadBizerbaFile ();
			
			
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

            sql = "CREATE TABLE `MELDE_PSS` ( `PREFIX` TEXT, `BELEGNUMMER` TEXT, `ZUSATZFELD` TEXT, `VERSANDCODE` TEXT, `VERSANDTAG` TEXT, `GEWICHT` NUMERIC, `PREIS` NUMERIC, `VERFOLGUNGSNUMMER` TEXT )";
			var command = new SQLiteCommand(sql, m_dbConnection);
			command.ExecuteNonQuery();
		}
		
		static void FillTableSQLiteDatabase(string inPrefix, string inBelegnummer, string inZusatzfeld, string inVersandcode, string inVersandtag)
		{
			SQLiteConnection m_dbConnection;
			string sql;
			
			m_dbConnection = new SQLiteConnection("Data Source=Bizerba.sqlite;Version=3;");
			m_dbConnection.Open();
			
		    sql = "INSERT INTO `MELDE_PSS` (PREFIX, BELEGNUMMER, ZUSATZFELD, VERSANDCODE, VERSANDTAG) VALUES ('" + inPrefix + "','" + inBelegnummer + "','" + inZusatzfeld + "','" + inVersandcode + "','" + inVersandtag + "')";
            Console.WriteLine(sql);
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

                    Console.Write(row[0]);
                    Console.Write(row[1]);
                    Console.Write(row[2]);
                    Console.Write(row[3]);
                    FillTableSQLiteDatabase(row[0], row[1], row[2], row[3], row[4]);

                    /*for (int i = 0; i < row.Count; i++ )
                    {
                        Console.Write(row[i]);
                        Console.Write(" ");
                    } */
                        /* foreach (string s in row.)
                        {
                        Console.Write(s);
                        Console.Write(" ");
                        } */
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
