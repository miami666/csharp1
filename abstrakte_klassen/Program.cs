/*
 Abstrakte Klasse

 Wir haben mittlerweile unser gesamtes "OOP-Gebäude" auf die berühmten 3 Säulen stellen können, denn wir lernten die Abkapselung, die Vererbung und zuletzt auch die Plymorphie kennen. Diese war bei unseren letzten Beispielen dazu geeignet, eine Vererbungshierarchie aufzubauen, einige Felder und Methoden zu vererben OHNE jedoch gezwungen zu sein, jede Methode 1:1 zu übernehmen (Stichwort: virtual -> override -> sealed)
   Ebenso konnten wir selbst entscheiden, ob wir den ctor der Basis(Eltern)-Klasse von außen aufrufbar machten oder ihn mit 'protected' schützten.

   Abstrakte Klassen werden uns hier einige Entscheidungen "abnehmen", sie sind eine syntaktische Erleichterung, aber nicht "lebenswichtig".
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_56_AbstrakteKlassen
{
    abstract class AbstrakteKlasse
    {
        public AbstrakteKlasse() // Abstrakte Klassen haben in der Regel einen protected ctor.
                                 // Da von abstrakten Klassen keine Objekte erzeugt werden sollen, macht ein public ctor keinen Sinn.
        {
            Console.WriteLine("Wir sehen diesen Text, denn erbende Klassen rufen immer auch den ctor der jeweiligen Basisklasse auf!");
        }

        // public abstract int Feld; // abstrakte Felder sind NICHT erlaubt
        public int Feld;
        public abstract int Property { get; set; } // Abstrakte Properies sidn erlaubt, da sie intern als Methoden arbeiten

        public void Ausgabe()
        {
            Console.WriteLine("Diese Methode wird 1:1 übernommen");
        }

        // 3 abstrakte Methoden
        // Abstrakte Methoden werden NICHT implementiert, dies erfolgt in der abgeleiteten Klasse
        public virtual void Methode1()
        {

        }
        public abstract void Methode2(string s);
        public abstract int Methode3(int a, int b);
    }

    class Subklasse : AbstrakteKlasse
    {
        //Alle abstrakten Member müssen in der Subklasse implementiert werden.

        public override int Property { get; set; }

        public override void Methode1()
        {
            Console.WriteLine("Hallo Welt");
        }

        public override void Methode2(string s)
        {
            Console.WriteLine("Es wurde folgender String übergeben:" + s);
        }

        public override int Methode3(int a, int b)
        {
            // automatisch von Visual Studio generiert
            // throw new NotImplementedException();

            return a + b;
        }

        public void Methode4()
        {
            Console.WriteLine("Methode4");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //VERSUCH ein Objekt vom Typ "AbstrakteKlasse" zu erzeugen
            // AbstrakteKlasse a = new AbstrakteKlasse();
            // Fehlermeldung: Es können keine Objekte einer abstrakten Klasse erzeugt werden

            Subklasse s = new Subklasse();
            s.Feld = 22;
            Console.WriteLine("Kontrollausgabe von Feld:" + s.Feld);
            s.Ausgabe();
            s.Methode1();
            s.Methode2("Blahblaa");
            Console.WriteLine("Kontrollausgabe des Rückgabewertes von Methode 3:" + s.Methode3(10, 20));
            s.Methode4();


            Console.ReadKey();
        }
    }
}

