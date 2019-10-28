/*
 ARRAYS (eindimensional)

 Motivation: 
    Immer dann, wenn wir für eine größere Anzahl von Variablen "das selbe" machen wollen (z.b auf einen Wert setzen) bietet es sich an, dies durch eine Schleife abarbeiten zu lassen.
 Problem: Wie kann ich Variablen "durchnummerieren" (damit ich anschließend in der Schleife pro Durchlauf
 die 1., 2., dritte ,.... Variable bearbeite)

 Lösung: Arrays

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_31_Array_Sort
{

    class Program
    {
        static void Main(string[] args)
        {
            // Deklarieren und Definieren von Arrays
            // mit 'new': Erzeugen eines neuen Objektes vom angegebenen Typs
            int[] intArray = new int[10]; // 10 = Anzahl der reservierten Felder

            // Initialisierung 
            // a) "zu Fuß"
            intArray[0] = 22;
            intArray[1] = 2;
            intArray[2] = 32;
            //...

            // Initialisierung 
            // b1) per Schleife (mit selbst gesetzter oberer Grenze "<10")
            // hier: alle Felder mit 1 füllen
            for (int i = 0; i < 10; i++) intArray[i] = 1;

            // Initialisierung 
            // b2) per Schleife (OHNE dass man die Anzahl  der Felder kennen muss)
            // => Verwendung von arrayName.Length
            // hier: alle Felder mit 1 füllen
            for (int i = 0; i < intArray.Length; i++) intArray[i] = 1;

            // Initialisierung 
            // c) sofort, in der selben Zeile in der wir deklarieren, definieren und erzeugen
            int[] array2 = new int[5] { 11, 2, 33, 444, 5 };
            // das Gleichheitszeichen vor { 11, 2, 33, 444, 5 } entfällt im Gegensatz zu ANSI C

            // Bemerkung zur foreach-Schleife
            // a) foreach klappt bei der Ausgabe (Auslesen der Inhalte)
            int[] foo1 = new int[5] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Kontrollausgabe des Arrays foo1:");
            foreach (int x in foo1)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();

            // b) foreach mit string
            string[] foo2 = new string[5] { "1a", "2b", "3c", "4d", "5e" };
            Console.WriteLine("Kontrollausgabe des Arrays foo2:");
            foreach (string x in foo2)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();

            // c) KLAPPT NICHT: foreach-Schleife zum Überschreiben
            // foreach (int y in foo1) y = 1;
            // Die Iterationsvariable y darf nicht überschrieben werden


            // andere Datentypen:
            double[] dArray = new double[3] { 1.1, 22.2, 33.3333 };
            Console.WriteLine("Kontrollausgabe des Double-Arrays:");

            for (int i = 0; i < dArray.Length; i++) Console.Write(dArray[i] + " ");


            string[] sArray = new string[2] { "C#", "ist super." };
            Console.WriteLine("\nKontrollausgabe des String-Arrays:");
            for (int i = 0; i < sArray.Length; i++)
            {
                Console.Write(sArray[i] + " ");
            }

            // Bemerkung zu den einzelnen Zeichen eines Strings
            string beispielString = "Abcdef...";
            // 2. Buchstabe des Strings (Index 1)
            Console.WriteLine("\n\nZweiter Buchstabe von " + beispielString + " lautet:" + beispielString[1]);

            // 5. Buchstabe des 2. Strings eines Arrays (hier:sArray)
            Console.WriteLine("5. Buchstabe des 2. Strings:" + sArray[1][4]);

            // Neben 'Length' gibt es noch weitere Größen auf die wir zugreifen können, ohne eigenen Code schreiben zu müssen

            int[] nochEinArray = new int[4] { 1, 2, 3, 4 };
            //Ausgabe des Minimums
            Console.WriteLine("\nMinimum des Arrays:" + nochEinArray.Min()); //LINQ

            //Ausgabe des Maximums
            Console.WriteLine("\nMaximum des Arrays:" + nochEinArray.Max()); //LINQ

            // wir können Arrays auch sortieren
            double[] dArray2 = new double[3] { 3.3, 2.2, 1.1 };
            Console.WriteLine("\nOriginal-Reihenfolge des double-Arrays:");
            for (int i = 0; i < dArray2.Length; i++) Console.Write(dArray2[i] + " ");

            // Sortierung
            Array.Sort(dArray2);
            Console.WriteLine("\nReihenfolge des double-Arrays nach Sortierung:");
            for (int i = 0; i < dArray2.Length; i++) Console.Write(dArray2[i] + " ");


            // Sortierung reverse
            Array.Sort(dArray2);
            Array.Reverse(dArray2);
            Console.WriteLine("\nReihenfolge des double-Arrays nach 2. Sortierung:");
            for (int i = 0; i < dArray2.Length; i++) Console.Write(dArray2[i] + " ");

            Console.ReadKey();


        }
    }
}