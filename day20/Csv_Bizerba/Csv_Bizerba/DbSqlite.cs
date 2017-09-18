/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 03.08.2017
 * Time: 11:05
 */
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics; // wegen Conditional

namespace Csv_Bizerba
{
	/// <summary>
	/// Database-Routines for SQLite.
	/// </summary>
	public class DbSqlite
	{
     	private string dataSource = "";
     	private SQLiteConnection connection;
        protected SQLiteTransaction transaction;	// Stores a reference to the database transaction.
        protected int txNestLevel;					// Holds the nesting level of transaction requests.
  
		public DbSqlite(string indataSource)
		{
			this.dataSource = indataSource;
		}
		
		
        public SQLiteConnection Connection
        {
            get
            {
                if (connection == null)
                    throw new InvalidOperationException("No valid connection.");

                return this.connection;
            }
        }
        
        
        public SQLiteCommand CreateCommand()
        {
            SQLiteCommand cmd = Connection.CreateCommand();
            cmd.Transaction = transaction;
            return cmd;
        }
		
        // Verbindung aufbauen.
        public bool Connect()
        {
        	bool result = false;
           
      		try
	  		{
       		 	this.connection = new SQLiteConnection(dataSource);
				this.connection.Open();
				result = true;
       		}
			catch(SQLiteException ex)
			{
    			SQLiteErrorCode code = ex.ErrorCode;
			}
		
        	return result;
        }
        
        // Verbindung abbauen.
        public bool Disconnect()
        {
           	 bool result = false;

           	 this.connection.Close();
           	 this.connection = null;

          	 result = true;
          	 
          	 return result;
		}
        
         public int BeginTransaction()
        {
          if (connection.State != ConnectionState.Open)
                throw new InvalidOperationException("Connection not open.");

            ++txNestLevel;

            if (transaction == null)
                transaction = connection.BeginTransaction();

            return txNestLevel; 
         
        }

        public void RollbackTransaction()
        {
            if (transaction == null)
                throw new InvalidOperationException("No active transaction.");

            if (--txNestLevel == 0)
            {
                transaction.Rollback();
                transaction = null;
            } 
        }
        
        public void CommitTransaction()
        {
            if (transaction == null)
                throw new InvalidOperationException("No active transaction.");

            if (--txNestLevel == 0)
            {
                transaction.Commit();
                transaction = null;
            } 
        }
        
         public DataTable DoQuery(string sql)
        {
            var cmd = new SQLiteCommand(connection);
            cmd.CommandText = sql;
 
            return DoQuery(cmd);
        }
        
        public DataTable DoQuery(SQLiteCommand cmd)
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
            
         /*
         Command API
         */
         
     
        public DataTable TestQuery()
        {
            return DoQuery("SELECT * FROM MELDE_PSS");  
        }
        
        public void CreateSQLiteTable()
        {
        	BeginTransaction();
        	try
        	{
        		SQLiteCommand cmd = CreateCommand();
        		string sql;
        		
        		/* 1. Tabelle */
        		sql = "CREATE TABLE `MELDE_PSS` ( `PREFIX` TEXT, `BELEGNUMMER` TEXT, `ZUSATZFELD` TEXT, `VERSANDCODE` TEXT, `VERSANDTAG` TEXT, `GEWICHT` NUMERIC, `PREIS` NUMERIC, `VERFOLGUNGSNUMMER` TEXT )";
            	cmd.CommandText = sql;
            	cmd.ExecuteNonQuery();
            	
            	/* 2. Tabelle */
            	sql = "CREATE TABLE 'BELEGNUMMER_UNIQUE' ( `BELEGNUMMER` TEXT NOT NULL, `ANZAHL` INTEGER, `GEWICHT` NUMERIC, `PREIS` NUMERIC, PRIMARY KEY(`BELEGNUMMER`) )";
            	cmd.CommandText = sql;
            	cmd.ExecuteNonQuery();
            	
            	CommitTransaction();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            } 
         
        }
        
        public void DeleteAllRows( string tablename )
        {
        	BeginTransaction();
        	try
        	{
        		SQLiteCommand cmd = CreateCommand();
        		string sql;
        		
        		/* Alle Datensätze löschen. */
        		sql =  "DELETE FROM " + tablename;
            	cmd.CommandText = sql;
            	cmd.ExecuteNonQuery();
            	CommitTransaction();
        	}
        	catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            } 
        	
        }
        
        public void DeleteSendRows( string tablename )
        {
        	BeginTransaction();
        	try
        	{
        		SQLiteCommand cmd = CreateCommand();
        		string sql;
        		
        		/* Alle Datensätze löschen. */
        		sql =   "DELETE FROM " + tablename +" where PREFIX='SEND'";
            	cmd.CommandText = sql;
            	cmd.ExecuteNonQuery();
            	CommitTransaction();
        	}
        	catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            } 
        	
        }
        
        public void FillTable( ref DataTable data )
        {
        	
        	BeginTransaction();
        	try
        	{
        	   SQLiteCommand cmd = CreateCommand();
        	   string sql;
        		
        	  /*  Über alle Datensätze der DataTable iterieren und in die Tabelle einfügen. */
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
	        	
	        		sql = "INSERT INTO `MELDE_PSS` (PREFIX, BELEGNUMMER, ZUSATZFELD, VERSANDCODE, VERSANDTAG, GEWICHT, PREIS, VERFOLGUNGSNUMMER) VALUES (@par0, @par1, @par2, @par3, @par4, @par5, @par6, @par7)";
	        		cmd.CommandText = sql;
	        		cmd.Parameters.AddWithValue("@par0", Prefix);
	        		cmd.Parameters.AddWithValue("@par1", Belegnummer);
	        		cmd.Parameters.AddWithValue("@par2", Zusatzfeld);
	        		cmd.Parameters.AddWithValue("@par3", Versandcode);
	        		cmd.Parameters.AddWithValue("@par4", Versandtag);
	        		cmd.Parameters.AddWithValue("@par5", Gewicht);
	        		cmd.Parameters.AddWithValue("@par6", Preis);
	          		cmd.Parameters.AddWithValue("@par7", Verfolgungsnummer);
	          		
	          		cmd.ExecuteNonQuery();
        	  }
        	  CommitTransaction();
        	}
        	catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            } 
        }
        
        public void FillHelpTable()
        {
        	BeginTransaction();
        	try
        	{
        		SQLiteCommand cmd = CreateCommand();
        		string sql;
        		
        		/* Für jede Belegnummer genau einen Datensatz erzeugen. */
        		sql = "INSERT INTO BELEGNUMMER_UNIQUE (BELEGNUMMER, ANZAHL) " +
        			"SELECT BELEGNUMMER, count(*) as ANZAHL FROM MELDE_PSS GROUP BY BELEGNUMMER HAVING COUNT(*)";
            	cmd.CommandText = sql;
            	cmd.ExecuteNonQuery();
            	CommitTransaction();
        	}
        	catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            } 
        	
        }
        
        public void UpdateHelpTable()
        {
        	var dt1 =  DoQuery("SELECT BELEGNUMMER, ANZAHL from BELEGNUMMER_UNIQUE");  
        	// Print_DT(ref dt1, "BELEGNUMMER_UNIQUE:");
        	
        	 // Über alle Datensätze von BELEGNUMMER_UNIQUE iterieren.
			foreach (DataRow row in dt1.Rows)
			{
				Debug.WriteLine(row[0]); // BELEGNUMMER
			}
        }
        
        [Conditional ("DEBUG")]
        void Print_DT(ref DataTable dtData, string comment)
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
			
		}
    
	}
}
