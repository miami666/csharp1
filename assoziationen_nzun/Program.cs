/*
    Assoziation Navigierbarkeit (Fall m:n)

    Wir haben zuletzt bereits kennengelernt, wie wir 1:n-Beziehungen programmiertechnsisch umsetzen können. Je nach Navigationsrichtung
    hatten wir dabei auf Listen zurückgegriffen, die uns auch im m:n helfen können.

    Wir hatten aber bereits angesprochen, dass die Implementierung von (Typ-fremdem) Listen (also z.B. Autolisten in Person) die OOP Philosophie
    der "Abkapselung" (im Sinne einer Abschirmung von einer Klasse zu allen anderen) verletzt. Da dies streng genommen auch für einfache 
    Fremdschlüssel gilt (also z.B. für das Attribut Besitzer vom Typ Person in Auto) werden wir uns auch noch ein alternatives Verfahren anschauen, 
    das wir auch bei 1:n-Beziehungen anwenden könnten:
    Definition einer weiteren ("Assoziations")-Klasse (erinnert an eine Hilfstabelle bei der Datenbankmodellierung)

*/
using System;
using System.Collections.Generic;


namespace G_46_Assoziation_Navigation_FALL_MzuN
{
    class Program
    {
        // Wir führen zunächst die beiden folgenden Klassen ein ...
        class Auto
        {
            public int Id;
            public string Marke;

            public List<Fahrer> FahrerListe = new List<Fahrer>();
        }

        class Fahrer
        {
            public int Id;
            public string Nachname;

            public List<Auto> AutoListe = new List<Auto>();
        }

        // ... mit denen wir die m:n Beziehung durch Listen abbilden werden.
        // (Ein Auto kann von mehreren Fahren genutzt werden, ein Fahrer hat das Recht verschiedene Autos zu nutzen)


        // Wir führen des weiteren noch die beiden folgenden Klassen ein:
        class Kunde
        {
            public int Id;
            public string Nachname;
        }

        class Produkt
        {
            public int Id;
            public double Preis;
        }

        // Um die unten angesprochene m:n-Beziehung zwischen Kunde und Produkt darstellen zu können, 
        // führen wir eine weitere Klasse ein
        // es handelt sich dabei um eine Assoziations-Klasse, die wir in diesem Fall "Einkauf" nennen können
        class Einkauf
        {
            // Weitere Attribute würden diese Assoziationsklasse aufwerten
            public int Id;
            public DateTime Datum;

            public Kunde Käufer;
            public Produkt Ware;
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // z.B. für das Sonderzeichen €

            // Einführung aller Objekte (noch OHNE Assoziations-Information)
            Auto a1 = new Auto();
            a1.Id = 1;
            a1.Marke = "VW";

            Auto a2 = new Auto();
            a2.Id = 2;
            a2.Marke = "Opel";


            Fahrer f1 = new Fahrer();
            f1.Id = 1;
            f1.Nachname = "Müller";

            Fahrer f2 = new Fahrer();
            f2.Id = 2;
            f2.Nachname = "Mayer";

            // Darstellung der vorliegenden Assoziationen:
            f1.AutoListe.Add(a1); // Fahrer 1 darf Auto 1 verwenden
            f1.AutoListe.Add(a2); // Fahrer 1 darf Auto 2 verwenden
            f2.AutoListe.Add(a1); // Fahrer 2 darf Auto 1 verwenden
            // (redundante) weitere Informationen (um auch die Navigierbarkeit von Auto zu Fahrer herstellen zu können)
            a1.FahrerListe.Add(f1); // Auto 1 darf von Fahrer 1 genutzt werden
            a1.FahrerListe.Add(f2); // Auto 1 darf von Fahrer 2 genutzt werden
            a2.FahrerListe.Add(f1); // Auto 2 darf von Fahrer 1 genutzt werden

            // 2 Beispielsausgaben (als Beispiele für die unterschiedlichen Navigationsrichtungen Fahrer->Auto / Auto->Fahrer)
            Console.WriteLine("Alle Autos von Fahrer 1:");
            foreach (Auto a in f1.AutoListe)
                Console.WriteLine("ID: " + a.Id + " / Marke: " + a.Marke);

            Console.WriteLine("\nAlle Fahrer des Autos 1:");
            foreach (Fahrer f in a1.FahrerListe)
                Console.WriteLine("ID: " + f.Id + " / Nachname: " + f.Nachname);


            // ***********************************************************************************************************************
            // Beispiel für eine Assoziationsklasse (Produkt - Kunde) 
            // m:n-Beziehung, denn: Ein Produkt kann von mehreren Kunden gekauft werden, und ein Kunde kann mehrere Produkte kaufen
            // (In diesem Beispiel: Kunde 1 kauft die Produkte 1 und 2  /  Kunde 2 kauft Produkt 1)

            // Instanziierung aller Objekte:
            Kunde k1 = new Kunde();
            k1.Id = 1;
            k1.Nachname = "Schmidt";

            Kunde k2 = new Kunde();
            k2.Id = 2;
            k2.Nachname = "Hansen";


            Produkt p1 = new Produkt();
            p1.Id = 1;
            p1.Preis = 3.50;

            Produkt p2 = new Produkt();
            p2.Id = 2;
            p2.Preis = 4.70;

            // Instanziierung der Objekte vom Typ Einkauf (jedes Objekt steht dann für eine Assoziation zwischen einem Kunden und einem Produkt)

            // Einkauf 1: Kunde 1 kaufte Produkt 1
            Einkauf e1 = new Einkauf();
            e1.Käufer = k1;
            e1.Ware = p1;

            // Einkauf 2: Kunde 1 kaufte Produkt 2
            Einkauf e2 = new Einkauf();
            e2.Käufer = k1;
            e2.Ware = p2;

            // Einkauf 3: Kunde 2 kaufte Produkt 1
            Einkauf e3 = new Einkauf();
            e3.Käufer = k2;
            e3.Ware = p1;

            // Damit wären wir bereits am Ziel FALLS wir uns ausschließlich mit einer Navigation Einkauf->Produkt, bzw. Einkauf->Kunde
            // begnügen würden. Beispiel:
            Console.WriteLine("\nKunde und Produkt von Einkauf 1:  Kundenname: " + e1.Käufer.Nachname + "   Produkt-ID: " + e1.Ware.Id);

            // Falls wir hingegen die Navigation Kunde->Produkt und Produkt->Kunde betrachten wollen, dann benötigen wir noch eine
            // Einkaufsliste (die als statische Liste auch in der Klasse Einkauf eingetragen werden könnte), die wir aber hier im Main einführen:

            // Liste aller Einkäufe:
            List<Einkauf> einkaufListe = new List<Einkauf>();
            // Befüllen der Liste mit allen drei Einkäufen:
            einkaufListe.Add(e1);
            einkaufListe.Add(e2);
            einkaufListe.Add(e3);

            //Alle Schritte in Einem!
            einkaufListe.Add(new Einkauf()
            {
                Käufer = new Kunde
                {
                    Id = 4,
                    Nachname = "Müller"
                },
                Ware = new Produkt
                {
                    Id = 4,
                    Preis = 1.99
                }
            });



            // Navigation Kunde->Produkt
            Console.WriteLine("\nListe aller Produkte, die von Kunden 1 gekauft wurden:");
            foreach (Einkauf e in einkaufListe)
            {
                if (e.Käufer.Id == 1)
                    Console.WriteLine("Produkt-ID: " + e.Ware.Id + "   Preis: " + e.Ware.Preis + "€");
            }

            // Navigation Produkt->Kunde
            Console.WriteLine("\nAlle Kunden der Ware 1:");
            foreach (Einkauf e in einkaufListe)
            {
                if (e.Ware.Id == 1)
                    Console.WriteLine("Kunden-ID: " + e.Käufer.Id + "   Nachname: " + e.Käufer.Nachname);
            }



            // Ergänzende Bemerkung:
            // Beim Design eines Programmes und der Erkenntnis, eine Assoziationsklasse einführen zu müssen (wollen) kann es natürlich
            // dabei bleiben, diese Assoziationsklasse als reine technische Notwendigkeit einzuführen und ansonsten inhaltlich nicht zu
            // nutzen ... nicht untypisch ist aber, dass man mit der Erkenntnis, eine Assoziationsklasse verwenden zu sollen, diese auch noch
            // als "eigenständige" Klasse begreift, entsprechend ergänzt und daher effektiver nutzt:

            // Beispiel:
            // Die Assoziationsklasse "Einkauf" muss nicht nur über die Assoziation Kunde-Ware sprechen, sondern kann durch weitere Informationen
            // aufgewertet werden (z.B. Einkaufsdatum) [wenn dies geschieht, dann lohnt es sich in der Regel auch, eine ID zu vergeben]

            Console.ReadKey();
        }
    }
}