using System;

namespace Schleifen
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];

            for (int i = 0; i < 10; i++)
            {
                arr[i] = i;
            }

            Console.WriteLine("for:");
            // for - Schleife
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 > 0)
                    continue;

                if (i > 7)
                    break;

                Console.WriteLine(arr[i]);
            }

            Console.WriteLine("while:");
            // while - Schleife
            int j = 0;

            while(j < 10)
            {
                if (j % 2 > 0)
                {
                    j++;
                    continue;
                }

                if (j > 7)
                    break;

                Console.WriteLine(arr[j++]);
            }

            Console.WriteLine("do");
            // do - Schleife
            j = 0;
            do
            {
                if (j % 2 > 0)
                {
                    j++;
                    continue;
                }

                if (j > 7)
                    break;

                Console.WriteLine(arr[j++]);
            } while (j < 10);

        }
    }
}
