using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Was zum Knobeln:

    Bitte erstellen Sie die Klasse 'MeinRandom' mit den folgenden Methoden:
        a) Methodenname:   MeinNext
           Übergabewerte:  2 Integer min und max
           Funktion:       Erzeugt eine ganze Zufallszahl zwischen (beiderseits einschließlich) min und max
           Rückgabewert:   Der ermittelte zufallswert
        b) Methodenname:   MeinNextDouble
           Übergabewerte:  2 Double min und max
           Funktion:       Erzeugt eine Double-Zufallszahl zwischen (beiderseits einschließlich) min und max
           Rückgabewert:   Der ermittelte zufallswert
        c) Methodenname:   MeinNextChar
           Übergabewerte:  2 Character startChar und endChar
           Funktion:       Erzeugt einen Zufalls-Character zwischen (beiderseits einschließlich) startChar und endChar
           Rückgabewert:   Der ermittelte zufalls-Character

    
   Testen Sie die Methoden bitte durch ein geeignetes Main
           
    HINWEISE:
        1.) Bedenken Sie bitte das Problem, dass ein Zufallsgenerator im Programmverlauf (höchstens) einmal aufgerufen werden sollte
            (Lösen Sie dieses Problem bitte ausschließlich durch die Klasse MeinRandom ...
             ... also OHNE, dass der Programmierer im Main einen Zufallsgenerator einführen muss.)
        2.) Es gibt hier unterschiedliche Lösungsstrategien - Konstruktoren sind nicht der einzige Weg
            (Insbesondere gilt: die angesprochenen 3 Methoden müssen nicht die einzigen Member der Klasse sein)
        3.) Ähnlich wie in ANSI C gibt es ein enges Verhältnis zwischen Character Und Integer (im Sinne der ASCII-Position)
        4.) Bei der Ausgabe eines Characters in Verbindung mit der Konkatenierung von Strings gibt es technische Probleme ... lösen Sie diese :-) 
*/
namespace G45_aufgabe_2
{
    class meinRandom
    {
        Random rnd = new Random(Guid.NewGuid().GetHashCode());

        public int MeinNext(int min,int max)
        {
          return  rnd.Next(min, max);

        }
        public double MeinNextDouble(double min, double max)
        {
            return rnd.NextDouble() * (max - min) + min ;

        }
        public char MeinNextChar(char start,char end)
        {
            char randomChar = (char)rnd.Next(start, end); 
            return randomChar;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string start = "a";
            string end = "h";
            meinRandom m = new meinRandom();
            Console.WriteLine(m.MeinNextChar(Convert.ToChar(start), Convert.ToChar(end)));
            
            meinRandom r = new meinRandom();
            Console.WriteLine(r.MeinNext(1,10));
            Console.ReadKey();
        }
    }
}
