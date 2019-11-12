using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Führen Sie bitte zunächst die drei folgenden Klassen ein:
        a) Klasse Land
            Member:
                Länderliste (statisch, öffentlich) [Liste aller instanziierten Objekte vom Typ Land]
                Firmenliste (öffentlich) [Liste aller Firmen, die im jeweiligen Land vertreten sind]
                Name des Landes (privat)
                Property für Name (NUR "get")
                Methode:
                    Name: ZeigeAlleFirmen
                    Übergabewerte: keine
                    Funktion: - Ausgabe der Überschrift: "Alle Firmen in" + Ländername
                              - Alle Namen der Firmen aus Firmenliste
                    Rückgabewert: keiner
                Konstruktor:
                    Übergabewert: Name des Landes
                    Funktion: - Füllt das private Feld (Name des Landes) 
                              - Fügt das Land zur Länderliste
        b) Klasse Firma
            Member:
                Firmaliste (statisch, öffentlich) [Liste aller instanziierten Objekte vom Typ Firma]
                Länderliste (öffentlich) [Liste aller Länder, in denen die Firma vertreten ist]
                Mitarbeiterliste (öffentlich) [Liste aller Mitarbeiter, die in der Firma arbeiten]
                Name der Firma (privat)
                Property für Name (NUR "get")
                2 Methoden:
                    1.) Name: ZeigeAlleLänder
                    Übergabewerte: keine
                    Funktion: - Ausgabe der Überschrift: Alle Länder in denen " + Name der Firma + " vertreten ist:"
                              - Alle Namen der Länder aus Länderliste
                    Rückgabewert: keiner
                    2.) Name: ZeigeAlleMitarbeiter
                    Übergabewerte: keine
                    Funktion: - Ausgabe der Überschrift: Alle Mitarbeiter die in" + Name der Firma + " arbeiten:"
                              - Alle Namen der Mitarbeiter aus Mitarbeiterliste
                    Rückgabewert: keiner
                Konstruktor:
                    Übergabewert: Name der Firma
                    Funktion: - Füllt das private Feld (Name der Firma) 
                              - Fügt die Firma zur Firmenliste
        c) Klasse Mitarbeiter
            Member:
                Mitarbeiterliste (statisch, öffentlich) [Liste aller instanziierten Objekte vom Typ Mitarbeiter]   
                Name des Mitarbeiters (privat)
                Firma (privat) [in der der Mitarbeiter arbeitet]
                Properties:
                    für Name und Fima (bei beiden NUR "get")
                Konstruktor:
                    Übergabewert: Name des Mitarbeiters, Firma
                    Funktion: - Füllt das private Feld (Name des Landes) 
                              - Fügt den Mitarbeiter zur Mitarbeiterliste
     Im Main
        a) Instanziierung: 
            Firmen: Microsoft, Apple, Volkswagen und Porsche
            Länder: Deutschland, USA, Dänemark
            Mitarbeiter: Mike, Marcy, Andrew, Amy, Volker, Verena, Paul und Petra
        b) Listen auffüllen:
            Microsoft und Volkswagen sind in allen drei Ländern vertreten
            Apple und Porsche nur in Deutschland und USA
            Jeder Mitarbeiter arbeitet in einer Firma des Anfangsbuchstabe identisch zu dem seines Vornamens ist
        c) Navigierbarkeit (als Ergebnis der Klassenmember): Land<->Firma und Firma<->Mitarbeiter (alle Assoziationen sind bidirektional)
        Kontrollausgabe:
            1.) Alle Firmen pro Land
            2.) Alle Länder pro Firma
            3.) Alle Mitarbeiter pro Firma
            4.) Firma jedes Mitarbeiters 
*/
namespace assoziationen_mzun_aufgabe_2
{
    class Land
    {
        public static List<Land> laenderli = new List<Land>();
        public List<Firma> firmenli = new List<Firma>();
        private string name;
        public string Name { get => name; }
        /*Methode:
                    Name: ZeigeAlleFirmen
                    Übergabewerte: keine
                    Funktion: - Ausgabe der Überschrift: "Alle Firmen in" + Ländername
                              - Alle Namen der Firmen aus Firmenliste
                    Rückgabewert: keiner
                Konstruktor:
                    Übergabewert: Name des Landes
                    Funktion: - Füllt das private Feld (Name des Landes) 
                              - Fügt das Land zur Länderliste*/
        public void ZeigeFirmen()
        {
            Console.WriteLine("\nAlle Firmen in " + name);
            foreach (Firma f in firmenli)
            {
                Console.WriteLine(f.Name);
            }
        }
        public Land(string s)
        {
            name = s;
            laenderli.Add(this);
        }
    }
    class Firma
    {
        public List<Land> laenderli = new List<Land>();
        public static List<Firma> firmenli = new List<Firma>();
        public List<Mitarbeiter> mitarbeiterli = new List<Mitarbeiter>();
        private string name = null;
        public string Name
        {
            get => name;
        }
        public void ZeigeLaender()
        {
            Console.WriteLine("\nAlle Laender in denen Firma " + name + " vertreten ist:");
            foreach (Land l in laenderli)
            {
                Console.WriteLine(l.Name);
            }
        }
        public void ZeigeMitarbeiter()
        {
            Console.WriteLine("\nAlle Mitarbeiter aus Firma " + name);
            foreach (Mitarbeiter m in mitarbeiterli)
            {
                Console.WriteLine(m.Name);
            }
        }
        public Firma(string f)
        {
            name = f;
            firmenli.Add(this);
        }
    }
    class Mitarbeiter
    {
        public static List<Mitarbeiter> mitarbeiterli = new List<Mitarbeiter>();
        private string name;
        private string firma;
        public string Name { get => name; }
        public string Firma { get => firma; }
        public Mitarbeiter(string m, string f)
        {
            name = m;
            firma = f;
            mitarbeiterli.Add(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Firma f1 = new Firma("Microsoft");
            Firma f2 = new Firma("Apple");
            Firma f3 = new Firma("Volkswagen");
            Firma f4 = new Firma("Porsche");
            Land l1 = new Land("Deutschland");
            Land l2 = new Land("Usa");
            Land l3 = new Land("Dänemark");
            /*Mike, Marcy, Andrew, Amy, Volker, Verena, Paul und Petra*/
            Mitarbeiter m1 = new Mitarbeiter("Mike", "Microsoft");
            Mitarbeiter m2 = new Mitarbeiter("Marcy", "Microsoft");
            Mitarbeiter m3 = new Mitarbeiter("Andrew", "Apple");
            Mitarbeiter m4 = new Mitarbeiter("Amy", "Apple");
            Mitarbeiter m5 = new Mitarbeiter("Volker", "Volkswagen");
            Mitarbeiter m6 = new Mitarbeiter("Verena", "Volkswagen");
            Mitarbeiter m7 = new Mitarbeiter("Paul", "Porsche");
            Mitarbeiter m8 = new Mitarbeiter("Petra", "Porsche");
            f1.mitarbeiterli.Add(m1);
            f1.mitarbeiterli.Add(m2);
            f2.mitarbeiterli.Add(m3);
            f2.mitarbeiterli.Add(m4);
            f3.mitarbeiterli.Add(m5);
            f3.mitarbeiterli.Add(m6);
            f4.mitarbeiterli.Add(m7);
            f4.mitarbeiterli.Add(m8);
            f1.laenderli.Add(l1);
            f1.laenderli.Add(l2);
            f1.laenderli.Add(l3);
            f2.laenderli.Add(l1);
            f2.laenderli.Add(l2);
            f3.laenderli.Add(l1);
            f3.laenderli.Add(l2);
            f3.laenderli.Add(l3);
            f4.laenderli.Add(l1);
            f4.laenderli.Add(l2);
            l1.firmenli.Add(f1);
            l1.firmenli.Add(f2);
            l1.firmenli.Add(f3);
            l1.firmenli.Add(f4);
            l2.firmenli.Add(f1);
            l2.firmenli.Add(f2);
            l2.firmenli.Add(f3);
            l2.firmenli.Add(f4);
            l3.firmenli.Add(f1);
            l3.firmenli.Add(f3);
            Console.WriteLine("\nAlle Firmen pro Land");
            foreach (Land l in Land.laenderli)
            {
                l.ZeigeFirmen();
            }
            Console.WriteLine("\nAlle Länder pro Firma");
            foreach (Firma f in Firma.firmenli)
            {
                f.ZeigeLaender();
            }
            Console.WriteLine("\nAlle Mitarbeiter pro Firma");
            foreach (Firma f in Firma.firmenli)
            {
                f.ZeigeMitarbeiter();
            }
            Console.WriteLine("\nFirma jedes Mitarbeiters");
            foreach (Mitarbeiter m in Mitarbeiter.mitarbeiterli)
            {
                Console.WriteLine(m.Name + " " + m.Firma);
            }
            Console.ReadKey();
        }
    }
}
