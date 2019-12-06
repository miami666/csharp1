using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Aufgabe 5
Schreiben Sie bitte das folgende C# Programm: ZahlRaten
 - Das Programm startet mit dem Auslosen einer Zufallszahl x (ganze Zahl zwischen 1 und 100)
 - anschließend beginnt eine Schleife, in der pro Durchlauf ...
   + vom User eine ganze Zahl abgefragt wird (bei unzulässigen Eingaben: Fehlermeldung + Wiederholung der abfrage)
   + ausgegeben wird, ob die Eingabe größer oder kleiner x ist
 - die Schleife endet mit einer Erfolgsmeldung, falls der User richtig lag
   + in der Erfolgsmeldung wird mitgeteilt, wieviele Versuche der User benötigte           
     */
namespace kleine_aufgaben_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int counter = 0;
            int number,randomNumber;
            randomNumber = rnd.Next(1, 101);
            Console.WriteLine("Bitte versuchen Sie die Zahl "+randomNumber+" zu erraten: ");
            do
            {
                bool success = int.TryParse(Console.ReadLine(), out number);
                counter++;
                if (!success) Console.WriteLine("Falsches Format"); 
                else continue;
            } while (number!=randomNumber);
            Console.WriteLine("Sie haben {0} Versuche benötigt um die richtige Zahl {1} zu erraten",counter,randomNumber);
            Console.ReadKey();
        }
    }
}
