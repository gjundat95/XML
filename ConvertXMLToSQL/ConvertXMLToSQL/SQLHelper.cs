using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertXMLToSQL
{
    public class SQLConnectData {

        public static SqlConnection getConnection(string serverName,string dbName)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=" + serverName + ";Initial Catalog=" + dbName + ";Integrated Security=True");
                Debug.Write("Ket noi thanh cong.");
                return conn;
            }
            catch (Exception ex)
            {
                Debug.Write("Khong thanh cong.");
                throw ex;
            }
        }
    }

    public class SQLHelper
    {
        public string serverName = @"DESKTOP-BCRS2OO\SQLEXPRESS";
        public string dbName = "DatabaseDemo";
       // public SQLHelper() { }

        public SQLHelper(string serverName, string dbName) {
            this.serverName = serverName;
            this.dbName = dbName;
        }

        public bool createTable(List<string> listElementName,string tableName) {
            Debug.Write("Crate table.");
            bool isFalse = false;

            if (listElementName.Count > 0 && tableName != null) {
                SqlConnection conn = SQLConnectData.getConnection(serverName,dbName);
                SqlCommand command = conn.CreateCommand();
                string query1 = @"Create table " + tableName + " ( ";
                string query3 = @" );";
                string query2 = "";
                string query = "";
                string temp = "  ntext  NULL,  ";
                foreach (string item in listElementName)
                {
                    query2 += item + temp;
                }
                query = query1 + query2 + query3;
                command.CommandText = query;

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Dispose();
                    conn.Close();
                    isFalse = true;
                }
                catch
                {
                    command.Dispose();
                }
                Debug.Write(query);
            }
            return isFalse;
        }

        public string getQueryCreateTable(List<string> listElementName, string tableName) {
            string query1 = @"CREATE TABLE " + tableName + " ( " ;
            string query3 = @" );";
            string query2 = "";
            string query = "";
            string temp1 = "  NTEXT  NULL,  ";
            string temp2 = "  NTEXT  NULL  ";
            for (int i = 0; i < listElementName.Count; i++)
            {
                if (i < listElementName.Count - 1)
                {
                    query2 += listElementName[i] + temp1;
                }
                else {
                    query2 += listElementName[i] + temp2;
                }
                
            }
            query = query1 + query2 + query3;
            return query + "\n \n";
        }

        public string getQueryInsertTable(List<string> listQuery) {
            string query = "";
            foreach (string item in listQuery)
            {
                query += item + " \n";
            }
            return query; // Query SQL
           
        }

        public bool insertTable(List<string> listQuery) {
            bool isFalse = false;
            SqlConnection conn = SQLConnectData.getConnection(serverName,dbName);
            SqlCommand cmd = conn.CreateCommand(); // Create new sqlcommand
            cmd.CommandType = CommandType.Text; // Type commad
            string query = "";
            foreach (string item in listQuery)
            {
                query += item + " ";
            }
            cmd.CommandText = query; // Query SQL
            try {
                conn.Open();
                cmd.ExecuteNonQuery(); //  excute query
                cmd.Dispose();
                conn.Close();
                isFalse = true;
            }
            catch (Exception ex) {
                throw ex;
                
            }

            return isFalse;
        }

        public bool deleteTableExists(string tableName) {
            bool isFalse = false;
            string query = String.Format(@"IF  EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES Where Table_Schema = 'dbo'  AND Table_Name ='{0}' ) BEGIN drop table {1} END",
                                            tableName,
                                            tableName
                                        );

            SqlConnection conn = SQLConnectData.getConnection(serverName,dbName);
            SqlCommand command = new SqlCommand(query,conn);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                command.Dispose();
                conn.Close();
                isFalse = true;
            }
            catch (Exception ex) {
                throw ex;
            }

            return isFalse;

        }

        public DataTable getData(string tableName) {
            try
            {
                string query = "Select * from " + tableName;
                SqlConnection conn = SQLConnectData.getConnection(serverName,dbName);
                SqlCommand command = new SqlCommand(query,conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = command;
                da.Fill(dt);
                command.Dispose();
                conn.Close();
                return dt;
            }
            catch (Exception ex) {
                throw ex;
            }
            
        }

        public DataTable getXML(string tableName)
        {
            try
            {
                string query =  @"declare @Var nvarchar(max) declare @Var1 nvarchar(max) "+
                                @"set @Var=(select * From "+tableName+" FOR XML AUTO, ELEMENTS xsinil , ROOT('"+tableName+"Root"+"')) " +
                                @"set @Var1 = (select CONVERT(nvarchar(max),REPLACE(@Var,' "+"xsi:nil=\"true\"',''))) " +
                                @"select CONVERT(xml, REPLACE(@Var1,' "+"xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"', '')) ";

                SqlConnection conn = SQLConnectData.getConnection(serverName, dbName);
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = command;
                da.Fill(dt);
                command.Dispose();
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string getQuerySQLInXML(string tableName) {
            string query = @"declare @Var nvarchar(max)"+"\n"+"declare @Var1 nvarchar(max) " +
                                @"set @Var=(select * From " + tableName + " FOR XML AUTO, ELEMENTS xsinil , ROOT('" + tableName + "Root" + "')) " +"\n"+
                                @"set @Var1 = (select CONVERT(nvarchar(max),REPLACE(@Var,' " + "xsi:nil=\"true\"',''))) " +"\n"+
                                @"select CONVERT(xml, REPLACE(@Var1,' " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"', '')) ";
            return query;
        }

    }


}
