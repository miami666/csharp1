using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_04_GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            long mem1 = GC.GetTotalMemory(false);
            Console.WriteLine(mem1);
            int[] values = new int[50000];
            long mem2 = GC.GetTotalMemory(false);
            long res = mem2 - mem1;
            Console.WriteLine(mem2);
            Console.WriteLine(res);
            values = null;
            GC.Collect();
            long mem3 = GC.GetTotalMemory(false);
            Console.WriteLine(mem3);
            Console.ReadKey();
        }
    }
}
