using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Führen Sie bitte zunächst die folgenden Klassen ein: 
        Tier (Attribute: Tierart und Name)
        Futter (Attribute: Bezeichnung und Kalorien)
        Fütterung (Attribute: !static!-Liste vom Typ Fütterung, MengeInKg, TierArt(vom Typ Tier) und FutterArt(vom Typ Futter))

    Führen Sie bitte die folgenden Objekte ein: (Attributwerte, die im folgenden nicht mitgeteilt werden, können von Ihnen frei gewählt werden)
        Tier
            Black Beauty
            Lassie
        Futter
            Trockenfutter
            Heu
            Fleisch

     Es gelten die folgende Assoziationen:
        Trockenfutter darf an Black Beauty und Lassie verfüttert werden
        Heu nur an das Pferd
        Fleisch nur an den Hund
    
    Für die Klasse Fütterung wird ferner verlangt:
        In Fütterung ist ein Konstruktor implementiert, für den gilt:
        1.) alle Attributwerte werden durch die Übergabewerte des Konstruktors gefüllt
        2.) die Fütterungsliste wird durch das neue (also gerade vom Konstruktor erzeugte) Objekt ergänzt [Listenname.Add(this)]

    Lassen Sie bitte anschließend im Main (mindestens) die beiden folgenden Kontrollausgaben ausführen:
        a) Alle Futtersorten von Black Beauty
        b) Alle Tiere, an die Trockenfutter verfüttert werden darf
*/

namespace assoziationen_mzun_aufgabe_1
{
    class Tier
    {
        public string tierart;
        public string name;

    }
    class Futter
    {
        public int kalorien;
        public string bezeichnung;
    }
    class Fuetterung
    {
        public static List<Fuetterung> FuetterungsListe = new List<Fuetterung>();
        public double mengeKg;
        public Tier tierart;
        public Futter Futterart;
        

        public Fuetterung(double m,Tier t,Futter f)
        {
            mengeKg = m;
            tierart = t;
            Futterart = f;
            FuetterungsListe.Add(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tier t1 = new Tier();
            t1.tierart = "Pferd";
            t1.name = "fury";
            Tier t2 = new Tier();
            t2.tierart = "Hund";
            t2.name = "lassie";
            Futter f1 = new Futter();
            f1.bezeichnung = "Trockenfutter";
            f1.kalorien = 300;
            Futter f2 = new Futter();
            f2.bezeichnung = "Heu";
            f2.kalorien = 200;
            Futter f3 = new Futter();
            f3.bezeichnung = "Fleisch";
            f3.kalorien = 400;
            Fuetterung tf1 = new Fuetterung(3, t1, f1);
            Fuetterung tf2 = new Fuetterung(2, t1, f2);
            Fuetterung tf3 = new Fuetterung(2, t2, f2);
            Fuetterung tf4 = new Fuetterung(1, t2, f3);
            Console.WriteLine("alle futtersorten von fury:");
            foreach(Fuetterung tf in Fuetterung.FuetterungsListe)
            {
                if(tf.tierart.name=="fury")
                {
                    Console.WriteLine(tf.Futterart.bezeichnung);
                }
            }
            Console.WriteLine("alle tiere die trockenfutter bekommen");
            foreach (Fuetterung tf in Fuetterung.FuetterungsListe)
            {
                if (tf.Futterart.bezeichnung == "Trockenfutter")
                {
                    Console.WriteLine(tf.tierart.name);
                }
            }
            Console.ReadKey();
        }
    }
}
