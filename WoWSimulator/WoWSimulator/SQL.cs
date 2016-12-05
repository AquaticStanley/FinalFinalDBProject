using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WoWSimulator
{
    public static class SQL
    {
        public static string ConnectionString = "";

        /// <summary>
        /// Use this function if the connection string is universal (I'm almost postive it is; you define the table in the query)
        /// </summary>
        /// <param name="sqlString">String of SQL used to get data from the tables or insert, update, whatever</param>
        /// <param name="error">Don't worry about this/param>
        /// <returns>Datatable if you were selecting something, null datatable if you were inserting or updating</returns>
        public static DataTable RunSQL(string sqlString)
        {
            DataTable table = new DataTable();
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=password;database=sys;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                var adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }
            return table;

            //var datatable = new DataTable();
            //var errors = string.Empty;
            //var cmd = new SqlCommand { CommandType = CommandType.Text, CommandText = sqlString };
            //var connection = new SqlConnection(ConnectionString);
            //cmd.Connection = connection;
            //try
            //{
            //    var adapter = new SqlDataAdapter(cmd);
            //    connection.Open();
            //    adapter.Fill(datatable);
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}
            //finally
            //{
            //    connection.Close();
            //}
            //return datatable;
        }

        //public static DataTable RunSQL(string sqlString, string connectionString)
        //{
        //    var datatable = new DataTable();
        //    var errors = string.Empty;
        //    var cmd = new SqlCommand { CommandType = CommandType.Text, CommandText = sqlString };
        //    var connection = new SqlConnection(connectionString);
        //    cmd.Connection = connection;

        //    try
        //    {
        //        var adapter = new SqlDataAdapter(cmd);
        //        connection.Open();
        //        adapter.Fill(datatable);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return datatable;
        //}
    }
}