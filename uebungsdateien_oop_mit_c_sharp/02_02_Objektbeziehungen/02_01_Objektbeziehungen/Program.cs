using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_01_Objektbeziehungen
{
    class Program
    {
        static void Main(string[] args)
        {
            Reise r = new Reise();
            r.AddKostenpunkt(new Beleg { Datum = DateTime.Now.Date, Betrag = 123.45m, Text = "Essen mit Herrn Müller" });
            r.AddKostenpunkt(new KmPauschale { AnzahlKm = 145, Datum = DateTime.Now.Date });
            r.AddKostenpunkt(new Tagespauschale { Datum = DateTime.Now.Date, StartDatum = DateTime.Now.Date.AddDays(-1) });

            foreach (var kp in r.Kostenpunkte)
            {
                Console.WriteLine($"{kp.Datum.ToShortDateString()}\t{kp.Text}\t{kp.Betrag}");
            }
        }
    }
}
