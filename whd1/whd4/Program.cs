using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whd4
{
    class Program
    {
        static void Main(string[] args)
        {
            string eingabe;
            int zahl1;
            double zahl2;
            bool parseStatus;

            Console.Write("Gib was ein:");
            eingabe = Console.ReadLine();

            parseStatus = int.TryParse(eingabe, out zahl1);

            if (parseStatus == true)
                Console.WriteLine("Die eingegebene Zahl lautet " + zahl1);
            else Console.WriteLine("Die Eingabe war ein Text und lautet " + eingabe);

            /////////////////////////////////////////////////////////////

            parseStatus = double.TryParse(eingabe, out zahl2);
            
            if (parseStatus == true)
                Console.WriteLine("Die eingegebene Zahl lautet " + zahl2);
            else Console.WriteLine("Die Eingabe war ein Text und lautet " + eingabe);

            Console.ReadKey();
        }
    }
}
