using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// G_32_ArrayMehrdim
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



namespace array2d_1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Einstieg am bekannten 1d Array

            int[] paulsSchulnoten = new int[4] { 4, 3, 2, 1 };
            Console.WriteLine("Die 3. Note von Paul war"+ paulsSchulnoten[2]);

            //2dim Array Noten und Jahre

            int[,] array = new int[3, 4] { { 3, 4, 5, 6 }, { 2, 1, 4, 3 }, { 4, 3, 2, 1 } };
            Console.WriteLine(array[0,1]);

            //3dim noten und Jahr schüler
            int[,,] array3d = new int[2, 3, 4]
            {
                {
                    {3,4,5,6 },  //schüler 1,jahr 1,noten 1 bis 4
                    {2,1,5,4 }, // schüler 1 jahr 2, noten 1 bis 4
                    {4,3,2,1 } // schüler 1 jahr 3 noten 1 bis 4
                },
                 {
                    {1,2,3,4 },  //schüler 2,jahr 1,noten 1 bis 4
                    {5,6,5,4 }, // schüler 2, jahr 2, noten 1 bis 4
                    {1,3,5,2 } // schüler 2, jahr 3 noten 1 bis 4
                }
            };
            Console.WriteLine("Schüler 1, Jahr 3,Prüfung 4"+array3d[0,2,3]);
            //length bei mehrdimensionalen array
            int[,,,] dim4 = new int[2, 3, 4, 5];
            Console.WriteLine("Array Length: "+dim4.Length);
            Console.ReadKey();
        }
    }
}
