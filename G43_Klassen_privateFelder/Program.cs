using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Abkapselung

    Wir hatten zuletzt ja mit der Klassenbildung das "Fundament" der OOP kennen gelernt 
    und können nun zu den angesprochenen "Säulen" übergehen, 
    und hier im ersten Durchlauf die der Säule der "Abkapselung"(von Daten gegenüber der Außenwelt) betrachten.
    Man spricht dann anschaulich auch vom "Geheimnis-Prinzip", weil Informationen, 
    die in einem Objekt abgespeichert sind, nur dem Objekt bekannt sind, 
    und weder von außen gelesen und erst Recht nicht verändert werden können.

    Diese Abkapselung ist aber natürlich "ein Ideal" und kann nicht immer vollständig durchgehalten werden. 
    Dennoch sollte das Bestreben herrschen, die Abkapselung so intensiv wie möglich (und sinnvoll) zu praktizieren.

*/

namespace G43_Klassen_privateFelder
{
    class Immobilie
    {
        //vollstängig abgekapselte oder vollständig öffentliche Variablen(Felder,Attribute)
        // private
        int counter = 0; // wenn nichts angegeben wird automatisch private
        // private Felder beginnen mit einem kleinem Buchstaben, public Felder mit einem grossen
        private double gewinnProzent=10;
        public int Oeffentlich;
        //teilweises oder vollständiges Aufheben des Schutzgrades
        //Beispiel am privaten Feld Name
        private string name;
        //vollständige rücknahme des schutzgrades mit hilfe von get und set properties
        public string Name //Konvention: property hat identischen Namen zur privaten Variable aber beginnt mit einem grossen Buchstaben
        {
            get
            {
                return name;
            }//allgemeine Syntax: get {return name der privaten Variable;} =>name kann nun ausgelesen werden
            set
            {
                name = value;
            }
        }//allgemeine Syntax set {name der privaten variable=value;} name kann nun eine zuweisung erhalten
             // Hinweis: name ist privat => von außen haben wir also keinen Zugriff ...
             //          ... ABER: Innerhalb der Klasse kennen sich die Member gegenseitig, ...
             //          ... die Property Name kann also mit dem Feld name kommunizieren

            // Das vollständige Aufheben eines Zugriffsmodus ist allerdings oft nicht sehr sinnvoll. 
            // Der Nutzen von Gettern und Settern besteht vielmehr darin, 
            // den Zugriff zu "regulieren" (nur unter bestimmten Bedingungen, oder nur get, kein set ..)

            // Beispiel für eine bedingte Setzung:
            // (die folgende private Variable soll GENAU 1-mal gestzt werden können, aber beliebig oft gelesen)
        private int baujahr;
        public int Baujahr
        {
            get { return baujahr; }
            set
            {
                if (counter == 0) baujahr = value;
                counter = 1;
            }
        }
        //Beispiel ein wert soll gesetzt werden soll aber nicht abfragbar sein
        private double einkaufspreis;
        public double Einkaufspreis
        {
            //kein get
            set
            {
                einkaufspreis = value;
            }
        }
        //beispiel: keine setzung aber abfrage von privater Variable die Ihren Wert mit Hilfe einer Berechnung innerhalb einer Property von privaten Feldern erhält

        //private double verkaufspreis;
        public double Verkaufspreis
        {
            //kein set=>private Variable überflüssig
            get { return einkaufspreis * (100 + gewinnProzent) / 100; }
        }
        // interessant für oop-sprachen die keine properties besitzen: Man kann diese Funktionalität auch durch eigene methoden simulieren-die allgemeine Konvention ist dann, dass diese Methoden mit der Bezeichnung get bzw. set bbeiginnen:

        private int privatesFeld;
        //vorbemerkungen zur get methode
        //a) sie muss public sein ( wie eine property, denn wir wollen sie ja von aussen verwenden
        //b) sie muss einen rückgabewert liefern dessen Typ des Typs des privaten Feldes entspricht

        public int GetprivatesFeld()
        {
            return privatesFeld;
        }

        //vorbemerkungen zur set methode
        //a) benötigt dementsprechende Übergabewerte
        //b) muss public sein
        //c) benötigt keinen Rückgabewert

        public void SetprivatesFeld(int x)
        {
            privatesFeld = x;
            

        }


        }
    //ende class Immobilie
    class Program
    {
        static void Main(string[] args)
        {
            //auf Felder der Klasse Immobilie zugreifen:
            //Erzeugen eines Objektes vom Typ Immobilie
            Immobilie haus = new Immobilie();
            haus.Oeffentlich = 22;
            Console.WriteLine("Beispielausgabe einer öffentlichen Variable"+haus.Oeffentlich);
            haus.Name = "Fernsehturm";
            Console.WriteLine("Haus Name"+haus.Name);
            haus.Baujahr = 1984;
            Console.WriteLine("Baujahr "+haus.Baujahr);
            //setzung der geheimen nicht auslesbaren Variable einkaufspreis
            haus.Einkaufspreis = 1000000;
            //auslesen des nicht setzbaren verkaufspreises
            Console.WriteLine("Verkaufspreis: "+haus.Verkaufspreis);

            //Verwendung von eigenen Property Methoden
            haus.SetprivatesFeld(101);
            Console.WriteLine("Kontrollausgabe: "+haus.GetprivatesFeld());
            Console.ReadKey();
        }
    }
}
