/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 03.08.2017
 * Time: 11:05
 */
using System;
using System.Data;
using System.Data.SQLite;

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
        
         public DataSet DoQuery(string sql)
        {
            var cmd = new SQLiteCommand(connection);
            cmd.CommandText = sql;
 
            return DoQuery(cmd);
        }
        
        public DataSet DoQuery(SQLiteCommand cmd)
        {
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(ds, "Result");

            return ds;
        }
            
         /*
         Command API
         */
         
     
        public DataSet TestQuery()
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
        
        
    
	}
}
