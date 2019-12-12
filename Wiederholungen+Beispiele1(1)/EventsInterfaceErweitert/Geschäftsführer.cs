using System;

namespace EventsInterfaceErweitert
{
    public class Geschäftsführer : IMitarbeiterBegrüßenKunde
    {
        public void Grüßen()
        {
            Console.WriteLine("Irasshaimase!!");
        }

        public Geschäftsführer(Einkaufzentrum e)
        {
            e.MitarbeiterHinzufügen(this);
        }
    }
}
