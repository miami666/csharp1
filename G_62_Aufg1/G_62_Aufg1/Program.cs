/*
 *  Schreiben Sie ein C# Programm,
 *  das die Klasse "InputKey" einführt.
 *      Dort soll in einer Methode in einer Endlosschleife vom Benutzer 
 *      ein tastendruck mit ReadKey(true) abgefragt werden.
 * Führen Sie den Delegaten InputEventHandler(char c) und ein passendes Event ein.
 *      Dieses Event soll nach jedem Tastendruck aufgerufen werden, wenn es aboniert wurde.
 *      Machen Sie sich mit dieser Schreibweise vertraut InputEvent?.Invoke(c);
 * Im Main soll nun das Event mit einer Methode aboniert werden.
 *      Diese Methode reagiert auf jeden Tastendruck mit der Ausgabe
 *      "Sie haben " + c + " gedrückt"
 * 
 * 
 *  Erweitern Sie Ihr Programm durch die Klasse Figur.
 *      Figur hat drei öffentliche Properties "int PosX", "int PosY" und "char Zeichen".
 *      Im Konstruktor soll das Zeichen mit einem übergebenen Wert initialisiert werden.
 *      Außerdem werden PosX und PosY auf die Hälfte der Konsolen-Breite und Höhe gesetzt.
 *  Erstellen Sie in Ihrer Klasse Program die Methode "ZeichneFigur", 
 *  die als Übergabewert eine Figur erhält.
 *      In dieser Methode setzen Sie den Cursor auf die X- und Y-Position der Figur und
 *      schreiben an diese Stelle das Zeichen, wenn sich die Koordinaten noch innerhalb des Fensters befinden.
 *  Ihre Event-Methode ändern Sie nun so ab, 
 *  dass sich die Figur durch Drücken der WASD Tasten auf dem Bildschirm bewegt.
 *      (z.B. dadurch, dass Sie die X- und Y-Positionen anpassen)
 *  Die Methode in der InputKey-Klasse können Sie nun noch so erweitern, 
 *  dass die Methode bzw. die Endlosschleife durch drücken der Escape-Taste beendet wird.
 *      Hinweis: ConsoleKey.Escape
 *
 *  Erzeugen Sie nun im Main ein Objekt der Figur und testen Sie das Programm.
 *  
 *  Zweite Erweiterung:
 *  Die Klasse Figur vererbt nun an die Klassen Spieler und Gegner
 *  In der Klasse Gegner implementieren Sie eine statische Liste, in die jedes Gegner-Objekt über den Konstruktor eingetragen wird.
 *  Die Methode "ZeichneFigur" wird in die Klasse Figur verschoben und mit virtual gekennzeichnet.
 *  Um jetzt die Figuren zu zeichnen, implementieren Sie in der Program-Klasse die Methode "zeichne()", 
 *  die nun zuerst für alle Gegner aus der Gegnerliste und dann für den Spieler die ZeichneFigur-Methode aufruft.
 *  In der Klasse Spieler überschreiben Sie nun die Methode. 
 *      Zuerst wird die Methode der Basisklasse aufgerufen, anschließend die Methode "checkKollision()",
 *      die Sie ebenfalls in Spieler implementieren. 
 *  Die Methode "checkKollision()" prüft nun jedes Element in der Gegnerliste, 
 *  ob die Position des Gegners mit der eigenen übereinstimmt.
 *      Ist dies der Fall, dann soll eine Methode "SagHallo(Figur figur)" aufgerufen werden, 
 *      in der der Gegner gegrüßt wird (Eine Textausgabe soll am oberen Rand des Bildschirmes relativ zentriert erfolgen).
 *      
 *  Legen Sie in Ihrem Programm zwei Gegner-Objekte an, weisen Sie ihnen gültige Positionen auf dem Bildschirm zu
 *  und probieren Sie die neuen Funktionalitäten aus.
 *  
 *  Wie Sie weiterhin das Programm erweitern, ist Ihnen überlassen. Sie können die Gegner sich bewegen lassen, sie bekämpfen, 
 *  Punkte Zählen oder Hindernisse einbauen.
 */


using System;
using System.Threading;

namespace G_62_Aufg1
{
    class Program
    {
        static Spieler spieler = new Spieler('@');
        static Gegner gegner1 = new Gegner('§');
        static Gegner gegner2 = new Gegner('X');
        static Gegner gegner3 = new Gegner('€');

        static InputKey input;
        static Thread inputThread;
        static Thread bewegeGegnerThread;


        static void Main(string[] args)
        {
            for (int i = 1; i < Console.WindowHeight - 2; i++)
            {
                new Hindernis('#', 0, i);
                new Hindernis('#', Console.WindowWidth - 2, i);
            }

            for (int i = 1; i < Console.WindowWidth - 2; i++)
            {
                new Hindernis('#', i, 0);
                new Hindernis('#', i, Console.WindowHeight - 2);
            }

            new Hindernis('M', 20, 10);
            new Hindernis('M', 30, 10);
            new Hindernis('M', 40, 20);

            input = new InputKey();
            input.InputEvent += spieler.Bewegen;

            gegner1.PosX = Console.WindowWidth / 3;
            gegner1.PosY = Console.WindowHeight / 3;
            gegner2.PosX = Console.WindowWidth / 2;
            gegner2.PosY = Console.WindowHeight / 3;

            Console.CursorVisible = false;

            zeichne();

            //Optional: Bewege Gegner mit Multithreading
            inputThread = new Thread(input.startInput);
            inputThread.Start();
            bewegeGegnerThread = new Thread(bewegeGegner);
            bewegeGegnerThread.IsBackground = true;
            bewegeGegnerThread.Start();

        }

        static void bewegeGegner()
        {
            while (true)
            {
                foreach (Gegner gegner in Gegner.GegnerListe)
                {
                    gegner.Bewegen();
                }
                zeichne();
                Thread.Sleep(1000);
            }
        }


        static void zeichne()
        {
            foreach (Gegner gegner in Gegner.GegnerListe)
            {
                gegner.zeichneFigur();
            }
            foreach (Hindernis hindernis in Hindernis.HindernisListe)
            {
                hindernis.zeichneFigur();
            }

            spieler.zeichneFigur();
        }

    }
}
