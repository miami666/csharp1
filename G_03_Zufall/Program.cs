using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
User Eingaben durch Zufallswerte simulieren
 */
namespace G_03_Zufall
{
    class Program
    {
        static void Main(string[] args)
        {
            // Einfuehren Zufallsgenerators
            Random zufallsGenerator = new Random();
            Console.WriteLine("eine erste Zufallszahl zwischen 0 und 4 Mrd: " + zufallsGenerator.Next());

            Console.ReadKey();
        }
    }
}
