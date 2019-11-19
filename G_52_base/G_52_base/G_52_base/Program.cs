/*
    Vererbungshierarchie mit "eigenen" Konstruktoren
    (in der Basisklasse und den Subklassen werden wir nicht nur Standardkonstruktoren verwenden)

    Wir haben bisher die Vererbung (als 2. wichtige Säule der OOP) betrachtet, ohne eigene ctor's einzuführen.
    Dies geschah, um das Prinzip der Vererbung möglichst einfach kennen zu lernen. 
    Nachteil war, dass wir die Vorteile von eigenen ctor#s nicht nutzen konnten, z.b. Initialisierung der Felder
    Dies werden wir im Folgenden ändern .....
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_52_base
{
    /*
    class Basis
    {
        int basisAttribut;
        public Basis(int b)
        {
            basisAttribut = b;
        }
    }

    class Subklasse : Basis
    {
        int subklasseAttribut;
        public Subklasse(int s)
        {
            subklasseAttribut = s;
        }
    }
    
    */

    // Erläuterung des Problems:
    // Wenn ein ctor einer Subklasse aufgerufen wird, dann wird ZUFOR (ein geeigneter) ctor der Basisklasse ausgeführt.
    // "geeigent" = im Sinne der gegebenen Übergabewerte
    // GENAU DIES ist hier aber das Problem:
    // In der Basisklasse gibt es NUR EINEN ctor, der einen Int-Übergabewert erwartet. In der Subklasse wird zwar ein Konstruktor mit genau einem Int-Übergabewert gestartet, ABER dessen Übergabewert wird nicht an den ctor der Basisklasse "weitergereicht"
    // => Der ctor der Basisklasse versucht zu starten OHNE das er einen Übergabewert erhielt -> Fehlermeldung

    // Lösung:

    class Basis1
    {

        int basisAttribut;
        public Basis1(int b)
        {
            basisAttribut = b;
        }

        public Basis1() // ein eigener Standard-ctor
        {

        }
    }

    class Subklasse1 : Basis1
    {
        int subklasseAttribut;
        public Subklasse1(int s)
        {
            subklasseAttribut = s;
        }
    }

    // Erläuterung der Lösung
    // Es kann nun ein geeigneter ctor gefunden werden, denn durch die Einführung des parameterlosen ctor's Basis1() existiert nun ein ctor innerhalb der Basisklasse, der aufgerufen werden kann, ohne dass man ihm Übergabewerte mit gibt
    // NACHTEIL: Der ctor Subklasse1() initialisiert nicht das Basisattribut
    // das führt zu folgendem Versuch:

    /*
    class Basis
    {
        int basisAttribut;
        public Basis(int b)
        {
            basisAttribut = b;
        }
    }

    class Subklasse : Basis
    {
        int subklasseAttribut;
        public Subklasse(int b, int s)
        {
            subklasseAttribut = s;
        }
    }

    */

    // Erläuterung des Problems:
    // Auch hier wird mit dem Aufruf des ctor's der Subklasse zunächst versucht, einen geeigneten ctor der Basisklasse aufzurufen.
    // Der hier eingeführete ctor der Subklasse besitzt aber 2 Parameter, und da es in der Basisklasse keinen Std.-ctor gibt und der Basisklasse keine Übergabewerte weitergereicht werden, scheitert erneut der Versuch aus der Basisklasse einen ctor zu starten

    // Lösung:

    class Basis2
    {
        public int basisAttribut; // public, um die Initialisierung ohne großen Aufwand testen zu können
        public Basis2(int b)
        {
            basisAttribut = b;
        }
    }

    class Subklasse2 : Basis2
    {
        public int subklasseAttribut; // public, um die Initialisierung ohne großen Aufwand testen zu können
        public Subklasse2(int b, int s) : base(b) // mit base(b) wird ein Integer an die Basisklasse weiter gereicht
                                                // falls mehrere Übergabewerte verlangt werden: base(a,b,...)
        {
            subklasseAttribut = s;
        }
    }

    // ACHTUNG: Ein Hinweis, der zeigen soll, dass das Fehlen von base(Übergabewert) für den Compiler "unsichtbar" bleiben kann, aber eben zu unerwünschten Folgen führt:

    class Basis3
    {
        public Basis3() // dieser ctor wird gefunden, falls base unten vergessen wird, also keine Übergabewerte weitergereicht werden
        { } // => KEINE Fehlermeldung des Compilers, aber dieser Std.-ctor initialisiert eben auch nichts.

        public int basisAttribut; // public, um die Initialisierung ohne großen Aufwand testen zu können
        public Basis3(int b)
        {
            basisAttribut = b;
        }
    }

    class Subklasse3 : Basis3
    {
        public int subklasseAttribut; // public, um die Initialisierung ohne großen Aufwand testen zu können
        public Subklasse3(int b, int s)// : base(b) // falls man base(..) vergisst, ABER s.o.
        {
            subklasseAttribut = s;
        }
    }

    // Erläuterung:
    // Hier würden wir SCHEINBAR durch den Aufruf des Subklassen-ctor's die beiden Attribute aus Basis und Subklasse initialisieren ...
    // ...in Wahrheit wird aber b im Subklassen-ctor ungenutzt "verpuffen" und (weil KEIN Übergabewert per 'base' nach oben weiter gereicht wurde) der Std.-ctor ausgeführt, der eben nichts initialisiert



    class Program
    {
        static void Main(string[] args)
        {
            // Erzeugung eines Objektes vom Typ Subklasse1
            Subklasse1 s1 = new Subklasse1(22);
            // Der Wert des Attributs s1.subklasseAttribut ist nun 22, ... der (geerbte Wert des Basisattributes ist allerdings weiterhin 0 (nicht initialisiert)

            // Erzeugung eines Objektes vom Typ Subklasse2
            Subklasse2 s2 = new Subklasse2(11, 22);
            Console.WriteLine("Kontrollausgabe (Subklasse2):\nBasisAttribut = {0}\nSubklassenAttribut = {1}", s2.basisAttribut, s2.subklasseAttribut);

            // Erzeugung eines Objektes vom Typ Subklasse3
            Subklasse3 s3 = new Subklasse3(33, 44);
            Console.WriteLine("Kontrollausgabe (Subklasse3):\nBasisAttribut = {0}\nSubklassenAttribut = {1}", s3.basisAttribut, s3.subklasseAttribut);

            Console.ReadKey();


        }
    }
}
