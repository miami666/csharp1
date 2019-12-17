using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Terminal.Gui;

namespace mysql_2
{
    class Program
    {
        static void Main(string[] args)
        {
            DB db = new DB();
            MySqlConnection connection = db.verbind();
            db.Insert(connection, 1, "Uschi", "Glas", "50859", "Keulen", "high 69", "xxx");
            db.Insert(connection, 2, "Roy", "Black", "50859", "Keulen", "high 69", "xxx");
            db.Displayparam(connection);
            db.Insert(connection, 3, "Jenna", "Jameson", "50859", "Keulen", "high 69", "xxx");
            db.Display(connection);
            Console.ReadKey();
            
        }
    }
}
