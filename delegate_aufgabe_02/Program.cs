using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace delegate_aufgabe_02
{
    /*
     * Führen Sie bitte zunächst einen Delegaten namens 'MeinDelegat' ein (übergabewerte: 2 Strings, Rückgabewert: bool)
Führen Sie bitte ferner die 4 folgenden Methoden ein:
Name:        		A_IstLängerAls_B
Übergabewerte:   	2 Strings A und B
Funktion:    		Ermittelt die Länge beider Strings
Rückgabewert:	true, FALLS A länger als B, SONST false
Name:        		A_hatMehrEAls_B
Übergabewerte:   	2 Strings A und B
Funktion:    		Ermittelt die Anzahl der (großen oder kleinen) E´s beider Strings
Rückgabewert:	true, FALLS A mehr E´s (bzw. e´s) als B hat, SONST false  
Name:        		Sortiere
Übergabewerte:   	String-Array und eine Delegat vom Typ MeinDelegat
Funktion:    		Sortiert das Array nach dem Bubblesort-Verfahren bzgl. des übergebenen Delegats [siehe Erläuterung(*)]
Rückgabewert:	keiner
Name:        		Ausgabe
Übergabewerte:   	String-Array
Funktion:    		Konsolenausgabe aller Felder (wählen Sie selbst ein Layout nach ihren Vorlieben :-)
Rückgabewert:	keiner
Führen Sie bitte zunächst ein String-Array  'arr'  ein, gefüllt mit den folgenden drei Strings: "Beere","Autobahnpolizist","Tee"
       Lassen Sie den aktuellen Inhalt des Arrays bitte auf der Konsole ausgeben
       Führen Sie bitte ferner ein Delegat  d  vom Typ MeinDelegat ein und initialisieren dieses mit dem Verweis auf  A_IstLängerAls_B
       Rufen Sie anschließend bitte die Methode Sortiere auf (Übergabewerte arr und d)
       Lassen Sie bitte erneut den aktuellen Inhalt des Arrays auf der Konsole ausgeben
       Überschreiben Sie daraufhin bitte d mit dem Verweis auf  A_hatMehrEAls_B
       Rufen Sie daraufhin bitte erneut die Methode Sortiere auf (Übergabewerte arr und d)
       Lassen Sie bitte auch diesmal den aktuellen Inhalt des Arrays auf der Konsole ausgeben    (*)ERLÄUTERUNG:
       Beim Bubblesort wird pro Durchlauf der inneren Schleife entschieden, ob für zwei benachbarte Elemente 'A' und 'B' gilt: A>B ...
       ... A>B ist eine Frage der Betrachtung: Es kann alphabetisch gemeint sein, oder bzgl. der Wortlänge, oder der Anzahl der EŽs ...
       Genau dies kann durch den übergebenen Delegaten entschieden werden!*/
    class Program
    {
        delegate bool MeinDel(string a, string b);
        static bool AlaengerB(string a, string b)
        {
            int aLen = a.Length;
            int bLen = b.Length;
            var result = aLen > bLen ? true : false;
            return result;
        }
        static bool AeB(string a, string b)
        {
            int ae = a.Length - a.ToUpper().Replace("E", "").Length;
            int be = b.Length - b.ToUpper().Replace("E", "").Length;      
            var result = ae > be ? true : false;
            return result;
        }
        static void Sortiere(string[] arr,MeinDel d,bool Reverse=false)
        {
            int len = arr.Length;
            for (int i = 1; i < len; i++)
                for (int j = 0, stop = len - i; j < stop; j++)
                    if (Reverse ? !d(arr[j], arr[j + 1]) : d(arr[j], arr[j + 1]))
                        swap(j, j + 1);
            void swap(int i, int j) { string temp = arr[i]; arr[i] = arr[j]; arr[j] = temp; }
        }
        static void Ausgabe(string[] arr)
        {
            //for(int i=0;i<arr.Length; i++)
            //{
            //    if(i==arr.Length-1) Console.Write(arr[i] + "\n");
            //    else Console.Write(arr[i]+" , ");
            //}
            int index = 1;
            foreach (string s in arr)
            {
              
                Console.WriteLine($"Wort {index}: {s}");
                index++;

            }
        }
        static void Main(string[] args)
        {
            string[] arr =  {  "Restmülltütenverschlusssicherungsdraht","Beere", "Autopahnpolizist", "Tee", "Schifffahrt", "Holzbein",
                "Heeresstärke", "Erdbeere",           "Selbstzerstörungsauslösungsschalterhintergrundbeleuchtungsglühlampensicherungshalterschraube",
                "Rindfleischetikettierungsüberwachungsaufgabenübertragungsgesetz",
                "Steuerentlastungsberatungsvorgesprächskoalitionsrundenvereinbarungen"};
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nunsortiert: \n");
            Console.ResetColor();
         
            Ausgabe(arr);
            MeinDel d = new MeinDel(AlaengerB);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nsortiert nach string Laenge: \n");
            Console.ResetColor();
            Sortiere(arr, d);
            Ausgabe(arr);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nReverse Sortierung String Laenge: \n");
            Console.ResetColor();
            Sortiere(arr, d, true);
            Ausgabe(arr);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nnach Anzahl der E's: \n");
            Console.ResetColor();
            d = AeB;
            Sortiere(arr, d);
            Ausgabe(arr);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nnachAnzahl der E's reversed: \n");
            Console.ResetColor();
            Sortiere(arr, d, true);
            Ausgabe(arr);
            Console.ReadKey();
        }
    }
}
