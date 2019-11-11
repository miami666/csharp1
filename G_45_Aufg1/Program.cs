/*
Schreiben Sie bitte ein C#-Programm, in dem ...
- eine Klasse 'Kurs' definiert wird
  + Folgende Member besitzt diese Klasse
    - privater Integer kursnummer
    - privater statischer Instanzenzähler
    - öffentlicher statischer maxWert (maximale Anzahl der zulässigen Instanzen vom Typ Kurs)
    - privates statischen Array vom Typ Kurs (Anzahl der Felder=maxWert)
    - öffentlicher Konstruktor 'Kurs(x)'
      Übergabewert: eine Kursnummer x
        Funktion: speichert x in kursnummer ab ...
                    FALLS diese Kursnummer nicht bereits bei zuvor instanziierten Objekten vergeben wurde
                    SONST wird kursnummer=-1 gesetzt und es erscheint eine Warnhinweis
			Der Kurs wird im Array abgelegt
        Rückgabewert: Keiner                                       
    - öffentliche statische Methode 'zeigeAlle()'
        Übergabewerte: Keine
        Funktion: Gibt alle Kursnummern der instanzierten Objekte vom Typ Kurs auf der Konsole aus
                  (Falls Kursnummer==-1 erscheint eine Fehlermeldung)
        Rückgabewert: Keiner
- im Main eine for-Schleife gestartet wird (Anzahl der Durchläufe: maxWert)
  + pro Durchlauf wird ein neues Objekt vom Typ Kurs instanziiert (Übergabewert ist eine Zufallszahl zwischen 1 und maxWert)
- im Main abschließend zur Kontrolle die Funktion zeigeAlle() aufgerufen wird
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_45_Aufg1
{
    class Kurs
    {
        private static int zähler = 0;
        public static int maxKursAnzahl = 10;
        private static Kurs[] kursArray = new Kurs[maxKursAnzahl];
        public static void zeigeAlle()
        {
            Console.WriteLine("Folgende Kursnummern wurden vergeben:");
            for (int i = 0; i < zähler; i++)
            {
                if (kursArray[i].kursnummer != -1) Console.WriteLine("Kurs " + (i + 1) + ": " + kursArray[i].kursnummer);
                else Console.WriteLine("Kurs " + (i + 1) + ": Kursnummer konnte noch nicht vergeben werden");
            }
        }

        public Kurs(int kursnummer)
        {
            kursArray[zähler] = this;
            zähler++;

            Console.Write("Aktuell übergebene Kursnummer: " + kursnummer);
            for (int i = 0; i < zähler - 1; i++)
            {
                if (kursArray[i].kursnummer == kursnummer)
                {
                    Console.Write(" (ACHTUNG: Wurde bereits vergeben!)");
                    this.kursnummer = -1;
                    break;
                }
            }
            if (this.kursnummer != -1) this.kursnummer = kursnummer;
            Console.WriteLine();
        }

        private int kursnummer;
    }


    class Program
    {
        static void Main(string[] args)
        {
            Random zuf = new Random();

            Console.WriteLine("Folgende Kursnummern wurden ausgelost:");
            for (int i = 0; i < Kurs.maxKursAnzahl; i++)
            {
                new Kurs(zuf.Next(1, 11));
            }

            Console.WriteLine();
            Kurs.zeigeAlle();

            Console.Write("\n\n\n\nDrücken einer beliebigen Taste beendet das Programm ");
            Console.ReadKey();
        }
    }
}
