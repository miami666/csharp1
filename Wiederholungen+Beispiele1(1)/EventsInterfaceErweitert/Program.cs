using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsInterfaceErweitert
{
    class Program
    {
        static void Main(string[] args)
        {

            Einkaufzentrum e = new Einkaufzentrum();
            Mitarbeiter ma1 = new Mitarbeiter("Astrid", e);
            Mitarbeiter ma2 = new Mitarbeiter("James", e);
            Geschäftsführer g = new Geschäftsführer(e);

            e.BegrüßenKundeEventAbonnieren();

            e.NeuerKundeBetrittDasGebäude();

            Console.ReadKey();
        } 
    }
}
