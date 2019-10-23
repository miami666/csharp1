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
            Console.Write("Geben Sie bitte einen Text ein (wird abgespeichert):");
            text = Console.ReadLine();
            Console.WriteLine("Control: " + text);

            //Abfragen von ganzen Zahlen
            Console.WriteLine("Bitte geben sie eine ganze Zahl ein:");
            text = Console.ReadLine();
            //klasse convert methode ToInt32
            int i;
            i = Convert.ToInt32(text);
            
            Console.WriteLine("control: " + i);
            Console.WriteLine("Bitte geben sie eine weitere  ganze Zahl ein:");
            i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("control: " + i);

            //Bemerkung
            //bei  der Klasse convert methode ToInt kommt es bei falschen zeichen zu Format Exception
            // bei zu großen Zahlen zu overflow exception

            //Abfrage von Kommazahlen
            double d;
            Console.WriteLine("Bitte geben sie eine Kommazahl ein");
            d = Convert.ToDouble(Console.ReadLine()
                );
            Console.WriteLine("control double:"+d);
            d.ToString("F1");
            Console.WriteLine("to string: "+d);

            //Try Parse
            Console.WriteLine("Zahl eingeben die mit Try Parse ausgegeben wird");
            var foo = Console.ReadLine();
            if (int.TryParse(foo, out int number1))
            {
                Console.WriteLine($"{number1} ist eine Zahl");
            }
            else
            {
                Console.WriteLine($"{foo} ist keine Zahl");
            }


            Console.WriteLine("KommaZahl eingeben die mit Try Parse ausgegeben wird");
            var doo = Console.ReadLine();
            if (double.TryParse(doo, out double number2))
            {
                Console.WriteLine($"{number2} ist eine Kommazahl");
            }
            else
            {
                Console.WriteLine($"{foo} is keine Kommazahl");
            }



            Console.ReadKey();
        }
    }
}
