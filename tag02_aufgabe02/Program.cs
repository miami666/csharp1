using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*


    AUFGABE B
    Ergänzen Sie den bisherigen Quellcode durch eine weitere (diesmal verschachtelte) Schleife ...
    - in der inneren Schleife sollen erneut wie in Aufgabe A zwei Double-Werte verglichen werden 
      und die Anzahl der benötigten Durchläufe 'x' ermittelt werden
    - Die Äußere Schleife soll 10000-mal durchlaufen werden, pro Durchlauf soll ...
      a) die innere Schleife gestartet und abgearbeitet werden (insbesondere soll also ein aktuelles 'x' ermittelt werden)
      b) der aktuelle x-Wert zu einer Gesamtsumme aufadiert werden
    - nach der verschachtelten Schleife soll der Durchschnittswert der benötigten Durchläufe der inneren Schleife 
      (also Gesamtsumme/10000) auf der Konsole auf 2 Nachkommastellen gerundet ausgegeben werden

    
    HINWEIS:
    Hier sollte sich nun obige Bemerkung bestätigen und der Durchschnittswert nahe bei 1000 liegen

*/
namespace tag02_aufgabe02
{
    class Program
    {
        static void Main(string[] args)
        {
            Random zufall = new Random();
            double a;
            double b;
            int x = 0;
            int resX=0;
            double pro;
            int max = 10000;
            for (int i = 0; i < 10000; i++)
            {
                do
                {
                    a = Math.Round(zufall.NextDouble(), 3);
                    b = Math.Round(zufall.NextDouble(), 3);
                    x++;
                }
                while (a != b);

                resX = x;
                

            }
            pro = (double)resX / (double)max;
           
            Console.WriteLine(Math.Round(pro,2));

            Console.WriteLine("any key to exit");
            Console.ReadKey(true);

        }
    }
}