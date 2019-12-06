using GLP_CSH_Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontoApp
{
    public class Konto
    {
        public string Kontonummer { get; private set; }
        public string Bankleitzahl { get; private set; }
        public Kunde Kontoinhaber { get; private set; }
        public double Kontostand { get; private set; }

        /// <summary>
        /// Wirft Exception wenn Betrag 0 oder negativ
        /// </summary>
        /// <param name="betrag">Der einzuzahlende Betrag</param>
        public void Einzahlen(double betrag)
        {
            if (betrag > 0)
            {
                Kontostand += betrag;
            }
            else
            {
                throw new Exception("Betrag negativ, keine Einzahlung möglich");
            }
        }

        /// <summary>
        /// Wirft Exception wenn Betrag 0 oder negativ.
        /// </summary>
        /// <param name="betrag">Der abzuhebende Betrag</param>
        /// <returns>true, wenn erfolgreich - false, wenn nicht erfolgreich</returns>
        public bool Abheben(double betrag)
        {
            if (betrag > 0)
            {
                if (Kontostand >= betrag)
                {
                    Kontostand -= betrag;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new Exception("Betrag negativ, keine Auszahlung möglich");
            }
        }

        public Konto(string ktonr, string blz, Kunde inh)
        {
            Kontonummer = ktonr;
            Bankleitzahl = blz;
            Kontoinhaber = inh;
        }


    }
}
