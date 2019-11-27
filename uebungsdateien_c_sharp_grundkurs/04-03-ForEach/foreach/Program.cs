using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];

            for (int i = 0; i < 10; i++)
                arr[i] = i;

            foreach (int value in arr)
            {
                if (value % 2 > 0)
                    continue;
                if (value > 7)
                    break;
                Console.WriteLine(value);
            }
        }
    }
}
