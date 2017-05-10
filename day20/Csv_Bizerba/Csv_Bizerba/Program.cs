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
using System.Diagnostics; // wegen Conditional


namespace Csv_Bizerba
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			//CreateSQLiteDatabase();
			//CreateTableSQLiteDatabase();
			
			DeleteAllDataRows("MELDE_PSS");
			DeleteAllDataRows("BELEGNUMMER_UNIQUE");
			
			ReadBizerbaFile ();
			DeleteSendDataRows();
			
			FillTableBELEGNUMMER_UNIQUE();
			
			
		}
		
		static void CreateSQLiteDatabase()
		{
			// SQLiteConnection m_dbConnection;
			SQLiteConnection.CreateFile("Bizerba.sqlite");
			
		}
		
		// Tabellen anlegen.
		static void CreateTableSQLiteDatabase()
		{
			SQLiteConnection m_dbConnection;
		
			
			m_dbConnection = new SQLiteConnection("Data Source=Bizerba.sqlite;Version=3;");
			m_dbConnection.Open();
			
			
			using (var command = new SQLiteCommand(m_dbConnection) )
            {
            	using (var transaction = m_dbConnection.BeginTransaction())
            	{
            	command.CommandText = "CREATE TABLE `MELDE_PSS` ( `PREFIX` TEXT, `BELEGNUMMER` TEXT, `ZUSATZFELD` TEXT, `VERSANDCODE` TEXT, `VERSANDTAG` TEXT, `GEWICHT` NUMERIC, `PREIS` NUMERIC, `VERFOLGUNGSNUMMER` TEXT )";
				command.ExecuteNonQuery();
				transaction.Commit();
            	}
            	
            	using (var transaction = m_dbConnection.BeginTransaction())
            	{
            	command.CommandText = "CREATE TABLE 'BELEGNUMMER_UNIQUE' ( `BELEGNUMMER` TEXT NOT NULL, `ANZAHL` INTEGER, `GEWICHT` NUMERIC, `PREIS` NUMERIC, PRIMARY KEY(`BELEGNUMMER`) )";
				command.ExecuteNonQuery();
				transaction.Commit();
            	}
            }
			m_dbConnection.Close();
		}
		
		// Delete all Rows.
		static void DeleteAllDataRows(string TableName)
		{
			SQLiteConnection m_dbConnection;
			
			m_dbConnection = new SQLiteConnection("Data Source=Bizerba.sqlite;Version=3;");
			m_dbConnection.Open();
			            
            using (var command = new SQLiteCommand(m_dbConnection) )
            {
            	using (var transaction = m_dbConnection.BeginTransaction())
            	{
            	command.CommandText = "DELETE FROM " + TableName;
				command.ExecuteNonQuery();
				transaction.Commit();
            	}
            }
            m_dbConnection.Close();
            
		}
		
		// SEND-Rows löschen.
		static void DeleteSendDataRows()
		{
			SQLiteConnection m_dbConnection;
			
			m_dbConnection = new SQLiteConnection("Data Source=Bizerba.sqlite;Version=3;");
			m_dbConnection.Open();
			            
            using (var command = new SQLiteCommand(m_dbConnection) )
            {
            	using (var transaction = m_dbConnection.BeginTransaction())
            	{
            	command.CommandText = "DELETE FROM MELDE_PSS where PREFIX='SEND';";
				command.ExecuteNonQuery();
				transaction.Commit();
            	}
            }
            m_dbConnection.Close();
            
		}
		
		
		// Belegnummer und Anzahl schreiben.
		static void FillTableBELEGNUMMER_UNIQUE()
		{
			SQLiteConnection m_dbConnection;
			
			m_dbConnection = new SQLiteConnection("Data Source=Bizerba.sqlite;Version=3;");
			m_dbConnection.Open();
			            
            using (var command = new SQLiteCommand(m_dbConnection) )
            {
            	using (var transaction = m_dbConnection.BeginTransaction())
            	{

            	command.CommandText = "INSERT INTO BELEGNUMMER_UNIQUE (BELEGNUMMER, ANZAHL) " +
            	"SELECT BELEGNUMMER, count(*) as ANZAHL FROM MELDE_PSS GROUP BY BELEGNUMMER HAVING COUNT(*);";
				command.ExecuteNonQuery();
				transaction.Commit();
            	}
            }
            m_dbConnection.Close();   
		} 
		
		// Gewicht und Preis berechnen.
		static void UpdateTableBELEGNUMMER_UNIQUE()
		{
			SQLiteConnection m_dbConnection;
			
			m_dbConnection = new SQLiteConnection("Data Source=Bizerba.sqlite;Version=3;");
			m_dbConnection.Open();
			            
            using (var command = new SQLiteCommand(m_dbConnection) )
            {
            	using (var transaction = m_dbConnection.BeginTransaction())
            	{
            	// command.CommandText = "" 
            	command.ExecuteNonQuery();
				transaction.Commit();
            	}
           
            }
            m_dbConnection.Close();         
		} 
		
		
		static void FillTableMELDE_PSS(ref DataTable data)
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
		
		Debug_Print(ref dtData);
  		FillTableMELDE_PSS(ref dtData);	
  	
	  }
		
		[Conditional ("DEBUG")]
		static void Debug_Print(ref DataTable dtData)
		{
			// Debug-Ausgabe
			foreach (DataRow row in dtData.Rows)
			{
    	 	foreach (var item in row.ItemArray)
    	   	{
              	
    	 		if (item.ToString() == "")
           	 	{
           	 	Debug.Write("- ");
           	 	}
           	 	else
           	 	{
           	 	Debug.Write(item+" ");	
           	 	}
    	   	 }
    	   	Debug.WriteLine(""); 
		}
			
		}
	}
}

