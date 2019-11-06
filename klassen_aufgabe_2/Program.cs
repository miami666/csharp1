using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Schreiben Sie bitte ein C#-Programm, in dem ...
 - eine Klasse Firma definiert wird
   + Die Member der Klasse sind: (Zugriffsmodifizierer jeweils public)
     - String: Name
     - Double-Liste: Konten
     - Methode: Summe
       + Funktion: berechnet den Gesamtbetrag aller Listenelemente
       + Rückgabewert: Gesamtbetrag
 - im Main 2 Firmen instanziiert werden
   + wählen Sie jeweils einen Firmennamen
   + die erste Firma hat 2 Konten, die zweite 3 (wählen Sie beliebige Kontobeträge)
   + beide Firmen sollen in der Liste 'firmenliste' abgespeichert werden
 - in einer foreach-Schleife alle Elemente (Name und Gesamtbetrag) aus firmenliste auf der Konsole ausgegeben werden
*/

namespace klassen_aufgabe_2
{
    class Firma
    {
        public string Name;
        public List<double> Konten = new List<double>();

        public double Summe()
        {
            double summe = 0;
            foreach (double k in Konten)
            {
                summe += k;
            }
            return summe;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Firma> firmenliste = new List<Firma>();

            Firma firma1 = new Firma();
            firma1.Name = "Contrabit";
            firma1.Konten.Add(1000.11);
            firma1.Konten.Add(2000.22);

            firmenliste.Add(firma1);

            Firma firma2 = new Firma();
            firma2.Name = "Antibyte";
            firma2.Konten.Add(111.11);
            firma2.Konten.Add(222.22);
            firma2.Konten.Add(333.33);

            firmenliste.Add(firma2);

            foreach (Firma f in firmenliste)
            {
                Console.WriteLine("Firma {0} hat ein Gesamtkapital von {1} Euro", f.Name, f.Summe());
            }

            Console.Write("\n\n\n\nEin beliebiger Tastendruck beendet das Programm ... ");
            Console.ReadKey();
        }
    }
}
