using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Delegates. Gegeben sei ein Array von Objekten der gleichen Art (z.B. Strings, Bruchzahlen oder sonstige Objekte). Schreiben Sie eine Methode Sort(arr, compare), 
 * die das Array arr sortiert und dazu eine Vergleichsmethode compare(x, y) verwendet, 
 * die als Delegate übergeben wird und zwei Objekte x und y des Arrays miteinander vergleicht, 
 * d.h. feststellt, ob x größer, kleiner oder gleich y ist.*/
namespace event_aufgabe_04
{
    
    class Program
    {
        delegate bool MeinDelegat(int x, int y);
        static bool XgroesserY(int x, int y)
        {
           var result = x > y ? true : false;
            return result;

        }
        static void Sort(int[] arr, MeinDelegat d, bool Reverse = false)
        {
            int len = arr.Length;
            for (int i = 1; i < len; i++)
                for (int j = 0, stop = len - i; j < stop; j++)
                    if (Reverse ? !d(arr[j], arr[j + 1]) : d(arr[j], arr[j + 1]))
                        swap(j, j + 1);
            void swap(int i, int j) { int temp = arr[i]; arr[i] = arr[j]; arr[j] = temp; }
        }
        static void Ausgabe(int[] arr)
        {
            int index = 1;
            foreach(int n in arr)
            {
                Console.WriteLine("Index["+index+"] "+n);
                index++;
            }
           
        }
        static void Main(string[] args)
        {
            int[] arr = { 9, 29, 3, 11, 15, 16, 42, 31 };
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Kontrollausgabe unsortiert: \n");
            Console.ResetColor();
            Ausgabe(arr);
            MeinDelegat d = new MeinDelegat(XgroesserY);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nKontrollausgabe aufsteigend sortiert: \n");
            Console.ResetColor();
            Sort(arr, d);
            Ausgabe(arr);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nKontrollausgabe absteigend(reversed) sortiert: \n");
            Console.ResetColor();
            Sort(arr, d,true);
            Ausgabe(arr);         
            Console.ReadKey();
        }
    }
}
