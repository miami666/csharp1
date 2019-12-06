using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsBeispiel
{
    //Mit "where T :" kann man Beschränkungen auf T festlegen,
    //so dürfen mit "where T : IGegenstand" dem T nur Datentypen zugewiesen werden,
    //die das Interface IGegenstand implementieren
    public class Regal<T> where T : IGegenstand
    {
        //public int Anzahl { get; private set; }
        public T[] Liste { get; private set; }


        public Regal(int maxAnzahl)
        {
            Liste = new T[maxAnzahl];
        }

        //Methode, die den generischen Typen verwendet
        public T GetT(int i)
        {
            return Liste[i];
        }

        //Generische Methode
        public void Generisch<Typ1, Typ2>(Typ1 a, Typ2 b)
        {

        }

    }

    //Es sind beliebig viele Typendefinitionen möglich
    public class Regal<T, V> where T : IGegenstand
    {
        public T[] Liste { get; private set; }
        public V[] VListe;
    }


    public interface IGegenstand
    {

    }

    public class Buch : IGegenstand
    {
        public string Verfasser { get; private set; }
        public string Titel { get; private set; }

        public Buch(string verfasser, string titel)
        {
            Verfasser = verfasser;
            Titel = titel;
        }
    }

    public class Taschenbuch : Buch
    {
        public Taschenbuch(string verfasser, string titel) : base(verfasser, titel)
        {

        }
    }

    public class Bierfass : IGegenstand
    {
        public string Brauerei { get; private set; }
        public double Liter { get; set; }

        public Bierfass(string brauerei, double liter)
        {
            Brauerei = brauerei;
            Liter = liter;
        }
    }

    public class Fernseher : IGegenstand
    {

    }


    class Program
    {
        static void Main(string[] args)
        {
            Regal<Bierfass> bierfassRegal = new Regal<Bierfass>(4);
            bierfassRegal.Liste[0] = new Bierfass("Karlsberg", 50);

            Regal<Buch> bücherRegal = new Regal<Buch>(100);
            bücherRegal.Liste[42] = new Buch("Douglas Adams", "Per Anhalter durch die Galaxis");

            Regal<Fernseher> fernseherRegal = new Regal<Fernseher>(2);
            fernseherRegal.Liste[0] = new Fernseher();

            Regal<Taschenbuch> taschenbuchRegal = new Regal<Taschenbuch>(200);

            Console.WriteLine(bierfassRegal.Liste[0].Brauerei);

            Console.ReadKey();
        }
    }
}
