using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a1;
            int[,] a2;
            int[, ,] a3;
            int[][] j2;  // "jagged" array
            int[][][] j3; 

            a1 = new int[] { 1, 29, 13, 4,234,2323 };
            a2 = new int[,] { { 123, 456, 789 }, { 1, 4, 6 } };  // Die Teile müssen alle gleich lang sein.
            a3 = new int[10, 20, 30];
            j2 = new int[3][];
            j2[0] = new int[] { 1, 2, 3 };  // Teilarrays können unterschiedliche Länge haben.
            j2[1] = new int[] { 3, 4, 6, 7, 2 };
            j2[2] = new int[] { 3, 4, 6, 7 };

            for (int i = 0; i < a1.Length; i++)
                Console.WriteLine(a1[i]);
           
            for (int i = 0; i < a2.GetLength(0); i++)
            {
                for (int j = 0; j <a2.GetLength(1); j++)
                {
                    Console.WriteLine(a2[i,j]);

                }
               
            }
            var rowCount = a2.GetLength(0);
            var colCount = a2.GetLength(1);
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    Console.Write(String.Format(a2[row, col]+"\t"));
                Console.WriteLine();
            }
            int[] arrayInt1 = new int[] { 1, 2, 3, 4, 5, 6 };
            int[,] arrayInt2;
            arrayInt2 = new int[,] { { 5, 4, 6 }, { 88, 99, 21 } };

            for (int row = 0; row < arrayInt1.Length; row++)  
            {
                Console.WriteLine(arrayInt1[row]);
             }

            for (int row = 0; row < arrayInt2.GetLength(0); row++)
            {
                for (int col = 0; col < arrayInt2.GetLength(1); col++)
                {
                    Console.Write(String.Format(arrayInt2[row, col] + "\t"));
                }
                Console.WriteLine();
            }
            

            Console.ReadKey();

        }
        
    }
}
