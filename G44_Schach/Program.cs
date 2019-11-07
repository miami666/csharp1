using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Schreiben Sie bitte ein C#-Programm, in dem ...
 - die Klasse 'Schachfeld' definiert wird
   + die Klasse besitzt zwei private Methoden (linie und reihe) und eine public (Zufallsfeld)
     - keine der Methoden hat Übergabewerte
     - linie liefert als Rückgabewert einen Buchstaben zwischen a und h (als String)
     - reihe liefert als Rückgabewert eine Ziffer zwischen 1 und 8 (als String)
     - Zufallsfeld liefert als Rückgabewert die Konkenation der Rückgabewerte aus linie und reihe
 - im Main ein Objekt feld vom Typ Schachfeld instanziiert wird
   + zur Kontrolle wird der Rückgabewert feld.Zufallsfeld() auf der Konsole ausgegeben
*/

namespace G44_Schach
{
    class Schachfeld
    {
        Random random = new Random();
        private string GetLinie()
        {
          
            int num = random.Next(0, 8); 
            char let = (char)('A' + num);
            return Convert.ToString(let);
        }
        private string GetReihe()
        {
            int num = random.Next(1, 8);
            return Convert.ToString(num);
        }
        public string Zufallsfeld()
        {
            
            return GetLinie() + "," + GetReihe();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Schachfeld s = new Schachfeld();
          
            var array = s.Zufallsfeld().Split(new[] { ',' }, 2); 
            string x = array[0];
            string y = array[1];
            char xk = Convert.ToChar(x);
            int xki= char.ToUpper(xk) - 64;
            int yk = Convert.ToInt32(y);
            Console.WriteLine(x+y+xki+yk);
            int[,] table = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0 && i != yk - 1 && j != xki - 1)
                    {
                        table[i, j] = 0;
                    }
                    else if (i == yk-1 && j == xki-1)
                        table[i, j] = 8;

                    else
                    {
                        table[i, j] = 1;
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine();
            }
       

            Console.ReadKey();
        }
    }
}
