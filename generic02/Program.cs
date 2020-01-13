using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Uebung Generics
Erstellen Sie eine generische Methode zum Vergleichen von Werten. Es sollen immer 2 Werte gleichen Typs zum Vergleich übergeben werden. Dabei kann der Typ variieren.
Bool erg = Vergleich(10.5, 20.5)
Bool erg = Vergleich(„er“, „sie“)
Usw.
Uebung2 Generics
Schreiben Sie eine generische Methode list = Copy(array), die ein Array beliebigen Elementtyps in eine generische Liste gleichen Elementtyps kopiert. Verwenden Sie als Listentyp List<T>
 */
namespace generic02
{
    class Program
    {
        //generische Methode T = Platzhalter Datentyp
        public static T[] FuellArray<T>(T value, int size)
        {
            T[] ret = new T[size];
            for (int i = 0; i < size; i++)
            {
                ret[i] = value;
            }
            return ret;
        }
        public static bool genCmp<T>(T value, T value2) 
        {
           
            return EqualityComparer<T>.Default.Equals(value, value2);
        }
        public static List<T> ArrayZuListe<T>(T[] arr)
        {
            List<T> Lst = new List<T>(arr);
            return Lst;
        }
        static void Main(string[] args)
        {
            //string value = "Hello";
            //string[] strArr = FuellArray<string>(value, 10);
            
            string str1 = "Crack";
            string str2 = "Heroin";

            Console.WriteLine("Testausgabe der generischen Vergleichsmethode:");
            Console.WriteLine();
            
            if (!genCmp<string>(str1, str2))
            {
                Console.WriteLine(str1 + " ist kein " + str2);
            }
            else
            {
                Console.WriteLine(str1 + " ist " + str2);
            }

            int zahl1 = 1;
            int zahl2 = 2;
            Console.WriteLine();
            Console.WriteLine("Testausgabe der generischen Vergleichsmethode mit Zahlen:");
            Console.WriteLine();

            if (!genCmp<int>(zahl1, zahl2))
            {
                Console.WriteLine(zahl1 + " ist nicht " + zahl2);
            }
            else
            {
                Console.WriteLine(zahl1 + " ist gleich " + zahl2);
            }
            string[] wortArr = {
                "Finger",
                "im",
                "Po",
                "Mexico"
            };
            Console.WriteLine();
            Console.WriteLine("Testausgabe der Liste mit den Werten des zuvor initialisierten Arrays:");
            Console.WriteLine();
            foreach (var item in ArrayZuListe<string>(wortArr))
            {
                Console.Write(item+" ");
            }
            Console.ReadKey();
        }
    }
}
