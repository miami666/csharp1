using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLP_CSH_Klassen
{
    public abstract class Kunde
    {
        public string Vorname { get; private set; }
        public string Nachname { get; private set; }
        public string Adresse { get; private set; }
        public DateTime KundeSeit { get; set; }

        protected Kunde(string vorname, string nachname, string adresse, DateTime kundeSeit)
        {
            Vorname = vorname;
            Nachname = nachname;
            Adresse = adresse;
            KundeSeit = kundeSeit;
        }


        // bei abstrakten Methoden keinen Funktionskörper! 
        public abstract void Login();
    }

    public class PrivateKunde : Kunde
    {
        public override void Login()
        {
            Console.WriteLine("Privater Kunde möchte sich einloggen!");
        }

        public PrivateKunde(string vorname, string nachname, string anschrift, DateTime kundeSeit) : base(vorname, nachname, anschrift, kundeSeit)
        {

        }
    }

    public class Geschäftskunde : Kunde
    {
        public override void Login()
        {
            Console.WriteLine("Geschäftskunde möchte sich einloggen!");
        }

        public Geschäftskunde(string vorname, string nachname, string anschrift, DateTime kundeSeit) : base(vorname, nachname, anschrift, kundeSeit)
        {

        }
    }
}
