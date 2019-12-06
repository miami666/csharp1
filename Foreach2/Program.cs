/* Schreiben Sie folgendes C# Programm:
 * Erstellen Sie ein Integer-Array der Größe MaxInt und lassen Sie es mit Zufallswerten füllen.
 * Anschließend speichern Sie sich die Systemzeit und lassen das Array in einer For-Schleife laufen 
 * (in dem Sie z.B. den aktuellen Wert an eine andere Variable zuweisen).
 * Speichern Sie sich wieder die Systemzeit und geben Sie die gemessene differenz aus.
 * Dann speichern Sie sich erneut die Systemzeit, lassen das Array in einer ForEach-Schleife laufen
 * und messen die verstrichene Zeit.
 * Erweiterung: Lassen Sie die beiden Schleifen mehrmals laufen und messen Sie den Durchschnitt
 */


using System;
using System.Collections.Generic;

namespace Foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            //SchleifenBeispiel();
            SchleifenLaufzeitMessung();

            Console.ReadKey();
        }

        public static void SchleifenLaufzeitMessung()
        {
            int länge = Int32.MaxValue / 10;
            int[] array = new int[länge];
            Random random = new Random();
            for (int i = 0; i < länge; i++)
            {
                array[i] = random.Next();
            }
            Console.WriteLine("Start");
            Console.ReadKey();
            int z = 0;
            long time = 0;
            long timeSum = 0;
            
            Console.WriteLine("For-Schleife");
            for (int i = 0; i < 100; i++)
            {
                time = DateTime.Now.Ticks;
                for (int j = 0; j < länge; j++)
                {
                    z = array[j];
                }
                time = DateTime.Now.Ticks - time;
                timeSum += time;
            }
            Console.WriteLine("Durchschnittlich " + TimeSpan.FromTicks(timeSum / 100).TotalSeconds + " Sekunden");
            timeSum = 0;
            Console.WriteLine("ForEach-Schleife");
            for (int i = 0; i < 100; i++)
            {
                time = DateTime.Now.Ticks;
                foreach (int value in array)
                {
                    z = value;
                }
                time = DateTime.Now.Ticks - time;
                timeSum += time;
            }
            Console.WriteLine("Durchschnittlich " + TimeSpan.FromTicks(timeSum / 100).TotalSeconds + " Sekunden");
            Console.ReadKey();
        }

        public static void SchleifenBeispiel()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };

            Console.WriteLine("Ausgabe in For-Schleife");
            for (int i = 0; i < array.Length; i++)
            {
                //array[i] = 6; Hier ist eine Zuweisung möglich
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("\nAusgabe in ForEach-Schleife");
            //Um eine Variable als Collection in der ForEach Schleife verwenden zu können, muss diese Variable über 
            //eine GetEnumerator Methode aus dem Interface IEnumerable verfügen
            foreach (int zahlAusArray in array)
            {
                //zahlAusArray = 6; Zuweisung nicht möglich
                Console.Write(zahlAusArray + " ");
            }


            List<string> stringListe = new List<string>() { "Hello", "World", "!" };

            Console.WriteLine("\nAusgabe in For-Schleife");
            for (int i = 0; i < stringListe.Count; i++)
            {
                //stringListe[i] = "Bla"; Zuweisung ist hier möglich
                Console.Write(stringListe[i] + " ");
            }

            Console.WriteLine("\nAusgabe in ForEach-Schleife");
            foreach (string stringAusListe in stringListe)
            {
                //stringAusListe = "Bla"; Zuweisung nicht möglich
                Console.Write(stringAusListe + " ");
            }

            //Wenn ich die Werte in einer Collection bei der Weiterverarbeitung über eine Schleife verändern möchte,
            //dann muss ich eine For-Schleife (oder While / Do-While) verwenden.
            //Möchte ich die Werte einfach nur ausgeben oder weiterverarbeiten ohne sie zu verändern,
            //dann kann ich die ForEach-Schleife verwenden
        }
    }
}
