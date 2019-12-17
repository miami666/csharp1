using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace mysql_1
{
    class DBConnect
    {
        static string myConnectionstring = "server=localhost;uid=root;password=;database=Mitarbeiter;";
        MySqlConnection con = new MySqlConnection(myConnectionstring);
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        //Constructor
        public DBConnect()
        {
            Initialize();
        }
        private void Initialize()
        {
            server = "localhost";
            database = "mitarbeiter";
            uid = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=";
            connection = new MySqlConnection(connectionString);
        }
        public MySqlConnection verbind()
        {
            try
            {
                con.Open();
                Console.WriteLine("connection established");
                Console.ReadKey();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                con = null;
            }
            return con;
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.Write("Kann keine Verbindung zum Datenbank Server erstellen");
                        break;
                    case 1045:
                        Console.Write("Benutzername und oder passwort ungültig");
                        break;
                }
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        public void Insert(MySqlConnection con, string vorname, string nachname, string plz, string ort, string strasse, string abteilung)
        {
            string query = "INSERT INTO mitarbeiter (vorname, nachname, plz, ort, strasse, abteilung) VALUES(@vorname,@nachname,@plz,@ort,@strasse,@abteilung)";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@vorname", vorname);
                cmd.Parameters.AddWithValue("@nachname", nachname);
                cmd.Parameters.AddWithValue("@plz", plz);
                cmd.Parameters.AddWithValue("@ort", ort);
                cmd.Parameters.AddWithValue("@strasse", strasse);
                cmd.Parameters.AddWithValue("@abteilung", abteilung);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(string updateparam, string vn, string nn, string ort, string plz, string str, string abt)
        {
            string query = "UPDATE mitarbeiter SET nachname='" + nn + "',vorname='" + vn + "',ort='" + ort + "',plz='" + plz + "',strasse='" + str + "',abteilung='" + abt + "' WHERE nachname=@param";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@param", updateparam);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public void Delete(string del)
        {
            string query = "DELETE FROM mitarbeiter WHERE vorname=@param OR nachname=@param";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@param", del);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public void Display(MySqlConnection con)
        {
            try
            {
                string sql = "Select * from mitarbeiter";
                MySqlCommand select = new MySqlCommand(sql, con);
                MySqlDataReader reader = select.ExecuteReader();
                Console.WriteLine($"{reader.GetName(1),-12} {reader.GetName(2),-12} {reader.GetName(3),-6} {reader.GetName(4),-10}  {reader.GetName(5),-20}  {reader.GetName(6),-10}");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetString(1),-12} {reader.GetString(2),-12} {reader.GetString(3),-6} {reader.GetString(4),-10}  {reader.GetString(5),-20}  {reader.GetString(6),-10}");
                    //Console.WriteLine("{0}\t",reader.GetInt32(0));
                   // for (int i = 1; i < reader.FieldCount; i++)
                   // {
                   //     Console.Write(reader.GetString(i));
                   // }
                    //Console.WriteLine("\n");
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        public void Displayparam(MySqlConnection con, string search)
        {
            try
            {
                string sql = "Select * from mitarbeiter where vorname=@param";
                MySqlCommand select = new MySqlCommand(sql, con);
                select.Parameters.AddWithValue("@param", search);
                MySqlDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("\n");
                    for (int i = 1; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader.GetString(i) + "\t");
                    }
                    Console.WriteLine("\n");
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool looping = true;
            string input;
            DBConnect db = new DBConnect();
            MySqlConnection dbcon = db.verbind();
            Console.SetCursorPosition(Console.WindowWidth / 2, 20);
            while (looping)
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth/2, 20);
                Console.WriteLine("====Menu====");
                Console.WriteLine("(a)nzeigen");
                Console.WriteLine("(s)uchen ");
                Console.WriteLine("(i)nsert ");
                Console.WriteLine("(u)pdate");
                Console.WriteLine("(l)öschen");
                Console.WriteLine("(e)xit");
                ConsoleKeyInfo pressedkey = Console.ReadKey(true);
                if (pressedkey.Key == ConsoleKey.A)
                {
                    db.Display(dbcon);
                    Console.ReadKey();
                   
                }
                if (pressedkey.Key == ConsoleKey.S)
                {
                    Console.WriteLine("Vorname der gesucht werden soll?");
                    input = Console.ReadLine();
                    db.Displayparam(dbcon, input);
                    Console.ReadKey();
                
                    
                }
                if (pressedkey.Key == ConsoleKey.I)
                {
                    string vn;
                    string nn;
                    string ort;
                    string plz;
                    string str;
                    string abteilung;
                    Console.WriteLine("Vorname?");
                    vn = Console.ReadLine();
                    Console.WriteLine("Nachname?");
                    nn = Console.ReadLine();
                    Console.WriteLine("PLZ?");
                    plz = Console.ReadLine();
                    Console.WriteLine("Ort?");
                    ort = Console.ReadLine();
                    Console.WriteLine("Strasse");
                    str = Console.ReadLine();
                    Console.WriteLine("Abteilung?");
                    abteilung = Console.ReadLine();
                    db.Insert(dbcon, vn, nn, plz, ort, str, abteilung);
                    Console.ReadKey();
                }
                if (pressedkey.Key == ConsoleKey.U)
                {
                    string vn;
                    string nn;
                    string ort;
                    string plz;
                    string str;
                    string abteilung;
                    Console.WriteLine("Nachname des Datensatzes der aktualisiert werden soll?");
                    input = Console.ReadLine();
                    Console.WriteLine("Vorname?");
                    vn = Console.ReadLine();
                    Console.WriteLine("Nachname?");
                    nn = Console.ReadLine();
                    Console.WriteLine("PLZ?");
                    plz = Console.ReadLine();
                    Console.WriteLine("Ort?");
                    ort = Console.ReadLine();
                    Console.WriteLine("Strasse");
                    str = Console.ReadLine();
                    Console.WriteLine("Abteilung?");
                    abteilung = Console.ReadLine();
                    db.Update(input, nn, vn, ort, plz, str, abteilung);
                    Console.ReadKey();
                }
                if (pressedkey.Key == ConsoleKey.L)
                {
                    Console.WriteLine("zu löschender Vorname oder Nachname?");
                    input = Console.ReadLine();
                    db.Delete(input);
                    Console.ReadKey();
                }
                if (pressedkey.Key == ConsoleKey.E)
                {
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
