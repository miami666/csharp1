using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern //https://www.philipphauer.de/study/se/design-pattern/observer.php
{
    public class Ware
    {
        public string Name { get; private set; }
        public Ware(string name)
        {
            Name = name;
        }
    }
    public class Zeitung
    {
        public string Name { get; private set; }
        public Zeitung(string name)
        {
            Name = name;
        }
    }


    public class Hersteller
    {
        //Die Herstellerklasse interessiert sich nicht für die speziellen Kunden
        //Das IKundeWaren Interface ist die Schnittstelle zwischen den speziellen Kunden-Klassen und der Hersteller-Klasse
        private List<IKundeWaren> ListeKunden = new List<IKundeWaren>();

        public void VerschickeWaren(Ware ware, int anzahl)
        {
            //Für jeden Eintrag in der ListeKunde wird die ErhalteWaren-Methode des Interfaces aufgerufen
            foreach (IKundeWaren kunde in ListeKunden)
            {                
                kunde.ErhalteWaren(ware, anzahl);
            }
        }

        public void KundeHinzufügen(IKundeWaren kunde)
        {
            ListeKunden.Add(kunde);
        }
        public void KundeEntfernen(IKundeWaren kunde)
        {
            ListeKunden.Remove(kunde);
        }

    }


    public class Verlag
    {
        private List<IKundeZeitung> ListeKunden = new List<IKundeZeitung>();
        public void VerschickeZeitung(Zeitung zeitung)
        {
            foreach (IKundeZeitung kunde in ListeKunden)
            {
                kunde.ErhalteZeitung(zeitung);
            }
        }

        public void KundeHinzufügen(IKundeZeitung kunde)
        {
            ListeKunden.Add(kunde);
        }
        public void KundeEntfernen(IKundeZeitung kunde)
        {
            ListeKunden.Remove(kunde);
        }
    }

    //Die Aufgabe dieser Interfaces ist es, die Schnittstellen-Methoden bereitzustellen
    //Dadurch weiß jede Klasse, die mit der Schnittstelle arbeitet, welche Methoden definitiv vorhanden sind
    public interface IKundeZeitung
    {
        void ErhalteZeitung(Zeitung zeitung);
    }

    public interface IKundeWaren
    {
        void ErhalteWaren(Ware ware, int anzahl);
    }

    //Die Kunden-Klassen, die das Interface implementieren.
    public class Großhändler : IKundeWaren
    {
        public string Name;
        //Die spezifische Implementierung der Schnittstellen-Methoden kann bei jeder Implementierung unterschiedlich sein
        public void ErhalteWaren(Ware ware, int anzahl)
        {
            Console.WriteLine(ware.Name + " " + anzahl);
        }
    }

    public class Einzelhändler : IKundeWaren
    {
        public void ErhalteWaren(Ware ware, int anzahl)
        {
            Console.WriteLine("Jetzt erhalten auch Einzelhändler ihre Waren!");
        }
    }

    public class PrivatKunde : IKundeWaren, IKundeZeitung
    {
        public void ErhalteWaren(Ware ware, int anzahl)
        {
            Console.WriteLine("Auch Privatkunden erfreuen sich über " + ware.Name);
        }

        public void ErhalteZeitung(Zeitung zeitung)
        {
            Console.WriteLine("Hier ist Ihre Zeitung!");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Hersteller hersteller = new Hersteller();
            Verlag verlag = new Verlag();

            Großhändler großhändler = new Großhändler();
            Einzelhändler einzelhändler = new Einzelhändler();
            PrivatKunde privatKunde = new PrivatKunde();

            hersteller.KundeHinzufügen(großhändler);
            hersteller.KundeHinzufügen(einzelhändler);
            hersteller.KundeHinzufügen(privatKunde);
            verlag.KundeHinzufügen(privatKunde);

            hersteller.VerschickeWaren(new Ware("Neue Ware"), 100);
            verlag.VerschickeZeitung(new Zeitung("Wochenspiegel"));

            Console.ReadKey();

        }
    }
}
