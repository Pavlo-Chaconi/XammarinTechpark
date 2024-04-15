using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace XammarinTechpark
{
    public class MSQL_DB
    {


        MySqlConnection conn;
        public MSQL_DB()
        {


            conn = new MySqlConnection("server=192.168.1.68;port=3306;username=root;password=;database=xammarin_techpark");


        }

        public void openConnection()
        {


            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

        }

        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public MySqlConnection getConnection()
        {
            return conn;
        }
    }
}
