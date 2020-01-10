using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Emma_Uebung
{
    class Program
    {
        public static void Main(string[] args)
        {
            emmasFilialenCollection laeden = new emmasFilialenCollection();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Eingabe für die {0}. Filiale", i + 1);
                Console.Write("Filiale: ");
                string Id = Console.ReadLine();
                Console.Write("Kasse Start: ");
                int TageskasseStart = Convert.ToInt32(Console.ReadLine());
                Console.Write("Kasse Ende: ");
                int TageskasseEnde = Convert.ToInt32(Console.ReadLine());
                laeden.Add(Id, TageskasseStart, TageskasseEnde);
                Console.WriteLine("Filiale {0} Tagesumsatz: {1}\n",laeden[Id].Id, laeden[Id].Umsatz);
            }
            Console.WriteLine("\nTopFiliale des Tages ist: {0}", laeden.UmsatzTop().Id);
            Console.WriteLine("\nFlopfiliale des Tages ist: {0}", laeden.UmsatzMin().Id);
            Console.ReadLine();
        }
    }
}
