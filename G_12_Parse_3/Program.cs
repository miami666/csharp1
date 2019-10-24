using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
  Schreiben Sie bitte ein C#-Programm, in dem ...
  - in einer Endlosschleife pro Durchlauf vom User eine Kommazahl abgefragt wird
  - versucht wird, den Eingabe-String mit tryParse zu einem Double x zu parsen
  - nach dem Parse-Versuch eine Erfolgs- (oder Misserfolgs)-Meldung und der Wert von x ausgegeben wird

  HINWEIS
      Die Eingaben von z.B.:
      - "2.4"
      - "2..4"
      - "24..."
      werden akzeptiert (und als der Wert 24 interpretiert) ... 
      ... das ist aber kein Fehler Ihres Programms, sondern eine Schwäche von C#  
*/

namespace G_12_Parse_3
{
    class Program
    {
        static void Main(string[] args)
        {

            bool running = true;

            while (running)
            {

                string[] stringArray = new string[5];
                for (int i = 0; i < stringArray.Length; i++)
                {
                    Console.WriteLine("Eingabe: ", i);
                    stringArray[i] = Console.ReadLine();
                }
                for (int index = 0; index < stringArray.Length; index++)
                {
                    if (double.TryParse(stringArray[index], out double _))
                    {
                        Console.WriteLine("Array Index Nr. " + index + " hat den Wert " + stringArray[index] + " TryParse erfolgreich");

                        Console.WriteLine("\nany key: nächsten Feldwert parsen? \nEnter Taste für Brexit");
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            running = false;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Array Index Nr. " + index + " TryParse gescheitert ");
                        Console.WriteLine("\nany key: nächsten Feldwert parsen? \nEnter Taste für Brexit");
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            running = false;
                        }

                    }
                }
            }
        }
    }
}
