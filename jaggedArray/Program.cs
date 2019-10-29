/*
  Jagged dim3ay (jagged = "gezackt")

  Erläuterung des Begriffs:
  Angenommen wir haben ein 2-dim dim3ay, also ein Array, das aus mehreren Arrays besteht,
  dann könnte folgender Fall vorliegen
  1. Array {1,2,3,4,5}
  2. Array {1,2,3}
  3. Array {1,2,3,4,5,6,7}
  h
  Motivation:
Mehrdimensionale Arrays "zwingen" uns bisher, diese rechteckige Form zu verwenden, 
betrachten wir aber das folgende Beispiel:
    Mehrere Städte -> in jeder mehrere Schulen -> in jeder mehrere Klassen -> in jeder mehrere Schüler
Dann ist eigentlich klar, dass nicht in jeder Stadt gleich viele Schulen vorkommen müssen, 
nicht jede Schule gleich viele Klassen besitzt
und natürlich auch nicht alle Klassen gleich groß sind ...

Zur Syntax:
Ein (mehrdimensionales) Jagged Array wird in der Form Typ[][][]...[][] notiert, 
also so, wie wir "klassische" Arrays in ANSI C schrieben
=> ACHTUNG: Verwechslungsgefahr

*/
/* 

    Ein Ladenbesitzer hat in 3 Städten Filialen

          

  Aufgabe:
  Schreiben Sie bitte ein C#-Programm, in dem ein entsprechendes jagged Array eingeführt wird.
  Füllen Sie bitte mittels verschachtelter Schleifen alle Felder mit dem Wert -1
  Geben Sie bitte pro Füllvorgang an, welche Mitarbeiternummer, Ladennummer und Stadtnummer aktuell befüllt wird 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              In Stadt 0 gibt es 2 Läden 
             In Stadt 1 gibt es 4 Läden
             In Stadt 2 gibt es 3 Läden

                      In Stadt 0, Laden 0 arbeiten 5 Mitarbeiter
                      In Stadt 0, Laden 1 arbeiten 2 Mitarbeiter

                      In Stadt 1, Laden 0 arbeiten 3 Mitarbeiter
                      In Stadt 1, Laden 1 arbeiten 2 Mitarbeiter
                      In Stadt 1, Laden 2 arbeiten 1 Mitarbeiter
                      In Stadt 1, Laden 3 arbeiten 4 Mitarbeiter

                      In Stadt 2, Laden 0 arbeiten 2 Mitarbeiter
                      In Stadt 2, Laden 1 arbeiten 2 Mitarbeiter
                      In Stadt 2, Laden 2 arbeiten 3 Mitarbeiter*/
            string[][][] dim3 = new string[3][][];

          
            dim3[0] = new string[2][];

            dim3[1] = new string[4][];
            dim3[2] = new string[3][];

            dim3[0][0] = new string[5];
       
            dim3[0][1] = new string[2];
     
           

      
            dim3[1][0] = new string[3];
    
            dim3[1][1] = new string[2];
      
            dim3[1][2] = new string[1];
         
            dim3[1][3] = new string[4];

            dim3[2][0] = new string[2];

            dim3[2][1] = new string[2];

            dim3[2][2] = new string[3];


            for (int i = 0; i < dim3.Length; i++)
            {
                for (int j = 0; j < dim3[i].Length; j++)
                {
                    for (int k = 0; k < dim3[i][j].Length; k++)
                    {
                        dim3[i][j][k] = "immer noch unbekannt";
                    }
                }
            }
          

            Console.ReadKey();
        }
    }
}

