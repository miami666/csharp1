using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDO;

namespace Persistenz
{
    class Program
    {
        void DatenSchreiben()
        {
            Mitarbeiter mitarbeiter = new Mitarbeiter();
            mitarbeiter.Vorname = "Mirko";
            mitarbeiter.Nachname = "Matytschak";

            Reise r = mitarbeiter.NewReise();
            r.Zweck = "Videoaufnahmen in Graz";
            r.AddKostenpunkt(new Beleg { Datum = DateTime.Now.Date, Betrag = 123.45m, Text = "Essen mit Herrn Müller" });
            r.AddKostenpunkt(new KmPauschale { AnzahlKm = 145, Datum = DateTime.Now.Date });
            r.AddKostenpunkt(new Tagespauschale { Datum = DateTime.Now.Date, StartDatum = DateTime.Now.Date.AddDays(-1) });

            PersistenceManager pm = new PersistenceManager();
            pm.MakePersistent(mitarbeiter);
            pm.Save();
        }

        void DatenLesen()
        {
            PersistenceManager pm = new PersistenceManager();
            var mitarbeiter = pm.Objects<Mitarbeiter>().Where(m => m.Nachname == "Matytschak").Single();
            Console.WriteLine($"{mitarbeiter.Vorname} {mitarbeiter.Nachname}");
            foreach (var r in mitarbeiter.Reisen)
            {
                Console.WriteLine($"\t{r.Zweck}");
                foreach (var kp in r.Kostenpunkte)
                {
                    Console.WriteLine($"\t\t{kp}");
                }
            }
        }

        void DatenbankBauen()
        {
            var pm = new PersistenceManager();
            pm.BuildDatabase();
        }

        static void Main(string[] args)
        {
            var program = new Program();
            //program.DatenbankBauen();
            //program.DatenSchreiben();
            program.DatenLesen();
        }
    }
}
