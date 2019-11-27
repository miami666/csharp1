using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonversionZahlen
{
    class Program
    {
        static void Main(string[] args)
        {
            uint x = uint.MaxValue;
            float f = x;
            //Console.WriteLine(x);
            //Console.WriteLine(f);
            uint x2 = (uint)f;
            //Console.WriteLine(x2);

            long l = x;
            Console.WriteLine(l);
            int i = (int)l;
            Console.WriteLine(i);
        }
    }
}
