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
  


