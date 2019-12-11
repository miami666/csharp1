using System;
using System.Collections.Generic;
using System.Linq; //Language Integrated Query


namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //LINQ funktioniert bei allem, was IEnumerable implementiert, 
            //XML Dokumente, ADO.NET Datasets, SQL Server Datenbanken und .NET Collections
            Random random = new Random();
            int[] zahlen = new int[10];
            for (int i = 0; i < 10; i++)
            {
                zahlen[i] = random.Next(10);
            }

            //Queries bestehen immer aus from, optional where und optional orderby und select in dieser Reihenfolge
            //Im Gegensatz zu SQL kommt das Select zum Schluss und From an den Anfang
            //Da der Datentyp nicht immer direkt bekannt ist, kann hier var verwendet werden
            var gerade =
                from zahl in zahlen
                where (zahl % 2) == 0
                orderby zahl descending
                select zahl;
            //Ausgabe des Datentyps
            Console.WriteLine(gerade.GetType());

            //Ausgabe des Ergebnisses / Ausgabe von gerade
            foreach(int zahl in gerade)
            {
                Console.Write(zahl + " ");
            }
            Console.WriteLine();


            int[] ungerade =
                (from zahl in zahlen
                 where (zahl % 2) == 1
                 orderby zahl ascending
                 select zahl).ToArray();

            foreach (int zahl in ungerade)
            {
                Console.Write(zahl + " ");
            }
            Console.WriteLine();


            string[] strings = new string[] { "Hallo", "Welt", "abc" };
            //Query für Strings, umgewandelt in eine Liste
            List<string> liste = 
                (from s in strings
                 where s.Contains("a")
                 select s).ToList();

            foreach (string s in liste)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            //Ebenfalls in LINQ sind Funktionen wie Sum()
            int summe = zahlen.Sum();
            Console.WriteLine(summe);
            //oder Max()
            int max = gerade.Max();
            Console.WriteLine(max);

            Console.ReadKey();
        }
    }
}
