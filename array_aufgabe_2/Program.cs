using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Schreiben Sie bitte ein C#-Programm, in dem ...
    - in einer Schleife 6 Lottozahlen abgefragt werden
        + Die Abfrage einer Zahl wird wiederholt, wenn ...
              a) Das Eingabeformat keiner ganzen Zahl entspricht
              b) Die eingegebene Zahl bereits zuvor ausgewählt wurde
              c) Die eingegebene Zahl nicht zwischen 1 und 49 liegt
        + Falls weder a), b) noch c) zutrifft, wird die eingegebene Zahl in das Integer-Array 'tipp' abgespeichert 
    - nach der Schleife das Array tipp sortiert wird
    - anschschließend das Array auf der Konsole ausgegeben wird
*/
namespace array_aufgabe_2
{
    class Program
    {
        public static void SpieleLotto(int[] arr)
        {
            Random rnd = new Random();
            int[] ziehung = new int[6];
            int anzahl, anzahlZiehungen = 0;
            int dreier = 0, vierer = 0, fuenfer = 0;

            do
            {
                for (int i = 0; i < 6; i++)
                {
                    ziehung[i] = rnd.Next(1, 50);
                    for (int j = 0; j < i; j++)
                    {
                        while (ziehung[i] == ziehung[j])        // Eingabe bereits in der Ziehung
                        {
                            ziehung[i] = rnd.Next(1, 50);
                        }
                    }
                }

                anzahl = 0;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (ziehung[i] == arr[j])
                        {
                            anzahl++;
                        }
                    }
                }
                if (anzahl == 3) { dreier++; }
                else if (anzahl == 4) { vierer++; }
                else if (anzahl == 5) { fuenfer++; }
                anzahlZiehungen++;
            } while (anzahl != 6);

            Console.WriteLine("Nach {0} Ziehungen hätten Sie gewonnen.\nDer Jackpot lag bei {1} Mio.", anzahlZiehungen, rnd.Next(1000));
            Console.WriteLine("Bis dahin hätten Sie {0} 3er, {1} 4er & {2} 5er gehabt", dreier, vierer, fuenfer);
        }
        static void Main(string[] args)
        {
            //int zahl;
            //bool valid = false;
            Console.WriteLine("6 aus 49!\n\n\nDrücken Sie eine Taste um fortzufahren");
            Console.ReadKey();
            Random r = new Random();
            int[] zahlen = new int[6];
            for (int i = 0; i < zahlen.Length; i++)
                zahlen[i] = r.Next(0,49);
            
            //int zahl;
            //bool valid = false;
            
            //for (int i = 0; i < 6; i++)
            //{
            //    do
            //    {
            //        Console.Clear();
            //        Console.WriteLine("Geben Sie ihre {0}. Zahl ein: ", (i + 1));
            //        valid = Int32.TryParse(Console.ReadLine(), out zahl);

            //        if (valid != true                                               // ungültig
            //            || Array.Exists<int>(zahlen, element => element == zahl)    // schon getippt
            //            || zahl < 1 || zahl > 49)                                   // nicht zwichen 1 und 49
            //        {
            //            valid = false;
            //            Console.WriteLine("Ungültig!\nDrücken Sie eine beliebige Taste, um erneut einzugeben.");
            //            Console.ReadKey();
            //            continue;
            //        }
            //        else
            //        {
            //            zahlen[i] = zahl;
            //        }
            //    } while (valid != true);
            //}
            
            
            Console.WriteLine("getippte Zahlen:");
            for (int i = 0; i < zahlen.Length; i++) Console.Write(zahlen[i] + " ");
            Array.Sort(zahlen);
            Console.WriteLine("\nReihenfolge nach Sortierung:");
            for (int i = 0; i < zahlen.Length; i++) Console.Write(zahlen[i] + " ");
            SpieleLotto(zahlen);
            Console.ReadKey();

        }
    }
}