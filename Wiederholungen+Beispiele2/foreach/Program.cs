using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHex
{
    class Program
    {


        static void Main(string[] args)
        {
            int[] arr = new int[5] { 1, 2, 3, 4, 5 };


            foreach (int x in arr)
            {
                if (x == 2)
                {
                    Console.WriteLine("Ich hab die Zwei gefunden!");
                    break;
                }
                Console.WriteLine("Suche weiter...");
            }
            Console.Write("Ende!");
            Console.ReadKey();

        }
    }
}
