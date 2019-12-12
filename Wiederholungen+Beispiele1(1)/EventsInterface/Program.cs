using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsInterface
{
 
    public class Einkaufzentrum
    {
        //Der Delegate stellt einen Datentypen da, mit dem ich Event-Variablen erzeugen kann
        //Der Delegate legt die Signatur der Methoden fest, mit denen auf das Event reagiert werden kann
        public delegate void NeuerKundeEventHandler();
        //Dies ist die Event-Variable, der wir die Methoden zur Abonnierung zuweisen können
        public event NeuerKundeEventHandler NeuerKundeHatDasGebäudeBetreten;

        /// <summary>
        /// Löst das NeuerKundeHatDasGebäudeBetreten-Event aus
        /// </summary>
        public void NeuerKundeBetrittDasGebäude()
        {
            if (NeuerKundeHatDasGebäudeBetreten != null)
                NeuerKundeHatDasGebäudeBetreten();
        }

    }

    public interface IMitarbeiterBegrüßenKunde
    {
        
        void Grüßen();
    }

    public class Geschäftsführer : IMitarbeiterBegrüßenKunde
    {
        public void Grüßen()
        {
            Console.WriteLine("Irasshaimase!!");
        }
    }

    public class Mitarbeiter : IMitarbeiterBegrüßenKunde
    {
        public string Name { get; set; }

        public Mitarbeiter(string name)
        {
            Name = name;
        }

        public void Grüßen()
        {
            Console.WriteLine("Irasshaimase!");
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Einkaufzentrum e = new Einkaufzentrum();
            Mitarbeiter ma1 = new Mitarbeiter("Astrid");
            Geschäftsführer g = new Geschäftsführer();
            e.NeuerKundeHatDasGebäudeBetreten += ma1.Grüßen;
            e.NeuerKundeHatDasGebäudeBetreten += g.Grüßen;

            e.NeuerKundeBetrittDasGebäude();

            Console.ReadKey();
        }
    }
}
