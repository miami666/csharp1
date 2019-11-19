using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Führen Sie bitte die beiden folgenden 2 Klassen ein:

        Klasse Gebäude
            Member
                öffentlicher String Adresse
                öffentliche statische Liste vom Typ Gebäude
                öffentliche statische Methode
                    Name: ZeigeGebäudeListe
                    Übergabewerte: keine
                    Funktion: Ausgabe der Überschrift "Liste aller Gebäude:"
                              Ausgabe der Adressen aller Gebäude 
                    Rückgabewert: keiner
                2 Konstruktoren
                    a) Übergabewert: keiner
                       Funktion: Trägt die neue Instanz in die Liste aller Gebäude ein 
                    b) Übergabewert: 1 String s
                       Funktion: Trägt die neue Instanz in die Liste aller Gebäude ein 
                                 Initialisiert die Adresse mit s  
        Klasse Villa (erbt von Gebäude)
            Member
                öffentlicher Integer Preis
                öffentliche statische Liste vom Typ Villa
                öffentliche statische Methode
                    Name: ZeigeVillaListe
                    Übergabewerte: keine
                    Funktion: Ausgabe der Überschrift "Liste aller Villen:"
                              Ausgabe der Adressen und Preise aller Villen 
                    Rückgabewert: keiner
                3 Konstruktoren
                    a) Übergabewert: keiner
                       Funktion: Trägt die neue Instanz in die Liste aller Villen ein 
                    b) Übergabewert: 1 String s
                       Funktion: Trägt die neue Instanz in die Liste aller Villen ein 
                                 Initialisiert die Adresse mit s 
                    c) Übergabewert: 1 String s und ein Integer p
                       Funktion: Trägt die neue Instanz in die Liste aller Villen ein 
                                 Initialisiert die Adresse mit s  
                                 Initialisiert den Preis mit p
  Im Main
    - Instanziierung und Initialisierung von 2 Gebäuden und 3 Villen
      (alle 5 Konstruktoren sollen verwendet werden)
    - Aufruf der beiden Methoden
*/
namespace vererbungshierarchie_aufgabe_2
{
    class Gebaeude
    {
        public string Adresse;
        public static List<Gebaeude> gListe = new List<Gebaeude>();
        public static void ZeigeGListe()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nListe aller Gebäude: ");
            Console.ResetColor();
            foreach (var g in gListe)
            {
                Console.WriteLine(g.Adresse);
            }
        }
        public Gebaeude()
        {
            gListe.Add(this);
        }
        public Gebaeude(string s)
        {
            gListe.Add(this);
            Adresse = s;
        }
    }
    class Villa : Gebaeude
    {
        public int Preis;
        public static List<Villa> vListe = new List<Villa>();
        public static void ZeigeVListe()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\nAlle Villen:");
            Console.ResetColor();
            foreach (var v in vListe)
            {
                Console.WriteLine(v.Adresse + " " + v.Preis);
            }
        }
        public Villa()
        {
            vListe.Add(this);
        }
        public Villa(string s):base(s)
        {
            vListe.Add(this);
           // Adresse = s;
        }
        public Villa(string s, int p) : base(s)
        {
            vListe.Add(this);
        
            Preis = p;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Gebaeude g1 = new Gebaeude();
            g1.Adresse = "Parkstrasse 666";
            Gebaeude g2 = new Gebaeude("Schlossallee 666");
            Gebaeude.ZeigeGListe();
            Villa v1 = new Villa();
            v1.Preis = 99999999;
            v1.Adresse = "110th Street";
            Villa v2 = new Villa("Lessingstrasse 6");
            Villa v3 = new Villa("Goethestrasse 12", 1000000);          
            Villa.ZeigeVListe();
            Console.ReadKey();
        }
    }
}
