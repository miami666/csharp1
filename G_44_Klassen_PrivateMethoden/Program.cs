/*
    Private Methoden
    Wir hatte zuletzt mit den privaten Feldern(Variablen) eine Anwendung der Idee der "Abkapselung" kennen gelernt, wobei wir diese
    nicht in allen Fällen konsequent durchhalten konnten: Gelegentlich müssen wir auf bestimmte Felder einer Klasse AUCH VON AUSSEN
    Zugriff haben, und nutzten hierzu die sogenannten Properties (eine Art von public-Methoden)

    Wir wunderten uns dabei NICHT darüber, dass diese Methoden (bzw. Properties) public waren, denn sie waren ja gerade dafür gedacht,
    einen Zugriff von aussen stattfinden lassen zu können. => Man kann daher den Eindruck gewinnen, dass private Methoden wenig sinnvoll sind.
    Dies ist tatsächlich auch oft der Fall, aber natürlich gibt es eine Ausnahme, den wir uns im Folgenden anschauen wollen:
*/
using System;
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


namespace G_44_Klassen_PrivateMethoden
{
    class Beispielsklasse
    {
        private int KomplizierteTeilberechnung_1()
        {
            // ...
            // ...
            // ... komplizierte Code
            // ...
            // ...
            return 11;
        }

        private int KomplizierteTeilberechnung_2()
        {
            // ...
            // ...
            // ... komplizierte Code
            // ...
            // ...
            return 4700;
        }

        public int Gesamtergebnis()
        {
            return KomplizierteTeilberechnung_1() + KomplizierteTeilberechnung_2();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Beispielsklasse b = new Beispielsklasse();
            int rückgabewert = b.Gesamtergebnis();
            Console.WriteLine(rückgabewert);

            Console.ReadKey();
        }
    }
}