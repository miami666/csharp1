using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G09_ReadLine
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            // zum Einlesen werden wir die Funktion ReadLine() verwenden, die ebenfalls in der Klasse Console vorkommt

            Console.Write("Geben Sie bitte einen Text ein (wird nicht abgespeichert):");
            Console.ReadLine();
            // Problem hier: Der bloße Aufruf der Funktion ReadLine() ermöglicht zwar eine Eingabe 
            // (die durch Return beendet wird) ...
            // aber: Das System fängt diese Eingabe nicht auf, es erscheint lediglich auf der Konsole

            // LÖSUNG des Problems: Wir speichern den Rückgabewert der Funktion ReadLine() in einem String ab 
            // (Der Rückgabewert ist nämlich gerade die User-Eingabe)


            Console.ReadKey();
        }
    }
}
