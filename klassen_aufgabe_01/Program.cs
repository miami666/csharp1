/*
    Einstieg in die Objekt-Orientierte-Programmierung (OOP)
        
    Die OOP wird gerne als eine programmier-Philosophie bezeichnet (besonders hochtrabend wird sogar von einem Paradigma gesprochen).
    Etwas bodenständiger können wir statt dessen feststellen, dass wir bei der OOP ein neues Verfahren kennenlernen werden, wie wir
    ein Programm aufbauen, bzw. strukturieren. Die OOP ist also vorallem ein "Ordnungs-Prinzip" bzgl. der Codierung.

    Die Literatur (bzw. gerne auch IHK-Prüfer) spricht von (bzw. fragt nach) den sogenannten "Säulen der OOP":
    - Die erste Säule ist die "Abkapselung" (im Moment reicht es uns, zu verstehen, dass damit eine Form der Modularisierung gemeint ist)
    - Die Vererbung (theoretisch SEHR bedeutend, in der Praxis weit weniger) Idee: Eine neue Klasse erbt von einer alten => Code kann übernommen werden
    - Polymorphie ("Vielgestaltigkeit") = Methoden mit dem selben Namen können (situationsbedingt) unterschiedliches leisten
                                            (außerdem können sie mit unterschiedlichen Parameterlisten ausgestattet sein)
                                            Beispiel: Die Sort-Methode kann auf Integer, Strings, Character ... angewendet werden

    "Einige Spaßvögel" führen auch noch eine vierte Säule ein: Die Klassenbildung
    Kritik an dieser Position: Dies ist keine Säule, sondern quasi die Voraussetzung der drei genannten Punkte...

    Lösung dieses "Streits":
    Die Klassenbildung ist das Fundament und Abkapselung,Vererbung und Polymorphie sind die auf ihr stehenden Säulen der OOP
       
         Objekt
       Orientierte
     Programmierung
         A     P 
         B     O
         K  V  L
         A  E  Y
         P  R  M
         S  E  O
         E  R  R 
         L  B  P
         U  U  H
         N  N  I
         G  G  E
      KLASSENBILDUNG




    Folgerichtig beginnen wir dem Fundament und stellen uns die Frage, wie wir Klassen definieren und aufrufen können
*/
using System;


namespace klassen_aufgabe_1
{
    class Person // Klassen sind automatisch public (wir können sie private werden lassen, müssen dann aber explizit private davor schreiben)
    {
        // Allgemeine Namenskonvention: public => GROSSER Anfangsbuchstabe

        // Beispiele für Felder
        public int Id;  // Member (Felder/Attribute/Variablen oder Methoden/Funktionen) einer Klasse sind automatisch private 
        public string Name;


        // Beispiel für eine Methode
        public void Ausgabe() // Diese Funktion benötigt keine Übergabwerte, denn sie arbeitet mit Feldern, die dem Objekt ja schon bekannt sind
        {
            Console.WriteLine("ID: {0}   Name: {1}", Id, Name);
        }

        public void Begrüßung(string s)
        {
            Console.WriteLine(s + " " + Name);
        }

        public int IdMalX(int x)
        {
            return Id * x;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Deklaration eines Objektes (Namensvergabe) und Definition (Mitteilung, zu welcher Klasse dieses Objekt gehört)
            Person p;

            // Instanziierung (Instanz=Objekt) => es wird nun tatsächlich ein Objekt erschaffen, bzw. Speicherplatz für dieses reserviert
            p = new Person();

            // Zuweisung von Werten an die Felder des Objektes p:
            p.Id = 1;
            p.Name = "Hans";

            // Aufruf einer Methode, die zum Objekt p gehört
            p.Ausgabe();

            // Aufruf einer anderen Methode (mit Übergabewert)
            p.Begrüßung("Hallo");
            p.Begrüßung("Grüß Gott");

            // Aufruf einer weiteren Methode (mit Rückgabewert und Übergabewert)
            int rückgabewertMerker;
            rückgabewertMerker = p.IdMalX(10);
            Console.WriteLine("Rückgabewert-Merker: " + rückgabewertMerker);

            Console.ReadKey();
        }
    }
}