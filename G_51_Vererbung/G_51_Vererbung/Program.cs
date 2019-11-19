/*
 Vererbung

 Definition: 
        Klassen können von anderen Klassen Code übernehmen => der dortige Code muss also nicht erneut geschrieben werden
        Die erbende Klasse wird "Subklasse" (Kindklasse) genannt, die Klasse von der geerbt wird, heißt "Basisklasse" (Mutterklasse)
 Bemerkung:
        Wir betrachten zunächst nur Klassen ohnen eignen ctor (verwenden also den Std-ctor)
        Diese Vorgehensweise erleichtert uns den Einstieg, eigene ctor bei Basis- und/oder Subklassen kommen später.


*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_51_Vererbung
{
    class Basisklasse // Basisklassen können NICHT von Subklassen erben => Fehlermeldung "Ringvererbung unzulässig"
    {
        public string BasisAttribut;
        public void BasisMethode(string s)
        {
            Console.WriteLine("Ich bin eine Basismethode, aufgerufen über das Objekt: " + s);
        }
    }

    class Subklasse_1 : Basisklasse // die "links notierte" Klasse erbt von der "rechts notierten"
    {
        public string Subklasse_1_Attribut;
        public void Subklasse_1_Methode()
        {
            Console.WriteLine("Ich bin eine Subklasse_1_Methode.");
        }
    }

    class Subklasse_2 : Basisklasse // die "links notierte" Klasse erbt von der "rechts notierten"
    {
        public string Subklasse_2_Attribut;
        public void Subklasse_2_Methode()
        {
            Console.WriteLine("Ich bin eine Subklasse_2_Methode.");
        }

        public new void BasisMethode(string s)
        {
            Console.WriteLine(s + " Ausgegeben aus der Subklasse_2");
        }
    }

    class SubSubklasse_3 : Subklasse_2 // die "links notierte" Klasse erbt von der "rechts notierten"
    {
        // public string SubSubklasse_3_Attribut;
        public void SubSubklasse_3_Methode()
        {
            Console.WriteLine("Ich bin eine SubSubklasse_3_Methode.");
        }
    }

/*
    Hinweise:
        a) Natürlich können auch weitere Klassen (sogar beliebig viele) von der Basisklasse erben, aber auch nur ein einziger Erbe ist erlaubt
        b) sogenannte "Mehrfachvererbung" (eine Subklasse erbt von mehreren Basisklassen) ist in C# NICHT erlaubt
            Begründung: Wenn es mehrere gleichnamige Methoden aus verschiedenen Basisklassen gibt, kann der Erbe über den Namen der Methode nicht entscheiden, aus welcher Basisklasse die jeweils gemeinte Methode stammt.
        c) Natürlich kann auch von einer Subklasse geerbt werden. In unserem Beispiel könnte es also ein Klasse X geben, die z.B: von der Subklasse_1 erbt. Die Subklasse_1 wäre dann zwar weiterhin eine Subklasse zur Basisklasse, aber selbst im Verhältnis zu X eine Basisklasse => X erbt dann also von der Basisklasse und der Subklasse_1

*/

    // Private Member und Vererbung

    class BasisPrivate
    {
        public int oeffentlicherInteger=1;
        private int privaterInteger = 3;

        public void ZeigePrivatenInteger()
        {
            Console.WriteLine("Ausgabe durch Aufruf der Methode ZeigePrivatenInteger aus der Basisklasse:" + privaterInteger);
        }
    }

    class Subklasse_3 : BasisPrivate
    {
        /* Es werden immer ALLE Member außer Konstruktoren und Destruktoren/Finalizers (da jede Klasse immer eigene  Struktoren benötigt) vererbt.
           Der Schutzgrad des Members in der Basisklasse bestimmt, ob auf den Member  zugegriffen werden kann.
           Da privaterInteger in der Klasse BasisPrivat den Schutzgrad "private" hat, kann nur dort darauf zugegriffen werden.
           Hinweis: Sie werden gelegentlich lesen, dass private Member nicht vererbt werden, da sie aus der Subklasse heraus nicht zugreifbar sind.         
         */
         public void SubZeigePrivatenInt()
        {
            Console.WriteLine("Ausgabe aus der Subklasse:");
            
            // KEIN Zugriff möglich
            //Console.WriteLine("privaterInt:" + privaterInteger);
            Console.WriteLine("öffentlicherInt:" + oeffentlicherInteger);

        }
    }


    // weiteres Beispiel
    class Tier
    {
        public int Alter;
    }

    class Hund : Tier
    {
        public string FarbeDesFells;
    }




    class Program
    {
        static void Main(string[] args)
        {
            Basisklasse b = new Basisklasse();
            b.BasisAttribut = "Ich bin ein Attribut des Objektes b (b ist vom Typ Basisklasse)";
            b.BasisMethode("b");

            Subklasse_1 s1 = new Subklasse_1();
            s1.BasisAttribut = "Ich bin ein Attribut des Objektes s1 - dieses Attribut erbte ich aus der  Basisklasse";
            s1.BasisMethode("s1");
            s1.Subklasse_1_Attribut = "Ich bin ein Attribut des Objektes s1 - dieses Attribut wurde in der Subklasse_1 definiert";
            s1.Subklasse_1_Methode();

            // Der Vollständigkeit halber sei noch erwähnt: Natürlich kann die Basisklasse NICHT auf Member der Subklasse zugreifen:
            // b.Subklasse_1_Attribut = "blabla"; ...denn Subklasse_1_Attribut ist unbekannt in der Basisklasse

            Subklasse_2 s2 = new Subklasse_2();
            s2.BasisAttribut = "Ich bin ein Attribut des Objektes s2 - dieses Attribut erbte ich aus der  Basisklasse";
            s2.BasisMethode("s2"); // Die geerbte BasisMethode ist in Subklasse_2 durch eine neue Definition der Methode verdeckt
            s2.Subklasse_2_Attribut = "Ich bin ein Attribut des Objektes s2 - dieses Attribut wurde in der Subklasse_2 definiert";
            s2.Subklasse_2_Methode();

            SubSubklasse_3 ss3 = new SubSubklasse_3();
            ss3.BasisAttribut = "Hello there!";
            ss3.BasisMethode("ss3");
            ss3.Subklasse_2_Attribut = "Hello there again!";
            ss3.Subklasse_2_Methode();
            ss3.SubSubklasse_3_Methode();

            Console.WriteLine("\n\nAttribute der initialisierten Objekte");
            Console.WriteLine(b.BasisAttribut);
            Console.WriteLine(s1.BasisAttribut);
            Console.WriteLine(s1.Subklasse_1_Attribut);
            Console.WriteLine(s2.BasisAttribut);
            Console.WriteLine(s2.Subklasse_2_Attribut);

            Console.WriteLine(ss3.BasisAttribut);
            Console.WriteLine(ss3.Subklasse_2_Attribut + "\n\n");

            BasisPrivate basisprivate = new BasisPrivate();
            basisprivate.ZeigePrivatenInteger();

            Subklasse_3 subklasse3 = new Subklasse_3();

            subklasse3.ZeigePrivatenInteger();
            subklasse3.oeffentlicherInteger = 5;
            subklasse3.SubZeigePrivatenInt();

            // Wenn Methoden vererbt werden, dann werden auch ihre Funktionalitäten vererbt.
            // Da in der Methode der Basisklasse auf das private Feld zugegriffen wird, geschieht dies auch über die vererbte Methode in der Subklasse

            // Hund : Tier - Beispiel

            Hund h = new Hund();
            h.Alter = 5; // Die Klasse Hund erbt den Member 'Alter' von Klasse Tier
            h.FarbeDesFells = "grün";



            Console.ReadKey();
        }
    }
}
