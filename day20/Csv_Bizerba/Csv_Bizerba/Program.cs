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
		
		static void FillTableSQLiteDatabase(PssData data)
		{
			SQLiteConnection m_dbConnection;
			
			m_dbConnection = new SQLiteConnection("Data Source=Bizerba.sqlite;Version=3;");
			m_dbConnection.Open();

	      
            SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO `MELDE_PSS` (PREFIX, BELEGNUMMER, ZUSATZFELD, VERSANDCODE, VERSANDTAG, GEWICHT, PREIS, VERFOLGUNGSNUMMER) VALUES (@par1, @par2, @par3, @par4, @par5, @par6, @par7, @par8)", m_dbConnection);
            insertSQL.Parameters.AddWithValue("@par1", data.Prefix);
            insertSQL.Parameters.AddWithValue("@par2", data.Belegnummer);
            insertSQL.Parameters.AddWithValue("@par3", data.Zusatzfeld);
            insertSQL.Parameters.AddWithValue("@par4", data.Versandcode);
            insertSQL.Parameters.AddWithValue("@par5", data.Versandtag);
            insertSQL.Parameters.AddWithValue("@par6", data.Gewicht);
            insertSQL.Parameters.AddWithValue("@par7", data.Preis);
            insertSQL.Parameters.AddWithValue("@par8", data.Verfolgungsnummer);

            try
            {
                insertSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }    
         
		}
		
		static void ReadBizerbaFile()
		{
		try
		{
			// Read data from CSV file
			using (var reader = new CsvFileReader(@"c:\pss\melde_1.txt"))
			{
				var row = new CsvRow();
                var csvLine = new PssData();

				while (reader.ReadRow(row))
				{
				
					 // Bildschirm-Ausgabe
					for ( int i = 0 ; i < row.Count; i++ )
					{
						Console.Write(row[i] + ";"); 
						
					}       
                    Console.WriteLine();
                
                   	csvLine.Prefix = row[0];
                   	csvLine.Belegnummer = row[1];
                   	csvLine.Zusatzfeld = row[2];
                   	csvLine.Versandcode = row[3];
                   	csvLine.Versandtag = row[4];
                   	csvLine.Gewicht = Convert.ToDecimal(row[5]);
                   	csvLine.Preis = Convert.ToDecimal(row[6]);
                   	// csvLine.Verfolgungsnummer = row[7]; 

                   FillTableSQLiteDatabase(csvLine);
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
