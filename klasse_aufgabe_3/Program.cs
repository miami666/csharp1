using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Führen Sie bitte die folgende Enumeration ein:
        Sieger (mit den Konstanten ist_A_Mann und ist_B_Mann)

    Führen Sie bitte die beiden folgenden Klassen ein:
        A_Mann
            String: Name
            Integer: x, y
            Bool: ImSpiel
            Methoden:
                a) Name: Jubeln
                   Übergabewerte: Keine
                   Funktion: Konsolenausgabe: "Ich liebe es, wenn ein Plan funktioniert!"
                   Rückgabewert: Keiner
                b) Name: Heulen
                   Übergabewerte: Keine
                   Funktion: Konsolenausgabe: "Ich hasse es, wenn ein Plan scheitert!"
                   Rückgabewert: Keiner 
                c) Name: Grüßen
                   Übergabewerte: eine Variable a vom Typ A-Mann
                   Funktion: Konsolenausgabe: Hallo + Name von a +"!"
                   Rückgabewert: Keiner   
        B_Mann
            String: Name
            Integer: x, y
            Bool: ImSpiel
            Methoden:
                a) Name: Jubeln
                   Übergabewerte: Keine
                   Funktion: Konsolenausgabe: "Wir B-Männer sind Siegertypen!"
                   Rückgabewert: Keiner
                b) Name: Heulen
                   Übergabewerte: Keine
                   Funktion: Konsolenausgabe: "Pah, der A-Mann hatte nur Glück ..."
                   Rückgabewert: Keiner 
                c) Name: Grüßen
                   Übergabewerte: eine Variable b vom Typ B-Mann
                   Funktion: Konsolenausgabe: Hallo + Name von b +"!"
                   Rückgabewert: Keiner 

   Main-Methode:
        - Führen Sie bitte ein Spielfeld ein (wählen Sie selbst Breite und Höhe)
        - Führen Sie 5 Spieler vom Typ A_Mann auf der linken Seite des Spielfelds mit zufälligen Positionen ein
          (Kein Spieler darf auf ein bereits bestzes Feld)
        - Führen Sie 5 Spieler vom Typ B_Mann auf der rechten Seite des Spielfelds mit zufälligen Positionen ein
          (Kein Spieler darf auf ein bereits bestzes Feld) 
        - Jeder A_Mann wird in einer Liste namens 'aListe' abgespeichert
        - Jeder B_Mann wird in einer Liste namens 'bListe' abgespeichert 
        - Die A_Männer werden der Reihe nach "Achim", "Albert", "Anton", "August" oder "Axel" genannt
        - Die B_Männer werden der Reihe nach "Bert", "Benjamin", "Björn", "Bodo" oder "Bruno" genannt
        - Jeder Mann speichert unter x und y die ausgeloste Position und den Wert 'true' bei ImSpiel

        Es startet eine Schleife, pro Durchlauf ...
         - wandern alle Männer auf ein zufälliges Nachbarfeld (falls nicht dabei das Spielfeld verlassen werden würde) 
         - grüßen sich die beiden A_Männer, falls sie auf einem identischen Feld landen
         - grüßen sich die beiden B_Männer, falls sie auf einem identischen Feld landen
         - kämpfen A_Mann gegen B_Mann, falls sie auf einem identischen Feld landen
           + der Sieger wird ausgelost
           + der Sieger jubelt
           + der Verlierer heult
           + beim Verlierer wird ImSpiel auf 'false' gesetzt
           + der verlierer wird aus seiner Liste entfernt
        ... die Schleife endet, falls nur noch Spieler von einem Team übrig geblieben sind 
*/

namespace klasse_aufgabe_3
{
    enum Sieger { ist_A_Mann, ist_B_Mann };
    class A_Mann
    {
        string name;
        int x, y;
        bool ImSpiel;
        public void Jubeln()
        {
            Console.WriteLine("Ich liebe es wenn ein Plan funktioniert");
    
        }
        public void Heulen()
        {
            Console.WriteLine("Ich hasse es wenn ein Plan scheitert");
        }
        public void Gruessen(A_Mann a)
        {
            Console.WriteLine("Hallo  "+a.name);

        }

    }
    class B_Mann
    {
        string name;
        int x, y;
        bool ImSpiel;
        public void Jubeln()
        {
            Console.WriteLine("Wir B-Männer sind Siegertypen");

        }
        public void Heulen()
        {
           
            Console.WriteLine("Pah, der A-Mann hatte nur Glück");
        }
        public void Gruessen(B_Mann b)
        {
            Console.WriteLine("Hallo  " + b.name);

        }


    }
    class Program
    {
        

        static void Main(string[] args)
        {
        }
    }
}
