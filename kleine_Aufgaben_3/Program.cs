using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Aufgabe 3
Schreiben Sie bitte das folgende C#-Programm : 
Es soll eine Methode aufgerufen werden:
  Funktionsname: FülleArray
  Übergabewert: 1 Referenz auf ein Integer-Array arr, 1 Integer 'anzahl'
  Funktion:     Füllt das Array arr mit anzahl-vielen Usereingaben, sofern diese zweistellig (und vom Format zulässig) sind
                Unzulässige Eingabe => Wiederholung der Abfrage 
Im Main soll die Funktion zu Testzwecken aufgerufen werden und anschließend ihr Inhalt auf der Konsole erscheinen*/

namespace kleine_Aufgaben_3
{
    class Program
    {
        static void fillArray(int anzahl, ref int[] arr)
        {
            int input;
            if (anzahl > 9)
            {
                Console.WriteLine("Eingabe von {0} Werten",anzahl);
                arr = new int[anzahl];
                for (int i = 0; i < anzahl; i++)
                {
                    int.TryParse(Console.ReadLine(), out input);
                    arr[i] = input;
                }
            }

        }
        static void Main(string[] args)
        {
            int[] intArray = new int[5]  {1,2,3,4,5};
            fillArray(10, ref intArray);
            for (int i = 0; i < intArray.Length;i++)
            {
                Console.WriteLine(intArray[i]);
               
            }
            Console.ReadKey();
        }
    }
}
