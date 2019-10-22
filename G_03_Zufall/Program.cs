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

            // im obigen Beispiel wurde der ausgeloste Wert lediglich auf der Konsole ausgegeben

            // Beispiel mit Speichern

            Int64 zufallszahl = zufallsGenerator.Next();
            Console.WriteLine("zweite Zufallszahl zwischen 0 und 4 Mrd.: " + zufallszahl);

            //Bestimmung Zufallszahl mit nach oben begrenztem, durch uns bestimmten Wert

            zufallszahl = zufallsGenerator.Next(10);
            Console.WriteLine("Zufallszahl mit nach oben begrenztem, durch uns bestimmten Wert: " + zufallszahl);

            Console.ReadKey();
        }
    }
}
