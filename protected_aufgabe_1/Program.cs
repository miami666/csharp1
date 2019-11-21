using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Führen Sie bitte die folgenden Klassen ein:
        Entität
        Gegenstand
        Lebewesen
        Tier
        Mensch
    Für diese gilt:
        Gegenstand und Lebewesen erben von Entität / Tier und Mensch erben von Lebewesen
        Nur von Gegenstand, Tier und Mensch sollen Objekte instanziierbar sein
    
    Aufgaben
        a) Erstellen Sie ein entsprechendes UML-Diagramm (# für protected)
        b) Für alle Klassen soll eine Liste eingeführt werden
        c) Alle Objekte sollen in alle passenden Listen eingetragen werden (Menschen also z.B. in der Menschen-, Lebewesen- und Entitäten-Liste)
        d) führen Sie bitte alle Objekte ein (Werte: siehe Screenshot)
        e) lassen Sie bitte alle Klassen ausgeben (wie im Screenshot)
*/
namespace protected_aufgabe_1
{
    class Entitaet
    {
        public static List<Entitaet> eListe = new List<Entitaet>();
        string name;
        int kg;
        public string Name
        {
            get => name;
            set
            {
            }
        }
        public int Kg
        {
            get => kg;
            set
            {

            }
        }
        protected Entitaet()
        {
            eListe.Add(this);
        }
        protected Entitaet(string n,int kg)
        {
            eListe.Add(this);
            name = n;
            this.kg = kg;
        }

    }
    class Gegenstand:Entitaet
    {
        public static List<Gegenstand> gListe = new List<Gegenstand>();
        string besitzer;
        public Gegenstand(string b,string n,int kg):base(n,kg)
        {
            gListe.Add(this);
            besitzer = b;

        }
        public static void ZeigegegListe() {
            foreach (var item in gListe)
	{
                Console.WriteLine(item.Name+" "+item.besitzer);

	}
        }

    }
    class Lebewesen:Entitaet
    {
        public static List<Lebewesen> lListe = new List<Lebewesen>();
        protected string geb;
        protected Lebewesen(string g)
        {
           
            geb = g;
            lListe.Add(this);

        }
        public static void ZeigelListe() 
        {
        foreach(var l in lListe) 
        {
        Console.WriteLine(l.Name+" "+l.geb);
        
        }

        }
    }
    class Tier:Lebewesen
    {
        public static List<Tier> tListe = new List<Tier>();
        string anzahlBeine;
        public Tier(string beine, string g) : base(g)
        {
           
            anzahlBeine = beine;
            tListe.Add(this);

        }
        public static void ZeigetListe()
        {
            foreach(var t in tListe)
            {
                Console.WriteLine(t.Name+" "+t.geb+" "+t.anzahlBeine);
            }
        }

    }
    class Mensch : Lebewesen
    {
        public static List<Mensch> mListe = new List<Mensch>();
        string beruf;
        public Mensch(string beruf,string g):base(g)
           
        {
            this.beruf = beruf;
            mListe.Add(this);

        }
        public static void ZeigemListe()
        {
            foreach(var m in mListe)
            {
                Console.WriteLine(m.beruf+" "+m.geb);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Mensch hans = new Mensch("Zimmermann", "01.01.200");
            Mensch.ZeigemListe();
            Console.ReadKey();
        }
    }
}
