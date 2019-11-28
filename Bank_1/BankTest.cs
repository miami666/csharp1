using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BankTest
    {
        /*Die Bank hat verschiedene Kundentypen(z.B. privat,Firma...)
         * es gibt normale Konten, Kreditkonten und Hypothekkonten*/

        /*Jedes Konto gehört zu einem Kunden,hat einen aktuellen Kontostand und eine monatliche Zinsrate (monthly based). 
         * normale skonten dürfen einzahlen und Geld abheben.
           Kredit- und Hypothekenkonten können nur Geld einzahlen.*/

        /*
         Alle Konten können ihren Zinsbetrag für einen bestimmten Zeitraum (in Monaten) berechnen.
        Im Normalfall wird es wie folgt berechnet: Anzahl_Monate * Zinssatz.
        Darlehenskonten sind in den ersten 3 Monaten nicht verzinslich
        wenn sie von Einzelpersonen gehalten werden und während der ersten 2 Monate von einer Firma gehalten
        werden.

         Einlagenkonten sind nicht verzinslich, wenn ihr Saldo positiv ist und weniger als 1000 beträgt.
             Hypothekenkonten sind in den ersten 12 Monaten für Unternehmen und in den ersten 6 Monaten nicht für Privatpersonen zu verzinsen.
             */
        static void Main()
        {
            //dummy-kunden erstellen
            Person person = new Person("Uschi", "Glas", "München");
            Person kunde = new Person("Angela", "Merkel", "Berlin");
            Firma firma = new Firma("AfD", "Im Anus", TypderFirma.BriefkastenFirma);

            //konto erstellen mit zinsrate 3% = 0.03M
            Einzahlungskonto ek1 = new Einzahlungskonto(person, 450.00M, 0.03M, 4);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Kontostand von {0} {1} ist {2}", person.Vorname,person.Nachname, ek1.Kontostand + " Euro\n");
            ek1.Kontostand = ek1.GeldEinzahlen(2400);
            Console.WriteLine("{0}s Kontostand nach Einzahlung von 2400 Euro  ist {1} Euro", person.Vorname, ek1.Kontostand);
            Console.WriteLine("Zinsen auf Einzahlung {0} {1} {2} Euro", person.Vorname,person.Nachname,ek1.BerechneZinsen());
            Console.ResetColor();
            //Darlehenskonto besitzerDarlehensKonto = new Darlehenskonto(person, 3200.0M, 0.04M, 13);
            //Console.WriteLine("Zinsen Darlehenskonto {0} is {1}", person.Vorname, besitzerDarlehensKonto.BerechneZinsen());
            //Hypothekenkonto besitzerHypothekenKonto = new Hypothekenkonto(person, 5060.80M, 0.05M, 14);
            //Console.WriteLine("Zinsen Hypothekenkonto {0} is {1}", person.Vorname, besitzerHypothekenKonto.BerechneZinsen());

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Einzahlungskonto ek2 = new Einzahlungskonto(kunde, 3000.50M, 0.023M, 2);
            Console.WriteLine("Kontostand von {0} {1} ist {2} Euro", kunde.Vorname,kunde.Nachname, ek2.Kontostand);
            Console.ResetColor();

            Console.WriteLine();
           /* Console.ForegroundColor = ConsoleColor.Red;
            Einzahlungskonto ek3 = new Einzahlungskonto(firma, 500.0M, 0.07M, 5);
            Console.WriteLine("Kontostand \"{0}\" {1} ist {2} Euro", firma.FirmaName, firma._firmatyp, ek3.Kontostand);
            Console.WriteLine("Zinsen Konto {0} {1} {2} Euro", firma.FirmaName,firma._firmatyp, ek3.BerechneZinsen());
            Hypothekenkonto hk1 = new Hypothekenkonto(firma, 2500.00M, 0.05M, 13);
            Console.WriteLine("Zinsen Hypothekenkonto{0} {1} {2} Euro", firma.FirmaName,firma._firmatyp, hk1.BerechneZinsen());
            Console.ResetColor();*/
            Console.ReadKey();
        }
    }
}
