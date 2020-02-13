using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*a)	Schreiben Sie folgendes C# Programm

Generische Klasse "Fass", wobei der mögliche Datentyp "Flüssigkeit" sein muss 
(Hinweis: "where T : Flüssigkeit")
Eigenschaften: Inhalt vom Typ T
 	Methoden:   Füllen() -> Übergabewert ist ein Objekt vom Typ T
Belegt den Inhalt mit dem übergebenen Objekt, 
wenn sich noch kein Inhalt in dem Fass befindet
Return True bei Erfolg, sonst False.
Leeren() -> Leert den Inhalt des Fasses
Abstrakte Klasse Flüssigkeit
Öffentliche Klasse Bier, erbt von Flüssigkeit
Eigenschaften: Brauerei vom Typ String
Methoden:   Einen Konstruktor, der die Werte initialisiert.
 Öffentliche Klasse Wein, erbt von Flüssigkeit
 	Eigenschaften: Herkunft vom Typ String
Methoden:   Einen Konstruktor, der die Werte initialisiert.

Im Main: Zwei Fässer anlegen und sie mit Bier und Wein füllen.
Alle Funktionalitäten testen.
*/
namespace hense_bausteinpruefung_31012020
{
    public abstract class Fluessigkeit
    {

    }
    public class Bier:Fluessigkeit
    {
        public string Brauerei { get; set; }
        public Bier(string brauerei)
        {
            Brauerei = brauerei;
        }
    }
    public class Wein:Fluessigkeit
    {
        public string Herkunft { get; set; }
        public Wein(string herkunft)
        {
            Herkunft = herkunft;
        }

    }
    public class Fass<T> where T : Fluessigkeit
    {
        public bool IsEmpty { get; set; } = true;
        public void Fill() { IsEmpty = false; }
        public void Empty() { IsEmpty = true; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bier b = new Bier("Veltins");
            Wein w = new Wein("Mosel");

            Fass<Bier> bfass = new Fass<Bier>();
            Fass<Wein> wfass = new Fass<Wein>();
            if (bfass.IsEmpty) { bfass.Fill(); } else { bfass.Empty(); }
            if (wfass.IsEmpty) { wfass.Fill(); } else { wfass.Empty(); }
            Console.ReadKey();
        }
    }
}
