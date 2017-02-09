/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 15.12.2016
 * Time: 10:08
 * 
 */
using System;
using CSD;
using System.Data;
using System.Data.SQLite;


namespace Csv_Bizerba
{
	class Program
	{
		public static void Main(string[] args)
		{
			// CreateSQLiteDatabase();
			// CreateTableSQLiteDatabase();
			
			
			ReadBizerbaFile ();
		
			
			//Console.Write("Press any key to continue . . . ");
			//Console.ReadKey(true);
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
		
		static void FillTableSQLiteDatabase(DataTable data)
		{
			SQLiteConnection m_dbConnection;
			
			m_dbConnection = new SQLiteConnection("Data Source=Bizerba.sqlite;Version=3;");
			m_dbConnection.Open();

	        foreach (DataRow row in data.Rows)
    	 	{
	        	string Prefix = row[0].ToString();
	        	string Belegnummer = row[1].ToString();
	        	string Zusatzfeld = row[2].ToString();
	        	string Versandcode = row[3].ToString();
	        	string Versandtag = row[4].ToString(); 
	        
	        	double Gewicht;
	        	double.TryParse(row[5].ToString(), out Gewicht);
	        
	        	double Preis;
	        	double.TryParse(row[6].ToString(), out Preis);
	        	
	        	string Verfolgungsnummer = row[7].ToString();
	        	
	        	SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO `MELDE_PSS` (PREFIX, BELEGNUMMER, ZUSATZFELD, VERSANDCODE, VERSANDTAG, GEWICHT, PREIS, VERFOLGUNGSNUMMER) VALUES (@par0, @par1, @par2, @par3, @par4, @par5, @par6, @par7)", m_dbConnection);	
	        	insertSQL.Parameters.AddWithValue("@par0", Prefix);
	        	insertSQL.Parameters.AddWithValue("@par1", Belegnummer);
	        	insertSQL.Parameters.AddWithValue("@par2", Zusatzfeld);
	        	insertSQL.Parameters.AddWithValue("@par3", Versandcode);
	        	insertSQL.Parameters.AddWithValue("@par4", Versandtag);
	        	insertSQL.Parameters.AddWithValue("@par5", Gewicht);
	        	insertSQL.Parameters.AddWithValue("@par6", Preis);
	            insertSQL.Parameters.AddWithValue("@par7", Verfolgungsnummer);
	        	
	        	try
            	{
                	insertSQL.ExecuteNonQuery();
            	}
            	catch (Exception ex)
            	{
                	throw new Exception(ex.Message);
            	}    
	        }
    	 
		}
		
		static void ReadBizerbaFile()
		{
		var dtData = new DataTable();
		var oFH = new CSD.clsFileHandler(@"c:\pss\melde_1.txt");
		
		oFH.Delimiter= ";";
		oFH.HeaderRow = -1;
		dtData = oFH.CSVToTable();
		
		// Debug-Ausgabe
		foreach (DataRow row in dtData.Rows)
		{
    	 foreach (var item in row.ItemArray)
    	   {
              	
           	 if (item == "")
           	 {
           	 System.Diagnostics.Debug.Write("- ");
           	 }
           	 else
           	 {
           	 System.Diagnostics.Debug.Write(item+" ");	
           	 }
    	   }
    	   System.Diagnostics.Debug.WriteLine(""); 
		}
		
  		FillTableSQLiteDatabase(dtData);	
  		// FillTableSQLiteDatabase_neu(dtData);	
	  }
	}
}

