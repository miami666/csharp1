using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLP_CSH_ArraySchleife
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] zahlenArray = new int[30];
            for (int i = 0; i < 30; i++)
            {
                zahlenArray[i] = rnd.Next(30) + 1;
            }

            char nochmal;
            do
            {
                int zaehler = 0;
                int eingabe;
                bool parseOK;
                do
                {
                    Console.Write("Bitte geben Sie eine Zahl ein: ");
                    //int eingabe = Convert.ToInt32(Console.ReadLine());
                    parseOK = Int32.TryParse(Console.ReadLine(), out eingabe);
                } while (!parseOK);

                foreach (int zahl in zahlenArray)
                {
                    if (zahl == eingabe)
                        zaehler++;
                }
                
                Console.WriteLine($"Zahl kommt {zaehler} mal im Array vor.");

                Console.WriteLine("Nochmal? j/anykey");
                nochmal = char.ToLower(Console.ReadKey(true).KeyChar);


            } while (nochmal == 'j');
            Console.ReadKey();
        }
    }
}
