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

namespace XML03
{
    class Program
    {
        static void Main(string[] args)
        {
            string connetionString = null;
            MySqlConnection connection;
            MySqlCommand command;
            MySqlDataAdapter adpter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            XmlReader xmlFile;
            string sql = null;

            int alter = 0;
            string telefon = null;
            string vorname = null;
            string zuname = null;
        

            connetionString = "server = localhost; uid = root; password =; database = personen; ";

            connection = new MySqlConnection(connetionString);

            xmlFile = XmlReader.Create("personen.xml", new XmlReaderSettings());
            ds.ReadXml(xmlFile);
            int i = 0;
            connection.Open();
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                vorname = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                telefon = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                zuname = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                alter = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[3]);
                
                
                sql = "insert into person(vorname,telefon,zuname,alterperson) values('" + vorname + "'," + telefon + ",'" + zuname + "',"+alter+")";
                command = new MySqlCommand(sql, connection);
                adpter.InsertCommand = command;
                adpter.InsertCommand.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
