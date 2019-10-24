using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Binäre(2), Oktale(8), Dezimale(10) oder Hexadezimale(16) Darstellungen
    
    Vorbemerkung:
    Wir hatten zuletzt bereits festgestellt, dass ein User zunächst nur Strings eingeben kann, 
    die dann entweder konvertiert oder geparsed werden müssen, 
    falls diese Eingaben als Zahlen interpretiert werden sollen. 
    Bei dieser gelegenheit lernten wir TryParse kennen, was kurzfristig den Eindruck hinterlassen konnte, 
    dass wir auf Convert.To... gänzlich verzichten könnten ... 
    "zur Ehrenrettung" dieser Klasse Convert dient nun aber das kommende Thema, 
    in dem wir die Umwandlung von (z.B.) dezimal nach binär, oder binär nach dezimal, usw. betrachten wollen.

    Bemerkung:
    default-mäßig werden Integer dezimal dargestellt 
    - wir können aber jeweils Strings produzieren, die andere Darstellungen erlauben 
    - wichtig ist aber dann, dass wir dem System "auf irgendeine Weise" mitteilen, 
    ob wir gerade von binären, oktalen, ... oder anderen "Basen" ausgehen
*/

namespace G_13_BinHexOct
{
    class Program
    {
        static void Main(string[] args)
        {
            int wert = 8;
            string binString;
            binString = Convert.ToString(wert, 2); // ToString weil wir einen String produzieren wollen, 2weil wir die Übersetzung auf Basis 2 durchführen wollen
            //umgekehrt
            wert = Convert.ToInt32(binString, 2);

            //oder
            wert = Convert.ToInt32(binString, 10); // redundant weil Basis 10 default ist

            //oder
            wert = Convert.ToInt32(binString, 16);

            // Notation hexadezimaler Zahlen
            // a) Akzeptanz bei Eingabe
            // b) Form der Ausgabe

            string hexStr1 = "aaa";
            string hexStr2 = "aaA";
            string hexStr3 = "AAa";
            string hexStr4 = "AAA";
            int wert1 = Convert.ToInt32(hexStr1, 16);
            int wert2 = Convert.ToInt32(hexStr2, 16);
            int wert3 = Convert.ToInt32(hexStr3, 16);
            int wert4 = Convert.ToInt32(hexStr4, 16);

            Console.WriteLine("\nAkzeptanz Grß und Kleinschreibung");
            Console.WriteLine(hexStr1);
            Console.WriteLine(hexStr2);
            Console.WriteLine(hexStr3);
            Console.WriteLine(hexStr4);

            //umgekehrt
            hexStr1 = Convert.ToString(wert1, 16);

            //binaer zu dezimal
            string dual = "10001010";
            int dez = Convert.ToInt32(dual, 2);
            Console.WriteLine("dual " +dual+ " ist in dezimal"+dez);
        }
    }
}
