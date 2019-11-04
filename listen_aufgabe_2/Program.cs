using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Schreiben Sie bitte zunächst die 3 folgenden Methoden:
    a) Funktionsname: SchreibeListe
       Übergabewert:  1 Referenz auf eine String-Liste 'l'
       Funktion:      l wird sortiert, anschließend werden alle Strings in l auf der Konsole ausgegeben
       Rückgabewert:  Keiner
    b) Funktionsname: MitLeerzeichen
       Übergabewert:  1 String 's'
       Funktion:      Füllt die boolsche Variable 'b' mit 'true', FALLS s (mindestens) ein Leerzeichen besitzt, SONST 'false'
       Rückgabewert:  b
    c) Funktionsname: SchonVorhanden
       Übergabewert:  1 String-Liste 'l' und ein String 's'
       Funktion:      Füllt die boolsche Variable 'b' mit 'true', FALLS s in l vorkommt, SONST 'false'
       Rückgabewert:  b

    Testen Sie die obigen Methoden bitte mit Hilfe des folgenden Programms:
    - Zunächst wird eine String-Liste eingeführt
    - Das Programm startet eine Endlos-Schleife, in der pro Durchlauf ...
      + die Konsole gelöscht wird
      + vom User ein Wort abgefragt wird
        - falls in der Eingabe ein Leerzeichen vorkommt: entsprechende Fehlermeldung:
        - falls in der Eingabe KEIN Leerzeichen vorkommt, ABER die Eingabe bereits in der Liste vorkommt: entsprechende Fehlermeldung
        - falls WEDER eine Leerzeichen vorkommt NOCH die Eingabe bereits vorkommt, so wird die Eingabe in die Liste mit aufgenommen
      + alle Elemente der Liste werden auf der Konsole ausgegeben
      + der Schleifendurchlauf endet nach einem Tastendruck
*/

namespace listen_aufgabe_2
{
    class Program
    {
        public static void SchreibeListe(List<string> l)
        {
            Console.WriteLine("\nListe sortiert");
            l.Sort();
            Display(l);

        }
        public static bool MitLeerzeichen(string s)
        {
            
            bool b=s.Contains(" ");
            return b;
        }
        public static bool SchonVorhanden(List<string> l,string s)
        {
            bool b = l.Contains(s);
            return b;
        }
        static void Main(string[] args)
        {
            string s;
            bool valid = true;
            List<string> l = new List<string>();
            // list elements 
            l.Add("A");
            l.Add("I");
            l.Add("G");
            l.Add("B");
            l.Add("E");
            l.Add("H");
            l.Add("F");
            l.Add("C");
            l.Add("D");

            Console.WriteLine("Liste unsortiert");
            Display(l);
            SchreibeListe(l);
            Console.ReadKey();
            do
            {
                Console.Clear();
                Console.WriteLine("Bitte ein Wort eingeben:");
                s = Console.ReadLine();
                if (MitLeerzeichen(s))
                {
                    Console.WriteLine("Fehler! Leerzeichen");
                    Console.ReadKey();

                }
                else
                {
                    if (SchonVorhanden(l, s))
                    {
                        Console.WriteLine("Fehler - schon vorhanden");
                        Console.ReadKey();
                    }
                    else
                    {
                        valid = false;
                        l.Add(s);
                    }
                }
            } while (valid!=false);
            SchreibeListe(l);
            Console.ReadKey();
            
        }
        public static void Display(List<string> list)
        {
            foreach (string g in list)
            {
                Console.Write(g + " ");
            }
        }
    }
}
