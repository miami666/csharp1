using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Schreiben Sie bitte ein C#-Programm, in dem ...
- eine Klasse 'Kurs' definiert wird
  + Folgende Member besitzt diese Klasse
    - privater Integer kursnummer
    - privater statischer Instanzenzähler
    - öffentlicher statischer MaxWert (maximale Anzahl der zulässigen Instanzen vom Typ Kurs)
    - privates statischen Array vom Typ Kurs (Anzahl der Felder=maxWert)
    - öffentlicher Konstruktor 'Kurs(x)'
      Übergabewert: eine Kursnummer x
        Funktion: speichert x in kursnummer ab ...
                    FALLS diese Kursnummer nicht bereits bei zuvor instanziierten Objekten vergeben wurde
                    SONST wird kursnummer=-1 gesetzt und es erscheint eine Warnhinweis
				  Der Kurs wird im Array abgelegt
        Rückgabewert: Keiner                                       
    - öffentliche statische Methode 'ZeigeAlle()'
        Übergabewerte: Keine
        Funktion: Gibt alle Kursnummern der instanzierten Objekte vom Typ Kurs auf der Konsole aus
                  (Falls Kursnummer==-1 erscheint eine Fehlermeldung)
        Rückgabewert: Keiner
- im Main eine for-Schleife gestartet wird (Anzahl der Durchläufe: maxWert)
  + pro Durchlauf wird ein neues Objekt vom Typ Kurs instanziiert (Übergabewert ist eine Zufallszahl zwischen 1 und maxWert)
- im Main abschließend zur Kontrolle die Funktion zeigeAlle() aufgerufen wird
HINWEIS: Wie kann ich das Array mit einer gültigen MaxGröße erstellen?
*/
namespace G45_aufgabe_1
{
    class Kurs
    {
        int kursnummer;
        private static int ObjektCounter = 0;
        public static int maxWert = 10;
        static Kurs[] Array = new Kurs[maxWert];
        public Kurs(int x)
        {
            Array[ObjektCounter] = this;
            ObjektCounter++;
            for (int i = 0; i < ObjektCounter - 1; i++)
            {
                if (x == Array[i].kursnummer)
                {
                    kursnummer = -1;
                    //Console.WriteLine("existiert schon");
                }
            }
            if (kursnummer != -1)
            {
                kursnummer = x;
            }
        }
        public static void ZeigeAlle()
        {
            for (int i = 0; i < maxWert; i++)
            {
                Console.WriteLine(Array[i].kursnummer);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Enumerable.Range(1, Kurs.maxWert).ToArray();
            var rannd = new Random(Guid.NewGuid().GetHashCode());

            // Shuffle the array
            for (int i = 0; i < Kurs.maxWert; ++i)
            {
                int randomIndex = rannd.Next(nums.Length);
                int temp = nums[randomIndex];
                nums[randomIndex] = nums[i];
                nums[i] = temp;

            }
            for (int i = 0; i < Kurs.maxWert; ++i)
            {
                Kurs k = new Kurs(nums[i]);
            }
            //Random r = new Random(Guid.NewGuid().GetHashCode());
            //for (int i = 0; i <Kurs.maxWert; i++)
            //{
            //    int rand = r.Next(1, Kurs.maxWert+1);
            //    Kurs k = new Kurs(rand);
            //}
            Kurs.ZeigeAlle();
            Console.ReadKey();
        }
    }
}
