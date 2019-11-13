using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace aggregation_komposition_aufgabe_1
{
    class Kuchenstueck
    {
        int gewicht;
        public int Gewicht { get => gewicht; }
        public Kuchenstueck(int g)
        {
            gewicht=g;
        }
    }
    class Kuchen
    {
        static List<Kuchen> kuchenliste = new List<Kuchen>();
         List<Kuchenstueck> stueckliste = new List<Kuchenstueck>();
        int gesamtgewicht()
        {          
            return stueckliste.Sum(item => item.Gewicht); 
        }
        public static void ZeigeAlle()
        {
            foreach(Kuchen k in kuchenliste)
            {
                Console.WriteLine("Kuchen: "+Convert.ToInt32(kuchenliste.IndexOf(k)+1));
                Console.WriteLine("Gesamtgewicht: "+k.gesamtgewicht());
                foreach (Kuchenstueck ks in k.stueckliste)
                {
                    Console.WriteLine(ks.Gewicht);
                }
            }
        }
        public Kuchen(List<int> int_liste)
        {
            if(int_liste.Count()>0)
            {
                kuchenliste.Add(this);
                foreach(int s in int_liste)
                {
                    stueckliste.Add(new Kuchenstueck(s));
                }
            }
            else
            {
                Console.WriteLine("leere Liste Du Sau Pillemann Arsch");
                Console.ReadKey(true);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new Kuchen(new List<int>() );
            new Kuchen(new List<int>() { 10,20,30});
            new Kuchen(new List<int>() { 100, 300, 250,50 });
            new Kuchen(new List<int>() { 1, 3, 2, 5,18 });
            Kuchen.ZeigeAlle();
            Console.ReadKey();
        }
    }
}
/*
    Führen Sie bitte die beiden folgenden Klassen ein:
        Klasse Kuchenstück
            Member:
                1 privater Integer gewicht
                1 Property für gewicht (NUR get)
                1 Konstruktor:
                    Übergabewert: 1 Integer gewicht
                    Funktion: Weist dem Feld den Wert des Parameters zu
                        /*
     * Klasse Kuchen
            Member:
                private statische Liste vom Typen Kuchen
                private Liste aller Kuchenstücke
                private Methode
                    Name: gesamtGewicht
                    Übergabewerte: keine
                    Funktion: Ermittelt das Gesamtgewicht aller Kuchenstücke
                    Rückgabewert: Gesamtgewicht
                öffentliche statische Methode
                    Name: ZeigeAlleKuchen
                    Übergabewerte: keine
                    Funktion: Gibt für alle Kuchen der Kuchenliste ...
                              - alle Stücke des Kuchens
                              - das Gewicht jedes seiner Kuchenstücke
                              - und das Gesamtgewicht des Kuchens
                              ... auf der Konsole aus
                Konstruktor:
                    Übergabewert: Integer-Liste
                    Funktion: (Es sei x = Anzahl der Elemente der Integer-Liste)
                              FALLS x > 0
                                    Kuchen wird zur Kuchenliste hinzugefügt
                                    Es werden x Kuchenstücke instanziiert
                                    Es werden die x Integerwerte der Reihe nach jedem Kuchenstück als Gewicht zugeordnet
                              SONST
                                    Der soeben instanziierte Kuchen wird der Kuchen-Liste NICHT zugeordnet
                                    (mit entsprechender Fehlermeldung)
Im Main
       Zunächst wird ein Kuchen mit 0 Kuchenstücken instanziiert
       Anschließend werden 3 weitere Kuchen mit jeweils 3, 4 und 5 Kuchenstücken instanziiert
       Zum Schluß wird die Methode ZeigeAlleKuchen() aufgerufen
*/
