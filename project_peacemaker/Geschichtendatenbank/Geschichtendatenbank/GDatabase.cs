﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Win32;
using System.Xml;
using System.Reflection;
using System.IO;
using FirebirdSql.Data.FirebirdClient;

namespace Geschichtendatenbank
{
    public class GDatabase
    {
        private string dataSource = "";
        private string database = "";
        private string userID = "SW_USER";
        private string password = "pass";

        private FbConnection connection;
        protected FbTransaction transaction;		/// Stores a reference to the database transaction.
        protected int txNestLevel;					/// Holds the nesting level of transaction requests.
        private string lastError = "";


        public FbConnection Connection
        {
            get
            {
                if (connection == null)
                    throw new InvalidOperationException("No valid connection.");

                if (connection.State != ConnectionState.Open)
                    throw new InvalidOperationException("Connection not open.");

                return this.connection;
            }
        }

        public FbCommand CreateCommand()
        {
            FbCommand cmd = Connection.CreateCommand();
            cmd.Transaction = transaction;
            return cmd;
        }

        public string LastError
        {
            get { return this.lastError; }
        }

        public bool Connect()
        {
            bool result = false;

            try
            {

                LoadIniXML();

                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = this.dataSource;
                cs.Database = this.database;
                cs.UserID = this.userID;
                cs.Password = this.password;
                cs.Charset = "NONE";

                this.connection = new FbConnection(cs.ToString());
                this.connection.Open();

                result = true;
            }
            catch (FbException ex)
            {
                switch (ex.ErrorCode)
                {
                    case 335544721: // network_error
                        this.lastError = string.Format("Es konnte keine Verbindung zum angegebenen Datenbank-Server hergestellt werden.\n\nFehlermeldung: {0}", ex.Message);
                        break;
                    case 335544344: // io_error
                        this.lastError = string.Format("Die angegebene Datenbankdatei auf dem Datenbank-Server konnte nicht geöffnet werden.\n\nFehlermeldung: {0}", ex.Message);
                        break;
                    default:
                        this.lastError = string.Format("Allgemeiner Datenbankfehler: {0}", ex.Message);
                        break;
                }

                if (this.connection != null)
                    this.connection.Close();

                this.connection = null;
            }
            catch (Exception ex2)
            {
                this.lastError = string.Format("Allgemeiner Fehler beim Verbindungsaufbau: {0}", ex2.Message);

                if (this.connection != null)
                    this.connection.Close();

                this.connection = null;
            }

            return result;
        }

        public bool Disconnect()
        {
            bool result = false;

            try
            {
                if (this.connection != null)
                    this.connection.Close();

                this.connection = null;

                result = true;
            }
            catch (Exception ex)
            {
                this.lastError = string.Format("Allgemeiner Fehler beim Verbindungsabbau: {0}", ex.Message);

                this.connection = null;
            }

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

        private void LoadIniXML()
        {
            string applicationFilePath = Assembly.GetExecutingAssembly().Location;
            string applicationPath = Path.GetDirectoryName(applicationFilePath);
            string iniXMLFilePath = applicationPath + "\\" + "Verbindung.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(iniXMLFilePath);

            if (doc.HasChildNodes)
            {
                XmlNode serverNode = doc.SelectSingleNode("//Server");
                XmlNode databaseNode = doc.SelectSingleNode("//Database");

                if (serverNode != null)
                    this.dataSource = serverNode.InnerText;

                if (databaseNode != null)
                    this.database = databaseNode.InnerText;
            }
        }


        public DataSet DoQuery(string sql)
        {
            FbCommand cmd = CreateCommand();
            cmd.CommandText = sql;

            return DoQuery(cmd);
        }

        public DataSet DoQuery(FbCommand cmd)
        {
            DataSet ds = new DataSet();
            FbDataAdapter da = new FbDataAdapter(cmd);
            da.Fill(ds, "Result");

            return ds;
        }

        public int DoExecuteCommand(FbCommand cmd)
        {

            return cmd.ExecuteNonQuery();
        }

        public object DoExecuteScalar(FbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }

       
        /* Command API */

        public DataSet QueryMainFormUebersicht()
        {
            return DoQuery("SELECT * FROM V_UEBERSICHT");
        }

        public DataSet QueryMainFormUebersicht_Filter_Titel(string Titel)
        {
            return DoQuery("SELECT * FROM V_UEBERSICHT WHERE TITEL LIKE '%" + Titel + "%'");
        }

        public DataSet QueryMainFormUebersicht_Filter_Jahr(string Entstehungsjahr)
        {
            string sql = "SELECT * FROM V_UEBERSICHT WHERE ENTSTEHUNGSJAHR = @Entstehungsjahr";

            FbCommand cmd = CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Entstehungsjahr", Entstehungsjahr);
            return DoQuery(cmd);  
        }

        public DataSet QueryEditGeschichteDialog(int Geschichte_ID)
        {
            string sql = "SELECT * FROM GESCHICHTE WHERE ID  = @Geschichte_ID;";

            FbCommand cmd = CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Geschichte_ID", Geschichte_ID);
            return DoQuery(cmd);
        }

        public DataSet QueryMainFormFiguren(int Geschichte_ID)
        {
            string sql = "SELECT VORNAME, NAME FROM V_FIGUREN WHERE GESCHICHTE_ID  = @Geschichte_ID;";

            FbCommand cmd = CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Geschichte_ID", Geschichte_ID);
            return DoQuery(cmd);
        }

        public int InsertGeschichte(string Bezeichnung, short Entstehungsjahr, int Autor_ID, int Genre_ID, int Land_ID, string Text )
        {
            int Geschichte_ID = 0;

            BeginTransaction();
            try
            {
                Geschichte_ID = GetMaxIDGeschichte();

                string sql = "INSERT INTO GESCHICHTE (ID, AUTOR_ID, LAND_ID, GENRE_ID, BEZEICHNUNG, ENTSTEHUNGSJAHR, TEXT) VALUES (@ID, @AUTOR_ID, @LAND_ID, @GENRE_ID, @BEZEICHNUNG, @ENTSTEHUNGSJAHR, @TEXT)";

                FbCommand cmd = CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Geschichte_ID);
                cmd.Parameters.AddWithValue("@BEZEICHNUNG", Bezeichnung);
                cmd.Parameters.AddWithValue("@ENTSTEHUNGSJAHR", Entstehungsjahr);
                cmd.Parameters.AddWithValue("@AUTOR_ID", Autor_ID);
                cmd.Parameters.AddWithValue("@GENRE_ID", Genre_ID);
                cmd.Parameters.AddWithValue("@LAND_ID", Land_ID);
                cmd.Parameters.AddWithValue("@TEXT", Text);
                
                DoExecuteCommand(cmd);

                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }

            return Geschichte_ID;
        }

        public DataSet QueryAutorComboBox()
        {
            string sql = "SELECT ID, NAME FROM AUTOR;";

            FbCommand cmd = CreateCommand();
            cmd.CommandText = sql;
            return DoQuery(cmd);
        }

        public DataSet QueryGenreComboBox()
        {
            string sql = "SELECT ID, BEZEICHNUNG FROM GENRE;";

            FbCommand cmd = CreateCommand();
            cmd.CommandText = sql;
            return DoQuery(cmd);
        }

        public DataSet QueryLandComboBox()
        {
            string sql = "SELECT ID, BEZEICHNUNG FROM LAND;";

            FbCommand cmd = CreateCommand();
            cmd.CommandText = sql;
            return DoQuery(cmd);
        }

        /* API Helpers */

        protected int GetMaxIDGeschichte()
        {
            int result = -1;

            FbCommand cmd = CreateCommand();
            cmd.CommandText = "SELECT GEN_ID(GESCHICHTE_ID_INC, 1) FROM RDB$DATABASE";
            result = Convert.ToInt32(DoExecuteScalar(cmd));

            return result;
        }
    }
 }


