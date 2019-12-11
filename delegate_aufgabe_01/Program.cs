using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_aufgabe_01
{
    /*
     * Erstellen Sie in der Klasse Program den Delegate "Ausgabe", der als Parameter ein String Array erhält
Erstellen Sie die drei void Methoden Bildschirm, Datei und Datenbank für den Delegate (d.h. gleiche Parameter)
Die drei Methoden sollen jeden String im Array testweise auf der Konsole ausgeben wobei die Methoden zur Unterscheidung auch das Ziel der Ausgabe mit ausgeben sollen z.B. Console.WriteLine("Schreibe {0} in die Datenbank...", daten[i]);
Testen Sie die Methoden und den Delegate im Main, indem Sie dort ein String Array anlegen, dem Delegate die Methoden zuweisen und aufrufen.

     */
    class Program
    {
        delegate void Ausgabe(string[] arr);
        static void Main(string[] args)
        {
            string[] strArr = new string[3] { "eins", "zwei", "drei" };
            Ausgabe ausgabeBildschirm = new Ausgabe(Bildschirm);
            ausgabeBildschirm = ausgabeBildschirm + Datenbank + Datei;
            ausgabeBildschirm(strArr);
            Console.ReadKey();
            
        }
       static void Bildschirm(string[] arr)
        {
            for(int i=0;i<arr.Length;i++)
            {
                Console.WriteLine("Schreibe {0} auf den Bildschirm ", arr[i]);
            }

        }
        static void Datei(string[] arr)
        {
            for(int i=0;i<arr.Length;i++)
            {
                Console.WriteLine("Scchreibe {0} ind Datei ", arr[i]);
            }

        }
       static void Datenbank(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Schreibe {0} in die Datenbank ", arr[i]);
            }
        }
    }
}
