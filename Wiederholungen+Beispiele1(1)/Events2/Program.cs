using System;

namespace Events2
{
    public class Klima
    {
        //Delegat, der einen Datentypen darstellt
        public delegate void TemperaturEventHandler(string s);
        
        //Event-Variable aus dem Delegatentypen, der ich nun Methoden mit der passenden Signatur zuweisen kann
        //Das Zuweisen der Methoden nennt man Abonnieren.
        public event TemperaturEventHandler TemperaturZuHoch;

        //Feld / private lokale Variable
        private double temperatur;

        //Property mit Get- und Set-Methoden
        public double Temperatur
        {
            get
            {
                return temperatur;
            }
            set
            {
                temperatur = value;

                //Ist die zugewiesene Temperatur größer 40 UND ist das Event abonniert?
                if (temperatur > 40 && TemperaturZuHoch != null)
                {
                    //Dann wird das Event ausgelöst. Dadurch wird jede zugewiesene Methode
                    //in der Reihenfolge der Zuweisung aufgerufen.
                    TemperaturZuHoch("Temperatur zu hoch!");
                }
            }
        }
    }

    public static class Server
    {
        //Diese Methode soll auf das Event reagieren -> Muss die gleiche Signatur wie der Delegat aufweisen
        public static void ServerCrash(string grund)
        {
            Console.WriteLine("Server ist abgestürzt. Grund: " + grund);
        }
    }

    public static class Person
    {
        public static void IchGehNichAusDemHaus(string grund)
        {
            Console.WriteLine("Ich geh nich aus dem Haus! " + grund);
            
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Klima klima = new Klima();
            //Events abonnieren! Achtung: Events nur mit += zuweisen!
            //Events können mit -= wieder deabonniert werden.
            klima.TemperaturZuHoch += Server.ServerCrash;
            klima.TemperaturZuHoch += Person.IchGehNichAusDemHaus;
            Console.WriteLine("Setze Temperatur auf 30");
            klima.Temperatur = 30;

            Console.WriteLine("Setze Temperatur auf 45");
            klima.Temperatur = 45; //<- Größer 40, also wird das Event ausgelöst

            


            Console.ReadKey();


        }
    }
}
