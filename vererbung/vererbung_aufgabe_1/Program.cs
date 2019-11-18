using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
namespace vererbung_aufgabe_1
{
    class Mensch
    {
        public string Name;
        public void Ansprache(string s)
        {
            Console.WriteLine(Name + ", " + s);
        }
    }
    class Kunde : Mensch
    {
        public double Einkaufssumme;
        string s;
        public string Bewertung()
        {


            if (Einkaufssumme > 500)
            {
                s = "Du bist guter Kunde";
            }
            else
            {
                s = "mehr einkaufen du musst";
            }
            return s;
        }

    }
    class Nichtkunde : Mensch
    {
        public string Adresse;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mensch paul = new Mensch();
            paul.Name = "Paul";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            paul.Ansprache("Du bist ein toller Mensch");
            Console.ResetColor();
            Kunde hans = new Kunde();
            hans.Einkaufssumme = 999.95;
            hans.Name = "Hans";
            Console.ForegroundColor = ConsoleColor.Yellow;
            hans.Ansprache("Danke für deinen Einkauf! " + hans.Bewertung());
            Console.ResetColor();
            Nichtkunde peter = new Nichtkunde();
            peter.Adresse = "11111 Kleinhausen, Hauptstrasse 22";
            peter.Name = "Peter";
            Console.ForegroundColor = ConsoleColor.Red;
            peter.Ansprache("Willst du nicht unser Kunde werden? Wir wissen wo du wohnst: " + peter.Adresse);
            Console.ResetColor();

            Console.ReadKey();
        }
    }
}
