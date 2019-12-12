using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer[] computers = { new Computer("Eigenbau"), new Desktop("HP"), new Notebook("ASUS") };

            foreach(Computer c in computers)
            {
                c.EinAusschalten();
            }

            foreach (Computer c in computers)
            {
                c.EinAusschalten();
            }


            Console.ReadKey();
        }

       
    }

    delegate void Schalter(string typ);


    static class Technik
    {
        // "externe" Methode zur Demonstration der Ausführung einer Delegate-Methode
        public static void Schalte(Schalter schalter, string typ)
        {
            if (schalter.Target is Computer)
                Console.WriteLine(((Computer)schalter.Target).Hersteller);
            schalter(typ);
        }
    }

    class Computer
    {
        public Schalter EinAus_DelegatVariable; //Schalter ist der Delegate-Typ, EinAus ist der Variablenname
        public string Hersteller { get; private set; }
        public bool Zustand { get; protected set; }

        public Computer(string hersteller)
        {
            Hersteller = hersteller;
        }

        public virtual void EinAusschalten()
        {
            Schalten();
            Technik.Schalte(EinAus_DelegatVariable, "Computer");
        }

        protected void Schalten()
        {
            if (!Zustand)
                EinAus_DelegatVariable = SchalteEin;
            else
                EinAus_DelegatVariable = SchalteAus;
        }

        //Delegate-Methoden
        protected void SchalteEin(string typ)
        {
            Console.WriteLine(typ + " " + Hersteller + " wird gestartet...");
            Zustand = true;
        }
        protected void SchalteAus(string typ)
        {
            Console.WriteLine(typ + " " + Hersteller + " wird heruntergefahren...");
            Zustand = false;
        }

    }

    class Desktop : Computer
    {
        public Desktop(string hersteller) : base(hersteller) { }

        public sealed override void EinAusschalten()
        {
            base.Schalten();

            Technik.Schalte(EinAus_DelegatVariable, "Desktop");
        }
    }

    class Notebook : Computer
    {
        public Notebook(string hersteller) : base(hersteller) { }

        public sealed override void EinAusschalten()
        {
            base.Schalten();

            Technik.Schalte(EinAus_DelegatVariable, "Notebook");
        }
    }

}
