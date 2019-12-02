using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace event_aufgabe_1
{
    class InputKey
    {
    char c;   
    public delegate void InputEventHandler(char c);
    public event InputEventHandler ieh;
    public void BenutzerEingabe()
        {
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();
                ieh?.Invoke(keyinfo.KeyChar);
            }
            while (keyinfo.Key != ConsoleKey.Escape);

            

        }
    }
    class Figur
    {
        public static Random rnd = new Random();
        public int PosX { get; set; }
        public int PosY { get; set; }
        public char Zeichen { get; set; }
        public Figur(char Zeichen)
        {
            this.Zeichen = Zeichen;
            
            PosX = Console.LargestWindowWidth/ 2;
            PosY = Console.LargestWindowHeight / 2;
        }

        public void SagHallo(Figur figur)
        {
            Console.SetCursorPosition(Console.WindowWidth / 3, 0);
            Console.WriteLine(">>Hallo {0}!<<", figur.Zeichen);
        }

        public virtual void zeichneFigur()
        {
            if (PosX >= 0 && PosX < Console.WindowWidth && PosY >= 0 && PosY < Console.WindowHeight)
                Console.SetCursorPosition(PosX, PosY);
            Console.WriteLine(Zeichen);
        }
        protected bool moveIsPossible(int targetX, int targetY)
        {
            foreach (Hindernis hindernis in Hindernis.HindernisListe)
                if (targetX == hindernis.PosX && targetY == hindernis.PosY)
                    return false;

            return true;
        }
        protected void Clear(Figur figur)
        {
            Console.SetCursorPosition(figur.PosX, figur.PosY);
            Console.Write(" ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            InputKey inputKey = new InputKey();
            inputKey.ieh += InputKey_ieh;

            inputKey.BenutzerEingabe();
           
            
        }
        public void ZeichneFigur(Figur f)
        {
            Console.SetCursorPosition(f.PosX, f.PosY);
            Console.Write(f);
        }



        private static void InputKey_ieh(char c)
        {
            Console.WriteLine("Arschloch a hat {0} gefickt",c);
           
        }
    }

    class Spieler : Figur
    {
        public Spieler(char zeichen) : base(zeichen)
        {
        }

        public override void zeichneFigur()
        {
            base.zeichneFigur();
            pruefeBegegnung();
        }
        private void pruefeBegegnung()
        {
            foreach (Gegner gegner in Gegner.GegnerListe)
            {
                if (PosX == gegner.PosX && PosY == gegner.PosY)
                    SagHallo(gegner);
            }
        }
        public void Bewegen(char c)
        {
            Clear(this);
            switch (c)
            {
                case 'w':
                    if (moveIsPossible(PosX, PosY - 1))
                        PosY--;
                    break;
                case 's':
                    if (moveIsPossible(PosX, PosY + 1))
                        PosY++;
                    break;
                case 'a':
                    if (moveIsPossible(PosX - 1, PosY))
                        PosX--;
                    break;
                case 'd':
                    if (moveIsPossible(PosX + 1, PosY))
                        PosX++;
                    break;
            }
            zeichneFigur();

        }
    }

    class Gegner : Figur
    {
        public static List<Gegner> GegnerListe = new List<Gegner>();
        public Gegner(char zeichen) : base(zeichen)
        {
            GegnerListe.Add(this);
        }
        public void Bewegen()
        {
            int neuX = PosX + rnd.Next(-1, 2);
            int neuY = PosY + rnd.Next(-1, 2);
            if (moveIsPossible(neuX, neuY))
            {
                Clear(this);
                PosX = neuX;
                PosY = neuY;
            }
            zeichneFigur();
        }
    }

    class Hindernis : Figur
    {
        public static List<Hindernis> HindernisListe = new List<Hindernis>();
        public Hindernis(char zeichen, int posX, int posY) : base(zeichen)
        {
            PosX = posX; PosY = posY;
            HindernisListe.Add(this);
        }
    }
}

