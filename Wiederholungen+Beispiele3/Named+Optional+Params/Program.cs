using System;
using System.Runtime.InteropServices;

namespace Named_Optional_Params
{
    class Program
    {
        static void Main(string[] args)
        {
            int ergebnis;
            int a = 2, b = 1;
            ergebnis = Addition(a, b);
            Console.WriteLine(ergebnis);

            //Aufruf mit "Named Parameters" oder "Named Arguments"
            //Argumente sind das, was übergeben wird, Parameter sind das, was angenommen wird
            //Also hier würde man es Argumente nennen (wir übergeben Argumente),
            //in der Methode sind es die Parameter, die zu der Methodensignatur gehören
            //b und 5 sind Argumente, zweiteZahl und ersteZahl sind Parameter
            ergebnis = Addition(zweiteZahl: b, ersteZahl: 5);
            Console.WriteLine(ergebnis);

            //Named Parameters können auch zusammen mit normaler Parameterübergabe verwendet werden!
            ergebnis = Addition(a, dritteZahl: 12, zweiteZahl: b);
            Console.WriteLine(ergebnis);

            //Dabei müssen die festen / normalen Parameter (auch positionierte Parameter) zuerst genannt werden
            //und danach kann man weitere Parameter benennen.
            //Darum führt dies hier zu einem Fehler.
            //ergebnis = Addition(zweiteZahl: 1, 6);

            //Aufruf ohne den optionalen Parameter
            ergebnis = AdditionOptional(99, 15);
            Console.WriteLine(ergebnis);

            //Aufruf mit optionalem Parameter
            ergebnis = AdditionOptional(99, 15, 1);
            Console.WriteLine(ergebnis);

            //Aufruf mit Default-Parametern
            ergebnis = AdditionDefault();
            Console.WriteLine(ergebnis);

            ergebnis = AdditionDefault(6);
            Console.WriteLine(ergebnis);

            ergebnis = AdditionParams(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Console.WriteLine(ergebnis);

            ergebnis = AdditionParams(10);
            Console.WriteLine(ergebnis);

            Console.ReadKey();
        }

        //Normale Methode
        public static int Addition(int ersteZahl, int zweiteZahl)
        {
            return ersteZahl + zweiteZahl;
        }

        //Erste Methode mit weiterem Parameter überladen
        public static int Addition(int ersteZahl, int zweiteZahl, int dritteZahl)
        {
            return Addition(ersteZahl, zweiteZahl) + dritteZahl;
        }

        //Methode mit optionalem, dritten Parameter
        //Wird hier "dritteZahl" nicht übergeben, wird sie auf 0 gesetzt
        //Das "= 0"  bestimmt also, dass der Parameter optional ist.
        //Alternative Schreibweise "[Optional] int dritteZahl"
        //Dafür muss System.Runtime.InteropServices eingebunden werden
        public static int AdditionOptional(int ersteZahl, int zweiteZahl, int dritteZahl = 0)
        {
            return Addition(ersteZahl, zweiteZahl) + dritteZahl;
        }

        //Methode mit "Default" Parametern
        //Ähnlich wie bei Optional, kann man Parametern einen anderen Wert als 0 zuweisen
        //Dies bewirkt, dass der zugewiesene Wert als Default genommen wird,
        //sollte kein anderer Wert übergeben werden
        public static int AdditionDefault(int ersteZahl = 1, int zweiteZahl = 10, int dritteZahl = 4)
        {
            return ersteZahl + zweiteZahl + dritteZahl;
        }

        //Optionale Parameter mit dem "params" Schlüsselwort
        //params darf nur einmal in der Methodensignatur vorkommen und muss immer als letzter
        //Parameter aufgelistet werden
        public static int AdditionParams(int ersteZahl, params int[] weitereZahlen)
        {
            int ergebnis = ersteZahl;
            foreach (int zahl in weitereZahlen)
                ergebnis += zahl;
            return ergebnis;
        }
    }

}
