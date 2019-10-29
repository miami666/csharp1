using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Führen Sie im Main bitte zunächst das folgende 3-Dimensionale Array ein: 

        string[,,] dim3 = new string[2, 3, 4]       {
                                                         {
                                                            {"Tabelle","Datenbank","Spalte","Zwang"},
                                                            {"zuweisen","setzen","erhalten","Liste"},
                                                            { "Puffer","Projekt","Organisation","Interessengruppe"}
                                                         },
                                                         {
                                                            {"table","database","column","constraint"},
                                                            {"assign","set","get","list"},
                                                            {"buffer","project","organization","stakeholder"}
                                                         }
                                                      };
     HINWEISE:
     - Die erste Dimension zählt die Sprache (0=Deutsch, 1=Englisch)
     - Die Zweite Dimension zählt das Fach (0=SQL, 1=C#, 2=PM)
     - Die Dritte Dimension zählt die Wortnummern [0 bis 3] (Für jede Sprache und jedes Fach jeweils 4 Wörter)  

     Schreiben Sie bitte das folgende C#-Programm, um den Umgang mit diesem 3-dimensionalen Array zu testen:
     - Das Programm besteht aus einer Endlos-Schleife, in der pro Durchlauf ...
       + Die Sprache abgefragt wird (Deutsch=1 / Englisch=2) - Wiederholung der Abfrage bei Fehleingabe
       + Das Fach abgefragt wird (SQL=1 / C#=2 / PM=3) - Wiederholung der Abfrage bei Fehleingabe
       + Die Wortnummer abgefragt wird (ein Wert zwischen 1 und 4) - Wiederholung der Abfrage bei Fehleingabe
       + das gewählte Wort, des gewählten Fachs in der gewählten Sprache auf der Konsole ausgegeben wird

       Beispiel:
       Bei der Auswahl: 1 1 1 (Deutsch, SQL, 1.Wort) kommt es zur Ausgabe von dim3[0,0,0]="Tabelle"

 */
namespace _3darray_aufgabe_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,,] dim3 = new string[2, 3, 4]
            {
                {
                    {"Tabelle","Datenbank","Spalte","Zwang"},
                    {"zuweisen","setzen","erhalten","Liste"},
                    {"Puffer","Projekt","Organisation","Interessengruppe"}
                },
                {
                     {"table","database","column","constraint"},
                     {"assign","set","get","list"},
                     {"buffer","project","organization","stakeholder"}
                }
            };
            int sprachwahl = 0;
            int fach = 0;
            int wort = 0;
            bool inputsprache = false;
            bool inputfach = false;
            bool inputwort = false;
       
            // Console.Write(dim3.GetLength(0));
            // Console.Write(dim3.GetLength(1));
            // Console.Write(dim3.GetLength(2));

            do
            {
                Console.Clear();
                Console.WriteLine("(1) Deutsch oder (2) Englisch");
                inputsprache = Int32.TryParse(Console.ReadLine(), out sprachwahl);
                if (inputsprache != true || sprachwahl < 1 || sprachwahl > 2)
                {
                    inputsprache = false;
                    Console.WriteLine("Ungültig!\nDrücken Sie eine beliebige Taste, um erneut einzugeben.");
                    Console.ReadKey();
                    continue;
                }
            } while (inputsprache!=true);
            do
            {
                Console.Clear();
                Console.WriteLine("(1)SQL (2)C# (3)PM ");
                inputfach = Int32.TryParse(Console.ReadLine(), out fach);
                if(inputfach != true || fach < 1 || fach > 3)
                {
                    inputfach = false;
                    Console.WriteLine("Ungültig!\nDrücken Sie eine beliebige Taste, um erneut einzugeben.");
                    Console.ReadKey();
                    continue;
                }
            } while (inputfach != true);
            do
            {
                Console.Clear();
                Console.WriteLine("1 2 3 oder 4?");
                inputwort = Int32.TryParse(Console.ReadLine(), out wort);
                if (inputwort != true || wort < 1 || fach > 4)
                {
                    inputwort = false;
                    Console.WriteLine("Ungültig!\nDrücken Sie eine beliebige Taste, um erneut einzugeben.");
                    Console.ReadKey();
                    continue;
                }
            } while (inputwort != true);       
            Console.WriteLine("DIM3[{0},{1},{2}] = {3}", sprachwahl - 1, fach - 1, wort - 1, dim3[sprachwahl - 1, fach - 1, wort - 1]);
            Console.ReadKey();
        }
    }
}

