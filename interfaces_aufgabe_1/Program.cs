using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Führen Sie bitte zunächst die 3 folgenden Interfaces ein:
        - Geräuschemacher (Property Dezibel[get und set] , Methode MacheGeräusch [weder Übergabe- noch Rückgabewerte])
        - Nahrungsaufnehmer (Property KalorienProTag[get und set] , Methode Essen [Übergabewert int])
        - EigenschaftenBesitzer (Methode ZeigeEigenschaften [weder Übergabe- noch Rückgabewerte])
    Führen Sie bitte ferner die Klasse Mensch ein
        Die Klasse Mensch soll alle drei Interface implementieren
            - Die Methode Essen soll "Hunger" "Papp-satt" oder "gerade genug" ausgegeben, ...
              ... falls der Übergabewert größer, kleiner oder gleich des Wertes kalorienProTag
            - Die Methode MacheGeräusch soll "Hallo Welt" auf der Konsole ausgeben
            - Die Methode ZeigeEigenschaften soll die Werte Dezibel und KalorienProTag ausgeben

    Im Main
        Instanziieren Sie bitte ein Objekt vom Typ Mensch
        Initialisieren Sie bitte alle Properties
        Testen Sie bitte alle Methoden durch Aufruf
*/
namespace interfaces_aufgabe_1
{
    interface IGM
    {
        int Db { get; set; }
        void Sound();

    }
    interface INA
    {
        int Kcal_pro_Tag { get; set; }
        void Eat(int num);
    }
    interface IEB
    {
        void ZE();

    }
    class Mensch:IGM,INA,IEB
    {
        public int Db { get; set; }
        public int Kcal_pro_Tag { get; set; }
        public void Sound()
        {
            Console.WriteLine("Hallo Welt");
            Console.Beep();
        }
        public void Eat(int num)
        {
            if(num < Kcal_pro_Tag)
            {
                Console.WriteLine("Hunger");
            }
            if(num>Kcal_pro_Tag)
            {
                Console.WriteLine("Pappsatt");
            }
            else
            {
                Console.WriteLine("gerade genug");
            }
        }
        public void ZE()
        {
            Console.WriteLine("Kalorien: "+Kcal_pro_Tag+" Dezibel: "+Db);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Mensch m1 = new Mensch();
            m1.Kcal_pro_Tag = 2400;
            m1.Db = 10;
            m1.Sound();
            m1.Eat(2500);
            m1.ZE();
            Console.ReadKey();
        }
    }
}
