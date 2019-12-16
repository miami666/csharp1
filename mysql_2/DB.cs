using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mysql_2
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection(myConnectionstring);
        static string myConnectionstring = "server=localhost;uid=root;password=;database=Mitarbeiter;";
        //string query = "select * from Mitarbeiter ";
        public MySqlConnection verbind()
        {
            try
            {
                connection.Open();
                Console.WriteLine("connection established");
                Console.ReadKey();

            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                connection = null;
            }
            return connection;
        }

        public void Display(MySqlConnection con)
        {
            try
            {
                string sql = "Select * from mitarbeiter";
                MySqlCommand select = new MySqlCommand(sql,con);
                MySqlDataReader reader = select.ExecuteReader();
                while(reader.Read())
                {
                    for(int i=0;i<reader.FieldCount;i++)
                    {
                        Console.WriteLine(reader.GetValue(i));
                    }
                   // Console.WriteLine("id: {0} Vorname: {1} Nachname: {2} PLZ: {3} Ort: {4} Strasse: {5} Abteilung: {6}", reader["id"],reader["vorname"],reader["nachname"], reader["plz"], reader["ort"], reader["strasse"], reader["abteilung"]);
                   

                }
                reader.Close();

            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();

            }

        }
       
        
                
            
    }
}
