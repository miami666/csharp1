using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*

Schreiben Sie bitte ein C#-Programm, in dem 
a) ein 2-dimensionales Array (Dimensionen 2,3) namens "lexikon" eingeführt wird
b) in [0,x] (für alle x=0;1 oder 2) ein Begriff initialisiert wird
c) in [1,x] jeweils die Erläuterung des Begriffes abgespeichert wird
d) in einer Endlosschleife vom User pro Durchlauf ein Begriff abgefragt wird
e) die passende Erläuterung ausgegeben wird, oder eine Fehlermeldung, falls der Begriff nicht vorhanden

Beispiel:
lexikon[0,0]="Auto" / lexikon[1,0]="Motorisiertes Straßen-Fahrzeug mit 4 Rädern"
lexikon[0,1]="OOP" / lexikon[1,1]="Abkürzung für 'Objektorientierte Programmierung'"
lexikon[0,2]="Süßstoff" / lexikon[1,2]="Kalorienarmer Zuckerersatz"

Hinweis:
- die erste Dimension (2) zählt also die "Textarten" (Begriff oder Erläuterung)
- die zweite Dimension (3) zählt die Anzahl der abgespeicherten Begriffs-Erläuterungs-Paare
*/

namespace array_mehrdimensional_aufgabe_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] lex = new string[2, 3] { { "Apple", "Arsch", "Interface" }, { "hessisch Apfel", "dein gesicht" , "Fahndungsfoto von Interpol"} };

                Console.WriteLine("Bitte Begriff eingeben:");
              
                string wort;
              
                wort = Console.ReadLine();

                string result = String.Empty;
                for (int i = 0; i < lex.GetLength(0); i++) 
                {
                    if (lex[0, i] == wort)
                    {
                        result = lex[1, i];
                        break;  
                    }

                }
                Console.WriteLine(result);
            Console.ReadKey();
            
        }
    }
}
