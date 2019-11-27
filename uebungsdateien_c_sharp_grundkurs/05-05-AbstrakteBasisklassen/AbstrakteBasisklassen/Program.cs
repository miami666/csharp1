using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrakteBasisklassen
{
    abstract class Person
    {
        string vorname;
        string nachname;

        string strasse;
        string plz;
        string ort;

        public string Bundesland
        {
            get
            {
                if (plz.StartsWith("8"))
                    return "Bayern";
                else if (plz.StartsWith("7"))
                    return "Baden Württemberg";
                else
                    return ("Preußen");
            }
        }
    }
    
    class Kunde : Person
    {
        //...
    }


    class Mitarbeiter : Person
    {

        decimal gehalt;

        virtual public void DoSomeWork()
        {
            Console.WriteLine("Ich mach's selbst");
        }

    }

    class Manager : Mitarbeiter
    {
        public override void DoSomeWork()
        {
            Console.WriteLine("Ich such mir einen, der's macht.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
