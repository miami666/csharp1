using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G45_KonstruktorenUndStaticMember
{
    class Auto
    {
        //Innerhalb der Klasse befindet sich kein eigener,expliziter Konstruktor=>Der Standard Konstruktor wird automatisch erstellt
        public int anzahlTueren;
    }
    class Bus
    {
        //eigener Konstruktor
        public Bus(int AnzahlSitzplaetze, string marke, string name)
        {
            this.AnzahlSitze = AnzahlSitzplaetze;
            this.Marke = marke;
            this.NameBusfahrer = name;
        }
        public int AnzahlSitze;
        public string Marke;
        public string NameBusfahrer;
    }
    class Computer
    {
        //eigener Konstruktor
        //erwartet Übergabewert Speicherplatz
        public Computer(int Speicherplatz)
        {
            this.Speicherplatz = Speicherplatz;

        }
        //2ter eigener Konstruktor
        //erwartet Übergabewert Speicherplatz und  Besitzer
        public Computer(int s,string b)
        {
            Speicherplatz = s;
            Besitzer = b;
        }
        //3ter Konstruktor
        //erwartet Übergabewert Besitzer;
        public Computer(string b)
        {
            Besitzer = b;
        }
        //4ter eigener Konstruktor
        // andere Reihenfolge der Übergabeparameter ist möglichghg
        public Computer(string b,int s)
        {
            Speicherplatz = s;
            Besitzer = b;
        }
        public int Speicherplatz;
        public string Besitzer;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();  
        }
    }
}
