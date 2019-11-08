/*
G_45_ctor_static
 
    Konstruktoren
    Wir haben beim Instanziieren  eines Objektes bisher ohne nähere Erläuterung die folgende Syntax verwendet:
    Klassenname Objektname = new Klassenname();
    Die Methode Klassenname() (hinter dem new) war dabei eine Fkt, die wir nicht selbst geschrieben hatten und die nur einen einzigen Job erfüllte: Speicherplatz reservieren für das gerade erzeugte Objekt.
    Name dieser Methode: "(Standard-)Konstruktor"

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_45_KonstruktorenUndStaticMember
{
    class Auto
    {
        // Innerhalb der Klasse befindet sich kein (eigener, expliziter) Konstruktor => Der Standard-Konstruktor wird automatisch erstellt
        public int AnzahlDerTueren;
    }

    class Bus
    {
        // eigener Konstruktor
        public Bus(int AnzahlDerSitzplaetze, string marke, string name)
        // ACHTUNG: public, damit wir ihn von außen verwenden können
        // hat KEINEN Rückgabewert, auch kein void
        // hat den selben Namen wie die Klasse (nur eben mit den runden Klammern einer Methode)
        {
            this.AnzahlDerSitzplaetze = AnzahlDerSitzplaetze;
            //links steht das Feld des Objektes, welches gerade instanziiert wird und dessen Feldwert initialisiert werden soll
            // zur Unterscheidung dient das Schlüsselwort "this" , im Sinne von "dieses" Objekt

            Marke = marke; // auf 'this' kann verzichtet werden, da kein Missverständnis zw. den Bezeichnern 'Marke'(Feld(Attribut) der Klasse) und 'marke' (Parameter) aufkommen kann 
            NameDesBusfahrers = name;
        }

        public int AnzahlDerSitzplaetze;
        public string Marke;
        public string NameDesBusfahrers;

    }

    class Computer
    {
        // 1. eigener Konstruktor
        // erwartet den Übergabewert Speicherplatz
        public Computer(int Speicherplatz)
        {
            this.Speicherplatz = Speicherplatz;
        }

        // 2. eigener Konstruktor
        // erwartet den Übergabewert Speicherplatz und Benutzername
        public Computer(int Speicherplatz, string Besitzer)
        {
            this.Speicherplatz = Speicherplatz;
            this.Besitzer = Besitzer;
        }

        // 3. eigener Konstruktor
        // erwartet den Übergabewert Benutzername
        public Computer(string Besitzer)
        {
            this.Besitzer = Besitzer;
        }

        // 4. eigener Konstruktor
        // erwartet den Übergabewert Speicherplatz und Benutzername(user)
        // eine andere Reihenfolge der Parameter ist möglich -> Methode damit immer noch eineindeutig
        // Vorteil: ich muss mir die Reihenfolge der Parameter nicht merken
        public Computer(string Besitzer, int Speicherplatz)
        {
            this.Speicherplatz = Speicherplatz;
            this.Besitzer = Besitzer;
        }

        // Fehler: gleicher Typ existiert schon!
        // 5. eigener Konstruktor ?
        // erwartet den Übergabewert Speicherplatz
        /*
         public Computer(int s)
        {
            Speicherplatz = s;
        }
        */

        public int Speicherplatz;
        public string Besitzer;
    }

    class Dorf
    {
        // Konstruktor ohne Code
        public Dorf()
        {
            // kein Code enthalten, könnte aber
        }

        public Dorf(int AnzahlDerEinwohner)
        {
            this.AnzahlDerEinwohner = AnzahlDerEinwohner;
        }
        public int AnzahlDerEinwohner;
    }

    class Eissorte
    {
        string name; // privates Feld
        public Eissorte(string n)
        {
            name = n;
        }
    }

    class Flugzeug
    {
        public Flugzeug(int AnzahlDerPropeller)
        {
            if (AnzahlDerPropeller > 0 && AnzahlDerPropeller < 13)
                this.AnzahlDerPropeller = AnzahlDerPropeller;
            // Wir können durch diese Bedingung die Initialisierung eines Feldes von einer Vorraussetzung abhängig machen
            // NICHT aber die Instanziierung => das Objekt wird in jedem Fall durch den Aufruf des Konstruktors erzeugt, die init. des Feldes 'AnzahlDerPropeller' geschieht aber nur, wenn die Bedingung erfüllt ist
        }
        public int AnzahlDerPropeller;
    }

    class Gaststaette
    {
        public int AnzahlDerSpeisekartenAufrufe = 0; // KEIN static => dieser Zähler gehört zum jeweiligen Objekt

        public void AusgabeDerSpeisekarte()
        {
            Console.WriteLine("Eisbein 9,50 Euro / Rotkohl .... ");

            // mit jedem Aufruf der Speisekarte erhöht sich der Zählwert
            AnzahlDerSpeisekartenAufrufe++;
        }
    }

    class Hausmeister
    {
        public static int ObjektCounter = 0; // static => dieser Zähler bezieht sich nicht auf ein einzelnes Objekt, sondern auf die gesamte Klasse
        public Hausmeister()
        {
            ObjektCounter++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Instanziierung eines Objektes vom Typ Auto mit Hilfe des Standard-Konstruktors Auto()
            Auto a = new Auto();
            a.AnzahlDerTueren = 4;
            Console.WriteLine("Anzahl der Türen des Autos:" + a.AnzahlDerTueren);

            // Instanziierung eines Objektes vom Typ Bus mit Hilfe eines eigenen Konstruktors UND Initialisierung mit Hilfe der Übergabewerte
            Bus b = new Bus(100, "Mercedes", "Müller");
            // durch Initialisierung im ctor kann ich mir Folgendes sparen ....
            b.AnzahlDerSitzplaetze = 99;
            //b.Marke = "Volvo";
            //b.NameDesBusfahrers = "Werner";
            Console.WriteLine("unser Bus: Sitzplätze:" + b.AnzahlDerSitzplaetze + "\tMarke:" + b.Marke + "\tFahrer:" + b.NameDesBusfahrers);

            // Instanziierung eines Objektes vom Typ Computer mit Hilfe eines von mehreren Konstruktoren (mit unterschiedlichen Parametern)
            // HINWEIS: erster Einblick in die Polymorphie (Überladen von Methoden)

            // nur 1 int Parameter
            Computer c1 = new Computer(1000);
            // Es gibt nur einen Konstruktor mit genau einem int als Übergabewert => Compiler weiß, welcher Konstruktor aufgerufen werden muss.
            Console.WriteLine("Kontrollausgabe c1: Speicher:" + c1.Speicherplatz);

            // 2 Parameter
            Computer c2 = new Computer("Schmidt", 100000);
            Console.WriteLine("Kontrollausgabe c2: Speicher:" + c2.Speicherplatz + "\tBesitzer" + c2.Besitzer);

            // 2 Parameter
            Computer c3 = new Computer(111111, "Schmitt");
            Console.WriteLine("Kontrollausgabe c3: Speicher:" + c3.Speicherplatz + "\tBesitzer" + c3.Besitzer);

            // 1 Parameter: Name
            Computer c4 = new Computer("Schulze");
            Console.WriteLine("Kontrollausgabe c4: Besitzer" + c4.Besitzer);

            // 0 Parameter - Versuch, den Standard-Konstruktor aufzurufen
            // Fehler:
            // Computer c5 = new Computer();
            // Achtung: mit dem ersten selbst eingeführten Konstruktor wurde der Standard-Konstrutor überschrieben
            // einen ctor mit 0 Übergabewerten gibt es nicht mehr

            // Verwendung eines "Standard-"Konstruktors
            Dorf d = new Dorf();

            // Verwendung eines ctor's zur init. von PRIVATEN Feldern
            Eissorte e = new Eissorte("Amarena");
            // folgendes ist nicht mehr möglich:
            // e.name = "Vanilla";
            // es ist daher nur 1 mal möglich (indirekt über den ctor) eine Eissorte zu setzen

            // Aufruf eines ctor, der nur bei einer erfüllten Bedingung mit Hilfe des Parameters initialisiert wird:
            Flugzeug f1 = new Flugzeug(22);
            Console.WriteLine("Kontrollausgabe: Anzahl der Propeller von f1:" + f1.AnzahlDerPropeller);

            Flugzeug f2 = new Flugzeug(4);
            Console.WriteLine("Kontrollausgabe: Anzahl der Propeller von f2:" + f2.AnzahlDerPropeller);
            // Hinweis: in beiden Fällen wurde das Objekt instanziiert.
            // falls man hingegen die Instanziierung von einer Bedingung abhängig machen möchte, so geschieht diese Überprüfung VOR Aufruf des ctor

            int propellerAnzahl = 22;
            Flugzeug f3 = null;
            if (propellerAnzahl >= 0 && propellerAnzahl < 10)
                f3 = new Flugzeug(propellerAnzahl);

            ////////////////////////////////////////////////////////

            // Zum Thema 'static'
            // Bei der Verwendung von eigenen Methoden haben wir bisher stets "static" notiert, ohne dessen Bedeutung näher zu erklären.
            // Nachdem wir nun mit Hilfe von Konstruktoren Objekte von selbst erschaffenen Klassen erzeugen können, haben wir aber das "Rüstzeug"
            // diesen Begriff ein wenig zu durchleuchten:
            // IMMER DANN, wenn wir UNABHÄNGIG von einem Objekt etwas(eine Variable, eine Methode, ein Array, eine Liste ...) einführen wollen,
            // müssen wir das Schlüsselwort "static" verwenden. FALLS HINGEGEN ein Feld, eine Methode ... zu einem konkreten Objekt gehört, so
            // muss auf static (natürlich) verzichtet werden:

            // Beispiel a) Ein Zähler, der zu einem Objekt gehört:
            // Instanziierung eines Objektes der Klasse Gaststätte:
            Gaststaette g = new Gaststaette();
            // 2-maliger Aufruf der Methode ...
            g.AusgabeDerSpeisekarte();
            g.AusgabeDerSpeisekarte();
            Console.WriteLine("Anzahl der Speisekartenaufrufe in g:" + g.AnzahlDerSpeisekartenAufrufe);

            //Instanziierung eines weiteren Objektes der Klasse 'Gaststaette'
            Gaststaette g2 = new Gaststaette();
            // 3-maliger Aufruf der Methode ...
            g2.AusgabeDerSpeisekarte();
            g2.AusgabeDerSpeisekarte();
            g2.AusgabeDerSpeisekarte();
            Console.WriteLine("Anzahl der Speisekartenaufrufe in g2:" + g2.AnzahlDerSpeisekartenAufrufe);

            // (static) Zähler, der nicht zu einem einzelnen Objekt SONDERN zur gesammten Klasse gehört:
            // Instanziierung von 3 Objekten des Typs 'Hausmeister'
            Hausmeister h1 = new Hausmeister();
            Hausmeister h2 = new Hausmeister();
            Hausmeister h3 = new Hausmeister();

            // Auslesen des Klassenzählers 
            // "Wieviele Objekte vom Typ Hausmeister wurden instanziiert?"
            Console.WriteLine("Anzahl der Objekte vom Typ Hausmeister:" + Hausmeister.ObjektCounter);
            // bei statischen Größen, die der Klasse gehören: Klassenname.Feldbezeichner

            // so geht es nicht:
            // Console.WriteLine("Anzahl der Objekte vom Typ Hausmeister:" + h1.ObjektCounter);


            Console.ReadKey();
        }
    }
}