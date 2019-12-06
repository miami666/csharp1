using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *Aufgabe 4
Schreiben Sie bitte das folgende C#-Programm: 
In einer Schleife soll ein Text abgefragt werden
Die Schleife wird entweder nach 10 erfolglosen Versuchen mit Fehlermeldung abgebrochen, 
oder zusammen mit einer Erfolgsmeldung, falls "dawai" eingegeben wurde

 */
namespace kleine_aufgaben_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string loesungswort = "dawai";
            bool won = false;
            string input = "";
            int counter = 0;
            Console.WriteLine("Raten sie das Loesungswort: ");
            do
            {
                input = Console.ReadLine();
                if (input == loesungswort)
                {
                    won = true;
                    break;
                }
                counter++;
            } while ((counter < 10 || !won));
            if (won) Console.WriteLine("Richtig! Das Loesungswort war: "+loesungswort);
            else Console.WriteLine("Leider haben sie das richtige Wort nicht erraten");
            Console.ReadKey();

        }
    }
}
