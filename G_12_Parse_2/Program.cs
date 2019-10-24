using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace G_12_Parse_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            string s1 = "10";
                        string s2 = "37";
                        string s3 = "6";
                        string s4 = "null";
                        string s5 = "palimpalim";*/
            //  int i = 0;
            bool running = true;

            while (running)
            {

                string[] stringArray = new string[] { "10", "37", "6", "null", "palimpalim" };
                // var a = (from s in stringArray where int.TryParse(s, out i) select i).ToArray();  // a = { 1, 2 }
                // var a = stringArray.Select((s, i) => int.TryParse(s, out i) ? i : 0).ToArray();
                // var a = Array.ConvertAll(stringArray, s => int.TryParse(s, out var i) ? i : 0);
                // Create a Random object  
                Random rand = new Random();
                // Zufallsobjekt bzw. Zufallsindex mit explizitem max Wert als Parameter  generieren 
                int index = rand.Next(stringArray.Length);
                if (int.TryParse(stringArray[index], out int _))
                {
                    Console.WriteLine(stringArray[index]);
                    Console.WriteLine();
                    Console.WriteLine("\nany key: nochmal\nEnter für Brexit");
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true); //true here mean we won't output the key to the console, just cleaner in my opinion.
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        running = false;
                    }

                }
                else
                {
                    Console.WriteLine("Zonk!");
                    Console.WriteLine("\nany key to start over");
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true); //true here mean we won't output the key to the console, just cleaner in my opinion.
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        running = false;
                    }

                }
            }





        }
    }
}
