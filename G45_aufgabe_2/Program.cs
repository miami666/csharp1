﻿using System;
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
        static Random rnd = new Random(Guid.NewGuid().GetHashCode());

        public static int MeinNext(int min, int max)
        {
            return rnd.Next(min, max);
        }
        public static double MeinNextDouble(double min, double max)
        {
            return rnd.NextDouble() * (max - min) + min;
        }
        public static char MeinNextChar(char start, char end)
        {           
            return (char)rnd.Next(start, end);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine(meinRandom.MeinNextChar('a', 'h'));
            for (int i = 0; i < 10; i++)
                Console.WriteLine(meinRandom.MeinNext(1, 10));
            for (int i = 0; i < 10; i++)
                Console.WriteLine(meinRandom.MeinNextDouble(1, 10));
            Console.ReadKey();
        }
    }
}
