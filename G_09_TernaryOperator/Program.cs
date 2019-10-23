using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_09_TernaryOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            char c = '+';
            int a, b;

            if (c == '+')
                a = 1 + 1;
            else
                a = 1 - 1;
            //condition ? consequent : alternative
            b = c == '+' ? 1 + 1 : 1 - 1;
            Console.WriteLine(a + " " + b);
            int zufall = new Random().Next(-5, 5);
            string ergebnis1, ergebnis2;

            if (zufall >= 0)
                ergebnis1 = "not minus";
            else
            {
                if (zufall < 0)
                    ergebnis1 = "negativ" + deineMudda();
                else ergebnis1 = deineMudda();
            }
            Console.WriteLine(zufall);
            Console.WriteLine(ergebnis1);

            ergebnis2 = (zufall > 0) ? "größer Null" : (zufall < 0) ? "kleiner Null" + deineMudda() : deineMudda();
            Console.WriteLine(ergebnis2);
            Console.ReadKey();
        }
        static string deineMudda()
        {
            return "deineMudda";
        }

            
    }
}
