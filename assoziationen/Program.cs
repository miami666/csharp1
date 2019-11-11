using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Assoziation und Navigierbarkeit: 

    Zum Begriff der Assoziation
        Wir haben zu Beginn unserer Beschäftigung mit der OOP zunächst einzelne Klassen implementiert und erst später
        auch Aufgabenstellungen mit mehreren Klassen betrachtet. Ohne uns darüber bereits explizite Gedanken zu machen,
        nutzten wir aber bereits aus, dass diese Klassen (bzw. deren Objekte) in Beziehung zueinander stehen können.
        Wir werden im ersten Angang uns auf die 1:n-Relationen konzentrieren. Was wir bisher "Relationen" nannten, wird 
        in der OOP auch als "Assoziation" bezeichnet.

    Zum Begriff der Navigierbarkeit
        In der Datenbankmodellierung hatten wir uns (im Sinne der 3. Normalenform) stets um Redundanz-Vermeidung bemüht.
        Keine Information, die man bereits aus bestehenden Informationen ableiten hätte können, sollte in einer Datenbank
        erscheinen. Dies vermeidet Redundanz ist aber nicht immer komfortabel. Genau damit befasst sich der Begriff der
        "Navigierbarkeit":
                
        Beispiel:
        Bei einer 1:n Beziehung (z.B. Auto-Person, eine Person kann mehrere Autos besitzen, aber jedes Auto hat nur einen Besitzer)
        haben wir den Fremdschlüssel stets "bei n" gesetzt (hier also: Fremdschlüssel Person in der Tabelle Auto).
        => Navigierbarkeit VON Auto ZU Person (Wenn ich ein bestimmtes Auto kenne, dann auch seinen Besitzer [im selben Datensatz])
        => KEINE (direkte) Navigierbarkeit von Person zu Auto (im Datensatz einer Person sind nicht seine Autos vermerkt)
*/

// Wir betrachten nun im Folgenden die 1:n-Beziehungen:
// a) Eine Person kann mehrere Autos besitzen (aber jedes Auto hat nur einen Besitzer)
// b) Eine Person kann mehrere Haustiere besitzen (aber jedes Haustier hat nur einen Besitzer)
// c) Eine Person kann mehrere Koffer besitzen (aber jeder Koffer hat nur einen Besitzer)


namespace assoziationen
{
    class person
    {
        public int id;
        public string nachname;
        public List<haustier> haustierliste = new List<haustier>();
        public List<koffer> kofferliste = new List<koffer>();
    }
    class auto
    {
        public int id;
        public string marke;
        public person besitzer;

    }
    class haustier
    {
        public int id;
        public string name;

    }
    class koffer
    {
        public int id;
        public string farbe;
        public person besitzer;

    }

   
    class Program
    {
        static void Main(string[] args)
        {

            //a) 1:n  Auto->Besitzer
            //Lösungsweg: Wir führen ein Feld in der Klasse auto vom Typ Klasse Person ein
            //Instanziieren einer Person:
            //wir starten mit einer Person damit diese existiert wenn wir in Auto diese als Besitzer eintragen
            person p1 = new person();
            p1.id = 1;
            p1.nachname = "Müller";
            //dann instanziieren von auto
            auto a1 = new auto();
            a1.id = 1;
            a1.marke = "opel";
            a1.besitzer = p1;

            //nun kann ich vom auto zur person navigieren
            //Bsp.: wie heißt der besitzer von auto 1 mit nachnamen
            Console.WriteLine("Nachname des Besitzers von Auto a1:"+a1.besitzer.nachname);
            //Aber die navigation von person zu auto gelingt uns nicht unmittelbar, einzige Lösung wäre hier alle autos abzuklappern und nach einem passenden Besitzer zu suchen

            //b) Person->Haustiere 1:n Beziehung Lösung: Liste haustier in class Person
            person p2 = new person();
            p2.id = 2;
            p2.nachname = "schulze";
            haustier h1 = new haustier();
            h1.id = 1;
            h1.name = "Bello";
            p2.haustierliste.Add(h1);
            haustier h2 = new haustier();
            h2.id = 2;
            h2.name = "Kitty";
            p2.haustierliste.Add(h2);
            // nun ist der Zugriff bzw. die Navigation von Person zu allen haustieren möglich
            Console.WriteLine("\nName aller Haustiere von person p2");
            foreach (haustier h in p2.haustierliste)
                Console.WriteLine(h.name);

            //c)Koffer-Person 1:n mit bidirektionaler Navigierbarkeit
            person p3 = new person();
            p3.id = 3;
            p3.nachname = "meier";
            koffer k1 = new koffer();
            k1.id = 1;
            k1.farbe = "blau";
            k1.besitzer = p3;
            p3.kofferliste.Add(k1);
            koffer k2 = new koffer();
            k2.id = 2;
            k2.farbe = "rot";
            k2.besitzer = p3;
            p3.kofferliste.Add(k2);
            Console.WriteLine("alle Koffer von person p3");
            foreach(koffer k in p3.kofferliste)
                Console.WriteLine(k.id+k.farbe);
            Console.ReadKey();
        }
    }
}
