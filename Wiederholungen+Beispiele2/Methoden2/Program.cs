//Statische Klasse StringAusgabe mit den Methoden
//StringAusgabeRechtsbündig, StringAusgabeLinksbündig, StringAusgabePositioniert
//Diese Methoden erhalten als Übergabe den auszugebenen String und gegebenenfalls die gewünschte Position

//Statische Klasse ArraySortieren mit den Methoden
//BubbleSort und QuickSort
//Diese Methoden erhalten als Übergabe das zu sortierende Array


using System;


namespace Methoden2
{
    public static class StringAusgabe
    {
        public static void StringAusgabeRechtsbündig(string s)
        {
            Console.SetCursorPosition(Console.WindowWidth - s.Length, Console.CursorTop);
            Console.Write(s);
        }

        public static void StringAusgabeLinksbündig(string s)
        {
            Console.Write(s);
        }

        public static void StringAusgabePositioniert(string s, int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(s);
        }

        public static void StringAusgabeZentriert(string s)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - s.Length / 2, Console.CursorTop);
            Console.Write(s);
        }
    }

    public static class ArraySortieren
    {
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length -1 - i; j++)
                {
                    if (array[j] > array[j+1])
                    {
                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public static void QuickSort(int[] array)
        {//https://de.wikibooks.org/wiki/Algorithmensammlung:_Sortierverfahren:_Quicksort
            quicksort(0, array.Length - 1, ref array);
        }

        private static void quicksort(int links, int rechts, ref int[] daten)
        {
            if (links < rechts)
            {
                int teiler = teile(links, rechts, ref daten);
                quicksort(links, teiler - 1, ref daten);
                quicksort(teiler + 1, rechts, ref daten);
            }
        }

        private static int teile(int links, int rechts, ref int[] daten)
        {
            int i = links;
            //Starte mit j links vom Pivotelement
            int j = rechts - 1;
            int pivot = daten[rechts];

            do
            {
                //Suche von links ein Element, welches größer als das Pivotelement ist
                while (daten[i] <= pivot && i < rechts)
                    i += 1;

                //Suche von rechts ein Element, welches kleiner als das Pivotelement ist
                while (daten[j] >= pivot && j > links)
                    j -= 1;

                if (i < j)
                {
                    int z = daten[i];
                    daten[i] = daten[j];
                    // tausche daten[i] mit daten[j]
                    daten[j] = z;
                }

            } while (i < j);
            //solange i an j nicht vorbeigelaufen ist 

            // Tausche Pivotelement (daten[rechts]) mit neuer endgültiger Position (daten[i])

            if (daten[i] > pivot)
            {
                int z = daten[i];
                daten[i] = daten[rechts];
                // tausche daten[i] mit daten[rechts]
                daten[rechts] = z;
            }
            return i; // gib die Position des Pivotelements zurück
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            StringAusgabe.StringAusgabeLinksbündig("Hello There");
            StringAusgabe.StringAusgabeRechtsbündig("Hello World");
            
            StringAusgabe.StringAusgabePositioniert("Good Morning, Vietnam!", 10, 10);
            Console.WriteLine();
            StringAusgabe.StringAusgabeZentriert("I am your Father!");
            Console.WriteLine();
            Random random = new Random();
            int[] array = new int[100];
            for (int i = 0; i < 100; i++)
                array[i] = random.Next(50) + 1;

            ArraySortieren.BubbleSort(array);

            Console.WriteLine();
            foreach (int i in array)
                Console.Write(i + " ");
            Console.WriteLine();

            array = new int[100];
            for (int i = 0; i < 100; i++)
                array[i] = random.Next(50) + 1;

            ArraySortieren.QuickSort(array);

            Console.WriteLine();
            foreach (int i in array)
                Console.Write(i + " ");
            Console.WriteLine();


            Console.ReadKey();
        }
    }
}
