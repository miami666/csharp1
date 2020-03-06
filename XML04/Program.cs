using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Xml;
using System.Data;

namespace XML04
{
    class Person
    {
        public string Vorname { get; set; }
        public string Zuname { get; set; }
        public int Alter { get; set; }
        public string Ort { get; set; }
        public string Strasse { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string connetionString = null;
            MySqlConnection connection;
            MySqlCommand command;
            MySqlDataAdapter adpter = new MySqlDataAdapter();
            string sql = null;
            int alter = 0;
            string telefon = null;
            string vorname = null;
            string zuname = null;
            string ort = null;
            string strasse = null;


            connetionString = "server = localhost; uid = root; password =; database = personen; ";

            connection = new MySqlConnection(connetionString);
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS person (" +
            "id INT AUTO_INCREMENT," +
            "vorname VARCHAR(255)," +
            "telefon VARCHAR(20)," +
            "zuname VARCHAR(100)," +
            "alterperson INTEGER, " +
            "ort VARCHAR(100)," +
            "strasse VARCHAR(100)," +
            "PRIMARY KEY(id));", connection))
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }





            XmlDocument doc = new XmlDocument();
            doc.Load("../../personen.xml");
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Personen/Person");
            foreach (XmlNode node in nodes)
            {
                Person person = new Person();
                vorname = node.SelectSingleNode("Vorname").InnerText;
                telefon = node.SelectSingleNode("Telefon").InnerText;
                zuname = node.SelectSingleNode("Zuname").InnerText;
                alter = Convert.ToInt32(node.SelectSingleNode("Alter").InnerText);
                ort = node.SelectSingleNode("Adresse/@Ort").InnerText;
                strasse = node.SelectSingleNode("Adresse/@Strasse").InnerText;


                sql = "insert into person(vorname,telefon,zuname,alterperson,ort,strasse) values('" + vorname + "','" + telefon + "','" + zuname + "'," + alter + ",'" + ort + "','" + strasse + "')";
                command = new MySqlCommand(sql, connection);
                adpter.InsertCommand = command;
                adpter.InsertCommand.ExecuteNonQuery();


            }

            connection.Close();
        }
    }
}
