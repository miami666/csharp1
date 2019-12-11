/* Schreiben Sie eine generische Methode "Tausche", 
 * die zwei Werte vom Typ T übergeben bekommt
 * und sie miteinander tauscht.
 * Verwenden Sie die Methode im Main mit Integer, Double und String Beispielwerten.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        public static void Tausche<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            int a = 10, b = 15;
            double d = 3.14, e = 0.33;
            string g = "Hello", h = "World";

            Tausche<int>(ref a, ref b);
            Tausche<double>(ref d, ref e);
            Tausche<string>(ref g, ref h);

            Console.WriteLine($"{a}, {b}");
            Console.WriteLine($"{d}, {e}");
            Console.WriteLine($"{g}, {h}");

            Console.ReadKey();


        }
    }
}
