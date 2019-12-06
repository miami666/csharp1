using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Aufgabe 1
Bitte schreiben Sie ein C#-Programm, das alle GERADEN Zahlen größer 0 und kleiner 100 auf der Konsole ausgibt:
Lösen Sie bitte diese Aufgabe in dreifacher Ausführung (mit einer for, while und do-while-Schleife)



            


Aufgabe 5

Schreiben Sie bitte das folgende C# Programm: ZahlRaten
 - Das Programm startet mit dem Auslosen einer Zufallszahl x (ganze Zahl zwischen 1 und 100)
 - anschließend beginnt eine Schleife, in der pro Durchlauf ...
   + vom User eine ganze Zahl abgefragt wird (bei unzulässigen Eingaben: Fehlermeldung + Wiederholung der abfrage)
   + ausgegeben wird, ob die Eingabe größer oder kleiner x ist
 - die Schleife endet mit einer Erfolgsmeldung, falls der User richtig lag
   + in der Erfolgsmeldung wird mitgeteilt, wieviele Versuche der User benötigte   
 */
namespace kleine_aufgaben_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <=100; i++)
            {
                if(i%2==0)
                {
                    Console.WriteLine(i);
                }

            }
            Console.ReadKey();
        }
    }
}
