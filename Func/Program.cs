using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func
{
    class Program
    {
        //Der Delegat lässt sich natürlich auch als Event nutzen
        public static event Func<int, int> Funktion;

        //Action funktioniert wie Func, nur dass Action keinen Return-Wert hat
        public static event Action<string> Aktion;
 
        static void Main(string[] args)
        {
            //Dieser Aufruf sieht komisch aus, da zwei Klammernpaare aufeinander folgen.
            //Operator liefert aber eine Methode zurück -> das zweite Klammernpaar ruft genau diese Methode auf
            Console.WriteLine(Operator('+')(5, 5));
            Console.WriteLine(Operator('/')(5, 0));

            //Event
            Funktion += Quadrat;
            Console.WriteLine(Funktion(5));

            Console.ReadKey();
        }

        //Func ist ein generischer Delegat.
        //Der letzte angegebene Typ bestimmt den Rückgabewert der Funktion/Methode
        //Die Typen davor bestimmen die Typen der Parameter
        //In diesem Beispiel gibt die Methode Operator eine Methode zurück,
        //die dem Delegaten Func<int, int, double> entspricht.
        //Also eine Methode mit zwei int Parametern und einem double Rückgabewert.
        public static Func<int, int, double> Operator(char op)
        {
            switch (op)
            {
                case '+': return ((int a, int b) => a + b);
                case '-': return ((int a, int b) => a - b);
                case '*': return ((int a, int b) => a * b);
                case '/': return ((int a, int b) => (b != 0 ? a / b : 0)); //Wenn b nicht 0, dann gib a / b zurück, sonst 0
                default: return ((int a, int b) => 0);
            }
        }

        public static int Quadrat(int a)
        {
            return a * a;
        }
        

    }
}
