/*
 *  - Erstellen Sie eine Struktur "Adresse" mit Straße, Hausnummer, PLZ und Ort
 *  - Erstellen Sie ein Interface "IAdresse" mit den Properties Name und Anschrift (Anschrift ist vom Typ Adresse)
 *      und der Methode Etikett() 
 *  - Erstellen Sie die Static Klasse Adressverwaltung mit den Static Methoden Etikett(IAdresse obj) 
 *      und Erfasse(IAdresse obj, string straße, int hausnr, string plz, string ort)
 *      (Die Klasse Adressverwaltung wird das Interface nicht implementieren, aber wir werden die Klasse verwenden,
 *      um Adressen auszugeben und zu erfassen)
 *  - Die Methode Etikett soll alle Informationen von IAdresse ausgeben (also Name und die Werte in Anschrift)
 *  - Die Methode Erfasse soll dem übergebenen IAdresse-Objekt die neuen Werte zuweisen
 *  - Erstellen Sie eine Klasse Person, die nun das Interface IAdresse implementiert und über den Konstruktor 
 *      public Person(string name, string straße, int hausnr, string plz, string ort) verfügt 
 *      Im Konstruktor sollen die Adress-Werte über die Adressverwaltung erfasst werden
 *  - In der Implementierung der Etikett-Methode des Interfaces soll die Etikett-Methode der Adressverwaltung
 *      aufgerufen werden
 *  - Testen Sie die Funktionalitäten im Main indem Sie dort eine Liste oder ein Array mit mehreren Personen anlegen und für jede
 *      Person die Etikett-Methode aufrufen.
 *  - Erweitern Sie das Programm durch Erstellen einer Klasse Firma, die ebenfalls IAdresse implementiert.
 *  - Fügen Sie zu Ihrer Liste im Main nun zusätzlich Objekte der Klasse Firma hinzu. Bewerkstelligen Sie dies ohne 
 *      Generalisierung der Klassen.
 */


using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IAdresse[] adressen =
            {
                //new Person("Klaus Müller", "Dorfstr.", 8, "12345", "Irgendwo"),
                //new Person("Marie Heinrich", "Stadtstr.", 24, "01234", "Sonstwo"),
                new Firma("Stahlbau GmbH", "Industriestr.", 2, "12345", "Irgendwo" )
            };

            foreach (IAdresse adresse in adressen)
                adresse.Etikett();

            Console.ReadKey();
        }
    }

    class Person : IAdresse
    {
        public string Name { get; set; }
        public Adresse Anschrift { get; set; }

        public Person(string name, string straße, int hausnr, string plz, string ort)
        {
            Name = name;
            Adressverwaltung.Erfasse(this, straße, hausnr, plz, ort);
        }

        public void Etikett()
        {
            Adressverwaltung.Etikett(this);
        }
    }

    class Firma : IAdresse
    {
        public string Name { get; set; }
        public Adresse Anschrift { get; set; }

        public Firma(string name, string straße, int hausnr, string plz, string ort)
        {
            Name = name;
            Adressverwaltung.Erfasse(this, straße, hausnr, plz, ort);
        }

        public void Etikett()
        {
            Adressverwaltung.Etikett(this);
        }
    }

    struct Adresse
    {
        public string Straße;
        public int Hausnummer;
        public string PLZ;
        public string Ort;

        public override string ToString()
        {
            return Straße + " " + Hausnummer + "\n" + PLZ + " " + Ort;
        }
    }

    interface IAdresse
    {
        string Name { get; }
        Adresse Anschrift { get; set; }
        void Etikett();
    }

    static class Adressverwaltung
    {
        public static void Etikett(IAdresse obj)
        {
            Console.WriteLine("\n" + new string('*', 30));
            Console.WriteLine("{0}", obj.Name);
            Console.WriteLine(obj.Anschrift); //<- geht dank überschriebener ToString()-Methode in der Struktur
            //Console.WriteLine("{0} {1}", obj.Anschrift.Straße, obj.Anschrift.Hausnummer);
            //Console.WriteLine("{0} {1}", obj.Anschrift.PLZ, obj.Anschrift.Ort);
            Console.WriteLine(new string('*', 30) + "\n");

        }
        public static void Erfasse(IAdresse obj, string straße, int hausnr, string plz, string ort)
        {
            obj.Anschrift = new Adresse { Straße = straße, Hausnummer = hausnr, PLZ = plz, Ort = ort };
        }
    }
}
