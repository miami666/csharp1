using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLP_CSH_Klassen;

namespace KontoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Konto konto = new Konto("123456789", "85050300", new PrivateKunde("Teto", "Kasane", "Strasse 1, 01099 Berlin", DateTime.Now));
            Console.WriteLine("Kontostand konto: {0}", konto.Kontostand);
            Konto konto1 = new Konto("012345678", "85050300", new Geschäftskunde("Erich", "Honecker", "Leninstrasse 5, 01099 Berlin", new DateTime(1966, 11, 11)));
            Console.WriteLine("Kontostand konto1: {0}", konto1.Kontostand);

            Einzahlen(konto, -100);
            Einzahlen(konto, 100);
            Einzahlen(konto1, 50000);

            Abheben(konto, -1050);
            Abheben(konto, 200);// Das Argument "200" wird in den Parameter betrag geschrieben
                                // Der Rückgabewert wird an die Stelle des Methodenaufrufes geschrieben
            Abheben(konto, 50);

            konto.Kontoinhaber.Login();
            konto1.Kontoinhaber.Login();
           
            Console.WriteLine("Aktueller Kontostand konto: {0}", konto.Kontostand);

            Console.ReadKey();
        }

        public static void Einzahlen(Konto konto, double betrag)
        {
            if (betrag > 0)
            {
                Console.WriteLine($"ich zahle {betrag} Euro auf das Konto ein");
                konto.Einzahlen(betrag);
            }
            else
                Console.WriteLine("Einzahlen-Betrag ungültig!");
        }

        public static void Abheben(Konto konto, double betrag)
        {
            if (betrag > 0)
            {
                Console.WriteLine("ich hebe {0} Euro vom Konto ab", betrag);
                bool b = konto.Abheben(betrag);
                if (b)
                {
                    Console.WriteLine("Abhebung hat geklappt");
                }
                else
                {
                    Console.WriteLine("Abhebung hat nicht geklapppt");
                }
            }
            else
            {
                Console.WriteLine("Abheben-Betrag ungültig!");
            }

        }

    }

    

    
}
