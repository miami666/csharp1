using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_12_Parse_2
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
 Schreiben Sie bitte ein C#-Programm, in dem ...
 - zunächst 5 Strings eingeführt werden
   + 3 dieser Strings sollen ganze Zahlen darstellen
   + ein String soll 'null' sein
   + ein String soll "Palimpalim" lauten
 - anschließend eine Endlosschleife startet, in der pro Durchlauf ...
   + ein String ausgewählt wird
   + versucht wird, diesen String in einen Integer zu Parsen
   + dieser Integer ausgegeben wird (falls das Parsen gelang) ansonsten eine Fehlermeldung erscheint
   + die Schleife erst nach einem Tastendruck mit dem nächsten Durchlauf fortfährt
*/
            string s1 = "10";
            string s2 = "37";
            string s3 = "6";
            string s4 = "null";
            string s5 = "palimpalim";
            bool running = true;

            while (running)
            {
                if (int.TryParse(s1, out int _))
                {
                    Console.WriteLine("Parsen von string s1 zu integer hat funktioniert");
                    Console.WriteLine(s1);
                    running = false;
                }
                else
                {
                    Console.WriteLine("Fehler beim Parsen von string s1 zu integer");
                    Console.WriteLine("\nneuer Parse Versuch startet");
                }
                Console.WriteLine("Hit any key to Brexit");
                Console.ReadKey();

            }

        }
    }
}
