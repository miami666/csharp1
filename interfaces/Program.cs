/*
 Interface

    Wir haben zuletzt mit den sogenannten "Abstrakten Klassen" eine Technologie kennen gelernt, 
    die von uns mit Hilfe von, protected, virtual und override bereits hätte simuliert werden können. 
    Abstakte Klasse waren aus dieser Sicht nur eine (kleine) syntaktische Erleichterung, 
    aber wie erwähnt kein "lebenswichtiger" Bestandteil unserer Thematik.

    Dies sieht bei Interfaces anders aus. Zum einen werden sie in gewisser Hinsicht "noch abstrakter" sein 
    (und dabei die Vorteile der Redundanz-Vermeidung durch Code-Übernahme aus der Basisklasse vollständig verlieren) 
    aber andererseits eine "Mehrfachvererbung" erlauben.
    (Mehrfachvererbung = Eine Subklasse kann mehrere Basisklassen haben)

    => Bei einem Interface geht es also nicht mehr darum, bereits geschriebenen Code erneut zu nutzen. 
    Statt dessen interessiert lediglich nur noch die (Vererbungs)-Struktur im Sinne eines "Ordnungsprinzips" 
    (bzw. einer Systematisierung, also einer GEMEINSAMEN SPRACHREGELUNG)

    Beispiel:
    In C# gibt es eine Klasse "Collection" die als Oberbegriff für Arrays, Listen, Enumerationen ... betrachtet werden kann.
    Für alle solche Collections (="Sammlungen") soll eine Sortier-Methode existieren. 
    WIE diese Methode jeweils arbeitet, kann sehr unterschiedlich sein 
    (erneut interessieren wir uns also für eine "Überschreibung" unserer Methode) 
    ABER DER NAME soll jedesmal "Sort()" lauten. 
    SO eine sprachliche Vereinbarung ist dann nicht nur für den Nutzer dieser Programmiersprache praktisch,
    sondern ist auch für die Entwickler vorteilhaft: 
    So kann zu Beginn die allgemeine Sprachregelung mitgeteilt werden 
    und dann das Projekt in unterschiedliche Arbeitsgruppen zerlegt werden 
    (Gruppe A entwickelt die Methode Sort() für Strings, Gruppe B für Integer ...)
*/
using System;
using System.Collections.Generic;

namespace G_59_Interface
{
    interface INameDesInterface_1 // Konvention: Der Name beginnt immer mit einem großen "I" gefolgt von einem großen Anfangsbuchstaben des Interface-Namens
    {
        // Konstruktoren sind in einem Interface verboten
        /*
        public INameDerInterface_1()
        {

        }
        */

        // private int feld; // Fehlermeldung: Auch Felder sind in einem Interface unzulässig
        // Das macht allerdings auch Sinn, denn von einem Interface können ja KEINE Objekte erzeugt werden 
        // => Felder=Attribut eines Objektes wären sinnlos
        // Ein Interface ist anschaulich gesprochen nur eine Liste von Werkzeugnamen, also nur von Methoden

        // Properties sind aber erlaubt:
        int Property { get; set; }
        /*public*/
        void Methode1(); // Zugriffsmodifizierer sind in einem Interface nicht zulässig
    }

    interface INameDesInterface_2
    {
        void Methode2();
    }

    class Klasse : INameDesInterface_1, INameDesInterface_2 // Man spricht NICHT vom erben, sondern von "Implementieren"
                                                            // WICHTIG: ALLE ELEMENTE des Interface müssen von der Klasse übernommen werden, ...
                                                            //          ... die dieses Interface implentiert
    {
        public int Property { get; set; }

        public void Methode1()
        {
            Console.WriteLine("Methode 1");
        }

        public void Methode2()
        {
            Console.WriteLine("Methode 2");
        }

        public void Methode3()
        {
            Console.WriteLine("Methode 3");
        }
    }

    class Klasse2 : INameDesInterface_1
    {
        public int Property { get; set; }

        public void Methode1()
        {
            Console.WriteLine("Methode1 aus Klasse2");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Klasse k = new Klasse();
            k.Methode1();
            k.Methode2();
            INameDesInterface_1 i1 = new Klasse();
            i1.Methode1();

            Klasse2 k2 = new Klasse2();

            List<INameDesInterface_1> liste = new List<INameDesInterface_1>();
            liste.Add(k);
            liste.Add(k2);

            foreach (INameDesInterface_1 i in liste)
            {
                i.Methode1();
            }

            Console.ReadKey();
        }
    }
}