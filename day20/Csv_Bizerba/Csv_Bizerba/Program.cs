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
		
		static void FillTableSQLiteDatabase(DataTable data)
		{
			SQLiteConnection m_dbConnection;
			
			m_dbConnection = new SQLiteConnection("Data Source=Bizerba.sqlite;Version=3;");
			m_dbConnection.Open();

	      
            SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO `MELDE_PSS` (PREFIX, BELEGNUMMER, ZUSATZFELD, VERSANDCODE, VERSANDTAG, GEWICHT, PREIS, VERFOLGUNGSNUMMER) VALUES (@par1, @par2, @par3, @par4, @par5, @par6, @par7, @par8)", m_dbConnection);
            /* insertSQL.Parameters.AddWithValue("@par1", data.Prefix);
            insertSQL.Parameters.AddWithValue("@par2", data.Belegnummer);
            insertSQL.Parameters.AddWithValue("@par3", data.Zusatzfeld);
            insertSQL.Parameters.AddWithValue("@par4", data.Versandcode);
            insertSQL.Parameters.AddWithValue("@par5", data.Versandtag);
            insertSQL.Parameters.AddWithValue("@par6", data.Gewicht);
            insertSQL.Parameters.AddWithValue("@par7", data.Preis);
            insertSQL.Parameters.AddWithValue("@par8", data.Verfolgungsnummer); */

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
		var dtData = new DataTable();
		var oFH = new CSD.clsFileHandler(@"c:\pss\melde_1.txt");
		
		oFH.Delimiter= ";";
		oFH.HeaderRow = -1;
		dtData = oFH.CSVToTable();
		
	
  		foreach (DataRow row in dtData.Rows)
    	 {
    	   foreach (var item in row.ItemArray)
    	   {
           	 Console.WriteLine("Value:"+item);
    	   }
    	 }
		
		
	/*	foreach ( DataRow dr in dtData.Rows )
		{
    		string name = dr["columnname"].ToString();
		} */
			
			
		
		
		
		}
	}
}

