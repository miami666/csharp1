using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whd3
{
    class Program
    {
        public struct mystruct
        {
            public double wert;
            public string wertname;
        }

        public static List<mystruct> meineListe;

        static bool fillMyStruct(out mystruct bla)
        {
            bool isEnde = false;
            do
            {
                Console.Write("Bitte Wert eingeben:");
                isEnde = double.TryParse(Console.ReadLine(), out bla.wert);
            }
            while (isEnde != true);
            isEnde = false;
            Console.Write("Bitte Wertnamen eingeben (oder ENDE für Ende):");
            bla.wertname = Console.ReadLine();
            //Kontrollausgabe
            Console.WriteLine("fillMyStruct: Wert:" + bla.wert + "   Wertname:" + bla.wertname);
            if (bla.wertname == "ENDE") return true;
            else return false;
        }

        static bool fillMyStructList(out List<mystruct> mylist)
        {
            // kleine Aufagbe:
            // User Eingabe von Werten unter Verwendung von fillMyStruct
            // Abbruch wenn "ENDE" eingegeben wird
            // Verwendung von TryParse
            // Ausgabe der Liste soll im Hauptprogramm erfolgen
            // Zeitvorgabe ca. 15-30min
            bool isEnde = false;
            mylist = new List<mystruct>();
            mystruct data;
            do
            {
                isEnde = fillMyStruct(out data);
                Console.WriteLine("fillMyStructList: Wert:" + data.wert + "   Wertname:" + data.wertname + "isEnde:" + isEnde);
                mylist.Add(data);

            }
            while (isEnde != true);
            return isEnde;
        }

        static void Main(string[] args)
        {

            //mystruct MeineStruktur;
            //if (fillMyStruct(out MeineStruktur))
            //    Console.WriteLine("wert:" + MeineStruktur.wert + "    Name:" + MeineStruktur.wertname);

            fillMyStructList(out meineListe);

            foreach (mystruct ms in meineListe)
            {
                Console.WriteLine("Wertname - Wert:" + ms.wertname + " - " + ms.wert);
            }

            Console.ReadKey();
        }
    }
}
