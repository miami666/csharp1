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

namespace _2darr_aufgabe_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                string[,] lexArray = new string[2, 3]
           {
                {"Apple","Bit","Interface" },
                {"hessisch für Apfel","Biersorte","Interpol Fahndungsfoto" }
           };


                int index;
                string suchwort = Console.ReadLine().ToLower();
                string beschreibung;
                
                for (int i = 0; i <= lexArray.GetLength(0); i++)
                {
                    if (lexArray[0, i].ToLower() == suchwort)
                    {
                        index = i;
                        beschreibung = lexArray[1, index];
                        Console.WriteLine(suchwort + " " + beschreibung);
                     
                        break;
                      
                       
                    }
                 
                }
                 
            }
        }
    }
}
