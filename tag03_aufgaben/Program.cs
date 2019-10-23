using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*

Schreiben Sie bitte ein C#-Programm, das 
a) einen Integer-Wert solange abfragt, bis er mindestens die Größe 10 hat
b) bei jeder zu kleinen Eingabe eine Fehlermeldung ausgibt und das Programm bis zu einem Tastendruck stoppt
c) bei einer Eingabe von mindestens 10 mit einer Erfolgsmeldung das Programm beendet
d) die Konsole bis zu einem beliebigen Tastendruck festhält

Bemerkungen:
1) Auch while und do-while Schleifen unterscheiden sich in C# nicht von denen in ANSI C
2) Fehleingaben im Sinne von Buchstaben, Zeichen, oder Kommazahlen werden vom Programm NICHT abgefangen 
namespace tag03_aufgaben
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zahl: ");
            var foo = Console.ReadLine();

            if (int.TryParse(foo, out int number1))
            {
               
               
            }
            else
            {
                Console.WriteLine($"{foo} ist keine Zahl");
            }
           if (number1 >= 10)
                {
                    Console.WriteLine("Erfolg");
                 
                }
                else
                {
                    Console.WriteLine("Fehler");

                }

            

            Console.ReadKey();
        }
    }
}
*/
/*
    Schreiben Sie bitte ein C#-Programm, in dem  ...
    - in einer Schleife pro Durchlauf solange 2 Double-Zahlen vom User abgefragt werden, 
	  bis deren Differenz (auf 2 Nachkommastellen gerundet) 0 beträgt
    - pro Durchlauf wird jeweils die aktuelle Differenz ausgegeben

    HINWEIS:
    Je nach Reihenfolge der Differenzbildung (bzw. Eingabe der Zahlen) kann die Differenz positiv, oder negativ sein ...
    ... sorgen Sie bitte bei der Ausgabe dafür, dass die Differenz stets als ein Wert größer gleich Null ausgegeben wird
                  
*/
namespace tag03_aufgaben
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Zahl: ");
                string foo = Console.ReadLine();

                if (double.TryParse(foo, out double number1))
                {

                }
                else
                {
                    Console.WriteLine($"{foo} ist keine KommaZahl");
                }
                Console.WriteLine("Zahl2: ");
                string doo = Console.ReadLine();
                if (double.TryParse(doo, out double number2))
                {

                }
                else
                {
                    Console.WriteLine($"{foo} ist keine Kommazahl");
                }
                double number3 = number1 - number2;
                var first2Dec = (int)(((decimal)number3 % 1) * 100);
                if (first2Dec == 00) running = false;
                else Console.WriteLine("nicht 00 neue Eingabe");             
            }

            Console.WriteLine("geschafft die ersten beiden Nachkommastellen sind 00");
            Console.ReadKey();
        }
    }
}
