/* Sie erhalten die Aufgabe, ein Programm zu schreiben, das den Rechnungsbetrag einer Rechnung berechnet. 
 * Die Rechnungspositionen sind in einem Array abgelegt. 
 * Der Betrag einer Rechnungsposition bestehend aus der Menge und dem Einzelpreis des Artikels 
 * soll in einer Funktion ausgelagert werden.
 * Erstellen Sie einen PAP, ein Struktogramm, oder Pseudocode und anschließend das C Programm. 
 */


using System;


namespace GLP_CSH_Rechnungsbetrag
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            random.Next(100);

            try
            {

            }
            catch (Exception)
            {

                throw;
            }


    }
    }

    public class Rechnungsposition
    {
        public int Menge { get; private set; }
        public double Preis { get; private set; }

        public Rechnungsposition(int menge, double preis)
        {
            Menge = menge;
            Preis = preis;
        }
    }
}
