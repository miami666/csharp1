using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    AUFGABE A
    Schreiben Sie bitte zunächst die folgende (CallByReference)-Methode:
        Name: InputInt
        Übergabewerte: 1 String s (z.B. "Geben Sie bitte eine ganze Zahl ein: ") und eine Referenz auf einen Integer x
        Funktion: 1.) Es wird s auf der Konsole ausgegeben
                  2.) Vom User wird eine ganze Zahl abgefragt und in dem String 'eingabe' abgespeichert
                  3.) Der String 'eingabe' wird in einen Integer mit TryParse geparsed, dieser Integer-Wert wird in x abgespeichert
        Rückgabewert: True, falls TryParse True zurückgibt, sonst False
    
    AUFGABE B
    Testen Sie bitte die obige Funktion durch folgendes Programm:
    - Das Programm startet eine Endlos-Schleife, die pro Durchlauf ...
      + eine do-while-Schleife startet, die pro Durchlauf
        - die Methode InputInt() aufruft
        - solange wiederholt wird, solange der Rückgabewert von InputInt() False ist
      + nach der do-while-Schleife den eingegebenen User-Wert zu der Variable 'summe' aufaddiert
      + die aktuelle Summe auf der Konsole ausgibt
*/

namespace callbyreference_aufgabe_2
{
    class Program
    {
        static bool InputInt(string s, out int x)
        {

            return Int32.TryParse(s, out x);

        }
        static void Main(string[] args)
        {
            int summe=0;
            int x;
            while (true)
            {
                do
                {                 
                    Console.WriteLine("Zahl eingeben bitte:");
                } while (!InputInt(Console.ReadLine(), out x));

                summe += x;
                Console.WriteLine(summe);

            }

        }
    }
}
