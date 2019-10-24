using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//AUFGABE A
//      Schreiben Sie bitte zunächst die beiden folgenden Methoden(und testen Sie diese mit dem Programm aus AUFGABE B)
//        1.) Methode
//            Funktionsname: HexInBin
//            Übergabewert: 1 String 's1' (Zahl in hexadezimaler Darstellung, Korrektheit wird nicht geprüft)
//            Funktion: s1 wird in einen String s2 übersetzt, der den selben Wert in binärer Form darstellt
//            Rückgabewert: s2
//        2.) Methode
//            Funktionsname: BinInHex
//            Übergabewert: 1 String 's1' (Zahl in binärer Darstellung, Korrektheit wird nicht geprüft)
//            Funktion: s1 wird in einen String s2 übersetzt, der den selben Wert in hexadezimaler Form darstellt
//            Rückgabewert: s2


namespace G_13_Aufg2
{
    class Program
    {
        static string HexInBin(string s1)
        {
            //if (zahl >= 0) return Convert.ToString(zahl, basis);
            //return "-" + Convert.ToString(-zahl, basis);

            int z = Convert.ToInt32(s1,16);
            return Convert.ToString(z,2);

        }
        static string BinInHex(int s1)
        {
            //if (zahl >= 0) return Convert.ToString(zahl, basis);
            //return "-" + Convert.ToString(-zahl, basis);
            return Convert.ToString(s1, 16);

        }
        static void Main(string[] args)
        {
           int zahl;
            bool running = true;
            while(running)
            {
                do
                {
                    Console.Clear();
                    Console.Write("Geben Sie bitte eine Zahl (in dezimaler Darstellung) ein: ");
                }
                while (!int.TryParse(Console.ReadLine(), out zahl));

                Console.WriteLine(HexInBin(zahl));


            }
        }
    }
}
