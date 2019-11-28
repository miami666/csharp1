using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BankTest
    {
        /*2.	A bank holds different types of accounts for its customers: 
         * deposit accounts, loan accounts and mortgage accounts. Customers could be individuals or companies.*/

        /*All accounts have customer, balance and interest rate (monthly based). 
         * Deposit accounts are allowed to deposit and with draw money. 
         * Loan and mortgage accounts can only deposit money.*/

        /*All accounts can calculate their interest amount for a given period (in months). 
         * In the common case its is calculated as follows: number_of_months * interest_rate.*/

        /*Loan accounts have no interest for the first 3 months 
         * if are held by individuals and for the first 2 months if are held by a company.*/

        /* Deposit accounts have no interest if their balance is positive and less than 1000. */

        /* Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.*/
        static void Main()
        {
            //kunden erstellen
            Person person = new Person("Uschi", "Glas", "München");
            Person kunde = new Person("Angela", "Merkel", "Berlin");
            Firma firma = new Firma("AfD", "Im Anus", TypderFirma.BriefkastenFirma);

            //konto erstellen interest 3% = 0.03M
            Einzahlungskonto ek1 = new Einzahlungskonto(person, 450.00M, 0.03M, 4);
            Console.WriteLine("Kontostand von {0} ist {1}", person.Vorname, ek1.Kontostand+" Euro");
            ek1.Kontostand = ek1.GeldEinzahlen(2400);
            Console.WriteLine("{0}s Kontostand nach Einzahlung von 2400 Euro  ist {1}", person.Vorname, ek1.Kontostand);
            Console.WriteLine("Zinsen auf Einzahlung {0} is {1}", person.Vorname, ek1.BerechneZinsen());
            Darlehenskonto besitzerDarlehensKonto = new Darlehenskonto(person, 3200.0M, 0.04M, 13);
            Console.WriteLine("Zinsen Darlehenskonto {0} is {1}", person.Vorname, besitzerDarlehensKonto.BerechneZinsen());
            Hypothekenkonto besitzerHypothekenKonto = new Hypothekenkonto(person, 5060.80M, 0.05M, 14);
            Console.WriteLine("Zinsen Hypothekenkonto {0} is {1}", person.Vorname, besitzerHypothekenKonto.BerechneZinsen());

            Console.WriteLine();
            Einzahlungskonto ek2 = new Einzahlungskonto(kunde, 3000.50M, 0.023M, 2);
            Console.WriteLine("Kontostand von {0} ist {1}", kunde.Vorname, ek2.Kontostand);

            Console.WriteLine();
            Einzahlungskonto ek3 = new Einzahlungskonto(firma, 500.0M, 0.07M, 5);
            Console.WriteLine("Kontostand \"{0}\" {1} ist {2}", firma.FirmaName,firma._firmatyp, ek3.Kontostand);
            Console.WriteLine("Zinsen Konto {0} is {1}", firma.FirmaName, ek3.BerechneZinsen());
            Hypothekenkonto hk1 = new Hypothekenkonto(firma, 2500.00M, 0.05M, 13);
            Console.WriteLine("Zinsen Hypothekenkonto {0} is {1}", firma.FirmaName, hk1.BerechneZinsen());
            Console.ReadKey();
        }
    }
}
