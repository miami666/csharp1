using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whd2
{
    class Program
    {

        //call-by-value
        static int sum(int a, int b)
        {
            a = a + b;
            Console.WriteLine("1. In 'sum' ist a=" + a);
            return a;
        }

        // call by reference mit ref
        public static void sum(ref int a)
        {
            a = a + a;
            Console.WriteLine("2. In 'sum' ist a=" + a);
        }

        // call by reference mit out
        public static void sum1(out int a)
        {
            //Console.WriteLine("3. In 'sum1' a=" + a);
            // Fehler: a noch nicht zugewiesen
            a = 5;
            //Console.WriteLine("3. In 'sum1' a=" + a);
            //a = a + a;
            //Console.WriteLine("3. In 'sum1' a=" + a);
        }

        static void Main(string[] args)
        {

            int a = 2;
            int b = 4;
            Console.WriteLine("1. Summe aus {0} und {1} ist {2}.", a, b, sum(a, b));

            int c=2;
            Console.WriteLine("2.Summe aus {0} und {1} ist :", a, a);
            sum(ref c);
            Console.WriteLine(c);

            Console.WriteLine("3. vor sum1 , c = " + c);
            sum1(out c);
            Console.WriteLine("3. nach sum1 , c = " + c);

            Console.ReadKey();
        }
    }
}
