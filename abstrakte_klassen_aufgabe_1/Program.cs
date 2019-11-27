using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Führen Sie bitte zunächst die abstrakte Klasse 'GeräuscheMacher' ein
        diese besitzt nur eine abstrakte Methode 'MacheGeräusch' (keine Über-, oder Rück-gabewerte)
    Führen Sie bitte ferner die Klassen Auto, Hund und Mensch ein, die von GeräuscheMacher erben
        keiner dieser Klassen enthält weitere Member
        Konsolenausgabe von MacheGeräusch in Auto:   "Brummmmmm ..."
        Konsolenausgabe von MacheGeräusch in Hund:   "Wau Wau Kläff Grrrrr ..."
        Konsolenausgabe von MacheGeräusch in Mensch: "C# lernen ist toll!!"
    Führen Sie bitte eine Liste vom Typ GeräuscheMacher ein
    Führen Sie bitte von allen drei Subklassen ein Objekt ein, und fügen dies der Liste zu
    Lassen Sie bitte mittels einer foreach-Schleife für alle Elemente der Liste die Methode aufrufen
*/

namespace abstrakte_klassen_aufgabe_1
{
    abstract class GM
    {
        public abstract void MakeSound();

    }
    class Auto:GM
    {
        public override void MakeSound()
        {
            Console.WriteLine("Bruuummmmm");
        }

    }
    class Hund:GM
    {
        public override void MakeSound()
        {
            Console.WriteLine("wuff");
        }

    }
    class Mensch:GM
    {
        public override void MakeSound()
        {
            Console.WriteLine("C# lernen ist faszinösend");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<GM> gmListe = new List<GM>();
            Auto a = new Auto();
            Hund h = new Hund();
            Mensch m = new Mensch();

            gmListe.Add(a);
            gmListe.Add(h);
            gmListe.Add(m);

            foreach (GM item in gmListe)
            {
                item.MakeSound();
                Console.Beep();

            }
            Console.ReadKey();
        }
    }
}
