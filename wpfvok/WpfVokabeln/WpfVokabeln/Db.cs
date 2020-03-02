using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfVokabeln
{
    class Db
    {
        static string myConnectionString = "server=127.0.0.1;uid=root;pwd=;database=test;";
        MySqlConnection conn = new MySqlConnection(myConnectionString);

        public MySqlConnection verbind()
        {
            try
            {
                conn.Open();
                Console.WriteLine("Connection hergestellt\n");
                Console.WriteLine("**********************\n");
                return conn;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                conn = null;
                return conn;
            }

        }
    }
}
