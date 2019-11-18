using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Führen Sie bitte die folgende Klasse ein:

    Klasse InputInteger
        Member:
            3 private Integer: x, y und eingabeZahl
            1 privater String: text
            1 privater String: eingabeString mit Startwert = ""
            1 Methode
                Name: Abfrage
                Übergabewert: keine
                Funktion: - Gibt den String text an den Koordinaten (x/y) aus und fragt in einer Schleife vom User einen Integer ab
                          - die User-(String)-Eingabe wird bei jedem Schleifen-Durchlauf in dem String "eingabeString" abgespeichert
                          - die User-(String)-Eingabe wird (mit TryParse) geparsed und der Wert in "eingabeZahl" abgespeichert
                          - die Schleife wird fortgesetzt, falls der Parse-Vorgang scheiterte
                          - FALLS der Parse-Vorgang scheiterte, wird die vom User eingegebene Zeichenfolge gelöscht
                          - FALLS der Parse-Vorgang glückte, endet die Schleife
                Rückgabewert: Der (erfolgreich) geparsede Wert
            1 Konstruktor
                Übergabewerte: x, y und text
                Funktion: Füllt die entsprechenden (privaten) Felder des Objekts

    Im Main
        - Instanziierung eines Objektes vom Typ InputInteger mit den Übergabewerten 2, 2 und "Geben Sie bitte eine ganze Zahl ein: "
        - Ruft die Methode Abfrage() dieses Objektes auf
        - Gibt zur Kontrolle den Rückgabewert von Abfrage() auf der Konsole aus

    HINWEIS:
        Alle drei Aufgaben im Main können IN EINER EINZIGEN ZEILE ausgeführt werden!
*/
namespace vererbung_aufgabe_2
{
    class InputInteger
    {
        int x=0, y=0, eingabeZahl;
        string text="", eingabeString="";
        public int Abfrage()
        {
            
            do
            {
                Console.SetCursorPosition(x, y);
                for (int i = 0; i < text.Length + eingabeString.Length; i++) Console.Write(" ");
                Console.SetCursorPosition(x, y);
                Console.Write(text);
                eingabeString = Console.ReadLine();
            } while (!int.TryParse(eingabeString, out eingabeZahl));
            return eingabeZahl;
        }
        public InputInteger(int x,int y,string text)
        {
           this.x=x;
           this.y=y;
           this.text=text;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new InputInteger(2, 2, "Geben sie bitte eine ganze Zahl ein: ").Abfrage());
        
         

            Console.ReadKey();
        }
    }
}
