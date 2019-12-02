using System;
using System.Collections.Generic;


namespace G_62_Aufg1
{

    class Figur
    {
        public static Random rnd = new Random();
        public int PosX { get; set; }
        public int PosY { get; set; }
        public char Zeichen { get; private set; }

        public Figur(char zeichen)
        {
            PosX = Console.WindowWidth / 2;
            PosY = Console.WindowHeight / 2;
            Zeichen = zeichen;
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
