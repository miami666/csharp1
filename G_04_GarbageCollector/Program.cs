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
            long mem1=GC.GetTotalMemory(false);
            Console.WriteLine("memory: "+ mem1);
            int[] array = new int[50000];
            long mem2=GC.GetTotalMemory(false);
            Console.WriteLine("memory nach array initialisierung: "+mem2);
            array = null;
            GC.Collect();
            long mem3 = GC.GetTotalMemory(false);
            Console.WriteLine("memory GC Collect: " + mem3);
            Console.ReadKey();
        }
    }
}
