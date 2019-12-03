using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ereignisse_events
{
    class InputKey
    {
        public delegate void InputEventHandler(Figur f, ConsoleKeyInfo Eingabe);
        public event InputEventHandler OnInput = null;
        // Wenn ein Knopf auf der Tastatur gedrückt wird, guckt er im Delegaten
        // ob auf die Eingabe reagiert werden muss.
        public void EingabeTaste(Object f)
        {
            do { OnInput(f as Spieler, Console.ReadKey(true)); } while (true);
        }
    }
    class Figur
    {
        // Random-Object für alle möglichen Random-Aufrufe
        public static Random rd = new Random();
        public Figur(char c) { Zeichen = c; }
        private int x;
        private int y;
        public int PosX
        {
            get => x;
            set
            {
                LoeschePos();
                // Stellt sicher, dass die neue Koordinate im "Konsolen-Frame" ist
                if (value > 1 && value < Console.WindowWidth - 2) x = value;
            }
        }
        public int PosY
        {
            get => y;
            set
            {
                LoeschePos();
                // Stellt sicher, dass die neue Koordinate im "Konsolen-Frame" ist
                if (value > 0 && value < Console.WindowHeight - 1) y = value;
            }
        }
        public char Zeichen { get; protected set; }
        public virtual void ZeichneFigur()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.Write(Zeichen);
        }
        private void LoeschePos()
        {
            // Überschreibt das alte Zeichen auf der Konsole
            Console.SetCursorPosition(PosX, PosY);
            Console.Write(' ');
        }
    }
    class Enemy : Figur
    {
        public Enemy() : base(' ')
        {
            int x, y;
            bool check = false;
            // Sucht Koordinate für das Objekt und checkt ob diese schon vergeben ist.
            // Wenn nicht werden die Koordinaten übernommen
            do
            {
                x = rd.Next(2, Console.WindowWidth - 1);
                y = rd.Next(1, Console.WindowHeight);
                check = false;
                foreach (Enemy g in Enemyliste)
                    if (g.PosX == x && g.PosY == y)
                        check = true;
            } while (check);
            PosX = x; PosY = y;
            Name = GetName();
            Zeichen = Name[0];
            Enemyliste.Add(this);
        }
        public string Name { get; private set; }
        public static List<Enemy> Enemyliste = new List<Enemy>();
        /// <summary>
        /// Sucht einen zufälligen Namen für das Gegner-Objekt heraus
        /// </summary>
        private string GetName()
        {
            string[] Names = { "gerhard Schröder", "Hillary Clinton", "Christoph Merz", "Ursula von der Leyen", "AKK", "Joe Biden", "Boris Johnson",
                            "Boris Becker", "Uschi Glas", "Roy Black", "Dieter Bohlen", "Dagi Bee", "Drachenlord", "Iron Maiden",
                            "Batman", "Cartman", "Bart Simpson", "Homer Simpson", "Mao Tse Tung", "Uli Hoeneß"};
            return Names[rd.Next(0, Names.Length)];
        }
    }
    class Spieler : Figur
    {
        public Spieler() : base('X')
        {
            PosX = Console.WindowWidth / 2;
            PosY = Console.WindowHeight / 2;
            Punkte = 0;
        }
        public int Punkte { get; private set; }
        public override void ZeichneFigur()
        {
            base.ZeichneFigur();
            CheckKollusion();
        }
        // Sicherheits-Variable für evtl überlappende Listen-Aufrufe (evtl nicht mehr nötig)
        public static bool inColl = false;
        private void CheckKollusion()
        {
            bool Collusion = false;
            inColl = true;
            int index = 0;
            // Hier wird geprüft, ob eine Kollision stattfindet
            for (int i = 0; i < Enemy.Enemyliste.Count; i++)
                if (PosX == Enemy.Enemyliste[i].PosX && PosY == Enemy.Enemyliste[i].PosY)
                {
                    Collusion = true;
                    index = i;
                }
            if (Collusion)
            {
                // Wenn ja, schreibe den getroffenen Gegner aus und lösche Ihn von der Liste
                Thread HitDisplay = new Thread(DisplayHits);
                HitDisplay.Start(index);
            }
            // sind alle Gegner raus, ist das Spiel vorbei
            if (Enemy.Enemyliste.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 2);
                Console.Write("┏━━━━━━━━━━━━━━━━━━━━━┓");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 1);
                Console.Write("┃  SPIEL GEWONNEN !!! ┃");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2);
                Console.Write("┃  ENTER drücken ...  ┃");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 + 1);
                Console.Write("┗━━━━━━━━━━━━━━━━━━━━━┛");
                Console.BackgroundColor = ConsoleColor.Black;
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                Environment.Exit(0);
            }
            inColl = false;
        }
        private void DisplayHits(object index)
        {
            Punkte++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 12, 0);
            Console.Write($" {Enemy.Enemyliste[(int)index].Name} wurde getroffen! ");
            Enemy.Enemyliste.RemoveAt((int)index);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(Console.WindowWidth - 10, 0);
            Console.Write($"Punkte: {Punkte,-3}");
            Thread.Sleep(2000);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 12, 0);
            Console.Write("                              	");
        }
    }
    class Program
    {
        static void Zeichne(Figur s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (!Spieler.inColl)
            {
                for (int i = 0; i < Enemy.Enemyliste.Count; i++)
                    Enemy.Enemyliste[i].ZeichneFigur();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            s.ZeichneFigur();
        }
        static int sleep = 50;
        public static void MoveEnemy(Object f)
        {
            // Gegner-Thread Methode
            // Hier werden die Gegner in einem bestimmten Zeitabstand bewegt
            do
            {
                if (Enemy.Enemyliste.Count > 0)
                {
                    //int which = Figur.rd.Next(0, Gegner.GegnerList.Count);
                    for (int which = 0; which < Enemy.Enemyliste.Count; which++)
                    {
                        int Direction = Figur.rd.Next(0, 8);
                        switch (Direction)
                        {
                            case 0: Enemy.Enemyliste[which].PosX++; break;
                            case 1: Enemy.Enemyliste[which].PosX--; break;
                            case 2: Enemy.Enemyliste[which].PosY++; break;
                            case 3: Enemy.Enemyliste[which].PosY--; break;
                            case 4:
                                Enemy.Enemyliste[which].PosX--;
                                Enemy.Enemyliste[which].PosY--; break;
                            case 5:
                                Enemy.Enemyliste[which].PosX--;
                                Enemy.Enemyliste[which].PosY++; break;
                            case 6:
                                Enemy.Enemyliste[which].PosX++;
                                Enemy.Enemyliste[which].PosY--; break;
                            case 7:
                                Enemy.Enemyliste[which].PosX++;
                                Enemy.Enemyliste[which].PosY++; break;
                        }
                    }
                    Zeichne(f as Spieler);
                    Thread.Sleep(sleep * Enemy.Enemyliste.Count);
                    // Geschwindigkeit=Intervall * (noch) existierenden Gegner
                }
            } while (true);
        }
        static void AuswertungTaste(Figur f, ConsoleKeyInfo b)
        {
            // Methode auf die der Ereignis-Delegat verweist
            switch (b.Key)
            {
                case ConsoleKey.W:
                    f.PosY--;
                    break;
                case ConsoleKey.S:
                    f.PosY++;
                    break;
                case ConsoleKey.A:
                    f.PosX--;
                    break;
                case ConsoleKey.D:
                    f.PosX++;
                    break;
                case ConsoleKey.Escape:
                    GegnerThread.Suspend();
                    // Bei Escape Eingabe Abfrage, ob das Spiel beendet werden soll.
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 2);
                    Console.Write("┏━━━━━━━━━━━━━━━━━━━━━┓");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 1);
                    Console.Write("┃  Wirklich Beenden?  ┃");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2);
                    Console.Write("┠─────────────────────┨");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 + 1);
                    Console.Write("┃    	(j/n)    	 ┃");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 + 2);
                    Console.Write("┗━━━━━━━━━━━━━━━━━━━━━┛");
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (Console.ReadKey(true).Key == ConsoleKey.J)
                    {
                        Environment.Exit(0);
                    }
                    else { Console.Clear(); GegnerThread.Resume(); pressed.EingabeTaste(f); }
                    break;
            }
            Zeichne(f);
        }
        static Thread GegnerThread = new Thread(MoveEnemy);
        static InputKey pressed = new InputKey();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            pressed.OnInput += AuswertungTaste;
            for (int i = 0; i < 10; i++)
                new Enemy();
            Spieler f1 = new Spieler();
            Zeichne(f1);
            Thread MainThread = new Thread(pressed.EingabeTaste);
            MainThread.Start(f1);
            // Multithread für die Gegner-Bewegung
            GegnerThread.IsBackground = true;
            GegnerThread.Start(f1);
        }
    }
}
