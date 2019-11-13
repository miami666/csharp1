using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Vorbemerkung:
        Wiederverwenden Sie bitte die Klasse "Auswahl" 
        (insgesamt wird das folgende Programm 5 Auswahl-Menüs anbieten, daher lohnt sich das Einbinden dieser Klasse)


   
                    
    Im Main
        In einer Endlosschleife kann der User durch die folgenden Menüs navigieren:

            Hauptmenü
                "Neue Tabelle" (Wenn dies gewählt wird, wird eine neue Tabelle instanziiert -> danach zurück zum Hauptmenü)
                "Tabelle auswählen" (Wenn dies ausgewählt wird, werden alle Tabellennamen zur Auswahl ausgegeben -> danach weiter zu Mittelmenü)

            Mittelmenü
                "Tabellenname wählen/ändern" (Wenn dies gewählt wird, kann der Tabellenname eingegeben werden -> danach zurück zum Hauptmenü)
                "Tabelle anzeigen" (Wenn dies gewählt wird, erscheint der "CREATE TABLE ... -Code" -> danach zurück zum Hauptmenü)
                "Tabellenspalten"  (Wenn dies gewählt wird, geht es zum Untermenü)
                "Tabelle löschen"  (Wenn dies gewählt wird, wird die Tabelle gelöscht -> danach zurück zum Hauptmenü) 

            Untermenü
                "Neue Spalte" (Wenn dies gewählt wird, werden ...
                                 - Spaltenname, Typ und Constraint abgefragt
                                 - Ein Spalten-Objekt mit diesen Werten instanziiert
                                 - Die Spaltenliste (der gewählten Tabelle) ergänzt
                                 - Die Spalten-Namens-Liste (der gewählten Tabelle) ergänzt
                                 -> danach zurück zum Hauptmenü)
                "Spalte löschen" (Wenn dies gewählt wird, werden ...
                                  - alle Spaltennamen (der gewählten Tabelle) ausgegeben und eine Auswahl abgefragt
                                  - die gewählte Spalte aus der Liste aller Spalten (der gewählten Tabelle) gelöscht
                                  - der Name der gewählte Spalte aus der Liste aller Spalten-Namen (der gewählten Tabelle) gelöscht
                                  -> danach zurück zum Hauptmenü)
*/
 

namespace aggregation_aufgabe_2
{
    /*
      Führen Sie bitte die beiden folgenden Klassen ein:

        Klasse Spalte
            Member:
                3 öffentliche Felder vom Typ String (Name, Typ, Constraint)
                1 Konstruktor:
                    Übergabewerte: Name, Typ und Constraint
                    Funktion: Initialisiert alle Felder*/
 class Spalte
    {
        public string Name,Typ,Constraint;
        public Spalte(string n,string t,string c)
        {
            Name = n;
            Typ = t;
            Constraint = c;
        }


    }
class Tabelle
    {
        List<Spalte> alleSpalten = new List<Spalte>();
        List<string> alleSpaltennamen = new List<string>();
        string nameTabelle;
        public static List<Tabelle> tabellenliste = new List<Tabelle>();
        //public static List<TName>
    }

        /*Klasse Tabelle
            Member:
                2 öffentliche statische Listen
                    - Liste aller Tabellen
                    - Liste aller (automatisch oder vom User gesetzten) Tabellennamen [Liste für das entsprechende Menü, siehe Klasse "Auswahl"]
                3 private Felder
                    - Liste aller Spalten (des jeweiligen Objekts vom Typ Tabelle)
                    - Liste aller Spaltennamen [Liste für das entsprechende Menü, siehe Klasse "Auswahl"]
                    - Name der Tabelle
                5 öffentliche Methoden
                    a) Name: SetzeTabellenName
                       Übergabewerte: Integer x, String s
                       Funktion: Weist s dem Feld Name zu und hängt s an die Liste der Tabellennamen an
                       Rückgabewert: keiner
                    b) Name: TabellenAusgabe
                       Übergabewerte: keine
                       Funktion: FALLS Spalten vorhanden: Gibt den SQL-Code aus, mit dem die Tabelle (und aller ihrer Spalten) kreiert werden kann
                                 FALLS noch keine Spalten vorhanden: Ausgabe der entsprechenden Fehlermeldung
                       Rückgabewert: keiner  
                    c) Name: AddSpalte
                       Übergabewerte: 3 Strings: Name, Typ und Constraint
                       Funktion: Instanziert ein Objekt vom Typ Spalte
                                 Initialisiert dieses mit den Übergabewerten
                                 Hängt das instanzierte Spalten-Objekt an die Liste aller Spalten (des Tabellen-Objekts)
                                 Hängt den Namen des instanziierten Spalten-Objekts an die Liste aller Spaltennamen (des Tabellen-Objekts)
                       Rückgabewert: keiner  
                    d) Name: AuswahlSpalten
                       Übergabewerte: keine
                       Funktion: Gibt auf der Konsole alle (durchnummerierten) Spaltennamen aus und fragt vom User seine Auswahl ab
                       Rückgabewert: User-Eingabe 
                    e) Name: RemoveSpalte
                       Übergabewerte: Integer Spaltennummer
                       Funktion: Löscht die Spalte mit der übergebenen Spaltennummer 
                       Rückgabewert: keiner 
                Konstruktor:
                    Übergabewert: keine
                    Funktion: Fügt die neue Tabelle zur Liste aller Tabellen hinzu
                              Setzt den Namen der Tabelle auf den provisorischen Wert "Tabelle x" (x = aktuelle Anzahl aller Tabellen)  
                              Fügt den Namen zur Liste aller Tabellennamen
     */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
