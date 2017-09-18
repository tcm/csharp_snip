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
			string dbname = "Test.sqlite";
			
			// CreateSQLiteDatabase(dbname);
			
			DbSqlite database = new DbSqlite("Data Source=" + dbname +";Version=3;");
			var dtData = new DataTable();
			
			
            if (database.Connect() == false)
            {
            	Console.WriteLine("Datenbankverbindung fehlgeschlagen!");
            }
            else
            {
            	// database.CreateSQLiteTable();
            	
            	database.DeleteAllRows("MELDE_PSS");
            	database.DeleteAllRows("BELEGNUMMER_UNIQUE");
            	
            	ReadFile(ref dtData);
            	
            	database.FillTable(ref dtData);
            	database.DeleteSendRows("MELDE_PSS");
            	
            	// Hier wird in einer Hilfstabelle für jede Belegnummer
            	// genau ein Datensatz erzeugt.
            	database.FillHelpTable();
            	
            	database.UpdateHelpTable();
            	
            	database.Disconnect();
            }	
			
		}		
		
		// Gewicht und Preis berechnen.
		static void UpdateTableBELEGNUMMER_UNIQUE()
		{
			SQLiteConnection m_dbConnection;
			
			m_dbConnection = new SQLiteConnection("Data Source=Bizerba.sqlite;Version=3;");
			m_dbConnection.Open();
			
			var rs1 = new SQLiteDataAdapter("select BELEGNUMMER, ANZAHL from BELEGNUMMER_UNIQUE", m_dbConnection); 
			var dt1 = new DataTable();
			rs1.Fill(dt1);
			Debug_Print_DT(ref dt1, "BELEGNUMMER_UNIQUE:");
			
			 // Über alle Datensätze von BELEGNUMMER_UNIQUE iterieren.
			foreach (DataRow row1 in dt1.Rows)
			{
				var sql = "select BELEGNUMMER, SUM(GEWICHT) AS GEWICHT, SUM(PREIS) AS PREIS from MELDE_PSS where BELEGNUMMER = '" + row1[0] + "'";
				var rs2 = new SQLiteDataAdapter(sql , m_dbConnection); 
			    var dt2 = new DataTable();
			    rs2.Fill(dt2);
			    
			    Debug_Print_DT(ref dt2, "GEWICHT und PREIS:");
			   
			    // Daten in BELEGNUMMER_UNIQUE schreiben.
			    // Preis und Gewicht aktualisieren.
			    using (var command = new SQLiteCommand(m_dbConnection) )
            	{
            		using (var transaction = m_dbConnection.BeginTransaction())
            		{
            		string Gewicht;
            		string Preis;
            		
            		Gewicht = Convert.ToString(dt2.Rows[0][1]).Replace(",",".");
            		Preis = Convert.ToString(dt2.Rows[0][2]).Replace(",",".");
            		
      			    var sql2 = "UPDATE BELEGNUMMER_UNIQUE SET GEWICHT="+ Gewicht +", PREIS=" + Preis + " WHERE BELEGNUMMER = '" +row1[0]+ "'";
      			    Debug.Print(sql2);
            	    command.CommandText = sql2;
					command.ExecuteNonQuery();
					transaction.Commit();
            		}
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
	        	
	        	var insertSQL = new SQLiteCommand("INSERT INTO `MELDE_PSS` (PREFIX, BELEGNUMMER, ZUSATZFELD, VERSANDCODE, VERSANDTAG, GEWICHT, PREIS, VERFOLGUNGSNUMMER) VALUES (@par0, @par1, @par2, @par3, @par4, @par5, @par6, @par7)", m_dbConnection);	
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
		
		
		static void ReadFile(ref DataTable dtData)
		{
		var oFH = new CSD.clsFileHandler(@"c:\pss\melde_1.txt");
		
		oFH.Delimiter= ";";
		oFH.HeaderRow = -1;
		dtData = oFH.CSVToTable();
		
		Debug_Print_DT(ref dtData, "MELDE_PSS:");
  		
	  }
			
		[Conditional ("DEBUG")]
		static void Debug_Print_DT(ref DataTable dtData, string comment)
		{
			// Debug-Ausgabe
			Debug.WriteLine(comment);
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
			Debug.WriteLine("");
			
		}
		}			
			
	}
  


