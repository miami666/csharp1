/*
  Jagged Array (jagged = "gezackt")

  Erläuterung des Begriffs:
  Angenommen wir haben ein 2-dim Array, also ein Array, das aus mehreren Arrays besteht,
  dann könnte folgender Fall vorliegen
  1. Array {1,2,3,4,5}
  2. Array {1,2,3}
  3. Array {1,2,3,4,5,6,7}

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

Weitere Informationen zu Jagged Arrays im Vergleich mit Mehrdimensionalen Arrays finden Sie hier:
 * https://stackoverflow.com/questions/597720/what-are-the-differences-between-a-multidimensional-array-and-an-array-of-arrays
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_33_JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2-dim Beispiel
            // 3 Klassen: Klasse 1 hat 20 Schüler, Klasse 2 hat 15 Schüler, Klasse 3 hat 25 Schüler
            // (für jeden Schüler soll der Name gespeichert werden)
            string[][] schuelerArray = new string[3][];
            // der 2. Eintrag fehlt, denn wir wissen zwar wieviele Klassen (3), 
            // aber die Anzahl der Schüler pro Klasse ist unterschiedlich
            // => das erzeugte Jagged Array ist also noch nicht vollkommen geschlossen
            // wir müssen durch die einzelen Klassen gehen
            
            // Klasse 0
            schuelerArray[0] = new string[20];
            // Klasse 1
            schuelerArray[1] = new string[15];
            // Klasse 2
            schuelerArray[2] = new string[25];

            // Füllen des schuelerArrays mit Hilfe einer verschachtelten Schleife
            // die Äußere zählt die Klassen, die Innere die Schüler

            for (int i=0; i<schuelerArray.Length; i++)
            {
                for (int j=0; j < schuelerArray[i].Length; j++)
                {
                    schuelerArray[i][j] = "unbekannt";
                }
            }

            // Ausgabe
            int tmp = 0;
            for (int i = 0; i < schuelerArray.Length; i++)
            {
                Console.WriteLine("\nKlasse " + i + ":");
                for (int j = 0; j < schuelerArray[i].Length; j++)
                {
                    Console.Write("S " + j + ":" + schuelerArray[i][j] + "\t");
                    tmp = j + 1;
                    if (tmp % 5 == 0)
                        Console.Write("\n");
                }
            }


            // Beispiel: 3-Dim JaggedArray
            // 2 Schulen, mit jeweils mehreren Klassen und je verschiedenen Schülern
            // Schule 0
            // Klasse 0: 10 Schüler
            // Klasse 1: 20 Schüler
            // Klasse 2: 12 Schüler
            // Schule 1
            // Klasse 0: 11 Schüler
            // Klasse 1: 21 Schüler
            // Klasse 2: 13 Schüler
            // Klasse 3: 23 Schüler
            // auch hier sollen die Schülernamen gespeichert werden

            // "Das Array verwaltet 2 Schulen"
            string[][][] dim3 = new string[2][][];

            //Schule 0 hat 3 Klassen
            dim3[0] = new string[3][];

            //Schule 1 hat 4 Klassen
            dim3[1] = new string[4][];

            // Schule 0, Klasse 0 hat 10 Schüler
            dim3[0][0] = new string[10];
            // Schule 0, Klasse 1 hat 20 Schüler
            dim3[0][1] = new string[20];
            // Schule 0, Klasse 2 hat 12 Schüler
            dim3[0][2] = new string[12];

            // Schule 1, Klasse 0 hat 11 Schüler
            dim3[1][0] = new string[11];
            // Schule 1, Klasse 1 hat 21 Schüler
            dim3[1][1] = new string[21];
            // Schule 1, Klasse 2 hat 13 Schüler
            dim3[1][2] = new string[13];
            // Schule 1, Klasse 3 hat 23 Schüler
            dim3[1][3] = new string[23];

            // Füllung von dim3
            for (int i = 0; i < dim3.Length; i++)
            {
                for (int j = 0; j < dim3[i].Length; j++)
                {
                    for (int k=0; k<dim3[i][j].Length; k++)
                    {
                        dim3[i][j][k] = "immer noch unbekannt";
                    }
                }
            }

            dim3[1][2][7] = "Anton Müller";
            // Beispiel für das Auslesen eines konkreten Schülernamens
            Console.WriteLine("In der Schule 1, Klasse 2 hat der Schüler 7 den Namen:" + dim3[1][2][7]);

            Console.ReadKey();

        }
    }
}
