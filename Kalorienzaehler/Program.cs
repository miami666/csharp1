using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalorienzaehler
{
    class Program
    {
        static void Main(string[] args)
        {
            double kcal;
            
 
            Dictionary<string, double> d = new Dictionary<string, double>();
            do
            {
                Console.WriteLine("Wat hammer jefräße?");
                string inp = Console.ReadLine();
                
                
                Console.WriteLine("Wieviell Kalorien hatt et denn jehaat?");
                Double.TryParse(Console.ReadLine(), out kcal);
                d.Add(inp, kcal);
                Console.WriteLine("Ich jläuve, et jeit los. Häste sonst nooch wat fieses jefräße?(y/n)");
            }
            while (Console.ReadLine() != "n");
            double sum = d.Sum(x => x.Value);
            Console.WriteLine("Da pack ich mir an de Kopp. Du has janz fiese " + sum + " Kalorien jefräße.\nDu mus " + 30*sum/50 + " Minuten die Beene vertredde john oder + " + 60*sum/400 + " Minuten schwemme.");
            Console.ReadKey();
        }
    }
}
