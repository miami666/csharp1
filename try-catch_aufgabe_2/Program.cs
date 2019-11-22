using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Schreiben Sie bitte zunächst die drei folgenden Methoden:
    a) Funktionsname: Schreibe
       Übergabewerte: Integerliste l
       Funktion:      Konsolenausgabe aller Elemente von l
       Rückgabewert:  Keiner
    b) Funktionsname: TryRemoveAt
       Übergabewerte: Referenz auf Integer-Liste l, Integer i 
       Funktion:      Versucht in l das Element mit Index i zu löschen
                      FALLS dieser Index existiert, wird das Element gelöscht und eine boolsche Variable b auf 'true' gesetzt
                      SONST wird kein Element gelöscht und b auf 'false' gesetzt
       Rückgabewert:  b
    c) Funktionsname: Length
       Übergabewerte: Integer-Liste l
       Funktion:      Ermittelt die Anzahl der Elemente von l
       Rückgabewert:  Anzahl der Elemente
    d) Funktionsname: TryRemoveFromXtoY
       Übergabewerte: Referenz auf Integer-Liste l, Integer x, Integer y 
       Funktion:      - FALLS x>y werden die Werte von x und y getauscht
                        SONST bleiben x und y unverändert
                      - Versucht in l alle Elemente mit Index x bis y (beiderseits einschließlich) zu löschen
                        FALLS alle diese Indices existieren, werden die entsprechenden Elemente gelöscht und eine boolsche Variable b auf 'true' gesetzt
                        SONST wird kein Element gelöscht und b auf 'false' gesetzt
       Rückgabewert:  b
   Testen Sie obige Funktionen bitte mit Hilfe des folgenden Programms:
    - Es wird eine Integerliste eingeführt und mit den Werten von 0 bis 9 gefüllt
    - Es startet eine Schleife, in der pro Durchlauf ...
      + die Konsole gelöscht wird
      + der bisherige Inhalt der Integerliste auf der Konsole ausgegeben wird
      + vom User eine ganze Zahl x abgefragt wird
      + die Schleife wiederholt wird  FALLS die Usereingabe keine ganze Zahl ODER das Element an der Stelle x nicht gelöscht werden kann
      + Dann über TryRemoveAt die Zahl an Stelle x löschen
    - Nach der Schleife der neue Inhalt der Integerliste auf der Konsole ausgegeben wird
    - anschließend eine neue Integerliste_2 eingeführt wird, die ebenfalls mit den Werten von 0 bis 9 gefüllt wird
    - der aktuelle Inhalt von Integerliste_2 auf der Konsole ausgegeben wird 
    - daruafhin eine Schleife startet, in der pro Durchlauf ...
      + zwei ganze Zahlen abgefragt werden
      + die Schleife wiederholt wird, FALLS nicht beide Eingaben ganze Zahlen sind, oder nicht beide Zahlen zulässige Indices in Integerliste_2 (Mit Hilfe von TryRemoveFromXtoY)
    - Nach der Schleife wird der neue Inhalt der Integerliste_2 auf der Konsole ausgegeben und das programm endet
*/

namespace try_catch_aufgabe_2
{
    class Program
    {
        static void Schreibe(List<int> iL)
        {
           foreach (var item in iL)
            {
                Console.WriteLine(item);
           }
        }
        public static bool TryRmvAt(List<int> iL, int i)
        {
            bool rmvd;
            if(iL.Contains(i))
            {
                iL.RemoveAt(i);
                rmvd = true;
           }
            else
            {
                rmvd = false;
           }
            return rmvd;
       }
        public int intLstLength(List<int> iL)
        {
           return iL.Count();
       }
        public static bool TryRmvRng(List<int> iL, int x, int y)
        {
            bool rmvd;
           if (x > y)
            {
                iL.RemoveRange(y, x-y+1);
                rmvd = true;
            }
            else if (x < y)
            {
                iL.RemoveRange(x, y-x+1);
                rmvd = true;
            }
            else
            {
                rmvd = false;
            }
                return rmvd;
        }
       static void Main(string[] args)
        {
            int x=0;
            int y=0;
            int pos = 0;
            int pos2 = 0;
            List<int> intLst = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                intLst.Add(i);
           }
            Console.ForegroundColor
             = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\nListe 1 vor Aufruf der Methode RemoveAt:\n\n");
            Console.ResetColor();
            foreach (int item in intLst)
            {
                Console.Write("Liste 1 Index {0}:", pos);
                Console.WriteLine(item);
                pos++;
           }
            do
            {
               // Console.Clear();
                Console.WriteLine("\n\nBitte eine Zahl eingeben: ");
           } while (!int.TryParse(Console.ReadLine(), out x));
            TryRmvAt(intLst, x);
            pos = 0;
            Console.WriteLine("\n\nListe 1 nach RemoveAt:\n\n");
            foreach (int item in intLst)
            {
                Console.Write("Liste 1 Index  {0}: ", pos);
                Console.WriteLine(item);
                pos++;
           }
            Console.ReadKey();
            Console.Clear();
            List<int> intLst2 = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                intLst2.Add(i);
           }
            Console.WriteLine("\n\nListe 2 vor Aufruf der Methode RemoveRange:\n\n");
            foreach (int item in intLst2)
            {
                Console.Write("Liste 2 Index  {0}: ", pos2);
                Console.WriteLine(item);
                pos2++;
           }
            bool flagX=false,flagY=false;
           do
            {
                if (!intLst2.Contains(x) && !intLst2.Contains(y))
                {
                    continue; 
                }
                if (!flagX)
                {
                    Console.WriteLine("\n\nBite eine Zahl(x) eingeben: ");
                    flagX = int.TryParse(Console.ReadLine(), out x);
                }
                if (!flagY)
                {
                    Console.WriteLine("\n\nBitte eine Zahl(y) eingeben: ");
                    flagY = int.TryParse(Console.ReadLine(), out y);
                }
           } while (!flagX || !flagY );
           TryRmvRng(intLst2, x, y);
            pos2 = 0;
            Console.WriteLine("\n\nListe 2 nach RemoveRange: \n\n");
            foreach (int item in intLst2)
            {
                Console.Write("Liste 2 Index  {0}: ", pos2);
                Console.WriteLine(item);
                pos2++;
           }
           Console.ReadKey();
       }
    }
}
