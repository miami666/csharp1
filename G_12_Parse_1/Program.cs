/*
    Parse / TryParse
    
    Vorbemerkung:
    Wir hatten zuletzt die Klasse Convert, bzw. deren Methoden ToInt, ToString, kennengelernt, 
    um Variablen von einem bestimmten Typ in einen anderen Typ zu übersetzen.
    Mit der Methode Parse werden wir nun sehr ähnliche Ziele verfolgen und tatsächlich unterscheidet sich
    die Funktionalität von Parse und Convert.To(...) nur wenig.
    Hinzu kommt, dass wir mit TryParse eine Methode geschenkt bekommen, die uns erlaubt, die Typumwandelung
    "auszuprobieren" (falls es bei der Typumwandelung zu einem Fehler kommen würde, stürzt das Programm nun
    nicht mehr ab, sondern wir können diesen Fehler abfangen)
    Dies alles hinterlässt den Eindruck, dass man auf Convert.(...) gänzlich verzichten könnte. 
    Tatsächlich aber werden wir in den folgenden Tagen noch Beispiele kennen lernen, 
    in denen uns Convert gute Dienste leisten wird.

    Für das Übersetzen eines Eingabe-Strings in einen Integer, Double, 
    wird sich aber im Folgenden eher TryParse anbieten

    Einziger (kleiner) Nachteil wird sein, dass wir bei der Verwendung von TryParse einen kleinen Vorgriff 
    unternehmen müssen, da wir es bei dieser Methode mit einer CallByReference-Funktion zu tun haben, 
    wenngleich wir über dieses Thema erst demnächst sprechen werden.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_12_Parse_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Der unterschied bei der Funktionalität von Convert.ToInt und int.Parse()
            string s = null;    // null im Sinne von "definiert leer"

            // Bei ANSI C war eine leer Variable stets mit einem Zufallswert gefüllt -
            // wenn wir sie mit null füllten, dann wurde von uns NICHT behauptet, dass wir ihren Inhalt kennen, 
            // sondern explizit mitgeteilt: "Variable ist leer"
            // (Weder das System noch wir als Programmierer können ja bei einem zufälligen Inhalt wissen, 
            // ob dieser zufällig,  oder bewusst gesetzt wurde)

            // 1.) Wir wollen nun diesen String mit Hilfe Convert.ToInt zu einem Integer Konvertieren:
            int i = Convert.ToInt32(s);
            Console.WriteLine("Kontrollausgabe: Der String s=null wurde mit Hilfe von Convert.ToInt32(s) konvertiert und in i abgespeicht => i=" + i);

            // 2.) Wir wollen nun den selben Übersetzungsprozess mit Parse stattfinden lassen:
            //    i = int.Parse(s);
            //    Console.WriteLine("Kontrollausgabe: Der String s=null wurde mit Hilfe von int.Parse(s) konvertiert und in i abgespeicht => i=" + i);

            // BEMERKUNG:
            // Im Gegensatz zu Convert.ToInt wird hier eine Fehlermeldung ausgegeben 
            // (und das Programm stürzt ab => ArgumentNullException)
            // Dieses Verhalten gefällt uns aber, denn tatsächlich wollen wir ja nicht, 
            // dass ein String der den Wert null besitzt "versehentlich"
            // in einen Integer umgewandelt wird, der nun den Wert 0 hat.

            // **************************************************************************************************************************************
            // Wir wollen nun aber die Fehlermeldungen von Parse "abfangen" können. 
            // Zu diesem zweck wollen wir zunächst testen, ob der Parse-Vorgang
            // fehlerfrei funktioniert und für den Fall, dass dem nicht so war, 
            // auf diesen Fehler programmtechnisch reagieren können (Beispiele wären:
            // User um eine erneute Eingabe bitten, oder eine selbsterschaffene Fehlermeldung ...)

            // Lösung des Problems ist die Methode TryParse():
            // HINWEIS
            // Die Methode TryParse übernimmt zwei Aufgaben:
            // 1.) Sie konvertiert (sofern möglich) per CallByReference die Variable deren Inhalt geparsed werden soll
            // 2.) Sie liefert darüberhinaus einen boolschen Rückgabewert: True, falls das Parsen klappte, False, falls nicht

            // BEMERKUNG
            // Die ganze Thematik sollte nicht mit der aus ANSI C bekannten "impliziten Konvertierung" verwechselt werden. 
            // Diese Implizite Konvertierung war in der Lage (ohne explizite Mitteilung seitens des Programmierers) 
            // ein Characterzeichen in seinen (Integer)-ASCII-Wert zu überstzen
            // (oder umgekehrt von Integer zu Zeichen) 
            // Beispiel: 
            // IMPLIZIT: char zeichen='A'; printf("%d",zeichen); => Ausgabe: 65
            // EXPLIZIT: char zeichen='A'; printf("%d",(int)zeichen); => Ausgabe: 65

            // Zur Vollständigkeit noch der Hinweis:
            // char zeichen='A'; printf("%c",zeichen); => Ausgabe: A

            // Es könnte nun aber irritieren, dass ein String ja ganz viele Zeichen besitzt - 
            // jedes Zeichen hat einen ASCII-Wert und die Frage wäre
            // zu welchem wir konvertieren sollten, das ist aber hier gar nicht gemeint:

            // GEMEINT IST HIER:
            // Der String "abc" kann NICHT in einen Integer geparsed werden, 
            // aber der String "123" kan in den Integer 123 übersetzt werden.

            // BEISPIEL
            int.TryParse(s, out i);

            // out steht für (eine Variante von) CallByReference, 
            // das werden wir uns später genauer anschauen
            // Im Moment reicht uns das Wissen, 
            // dass bereits durch den Aufruf dieser Funktion die "Variable hinter out" gefüllt wurde
            Console.WriteLine("Kontrollausgabe: Der String s=null wurde mit Hilfe von int.TryParse(s, out i) konvertiert und in i abgespeicht => i=" + i);

            // Man könnte nun den Eindruck gewinnen, dass wir uns im Kreise drehen, denn wir starteten mit Convert, 
            // waren unglücklich, dass dort null in 0 konvertiert wurde, verwendeten anschließlend Parse, 
            // bei dem es tatsächlich zur Fehlermeldung kam, da null eben nicht sinnvoll
            // zu einer ganzen Zahl umgewandelt werden kann, störten uns aber daran, 
            // dass das Programm abstürzte, führten daraufhin TryParse ein und stehen
            // nun "allen Ernstes" wieder am Anfang, denn TryParse lässt null zu 0 werden ...

            // Lösung ist aber der (bisher noch ungenutzte, boolsche) Rückgabewert von TryParse:
            bool parseHatGeklappt = int.TryParse(s, out i);
            if (parseHatGeklappt)
                Console.WriteLine("Das Parsen von \"" + s + "\" hat geklappt! i=" + i
                    + " Die boolsche Variable 'parseHatGeklappt' hat den Wert: " + parseHatGeklappt);
            else
                Console.WriteLine("Das Parsen von \"" + s + "\" hat NICHT geklappt! i=" + i
                    + " Die boolsche Variable 'parseHatGeklappt' hat den Wert: " + parseHatGeklappt);

            // Testen des obigen Codes an einem neuen String:
            s = "abc";
            parseHatGeklappt = int.TryParse(s, out i);
            if (parseHatGeklappt)
                Console.WriteLine("Das Parsen von \"" + s + "\" hat geklappt! i=" + i
                    + " Die boolsche Variable 'parseHatGeklappt' hat den Wert: " + parseHatGeklappt);
            else
                Console.WriteLine("Das Parsen von \"" + s + "\" hat NICHT geklappt! i=" + i
                    + " Die boolsche Variable 'parseHatGeklappt' hat den Wert: " + parseHatGeklappt);

            // Erneutes Testen des obigen Codes an einem neuen String:
            s = "123";
            parseHatGeklappt = int.TryParse(s, out i);
            if (parseHatGeklappt)
                Console.WriteLine("Das Parsen von \"" + s + "\" hat geklappt! i=" + i
                    + " Die boolsche Variable 'parseHatGeklappt' hat den Wert: " + parseHatGeklappt);
            else
                Console.WriteLine("Das Parsen von \"" + s + "\" hat NICHT geklappt! i=" + i
                    + " Die boolsche Variable 'parseHatGeklappt' hat den Wert: " + parseHatGeklappt);

            Console.WriteLine("\n\n\n\nDas Drücken einer beliebigen Taste beendet das Programm");
            Console.ReadKey();
        }
    }
}

