/*
 Schreiben Sie bitte ein C#-Programm, in dem ...
 - zunächst 3 Strings (vorname,nachname,vorPunktNach) eingeführt werden
   + nachname ist mit "Meyer" initialisiert
   + vorname ist zu Beginn mit "unbekannt" initialisiert
   + vorPunktNach ist zu Beginn NICHT initialisiert
 - anschließend die Funktion 'fragUndFüll' aufgerufen wird
   + Die Funktion erhält als Übergabewerte den Value nachname und die Referenzen vorname und vorPunktNach
   + Die Funktion fragt vom User den Vornamen ab
   + Die Usereingabe soll die Variable vorname überschreiben
   + Ferner soll in vorPunktNach der erste Buchstaben des Vornamens, gefolgt von einem Punkt und dem Nachnamen abgespeichert werden
 - zuletzt eine Kontrollausgabe alle drei Variablen auf der Konsole ausgibt
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_21_Aufg1
{
    class Program
    {
        static void fragUndFüll(string nach, ref string vor, out string vorPunktNach)
        {
            Console.Write("Geben Sie bitte den Vornamen von {0} an: ", nach);
            vor = Console.ReadLine();
            vorPunktNach = vor[0] + "." + nach;
        }

        static void Main(string[] args)
        {
            string nachname = "Meyer", vorname = "unbekannt", vorPunktNach;

            fragUndFüll(nachname, ref vorname, out vorPunktNach);
            Console.WriteLine("{0} heißt mit Vornamen {1} und wird abgekürzt in der Form {2} notiert", nachname, vorname, vorPunktNach);

            Console.Write("\n\n\n\nEin beliebiger Tastendruck beendet das Programm ... ");
            Console.ReadKey();
        }
    }
}