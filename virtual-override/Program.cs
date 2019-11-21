/*
Polymorphie
    Neben der Abkapselung und der Vererbung ist dies die dritte Säule der OOP. 
    Poly="Viel" und Morphie="Gestalt" spricht bereits an, worum es geht: Methoden mit gleichem Namen aber unterschiedlichem Funktionskörper.
        
    Tatsächlich kommt die Polymorphie in zwei Varianten vor: 
    a) unterschiedliche Parameterlisten (das lernten wir bereits bei den Konstruktoren zum ersten mal kennen)
    b) unterschiedliche Funktionalität (bei identischer Parameterliste)

    Motivation:
    Im Rahmen der Vererbung kann es sein, dass verschiedene Objekte unterschiedlicher Klassen einer gemeinsamen Basisklasse
    zugeordnet werden können. Wenn wir alle diese Objekte in eine statische Liste der Basisklasse eintragen und der Reihe nach alle
    Elemente dieser Liste durchlaufen, dann kann es sein, dass wir für jedes dieser Elemente eine bestimmte Methode aufrufen wollen,
    die bei jedem Schleifendurchlauf (wir durchlaufen die Liste ja mit Hilfe einer Schleife) DEN SELBEN NAMEN trägt, DIE SELBEN
    ÜBERGABEWERTE erhält aber für jeden speziellen Objekt-Typ eine eigene Funktionalität hat.

Erläuterung an folgendem Beispiel:
Wir wollen eine (sehr allgemeine) Klasse "Formel" einführen, von der einige weitere Klassen erben werden.
Diese Klassen erben dann zunächst die sehr allgemeinen Attribute der Basisklasse UND eine Methode (deren Funktionalität sie aber jeweils "überschreiben" werden)
Auf diese Weise werden wir alle Objekte der unterschiedlichen Subklassen in einer gemeinsamen Liste ablaufen können, jedesmal den selben Methodenaufruf
starten, aber für jeden Typ von Objekt jeweils die individuelle Funktionalität erleben.
*/
using System;
using System.Collections.Generic;


namespace G_54_virtual_override
{
    class Formel
    {
        public static List<Formel> FormelListe = new List<Formel>();

        public Formel(string bezeichnung)
        {
            Bezeichnung = bezeichnung;
            FormelListe.Add(this);
        }

        public string Bezeichnung;

        public virtual double Berechne() // virtual: Mit diesem Schlüsselwort wird angezeigt, dass erbende Klasse diese Methode überschreiben können
        {
            Console.WriteLine("Ich bin virtuell und kann nichts berechnen");
            return 0;
        }
    }

    class Quadrat : Formel
    {
        public Quadrat(double seitenlänge, string bezeichnung) : base(bezeichnung)
        {
            Seitenlänge = seitenlänge;
        }

        public double Seitenlänge;

        public override double Berechne()
        {
            return Math.Pow(Seitenlänge, 2); // alternativ natürlich auch Seitenlänge*Seitenlänge möglich
        }
    }

    class Summe : Formel
    {
        public Summe(double summand1, double summand2, string bezeichnung) : base(bezeichnung)
        {
            Summand1 = summand1;
            Summand2 = summand2;
        }

        public double Summand1;
        public double Summand2;

        public override double Berechne()
        {
            return Summand1 + Summand2;
        }
    }

    class Prozent : Formel
    {
        public Prozent(double dasGanze, double prozentsatz, string bezeichnung) : base(bezeichnung)
        {
            DasGanze = dasGanze;
            Prozentsatz = prozentsatz;
        }

        public double DasGanze;
        public double Prozentsatz;

        public override double Berechne()
        {
            return DasGanze * Prozentsatz / 100;
        }
    }


    // Ein Beispiel zum Unterschied "Methode überschreiben" und "Methode verdecken"
    class Base
    {
        public virtual void Methode1()
        {
            Console.WriteLine("Virtual Methode1 in Base");
        }
        public void Methode2()
        {
            Console.WriteLine("Normale Methode2 in Base");
        }
        public void Methode3()
        {
            Console.WriteLine("Normale Methode3 in Base");
        }
    }

    class Sub : Base
    {
        public override void Methode1()
        {
            Console.WriteLine("Override Methode1 in Sub");
        }
        public new void Methode2()
        {
            Console.WriteLine("New Methode2 in Sub");
        }
        public void Methode4()
        {
            Console.WriteLine("Normale Methode4 in Sub");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // Instanziierung eines Objektes vom Typ "Formel"
            Formel f = new Formel("Oberbegriff: ");
            Console.WriteLine("Name der Formel: " + f.Bezeichnung);
            f.Berechne();

            // Instanziierung mehrerer Objekte unterschiedlicher (von Formel abgeleiteter) Klassen:
            Quadrat q = new Quadrat(10, "Quadrat-Fläche: ");
            Summe s = new Summe(20, 30, "Summe: ");
            Prozent p = new Prozent(200, 15, "Prozentualer Anteil: ");

            // Ausgabe aller Berechnungsergebnisse aller Objekte der statischen Liste aus der Basisklasse:
            Console.WriteLine("\n\nAlle Berechnungsergebnisse:");
            foreach (Formel formel in Formel.FormelListe)
                Console.WriteLine(formel.Bezeichnung + formel.Berechne());

            Console.WriteLine();
            Base baseKlasse = new Base();
            Sub subKlasse = new Sub();

            Console.WriteLine("Aufruf von baseKlasse");
            baseKlasse.Methode1(); //Ausgabe: "Virtual Methode1 in Base"
            baseKlasse.Methode2(); //Ausgabe: "Normale Methode2 in Base"
            baseKlasse.Methode3(); //Ausgabe: "Normale Methode3 in Base"

            Console.WriteLine("Aufruf von subKlasse");
            subKlasse.Methode1(); //Ausgabe: "Override Methode1 in Sub" <- Methode in Base wurde überschrieben
            subKlasse.Methode2(); //Ausgabe: "New Methode2 in Sub" <- Methode in Base wurde verdeckt
            subKlasse.Methode3(); //Ausgabe: "Normale Methode3 in Base" <- Ausgabe der geerbten Methode ohne Änderung
            subKlasse.Methode4(); //Ausgabe: "Normale Methode4 in Sub"

            Console.WriteLine("Sonderfall");
            Base baseKlasseSub = new Sub(); //Eine solche Instanziierung ist dank Polymorphie und Vererbung möglich

            baseKlasseSub.Methode1(); //Ausgabe: "Override Methode1 in Sub"
            baseKlasseSub.Methode2(); //Ausgabe: "Normale Methode2 in Base"
            baseKlasseSub.Methode3(); //Ausgabe: "Normale Methode3 in Base"
            //baseKlasseSub.Methode4(); //Dies funktioniert nicht, da es in Base keine Methode4 gibt.

            //Warum diese Ausgaben? baseKlasseSub ist ein Objekt vom Typ Base, es wurde jedoch eine Instanz von Sub gebildet.
            //In diesem Fall werden aus der Sub Klasse nur die überschriebenen Methoden aufgerufen, nicht jedoch die verdeckten.

            Console.ReadKey();
        }
    }
}

/*
 

    The virtual keyword is used to modify a method, property, indexer, or event declared in the base class and allow it to be overridden in the derived class.
    The override keyword is used to extend or modify a virtual/abstract method, property, indexer, or event of base class into derived class.
    The new keyword is used to hide a method, property, indexer, or event of base class into derived class.
*/
