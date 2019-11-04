/*
Listen

    Definition
        Listen sind - anschaulich gesprochen - "bequeme Arrays". 
        Gemeint ist: wir müssens uns keine Gedanken über die maximale
        Länge machen (wie dies bei Arrays ja im Rahmen der Deklaration und Definition bereits geschieht)
        Das hat den Vorteil, dass man (ähnlich wie bei Tabellen in SQL) 
        beliebig viele Elemente zu einer Liste hinzufügen kann
        und also zum Zeitpunkt der Definition der Liste NICHT wissen muss, 
        wieviel Speicherplatz man benötigen wird.

    Hinweis
        Man könnte daher den Eindruck gewinnen, dass Listen die Verwendung von Arrays vollständig ersetzen könnte,
        dennoch gibt es auch für Arrays eine Motivation: Bessere Performance. 
        Grund: Wenn ich bei einem Array die Startadresse des nullten Feldes kenne
        (z.B. 1000) und ich interessiere mich für den Wert des 300-sten Feldes, 
        dann kann ich sofort dessen Adresse ermitteln: 1000+300
        und also an der Adresse 1300 nachschauen, was dort gespeichert ist.
        Bei einer Liste gelingt dies nicht - dort verweist jedes Feld per Pointer auf das Nachbarfeld 
        und wenn wir z.B. dass 300-ste Feld auslesen wollen, 
        so werden wir von Feld 0 über dessen Pointer zu Feld 1 gehen können, 
        dort den Pointer von Feld 2 finden, um daraufhin Feld 2 ansteuern zu können ... u.s.w. ...
*/
using System;
using System.Collections.Generic;


namespace G_34_Listen
{
    class Program
    {
        static void Main(string[] args)
        {
            // DEKLARATION+DEFINITION ******************************************************************************************************************
            // Deklaration und Definition einer Liste (am Beispiel einer Integer-Liste)
            // Deklaration: Ich vergebe einen Namen
            // Definition: Ich teile Eigenschaften mit - hier: Der Typ aller abgespeicherten Listen-Elemente, 
            // (NICHT die Länge der Liste)
            List<int> integerListe = new List<int>();


            // HINZUFÜGEN *******************************************************************************************************************************
            // Hinzufügen eines Elementes an diese Liste (das Element wird "hintendran" gehangen)
            integerListe.Add(11);

            // Ausgabe aller (bisher) in der Liste befindlichen Elemente
            Console.WriteLine("Bisheriger Inhalt der Integer-Liste:");
            foreach (int element in integerListe)
                Console.Write(element + " ");

            // Hinzufügen eines weiteren Elementes an diese Liste 
            integerListe.Add(22);

            // Ausgabe aller (bisher) in der Liste befindlichen Elemente (das neue kommt wirlich ans Ende)
            Console.WriteLine("\n\nBisheriger Inhalt der Integer-Liste:");
            foreach (int element in integerListe)
                Console.Write(element + " ");

            // und noch ein drittes Element
            integerListe.Add(5);

            // Ausgabe aller (bisher) in der Liste befindlichen Elemente 
            Console.WriteLine("\n\nBisheriger Inhalt der Integer-Liste:");
            foreach (int element in integerListe)
                Console.Write(element + " ");

            // und noch ein viertes Element (bewußt der selbe Wert, wie beim 2. Element)
            integerListe.Add(22);

            // Ausgabe aller (bisher) in der Liste befindlichen Elemente 
            Console.WriteLine("\n\nBisheriger Inhalt der Integer-Liste:");
            foreach (int element in integerListe)
                Console.Write(element + " ");

            // ENTFERNEN *******************************************************************************************************************************
            // Das Entfernen von Elementen geschieht (üblicherweise) über dessen Wert, 
            // kann aber auch über die position geschehen
            integerListe.Remove(22);
            // Bemerkungen: a) Remove löscht nur den ersten Treffer 
            // (hier also die erste "22" ("von links") die er findet)
            //              b) Gibt den Rückwert "true" FALLS er einen Treffer fand, SONST "false"   

            // Ausgabe aller (bisher) in der Liste befindlichen Elemente 
            Console.WriteLine("\n\nBisheriger Inhalt der Integer-Liste:");
            foreach (int element in integerListe)
                Console.Write(element + " ");

            // RemoveAt: Das Löschen bzgl einer bestimmten Position:
            integerListe.RemoveAt(0);


            // Hier wird das allererste Feld (Index=0) gelöscht 
            // (erinnert an eine Warteschlange: "Vorne" verschwinden Kunden und "hinten" kommen neue dazu)
            // Ausgabe aller (bisher) in der Liste befindlichen Elemente 

            // Kontrollausgabe
            Console.WriteLine("\n\nBisheriger Inhalt der Integer-Liste:");
            foreach (int element in integerListe)
                Console.Write(element + " ");


            // Hinweis: (Beim Löschen von Positionen die nicht existieren)
            /*integerListe.RemoveAt(100);
            // Kontrollausgabe
            Console.WriteLine("\n\nBisheriger Inhalt der Integer-Liste:");
            foreach (int element in integerListe)
                Console.Write(element + " ");
            // ACHTUNG! zu große Indices (oder negative) führen zum Programmabbruch!
            /**/

            // Index finden *************************************************************************************************************************
            // Beispiel: Es soll ein Wert gesucht werden, der mehrmals vorkommt (hier 22), 
            // aber der als zweiter erscheinende soll gelöscht werden
            // Lösung: Man könnte zwar mit IndexOf() arbeiten, würde dann aber nur den ersten Treffer finden, 
            // daher durchläuft man die Liste mit einer eigenen foreach-Schleife, 
            // um den gesuchten Index zu finden:

            // Vorbemerkung:
            // Um diese Aufgabe (bzw. deren Lösung) vorführen zu können, 
            // ergänzen wir den aktuellen Inhalt unserer Liste (5 22) durch 7 und 22
            integerListe.Add(7);
            integerListe.Add(22);
            // Kontrollausgabe
            Console.WriteLine("\n\nBisheriger Inhalt der Integer-Liste:");
            foreach (int element in integerListe)
                Console.Write(element + " ");

            // Wir benötigen 2 Zähler:
            int index = 0; // Dieser Zähler zählt jeweils pro Schleifen-Durchlauf die aktuelle Position in der Liste
            int treffer = 0; // Dieser Zähler zählt, wie oft die 22 bereits gefunden wurde
            foreach (int e in integerListe)
            {
                if (e == 22)
                {
                    treffer++;
                    if (treffer == 2)
                    {
                        break;
                    }
                }
                index++;
            }
            integerListe.RemoveAt(index);
            // für den in der obigen foreach-Schleife ermittelten Index löschen wir das entsprechende Feld

            // Kontrollausgabe
            Console.WriteLine("\n\nBisheriger Inhalt der Integer-Liste:");
            foreach (int element in integerListe)
                Console.Write(element + " ");



            // Frage nach dem Vorkommen eines bestimmten Wertes in der Liste **********************************************************************
            // Wir werden hierzu die Contains()-methode verwenden, die einen Bool-Wert zurückliefert
            // Ist 22 ein Element der Integer-Liste?
            bool _22istDrin = integerListe.Contains(22);
            // Unterstrich vor 22, weil Variablen nicht mit Ziffern beginnen dürfen

            // Kontrollausgabe:
            Console.WriteLine("\n\nDer Inhalt von '_22istDrin' lautet: " + _22istDrin);

            // Ist100 ein Element der Integer-Liste?
            bool _100istDrin = integerListe.Contains(100);

            // Kontrollausgabe:
            Console.WriteLine("\nDer Inhalt von '_100istDrin' lautet: " + _100istDrin);


            // Beliebige Typen **********************************************************************************************************************0
            // Der Vollständigkeit halber sei noch erwähnt: auch andere Typen sind (natürlich) zulässig

            List<string> namensListe = new List<string>();
            namensListe.Add("Hans");
            // ...
            // Natürlich können auch Variablewerte an die Liste angehängt werden:
            string name = "Klaus";
            namensListe.Add(name);
            // Kontrollausgabe:
            Console.WriteLine("\nListe aller Namen:");
            foreach (string feld in namensListe) Console.Write(feld + " ");
            name = "Peter";
            namensListe.Add(name);
            // Kontrollausgabe:
            Console.WriteLine("\nListe aller Namen:");
            foreach (string feld in namensListe) Console.Write(feld + " ");
            // Bemerkung:
            // Wir haben gerade zweimal den Inhalt der String-Variable 'name' an der Liste angehangen.
            // DEN INHALT(!) (NICHT die Referenz auf die Variable name) => die Strings "Klaus" und "Peter" erschienen in der Liste

            // ... und natürlich kann es auch double-Listen, oder char-Listen, oder ... geben

            Console.ReadKey();
        }
    }
}