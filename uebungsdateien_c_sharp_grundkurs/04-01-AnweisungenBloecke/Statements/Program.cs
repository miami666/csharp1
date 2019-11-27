using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;

            {
                int b = 10;
            }

            // b ist hier nicht mehr sichtbar.
            // Die folgende Zeile würde einen Compilerfehler verursachen:
            // Console.WriteLine(b);
            
            Console.WriteLine(a);

            if (args.Length > 0)
            {
                Console.WriteLine("Programm hat Argumente");
            }
        }
    }
}
