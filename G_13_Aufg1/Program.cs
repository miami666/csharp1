using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// G_13_Aufg1
/*
 Schreiben Sie bitte ein C#-Programm, in dem innerhalb einer Endlosschleife ...
 - eine ganze Zahl 'z' abgefragt wird (Eingabe dezimal - Wiederholung bis Eingabe korrekt)
 - eine ganze Zahl 'b' abgefragt wird (Eingabe dezimal - Wiederholung bis Eingabe korrekt)
 - eine Funktion aufruft, die z in einen String konvertiert (Der String soll z als Zahl zur Basis b darstellen)
   + Name der Funktion: 'DezInBasis'
   + Übergabewerte: z und b
   + Rückgabewert: der oben angesprochene String
 - der nächste Schleifendurchlauf nach Tastendruck startet

  Erläuterung an 2 Beispielen:
  - Der Aufruf von DezInBasis(8,2) ergibt als Rückgabewert den String "1000", denn 1000 ist die binäre Darstellung von 8
  - Der Aufruf von DezInBasis(172,16) ergibt als Rückgabewert den String "ac", denn ac ist die hexadezimale Darstellung von 172

 2 Wichtige Hinweise:
 a) C# unterstützt bei der Syntax Convert.ToString(zahl,basis) NICHT JEDE Basis 
    => ermitteln Sie bitte die zulässigen Basen und lassen Sie die Funktion nur für zulässige Basen aufrufen
 b) C# unterstützt bei der Syntax Convert.ToString(zahl,basis) NICHT die Umwandlung von negativen Zahlen
    => ergänzen Sie bitte die Funktion 'DezInBasis' dahingehend, dass diese auch für negative Zahlen sinnvolle Ergebnisse liefert
 */

namespace G_13_Aufg1
{
    class Program
    {
        static string DezInBasis(int zahl, int basis)
        {
            //if (zahl >= 0) return Convert.ToString(zahl, basis);
            //return "-" + Convert.ToString(-zahl, basis);
            return Convert.ToString(zahl, basis);

        }

        static void Main(string[] args)
        {
            int zahl, basis;
            bool running = true;
            while (running)
            {
                do
                {
                    Console.Clear();
                    Console.Write("Geben Sie bitte eine Zahl (in dezimaler Darstellung) ein: ");
                }
                while (!int.TryParse(Console.ReadLine(), out zahl));


                do
                {
                    Console.Clear();
                    Console.WriteLine("Geben Sie bitte eine Zahl (in dezimaler Darstellung) ein: " + zahl);
                    Console.Write("Geben Sie bitte (erneut in dezimaler Darstellung) die Basis ein,"
                               + "zu der Ihre Eingabe umgewandelt werden soll: ");
                }
                while (!int.TryParse(Console.ReadLine(), out basis));

                if (basis != 2 && basis != 8 && basis != 10 && basis != 16)
                    Console.WriteLine("Die Basis " + basis + " ist nicht zulässig!");
                else
                    Console.WriteLine("Die Darstellung von " + zahl + " zur Basis " + basis + " lautet: " + DezInBasis(zahl, basis));

                Console.Write("\n\n\n\nbeliebige Taste für eine neue Eingabe\nEnter zum Beenden");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    running = false;
                }
            }
        }

    }
}
