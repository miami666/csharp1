using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Aufgabe 2
Schreiben Sie bitte das folgende C#-Programm :
In einer Schleife wird der User solange aufgefordert eine ganze Zahl > 10 einzugeben, bis dies geschieht. Nach der Schleife wird eine Erfolgsmeldung ausgegeben
 */
namespace kleine_Aufgaben_2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int zahl;
            do
            {
                Console.WriteLine("Zahl eingeben:");
                int.TryParse(Console.ReadLine(), out zahl);

            } while (zahl<10);

            Console.WriteLine("Gewonnen!!!!");
            Console.ReadKey();
        }
    }
}
