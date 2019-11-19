/*
    Führen Sie bitte die folgenden Klassen ein:
        a) Klasse "Mensch"
            1 Feld: 
               Name
            1 Methode: 
               Name: Ansprache
               Übergabewert: 1 String s
               Funktion: Gibt auf der Konsole aus:  Name+", "+s
               Rückgabewert: KEINER
         b) Klasse "Kunde"
             1 Feld: 
                Einkaufssumme
             1 Methode: 
                Name: Bewertung
                Übergabewert: KEINER
                Funktion: FALLS Einkaufssumme>500: Füllt einen String s mit "Du bist ein guter Kunde!" 
                          SONST: Füllt s mit "Du solltest bei uns mehr einkaufen!"
                Rückgabewert: s
         c) Klasse "NichtKunde"
             1 Feld: 
                Adresse
             KEINE Methode

      Vererbung:
        Kunde und NichtKunde erben von Mensch

      
      Test im Main:
         - Führen Sie bitte einen Menschen "Paul" ein ...
           ... und führen Sie bitte für Paul die Methode Ansprache() mit dem übergabewert "Du bist ein toller Mensch!" aus
         - Führen Sie bitte einen Kunden "Hans" mit der Einkaufsumme 999,95 ein ...
           ... und führen Sie bitte für Hans die Methode Ansprache() mit dem übergabewert "Danke für Deinen Einkauf! "+(Bewertung von Hans) aus
           HINWEIS: Bewertung von Hans --> siehe die entsprechende Methode in der Klasse Kunde
         - Führen Sie bitte einen Nicht-Kunden "Peter" mit der Adresse  "11111 Kleinhausen, Hauptstraße 22"  ein ...
           ... und führen Sie bitte für Peter die Methode Ansprache() mit dem übergabewert:
                           "willst Du nicht unser Kunde werden? ... Wir wissen wo du wohnst: "+(Peters Adresse) aus
           HINWEIS: Peters Adresse --> siehe das entsprechende Feld in der Klasse NichtKunde 
                         
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_51_Aufg1
{
    class Program
    {
        class Mensch // Basisklasse
        {
            public string Name;

            public void Ansprache(string s)
            {
                Console.WriteLine(Name + ", " + s);
            }
        }

        class Kunde : Mensch // Kunde ist (eine) Subklasse von Mensch
        {
            public double EinkaufsSumme;

            public string Bewertung()
            {
                if (EinkaufsSumme > 500) return "Du bist ein guter Kunde!";
                else return "Du solltest bei uns mehr einkaufen!";
            }
        }

        class NichtKunde : Mensch
        {
            public string Adresse;
        }

        static void Main(string[] args)
        {
            Mensch m = new Mensch();
            m.Name = "Paul";
            m.Ansprache("Du bist ein toller Mensch!");

            Kunde k = new Kunde();
            k.Name = "Hans"; // Name wurde aus Mensch geerbt(!)
            k.EinkaufsSumme = 999.95;
            k.Ansprache("Danke für Deinen Einkauf! " + k.Bewertung());

            NichtKunde nk = new NichtKunde();
            nk.Name = "Peter";
            nk.Adresse = "11111 Kleinhausen, Hauptstraße 22";
            nk.Ansprache("willst Du nicht unser Kunde werden? ... Wir wissen wo du wohnst: " + nk.Adresse);

            Console.ReadKey();
        }
    }
}