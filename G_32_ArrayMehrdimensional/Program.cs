/*
Mehrdimensionale Arrays
***********************

    ERLÄUTERUNG ("Was bedeutet eigentlich (Mehr)-Dimensionalität")
    Unter einer Dimension versteht man die Abzählbarkeit von Objekten. 
    Mehrdimensionalität kann man sich am besten verdeutlichen,
    wenn man schrittweise von der 1-Dimensionalität zur 2-Dimensionalität, 
    3-Dimensionalität ... weiter schreitet.

    .) 0-Dimensionalität (es wird nicht gezählt)
        Eine einzige Variable
    a) 1-Dimensionalität
        Ein 1-dimensionales Array ist schlicht eine Ansammlung von durchnummerierten Variablen. 
        Da eine Dimension ja immer eine Abzählung meint, 
        wird also im 1-dimensionalen diese Abzählung auf die Variablen bezogen:
        Array[mit 3 Feldern] => Feld 0 / Feld 1 / Feld 2
    b)  2-Dimensionalität
        Wenn wir den Übergang von 1- zu 2-Dimensionalität betrachten, 
        dann beginnen wir (1-dimensionale) Arrays abzuzählen:
        Array[Anzahl der Arrays , Anzahl der Felder (pro Array)]  
        Array0(Feld 0 / Feld 1 / Feld 2...) Array1(Feld 0 / Feld 1 / Feld 2...) ...
    c)  3-Dimensionalität
        Damit ist das "Bauprinzip" dann auch schon verraten, 
        denn beim Übergang von 2- zu 3-dimensionalen Arrays zählen wir die Anzahl der 2-dim. Arrays
        Array[Anzahl der 2 dimensionalen Arrays , Anzahl der Arrays (pro 2-dimensionalem), Anzahl der Felder (pro Array)]

    BEMERKUNG (zur Syntax)
    In Ansi C haben wir mehrdimensinale Arrays in der Form notiert, dass wir die Anzahl der Dimension durch die Anzahl 
    der hintereinander notierten eckigen Klammern darstellten: 
    drei-dimensionales Array in C: arrayName[a][b][c]
    In C# werden wir dies innerhalb einer einzigen eckigen Klammer (aber durch Kommata getrennt) darstellen: 
    drei-dimensionales Array in C# arrayName[a,b,c]

    HINWEIS
    Auch in C# gibt es die Notation arrayName[][][]! 
    Dies bedeutet aber etwas anderes und wird von uns später betrachtet
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_32_ArrayMehrdimensional
{
    class Program
    {
        static void Main(string[] args)
        {
            // Einstieg am Bekannten: 1-dimensionales Array
            // Beispiel: Pauls Schulnoten in diesem Jahr ( wir behaupten, er hatte 4 Prüfungen)
            // wir betrachten hier nur ganzzahlige Noten

            int[] paulsSchulnoten = new int[4] { 4, 3, 2, 1 };
            //Beispielausgabe
            Console.WriteLine("Die 3. Note von Paul war: " + paulsSchulnoten[2]);

            // Übergang zur 2-Dimensionalität
            // Wir wollen weiterhin die Noten pro Jahr zählen (1. Dim.);
            // nun aber auch die Jahre (2. Dim.).
            // Wir nehmen die letzten 3 Jahre und haben weiterhin 4 Prüfungen pro Jahr.

            int[,] paulsSchulkarriere = new int[3, 4]   {
                                                        {3,4,5,6},
                                                        {2,1,4,3 },
                                                        {4,3,2,1 }
                                                        };
            //Beispielausgabe
            Console.WriteLine("Die 2. Note im 1. Jahr von Paul war: " + paulsSchulkarriere[0,1] );

            // Übergang zur 3-Dimensionalität
            // Wir wollen weiterhin die Noten pro Jahr zählen (1. Dim.) mit 4 Prüfungen pro Jahr.
            // nun aber auch die Jahre (2. Dim.).
            // Wir wollen dies auch für unterschiedliche Schüler erfassen (3. Dim.)
            // Beispiel: 2 Schüler, 3 Jahre, 4 Prüfungen
            int[,,] schulStatistik = new int[2, 3, 4]
                                        {
                                            {
                                                {3,4,5,6 },     // Schüler 1, Jahr 1, Noten 1 bis 4
                                                {2,1,5,4 },     // Schüler 1, Jahr 2, Noten 1 bis 4
                                                {4,3,2,1 }      // Schüler 1, Jahr 3, Noten 1 bis 4
                                            },
                                            {
                                                {1,2,3,4 },     // Schüler 2, Jahr 1, Noten 1 bis 4
                                                {5,6,5,4 },     // Schüler 2, Jahr 2, Noten 1 bis 4
                                                {1,3,5,2 }      // Schüler 2, Jahr 3, Noten 1 bis 4

                                            }
                                        };
            // Beispielausgabe
            Console.WriteLine("Schüler 1, Jahr 3, Prüfung 4: " + schulStatistik[0, 2, 3]);
            //Erinnerung: Arrays beginnen am Index 0 !

            // Length bei mehrdimensionalen Arrays
            int[,,,] dim4 = new int[2, 3, 4, 5];
            Console.WriteLine("\nint[,,,] dim4 = new int[2, 3, 4, 5]");
            Console.WriteLine("=> dim4.Length = " + dim4.Length + "(=2*3*4*5)");
            // GetLength(0) entspricht hier der 4. Dimension, Ausgabe: 2
            Console.WriteLine("=> dim4.GetLength(0) = " + dim4.GetLength(0));

            Console.WriteLine("=> dim4.GetLength(1) = " + dim4.GetLength(1));
            Console.WriteLine("=> dim4.GetLength(2) = " + dim4.GetLength(2));
            Console.WriteLine("=> dim4.GetLength(3) = " + dim4.GetLength(3));


            Console.ReadKey();

        }
    }
}
