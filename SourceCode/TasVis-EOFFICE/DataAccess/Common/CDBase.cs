using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Common
{
    public class CDBase
    {
        private SqlConnection conn;

        public SqlConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }
        private SqlDataAdapter dataAp;
        private DataSet dataSet;
        private DataTable dataTable;
        public static string strConnectionString;

        public static bool ValidConnect = false;

        public bool Connect()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                conn.Open();
                ValidConnect = true;
            }
            catch
            {
                ValidConnect = false;
            }
            return ValidConnect;
        }

        public void closeConnection()
        {
            conn.Close();
        }

        public DataTable RunProcedureGet(string procedureName,SqlParameter[] sqlParameter)
        {
            Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                foreach (SqlParameter sqlPara in sqlParameter)
                {
                    cmd.Parameters.Add(sqlPara);
                }
                da.SelectCommand = cmd;
                da.Fill(dt);

            }
            catch(Exception ex) { }
            finally
            {
                cmd.Dispose();
                closeConnection();
            }
            return dt;
        }

        public bool RunProcudure(string procedureName, SqlParameter[] sqlParameter)
        {
            Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            int numRecordsEffect = 0;
            try
            {
                foreach (SqlParameter sqlPara in sqlParameter)
                {
                    cmd.Parameters.Add(sqlPara);
                }
                numRecordsEffect=cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { }           
                      
            finally
            {
                cmd.Dispose();
                closeConnection();
            }
            if (numRecordsEffect > 0)
            {
                return true;
            }  
            return false;
        }

    }
}
