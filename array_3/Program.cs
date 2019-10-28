using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array_3
{
    class Program
    {
        static void Result(int[] arr)
        {

            // displaying the array elements 
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Array Element: " + arr[i]);
            }

        }

        // Main method 
        public static void Main()
        {

            // declaring an array  
            // and intializing it 
            int[] arr = { 1, 2, 3, 4, 5 };

            // callling the method 
            Result(arr);
            Console.ReadKey();
        }
    }
}
