//Das Interface IMaths mit den Methoden Addieren und Subtrahieren
//Die Klasse MathsLibrary, dort wird das Interface implementiert
//In der Main ein Objekt vom Typ IMaths mit MathsLibrary instanziieren
//Und die beiden Methoden aufrufen
//Interface und Klasse in seperate Dateien
//Überlegen Sie sich, wie Sie sinnvoll die Klasse MathsLibrary mit weiteren 
//Methoden (z.B. Multiplizieren und Dividieren) erweitern können.
//Warum kann es problematisch sein, wenn Sie das bestehende Interface verändern?

using System;


namespace MathsInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            IMaths maths = MathsFactory.CreateMaths();
            Console.WriteLine(maths.Addieren(1, 5));
            Console.WriteLine(maths.Subtrahieren(10, 9));

            IMathsExtended mathsExtended = MathsFactory.CreateMathsExtended();
            Console.WriteLine(mathsExtended.Dividieren(12, 3));
            Console.WriteLine(mathsExtended.Multiplizieren(9, 4));

            IMathsQuadrat mathsQuadrat = MathsFactory.CreateMathsQuadrat();
            mathsQuadrat.Quadrieren(5);
            Console.ReadKey();
        }
    }
}
