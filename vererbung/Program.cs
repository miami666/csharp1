using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Vererbung: Klassen können von anderen Klassen  Code übernehmen =>der dortige Code muss also nicht neu geschrieben werden.
 * Die erbende Klasse wird Subklasse genannt, die Klasse von der geerbt wird bezeichnet man als Basisklasse.
 * 
 * Wir betrachten zunächst nur Klassen ohne eigenen Konstruktor(verwenden also den Standard Konstruktor)
*/
namespace vererbung
{
    class Basisklasse //Basisklassen können nicht von Subklassen erben
    {
        public string Basisattribut;
        public void Basismethode(string s)
        {
            Console.WriteLine("Ich bin eine Basismethode aufgerufen über das Objekt "+s);
        }
       

    }
    class Subklasse_1:Basisklasse
    {
        public string Subklasse_1_Attribut;
        public void Subklasse_1_Methode()
        {
            Console.WriteLine("Ich bin eine Methode der Subklasse 1 ");
        }


    }
    class Subklasse_2 : Basisklasse
    {
        public string Subklasse_2_Attribut;
        public void Subklasse_2_Methode()
        {
            Console.WriteLine("Ich bin eine Methode der Subklasse 2 ");
        }
        public new void Basismethode(string s)
        {
            Console.WriteLine(s + " ausgegeben aus der subklasse 2");
        }
    }
    class SubSubklasse_3 : Subklasse_2
        {
            public void SubSubklasse_3_Methode()
            {
                Console.WriteLine("Ich bin eine SubSubklasse_3_Methode");
            }
        }
        //private Member und Vererbung
class BasisPrivate
    {
        public int oeffentlicherInteger;
        private int privaterInteger = 3;
        public void ZeigeprivatenInteger()
        {
            Console.WriteLine(privaterInteger);
        }
       

    }
    class Subklasse_3:BasisPrivate
    {
       
        

    }
    class Tier
    {
        public int alter;
    }
    class Hund:Tier
    {

    }
    public class A
    {
        private int value = 10;

        public class B : A
        {
            public int GetValue()
            {
                return this.value;
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Basisklasse b = new Basisklasse();
            b.Basisattribut = "ich bin ein attribut des objektes b vom typ Basisklasse";
            b.Basismethode("b");
         

            Subklasse_1 s1 = new Subklasse_1();
            s1.Basisattribut = "ich bin ein attribut des objektes s1.Dieses attribut erbte ich aus der Basisklasse";
            s1.Basismethode("s1");
            s1.Subklasse_1_Attribut = "ich bin ein attribut des objektes s1 dieses attribut wurde in der subklasse 1 definiert";
            s1.Subklasse_1_Methode();

            Subklasse_2 s2 = new Subklasse_2();
            s2.Basisattribut = "ich bin ein attribut des objektes s2.Dieses attribut erbte ich aus der Basisklasse";
            s2.Basismethode("s2");
            s2.Subklasse_2_Attribut=("Ich bin ein attribut des objektes s2 dieses attribut wurde in der subklasse 2 definiert");
            SubSubklasse_3 ss3 = new SubSubklasse_3();
            ss3.Basisattribut = "hello";
            ss3.Basismethode("ss3");
            ss3.Subklasse_2_Attribut = "Hello there again";
            ss3.SubSubklasse_3_Methode();

            Console.WriteLine("\n\nAttribute der initialisierten Objekte");
            Console.WriteLine(b.Basisattribut);
            Console.WriteLine(s1.Basisattribut);
            Console.WriteLine(s1.Subklasse_1_Attribut);
            Console.WriteLine(s2.Basisattribut);
            Console.WriteLine(s2.Subklasse_2_Attribut);
            Console.WriteLine(ss3.Basisattribut);
            Console.WriteLine(ss3.Subklasse_2_Attribut);

            Subklasse_3 sub3 = new Subklasse_3();
            sub3.ZeigeprivatenInteger();

            var xb = new A.B();
            Console.WriteLine(xb.GetValue());






            Console.ReadKey();
        }
    }
}
