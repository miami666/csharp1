using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


namespace interfaces_aufgabe_2
{
   public struct Adresse
    {
       public string str;
       public int hnr;
       public  string plz;
       public string ort;
    }
    interface IAdr
    {
        string Name { get; set; }
       Adresse Anschrift { get; set; }
        void Etikett();
   }
 static class Adressverwaltung
    {
      public static void Etikett(IAdr obj)
        {
            Console.WriteLine(obj.Name+" "+obj.Anschrift.str+" "+obj.Anschrift.hnr+" "+obj.Anschrift.plz+" "+obj.Anschrift.ort);
        }
       public static void Erfasse(IAdr obj, string straße, int hausnr, string plz, string ort)
        {
            obj.Anschrift = new Adresse() { str = straße, hnr = hausnr, plz = plz, ort = ort };
       }
   }
    class Person : IAdr
    {
        public string Name { get; set; }
        public Adresse Anschrift { get; set;  }
       public void Etikett()
        {
            //Console.WriteLine(Name+" "+Anschrift.str+" "+Anschrift.hnr+" "+Anschrift.plz+" "+Anschrift.ort);
            Adressverwaltung.Etikett(this);
       }
        public Person(string name, string straße, int hausnr, string postlz, string stadt) {
            Name = name;
            // Anschrift = new Adresse() { str = straße, hnr = hausnr, plz = postlz, ort = stadt };
            Adressverwaltung.Erfasse(this, straße, hausnr, postlz, stadt);
        }
   }
    class Firma : IAdr
    {
        public string Name { get; set; }
        public Adresse Anschrift { get; set; }
        public void Etikett()
        {
            //Console.WriteLine(Name+" "+Anschrift.str+" "+Anschrift.hnr+" "+Anschrift.plz+" "+Anschrift.ort);
            Adressverwaltung.Etikett(this);
        }
        public Firma(string name, string straße, int hausnr, string postlz, string stadt)
        {
            Name = name;
            // Anschrift = new Adresse() { str = straße, hnr = hausnr, plz = postlz, ort = stadt };
            Adressverwaltung.Erfasse(this, straße, hausnr, postlz, stadt);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List < IAdr > personen = new List<IAdr>();
            Person p1 = new Person("Otto", "Schloßallee", 666, "50825", "Köln");
            Person p2 = new Person("Uschi", "Parkstrasse", 111, "50823", "Köln");
            Person p3 = new Person("Roy", "Musterstrasse", 333, "50859", "Köln");
            Firma f1 = new Firma("adidas", "blastrasse", 1, "50827", "Köln");
            personen.Add(p1);
            personen.Add(p2);
            personen.Add(p3);
            personen.Add(f1);
            foreach (IAdr p in personen)
            {
                p.Etikett();

            }
          // Console.WriteLine(p1.Anschrift);
           Console.ReadKey();
       }
    }
}
