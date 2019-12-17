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
            catch (MySqlException ex)
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
                MySqlCommand select = new MySqlCommand(sql, con);
             
                MySqlDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {
                  
                        Console.WriteLine("{0}\t {1}\t {2}\t {3}\t {4}\t {5}\t {6}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));

            
                    // Console.WriteLine("id: {0} Vorname: {1} Nachname: {2} PLZ: {3} Ort: {4} Strasse: {5} Abteilung: {6}", reader["id"],reader["vorname"],reader["nachname"], reader["plz"], reader["ort"], reader["strasse"], reader["abteilung"]);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        public void Displayparam(MySqlConnection con)
        {
            try
            {
                string sql = "Select * from mitarbeiter where vorname=@param";
                MySqlCommand select = new MySqlCommand(sql, con);
                select.Parameters.AddWithValue("@param", "Uschi");
                MySqlDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {
                    //for (int i = 0; i < reader.FieldCount; i++)
                    //{
                        //Console.WriteLine($"{reader.GetValue(i),-10}");
                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                   
                    //}
                    // Console.WriteLine("id: {0} Vorname: {1} Nachname: {2} PLZ: {3} Ort: {4} Strasse: {5} Abteilung: {6}", reader["id"],reader["vorname"],reader["nachname"], reader["plz"], reader["ort"], reader["strasse"], reader["abteilung"]);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }


        public void Insert(MySqlConnection con,int id, string vorname, string nachname, string plz, string ort, string strasse, string abteilung)
        {
           
            try
            {
                string query = "INSERT INTO mitarbeiter (id,vorname, nachname, plz, ort, strasse, abteilung) VALUES(@id,@vorname,@nachname,@plz,@ort,@strasse,@abteilung)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@vorname", vorname);
                cmd.Parameters.AddWithValue("@nachname", nachname);
                cmd.Parameters.AddWithValue("@plz", plz);
                cmd.Parameters.AddWithValue("@ort", ort);
                cmd.Parameters.AddWithValue("@strasse", strasse);
                cmd.Parameters.AddWithValue("@abteilung", abteilung);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
          

           
        }

    }
}
