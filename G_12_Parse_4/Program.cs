using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*

  Schreiben Sie bitte ein C#-Programm, in dem ...
  - zunächst ein leerer String s eingeführt wird
  - eine for-Schleife gestartet wird, die 5-mal durchlaufen wird. Pro Durchlauf ...
     + wird mit ReadKey() - also ohne Return - vom User ein Zeichen abgefragt
     + wird das Zeichen an den String s angehängt
  - nach der Schleife mit TryParse getestet wird, ob der gefüllte String in einen Integer ge-parsed werden kann
    + falls geparsed werden kann UND die Eingabe dem Integer 12345 entspricht erscheint auf der Konsole "Tür wird geöffnet!"
    + sonst: "Sie erhalten keinen Einlass!"
  - das Programm nach einem beliebigen Tastendruck beendet wird

  HINWEISE:
  - Das Bei ReadKey() vom User eingetippte Zeichen erscheint auf der Konsole, ...
    ... das war für uns bisher nur immer "unsichtbar", da unser programm bisher immer mit ReadKey() endete
  - Recherchieren Sie bitte zur Anweisung   Console.ReadKey().KeyChar   ...
    ... um in der Lage zu sein, mit dem eingegebenen Zeichen auch arbeiten zu können

*/

namespace G_12_Parse_4
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
                string result2 = ConvertStringArrayToStringJoin(stringArray);
                Console.WriteLine(result2);
                if (int.TryParse(result2, out int zahl))
                {
                    Console.WriteLine("TryParse des Schlüssels erfolgreich");
                    Console.WriteLine("\nSchlüssel benutzen? \nEnter Taste für Brexit");
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        running = false;
                    }
                    if (zahl == 12345)
                    {
                        Console.WriteLine("Tür wird geöffnet!");
                        Console.ReadKey();
                        running = false;
                    }
                    else
                    {
                        Console.WriteLine("Du kommst hier nisch rein!");
                        Console.ReadKey();
                        running = false;
                    }                
                }
                else
                {
                    Console.WriteLine("TryParse gescheitert ");
                    Console.WriteLine("\nany Key um es nochmal zu machen \nEnter Taste für Brexit");
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        running = false;
                    }
                }
            }
            Console.ReadKey();
        }
        static string ConvertStringArrayToStringJoin(string[] array)
        {
            string result = string.Join("", array);
            return result;
        }
    }
}
