/* Schreiben Sie ein C# Programm, das
 * - die Klassen Computer, Desktop, Notebook und Server einführt.
 * - Jeder Computer hat einen Zustand (Ein/Aus)
 * - Einen Hersteller, der nur ein mal über den Konstruktor gesetzt werden darf
 * - Eine Statische Liste, die die aktuelle Instanz speichert 
 * (die Klasse Computer besitzt eine Liste vom Typ Computer, in die im Konstruktor das Objekt hinzugefügt wird)
 * - Und eine Methode zum Ein- und Ausschalten (Eine Methode, die beides erledigt)
 * (Diese Methode gibt den Typ des Computers und den neuen Zustand aus, siehe Screenshot)
 * (Versuchen Sie diese Ausgabe abhängig vom Zustand in nur einer Zeile zu implementieren)
 * - Überlegen Sie sich eine geeignete Vererbungsstruktur, von der Basisklasse soll kein Objekt erzeugt werden können
 * - Verwenden Sie in den Subklassen die Konstruktor-Verkettung zur Initialisierung des Herstellers in der Basisklasse
 * - Geben Sie im Main für jeden Computer in der Liste den Hersteller aus und rufen Sie die Methode zum Ein- und Ausschalten auf
 * (Siehe Screenshot) 
 * 
 * Beachten Sie, dass der Zustand nur über die Methode zum Ein- und Ausschalten geändert werden darf!
 * 
 * Erweitern Sie anschließend das Programm durch die Klasse Büro
 * - Jedes Büro hat eine Nummer, die nur ein mal durch den Konstruktor gesetzt werden darf
 * - eine Liste mit den sich im Büro befindenden Computern
 * - eine Statische Liste mit allen Büros
 * - und eine Statische Liste mit allen Büros
 * - Erweitern Sie die Main so, dass nun anstatt der Computerliste die Büroliste durchlaufen wird
 * (erzeugen Sie dazu zwei Büros mit je zwei Computern)
 * - und rufen Sie für jedes Büro die Nummer und für jeden Computer in jedem Büro den Hersteller und die Methode zum Ein- und Ausschalten auf
 */

using System;
using System.Collections.Generic;

namespace ILP_List_Polymorphie
{
    public class Computer
    {
        public static List<Computer> ComputerListe = new List<Computer>();

        public string Hersteller { get; private set; }
        public bool Zustand { get; private set; }

        protected Computer(string hersteller)
        {
            Zustand = false;
            Hersteller = hersteller;
            ComputerListe.Add(this);
        }

        public virtual void EinAusschalten()
        {
            Zustand = !Zustand;
        }
    }

    public class Desktop : Computer
    {
        public Desktop(string hersteller) : base(hersteller)
        {

        }

        public override void EinAusschalten()
        {
            base.EinAusschalten();
            Console.WriteLine("Desktop wurde {0}geschaltet.", Zustand ? "ein" : "aus");
        }
    }

    public class Notebook : Computer
    {
        public Notebook(string hersteller) : base(hersteller)
        {

        }

        public override void EinAusschalten()
        {
            base.EinAusschalten();
            Console.WriteLine("Notebook wurde {0}geschaltet.", Zustand ? "ein" : "aus");
        }
    }

    public class Server : Computer
    {
        public Server(string hersteller) : base(hersteller)
        {

        }
        public override void EinAusschalten()
        {
            base.EinAusschalten();
            Console.WriteLine("Server wurde {0}geschaltet.", Zustand ? "ein" : "aus");
        }

    }

    public class Büro
    {
        public static List<Büro> BüroListe = new List<Büro>();
        public List<Computer> ComputerListe = new List<Computer>();
        public int Nummer { get; private set; }
        public Büro(int nummer)
        {
            Nummer = nummer;
            BüroListe.Add(this);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Desktop desktop = new Desktop("Dell");
            Notebook notebook = new Notebook("HP");
            Server server = new Server("IBM");

            foreach (Computer computer in Computer.ComputerListe)
            {
                Console.Write(computer.Hersteller + ": ");
                computer.EinAusschalten();
            }


            Console.WriteLine("\n\n");

            Büro büro1 = new Büro(1);
            büro1.ComputerListe.Add(new Desktop("Dell"));
            büro1.ComputerListe.Add(new Notebook("HP"));
            Büro büro2 = new Büro(2);
            büro2.ComputerListe.Add(new Server("IBM"));
            büro2.ComputerListe.Add(new Desktop("Medion"));

            foreach (Büro büro in Büro.BüroListe)
            {
                foreach (Computer computer in büro.ComputerListe)
                {
                    Console.Write("Büro " + büro.Nummer + " - " + computer.Hersteller + ": ");
                    computer.EinAusschalten();
                }
            }


            Console.ReadKey(true);

        }
    }
}
