using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Schreiben Sie bitte ein C#-Programm, in dem ...
 - eine Klasse 'Produkt' definiert wird
   + Klassenmember sind:
     - Counter (Integer, public)
     - name (String, private)
        + Property Name: "normales" set / bei get wird der Counter hochgezählt FALLS name bereits initialisiert
     - mindestpreis (Integer, private)
        + Property Mindestpreis: "normales" set / KEIN get
     - verkaufspreis (Integer, private)
        + Property Verkaufspreis: "normales" get / set nur FALLS value>=mindestpreis SONST verkaufspreis=mindestpreis
 - im Main alle obigen "Feature" getestet werden
*/

namespace G43_aufgabe_01
{
    class Produkt
    {
        public int counter = 0;
        string name;
        public string Name
        {
            get
            {
                if (name != null) counter++;
                return name;
            }
            set
            {
                name = value;
            }
        }
        private int mindestpreis;
        public int Mindestpreis
        {
            set
            {
                mindestpreis = value;
            }
        }
        private int verkaufspreis;
        public int Verkaufspreis
        {
            get
            {
                return verkaufspreis;
            }
            set
            {
                if (value >= mindestpreis) verkaufspreis = value;
                else verkaufspreis = mindestpreis;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Produkt a = new Produkt();
            a.Name = "Schnaps";
            a.Mindestpreis = 2;
            a.Verkaufspreis = 1;
            Console.WriteLine("Produkt Name: " + a.Name + "\nVerkaufspreis: " + a.Verkaufspreis);
            Console.ReadKey();
        }
    }
}
