using System;

namespace EventsInterfaceErweitert
{
    public class Mitarbeiter : IMitarbeiterBegrüßenKunde
    {
        public string Name { get; set; }

        public Mitarbeiter(string name, Einkaufzentrum e)
        {
            Name = name;
            e.MitarbeiterHinzufügen(this);
        }

        public void Grüßen()
        {
            Console.WriteLine("Irasshaimase!");
        }
    }
}
