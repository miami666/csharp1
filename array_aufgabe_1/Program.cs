using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*

Schreiben Sie bitte ein C#-Programm, das 
a) in einer Endlosschleife den User zu Beginn jeden Durchlaufs fragt, ob er eine  ...
	(1) Übersetzung, oder
	(2) Monatsnummer wünscht 

b) bei Eingabe von (1) einen deutschen Monatsnamen abfragt und die englische Übersetzung ausgibt
c) bei Eingabe von (2) einen deutschen Monatsnamen abfragt und die Monatsnummer ausgibt (Januar=1, ...)
d) bei Fehleingaben (Auswahl ungleich 1 und 2 / nicht-existenter deutscher Monatsname) eine entsprechende Fehlermeldung ausgibt

Bemerkung:
Versuchen Sie die Aufgabe bitte zunächst durch zwei 1-dimensionale String-Arrays zu lösen. 
*/

namespace array_aufgabe_1
{
    class Program
    {

        static void Main(string[] args)
        {
            int zahl = 0;
            bool running = true;
            do
            {
                Console.WriteLine("(1) Übersetzung\t(2) Monatsnummer");
                zahl = Convert.ToInt32(Console.ReadLine());
                if(zahl==2)
                {
                    string monatEingabe;
                    Console.WriteLine("Monat eingeben: ");
                    monatEingabe = Console.ReadLine();

                    Dictionary<string, string> monate = new Dictionary<string, string>()
{
                { "januar", "01"},
                { "februar", "02"},
                { "märz", "03"},
                { "april", "04"},
                { "mai", "05"},
                { "juni", "06"},
                { "juli", "07"},
                { "august", "08"},
                { "september", "09"},
                { "oktober", "10"},
                { "november", "11"},
                { "dezember", "12"},
};
          
                        foreach (var monat in monate)
                        {
                            if (monatEingabe.ToLower() == monat.Key))
                            {
                                Console.WriteLine(monat.Value);   
				break;
                            }
                        }
                }
                else if(zahl==1) {
                    Console.WriteLine("Monat eingeben: ");
                    string monatEingabe = Console.ReadLine();

                    Dictionary<string, string> monate = new Dictionary<string, string>()
{
                { "januar", "january"},
                { "februar", "february"},
                { "märz", "march"},
                { "april", "april"},
                { "mai", "may"},
                { "juni", "june"},
                { "juli", "july"},
                { "august", "august"},
                { "september", "september"},
                { "oktober", "october"},
                { "november", "november"},
                { "dezember", "december"},
};
                        foreach (var monat in monate)
                        {
                            if (monatEingabe.ToLower() == monat.Key)
                            {
                                Console.WriteLine(monat.Value);
				break;
                            }
                        }
                         
                }
                else
                {
                    Console.WriteLine("zonk");
                    break;
                }
            } while (true);
        }
    }
}
