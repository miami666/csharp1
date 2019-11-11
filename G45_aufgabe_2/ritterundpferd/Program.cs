using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Erstellen Sie bitte zunächst die beiden folgenden Klassen 'Ritter' und 'Pferd'
        Member
            Die Klasse Ritter besitzt die Felder 'Name'(public, String), 'SeinPferd'(public, Pferd) und eine statische Liste vom Typ Ritter
            Die Klasse Pferd besitzt die Felder 'Name'(public, String), 'Besitzer'(public, Ritter) und eine statische Liste vom Typ Pferd
            Die Klasse Ritter hat zwei Konstruktoren:
                a) Übergabewerte: Keine
                   Funktion: - Instanziiert ein neues Objekt p vom Typ Pferd
                             - Initialisiert Besitzer in p mit 'this' (also jenem Ritter, der gerade instanziiert wird)
                             - Initialisiert SeinPferd mit p
                             - this und p werden zu den entsprechenden Listen hinzugefügt
                b) Übergabewerte: 2 Strings (Name des Ritters und Name des Pferdes)
                   Funktion: - die gleichen Funktionen wie in a)
                             - Initialisierung des Ritter- und Pferde-Namens
            Die Klasse Pferd besitzt nur einen Standard-Konstruktor
        Im Main
            - Instanziieren Sie bitte zunächst einen Ritter (und sein Pferd) mit Hilfe des Parameter-LOSEN Konstruktors aus Ritter
              Initialisieren Sie bitte anschließend die Namen mit "Graf von Holzhausen" und "Lucy"
            - Instanziieren Sie daraufhin bitte einen weiteren Ritter (und sein Pferd) mit Hilfe des anderen Konstruktors
              Verwenden Sie als Übergabewerte bitte die Strings "Prinz von Doppelkeks" und "Schoko"
            - Geben Sie bitte anschließend alle Elemente der Ritterliste (und das jeweils zugehörigen Pferd) aus  
            - Geben Sie zum Schluß auch alle Elemente der Pferdeliste (und den jeweils zugehörigen Besitzer) aus  
*/
namespace ritterundpferd
{
    class Ritter
    {
        public Ritter()
        {
            Pferd p = new Pferd();
            p.besitzer = this;
            seinPferd = p;
            listr.Add(this);
            Pferd.listp.Add(p);
        }
        public Ritter(string ritterName,string pferdeName)
        {
            Pferd p = new Pferd();
            p.besitzer = this;
            seinPferd = p;
            this.name = ritterName;
            p.name = pferdeName;
            listr.Add(this);
            Pferd.listp.Add(p);
        }
        public string name;
        public Pferd seinPferd;
        public static List<Ritter> listr = new List<Ritter>();
    }
    class Pferd
    {
        public string name;
        public Ritter besitzer;
        public static List<Pferd> listp = new List<Pferd>();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Ritter r = new Ritter();
            r.name = "Graf von Holzhousen";
            r.seinPferd.name = "lucy";
            r = new Ritter("Prinz von Doppelkeks", "Schoko");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nListe der Ritter");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Ritter ritter in Ritter.listr)            
                Console.WriteLine("Der Ritter {0} reitet auf {1}", ritter.name, ritter.seinPferd.name);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nListe der Gäule");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Pferd pferd in Pferd.listp)
                Console.WriteLine("Das Pferd {0} wird geritten von {1}", pferd.name, pferd.besitzer.name);
            Console.ReadKey();
        }
    }
}
