/*
Aggrgation und Komposition
    
Zur Aggregation
    Die Aggregation ist zwar eine UML-technisch ausgezeichnete Assoziation, wird aber programmiertechnisch wie eine "normale"
    Assoziation behandelt. Tatsächlich kann man aus der Tatsache, dass eine bestimmte Assoziation eine Aggregation ist, auch
    noch nicht einmal schließen, welche "Multiplizität" (bzw. Kardinalität) vorliegt - Beispiele:
                
        a) Die Assoziation Klasse - Schüler ist eine Aggregation 
            (Multiplizität: 1:n, denn jeder Schüler gehört zu einer eindeutigen Klasse, aber zu einer Klasse gehören mehrere Schüler)
        b) Die Assoziation Student-Vorlesung ist ebenfalls eine Aggregation
            (Multiplizität: m:n, denn ein Student kann mehreren Vorlesungen zugeordnet werden, so wie einer Vorlesung auch mehrere Studenten)
             
        => Aus der Information, dass bei einer bestimmten Assoziation eine Aggregation vorliegt können wir keine C#-Implementierungsregeln
            ableiten (je nach Navigierbarkeit kann ein Feld, oder eine Liste, oder aber auch eine Assoziationsklasse angeraten sein)


Zur Komposition
    Diese Assoziation ist auch programmiertechnisch interessant, denn die Lebensdauer der Teile hängt von der Lebendauer des Ganzen ab -
    wenn also z.B. ein Objekt vom Typ Haus gelöscht wird, dann müssen auch alle Räume gelöscht werden (bzw. vom Garbage-Collector entfernt
    werden) ...
    INTERESSANTERWEISE gibt es zur Umsetzung von Kompositionen KEINE allgemein anerkannten Techniken, sondern diese werden "diskutiert"

    HINWEIS:
        Gelegentlich kann bei Kompositionen auch die umgekehrte Sichtweise eine Rolle spielen: 
        Wenn ALLE Teile gelöscht werden, dann verschwindet auch das Ganze: 
        (Ein Haus, bei dem einige Räume verloren gehen, kann weiter existieren, es existiert aber sicher nicht mehr, wenn ALLE Räume verschwanden)
*/
using System;
using System.Collections.Generic;

namespace G_49_Aggregation_Komposition
{
    class EinTeil
    {
        //Mit dieser TeileListe implementieren wir eine Aggregation, ohne sie eine Komposition
        //public static List<EinTeil> TeileListe = new List<EinTeil>();

        public EinTeil(int x)
        {
            this.x = x;
            //TeileListe.Add(this);
        }


        public int x;
    }

    class DasGanze
    {
        public static List<DasGanze> GanzeListe = new List<DasGanze>(); // Liste aller Objekte vom Typ DasGanze (also statisch)

        public DasGanze(int xVonTeil1, int xVonTeil2, int DasGanzeId)
        {
            this.id = DasGanzeId; // Initialisierung des (einzigen) feldes des Objektes vom Typ DasGanze
            GanzeListe.Add(this); // Das gerade instanziierte Objekt vom Typ DasGanze wird in die statische Liste eingefügt
            teileListe.Add(new EinTeil(xVonTeil1)); // Instanziierung eines neuen Objektes vom Typ EinTeil, initialisierung mit a und Listen-Hinzufügung
            teileListe.Add(new EinTeil(xVonTeil2)); // Instanziierung eines neuen Objektes vom Typ EinTeil, initialisierung mit b und Listen-Hinzufügung
        }

        public List<EinTeil> teileListe = new List<EinTeil>(); // Eine Liste der Teile, diese existieren nur hier und werden entsprechend verschwinden ...
                                                               // ... falls auch das Objekt (vom Typ DasGanze) verschwindet
        int id;

        // Beim Instanziieren eines Objektes vom Typ DasGanze muss man die beiden folgenden Fälle unterscheiden:
        //   a) Bereits zum Zeitpunkt der Instanziierung sind ALLE Teile bekannt 
        //        => Das Instanziieren der Teile kann durch den Aufruf des Ganze-Konstruktors bewerkstelligt werden
        //   b) Erst nach der Instanziierung des Ganzen ist bekannt, welche Teile nötig sind (bzw. welche noch hinzugefügt werden sollen)
        //        => Es muss eine zusätzliche (öffentliche) Methode innerhalb der Klasse DasGanze eingefügt werden, mit deren Hilfe
        //           die Instanzen vom Typ EinTeil instanziiert und in der entsprechenden Liste eingetragen werden

        public void ZeigeAlles()
        {
            Console.WriteLine("id = " + id);
            foreach (EinTeil t in teileListe)
                Console.Write(" x = " + t.x);
            Console.WriteLine();
        }

        public void AddTeil(int xVonTeil)
        {
            teileListe.Add(new EinTeil(xVonTeil));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Beipiel:
            // Wir nehmen an, dass jedes Objekt vom Typ DasGanze aus genau 2 Teilen besteht.
            // Wir können dann beim Aufruf des Ganze-Konstruktors zwei Integer übergeben, 
            // mit denen wir die beiden Objekte vom Typ EinTeil initialisieren können. 
            // (Der Ganze Konstruktor instanziiert UND Initialisiert also jeweils 2 Objekte vom Typ EinTeil 
            // und trägt beide in die teileListe)
            // Ferner soll der Ganze-Konstruktor natürlich auch die Felder des Objektes vom Typ DasGanze initialisieren 
            // und "diesen" (this) natürlich auch in die statische Liste einfügen

            // Instanziierung eines neuen Objekts vom Typen DasGanze
            new DasGanze(33, 44, 300);
            DasGanze.GanzeListe[0].ZeigeAlles();
            // Hinzufügen eines neuen Teils zu diesem ersten Objekt vom Typ DasGanze
            DasGanze.GanzeListe[0].AddTeil(55);
            // Kontrollausgabe:
            DasGanze.GanzeListe[0].ZeigeAlles();

            // Instanziierung eines weiteren Objekts vom Typen DasGanze
            new DasGanze(10, 20, 400);
            DasGanze.GanzeListe[1].ZeigeAlles();

            // Ausgabe aller Objekte vom Typ DasGanze:
            Console.WriteLine("\nListe aller Objekte vom Typ DasGanze:");
            foreach (DasGanze g in DasGanze.GanzeListe)
                g.ZeigeAlles();

            // Löschen des ersten Objekts aus der statischen Liste der Klasse DasGanze:
            DasGanze.GanzeListe.RemoveAt(0);
            DasGanze.GanzeListe[0].teileListe[0].x = 99; // <- Funktioniert, da bei Objekten immer die Referenz auf den Speicher gespeichert wird

            // Kontroll-Ausgabe aller Objekte vom Typ DasGanze nach Löschung:
            Console.WriteLine("\nListe aller Objekte vom Typ DasGanze:");
            foreach (DasGanze g in DasGanze.GanzeListe)
                g.ZeigeAlles();


            //Wenn man in EinTeil eine statische TeileListe hinzufügt und dort die Referenz auf jedes Teil speichert,
            //dann bleiben diese Teile erhalten, auch wenn das Ganze gelöscht wird!
            //foreach (EinTeil t in EinTeil.TeileListe)
            //    Console.WriteLine(t.x);

            Console.ReadKey();
        }
    }
}