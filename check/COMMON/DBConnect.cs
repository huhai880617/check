using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Data;
using Devart.Data;
using Devart.Data.MySql;

namespace check
{
    public static class DBConnect
    {
        public static string ConnectString = Properties.Settings.Default.Setting1;

        //引导数据库连接数据库调用Web.Config文件      
        private static MySqlConnection connection;
        //创建连接  
        public static MySqlConnection Connection
        {
            get
            {
                MySqlConnection myConn = new MySqlConnection(ConnectString);
                string connectionString = myConn.ConnectionString;
                if (connection == null)
                {
                    connection = new MySqlConnection(connectionString);
                    //打开连接  
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }
        //（无参）返回执行的行数(删除修改更新)  
        public static int ExecuteCommand(string safeSql)
        {
            MySqlCommand cmd = new MySqlCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        //（有参）  
        public static int ExecuteCommand(string sql, params MySqlParameter[] values)
        {
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            return cmd.ExecuteNonQuery();
        }
        //（无参）返回第一行第一列(删除修改更新)  
        public static int GetScalar(string safeSql)
        {
            MySqlCommand cmd = new MySqlCommand(safeSql, Connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        //（有参）  
        public static int GetScalar(string sql, params MySqlParameter[] values)
        {
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        //返回一个DataReader（查询）  
        public static MySqlDataReader GetReader(string safeSql)
        {
            MySqlCommand cmd = new MySqlCommand(safeSql, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public static MySqlDataReader GetReader(string sql, params MySqlParameter[] values)
        {
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        //返回一个DataTable  
        public static DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(safeSql, Connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable GetDataSet(string sql, params MySqlParameter[] values)
        {
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}
