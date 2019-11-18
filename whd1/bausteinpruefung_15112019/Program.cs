using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace bausteinpruefung_15112019
{
    class Program
    {
        static void Main(string[] args)
        {
            string eingabe;
            bool parseStatus;
            int zahl1;
            bool valid = true;
            do
            {
                Console.WriteLine("Ihr Geburtsjahr: ");
                eingabe = Console.ReadLine();
                parseStatus = int.TryParse(eingabe, out zahl1);
                if (parseStatus == true&&zahl1>=0)
                {
                    DateTime zeroTime = new DateTime(1, 1, 1);
                    DateTime a = new DateTime(zahl1, 1, 1);
                    DateTime b = DateTime.Now;
                    TimeSpan span = b - a;
                    // weil wir in Jahr 1 des greg. Kalenders starten ziehen wir 1 ab.
                    int years = (zeroTime + span).Year - 1;
                    Console.WriteLine("Jahre vergangen: " + years);
                }
                else
                {
                    Console.WriteLine("Fehler");
                    valid = false;
                    continue;
                }
            } while (false);
               Console.ReadKey();
        }
    }
}
