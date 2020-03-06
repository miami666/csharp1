using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using MySql.Data.MySqlClient;
using System.Data;

namespace XML07
{

    class Program
    {
      
        static void Main(string[] args)
        {
            string connetionString = null;
            MySqlConnection connection;
            connetionString = "server = localhost; uid = root; password =; database = personen; ";
            connection = new MySqlConnection(connetionString);
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Person",connection))
            {
                string filename = "personen2.xml";
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                ds.Tables[0].WriteXml(Path.Combine(path,filename));
            }
            connection.Close();
        }
    }
}
