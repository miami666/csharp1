using System;
using System.Collections.Generic;
using System.Linq;
/*
    Führen Sie bitte die folgende Enumeration ein:
        Sieger (mit den Konstanten ist_A und ist_B)
    Führen Sie bitte die beiden folgenden Klassen ein:
        A
            String: Name
            Integer: x, y
            Bool: ImSpiel
            Methoden:
                a) Name: Jubeln
                   Übergabewerte: Keine
                   Funktion: Konsolenausgabe: "Ich liebe es, wenn ein Plan funktioniert!"
                   Rückgabewert: Keiner
                b) Name: Heulen
                   Übergabewerte: Keine
                   Funktion: Konsolenausgabe: "Ich hasse es, wenn ein Plan scheitert!"
                   Rückgabewert: Keiner
                c) Name: Grüßen
                   Übergabewerte: eine Variable a vom Typ A-Mann
                   Funktion: Konsolenausgabe: Hallo + Name von a +"!"
                   Rückgabewert: Keiner
        B
            String: Name
            Integer: x, y
            Bool: ImSpiel
            Methoden:
                a) Name: Jubeln
                   Übergabewerte: Keine
                   Funktion: Konsolenausgabe: "Wir B-Männer sind Siegertypen!"
                   Rückgabewert: Keiner
                b) Name: Heulen
                   Übergabewerte: Keine
                   Funktion: Konsolenausgabe: "Pah, der A-Mann hatte nur Glück ..."
                   Rückgabewert: Keiner
                c) Name: Grüßen
                   Übergabewerte: eine Variable b vom Typ B-Mann
                   Funktion: Konsolenausgabe: Hallo + Name von b +"!"
                   Rückgabewert: Keiner
   Main-Methode:
        - Führen Sie bitte ein Spielfeld ein (wählen Sie selbst Breite und Höhe)
        - Führen Sie 5 Spieler vom Typ A auf der linken Seite des Spielfelds mit zufälligen Positionen ein
          (Kein Spieler darf auf ein bereits bestzes Feld)
        - Führen Sie 5 Spieler vom Typ B auf der rechten Seite des Spielfelds mit zufälligen Positionen ein
          (Kein Spieler darf auf ein bereits bestzes Feld)
        - Jeder A wird in einer Liste namens 'aListe' abgespeichert
        - Jeder B wird in einer Liste namens 'bListe' abgespeichert
        - Die A_Männer werden der Reihe nach "Achim", "Albert", "Anton", "August" oder "Axel" genannt
        - Die B_Männer werden der Reihe nach "Bert", "Benjamin", "Björn", "Bodo" oder "Bruno" genannt
        - Jeder Mann speichert unter x und y die ausgeloste Position und den Wert 'true' bei ImSpiel
        Es startet eine Schleife, pro Durchlauf ...
         - wandern alle Männer auf ein zufälliges Nachbarfeld (falls nicht dabei das Spielfeld verlassen werden würde)
         - grüßen sich die beiden A_Männer, falls sie auf einem identischen Feld landen
         - grüßen sich die beiden B_Männer, falls sie auf einem identischen Feld landen
         - kämpfen A gegen B, falls sie auf einem identischen Feld landen
           + der Sieger wird ausgelost
           + der Sieger jubelt
           + der Verlierer heult
           + beim Verlierer wird ImSpiel auf 'false' gesetzt
           + der verlierer wird aus seiner Liste entfernt
        ... die Schleife endet, falls nur noch Spieler von einem Team übrig geblieben sind
*/

namespace avsb
{
    //enum Sieger { ist_A, ist_B }
    class A
    {
        public string name;
        public int x, y;
        public bool ImSpiel;

        public A(string _name, int _x, int _y)
        {
            name = _name;
            x = _x;
            y = _y;
            ImSpiel = true;
        }
        public override string ToString()
        {
            return "Name: " + name + "  x: " + x + " y: " + y;
        }
        public void Jubeln()
        {
            Console.WriteLine($"{name}: Ich liebe es wenn ein Plan funktioniert");
        }
        public void Heulen()
        {
            Console.WriteLine($"{name}: Ich hasse es wenn ein Plan scheitert");
        }
        public void Gruessen(A a)
        {
            Console.WriteLine($"{name}: Hallo {a.ToString()}");
        }

    }
    class B
    {
        public string name;
        public int x, y;
        public bool ImSpiel;
        public B(string _name, int _x, int _y)
        {
            name = _name;
            x = _x;
            y = _y;
            ImSpiel = true;
        }
        public override string ToString()
        {
            return "Name: " + name + "  x: " + x + " y: " + y;
        }
        public void Jubeln()
        {
            Console.WriteLine($"{name}: Wir B-Männer sind Siegertypen");

        }
        public void Heulen()
        {

            Console.WriteLine($"{name}: Pah, der A-Mann hatte nur Glück");
        }
        public void Gruessen(B b)
        {
            Console.WriteLine($"{name}: Hallo {b.ToString()} ");
        }

    }
    class Pos
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class Program
    {
        static readonly Random rnd = new Random();
        static Pos[] GenRndUniqPointArray(int minX, int maxX, int minY, int maxY, int count)
        {
            Pos[] result = new Pos[count];
            Pos p;
            for (int i = 0; i < count; i++)
            {
                do
                {
                    p = new Pos { X = rnd.Next(minX, maxX), Y = rnd.Next(minY, maxY) };
                } while (result.Contains(p));
                result[i] = p;
            }
            return result;
        }
        static Pos Move(int x, int y)
        {
            Pos result = new Pos { X = x, Y = y };
            bool[] can = new bool[4] { true, true, true, true };
            int move;
            if (x == 0) { can[0] = false; }
            if (x == 9) { can[1] = false; }
            if (y == 0) { can[3] = false; }
            if (y == 9) { can[2] = false; }

            do
            {
                move = rnd.Next(0, 4);
            } while (!can[move]);

            switch (move)
            {
                case 0:
                    //move UP
                    result.X = x - 1;
                    break;
                case 1:
                    //move Down
                    result.X = x + 1;
                    break;
                case 2:
                    //move Right
                    result.Y = y + 1;
                    break;
                case 3:
                    //move Left
                    result.Y = y - 1;
                    break;
            }
            if (result.X < 0 || result.Y < 0 || result.X > 9 || result.Y > 9)
            {
                Console.WriteLine("bad!!!!!!!!!!!!!!!!!!!");
            }
            return result;
        }
        static void PrintGF(List<A> a, List<B> b)
        {
            //gamefield
            int[,] gf = new int[10, 10];
            foreach (A al in a)
            {
                //Console.WriteLine(al);
                if (al.ImSpiel) { gf[al.x, al.y] = 9; }
            }
            foreach (B bl in b)
            {
                Console.WriteLine(bl);
                if (bl.ImSpiel) { gf[bl.x, bl.y] = 8; }
            }

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (gf[y, x] == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" A");
                        Console.ResetColor();
                    }
                    else if (gf[y, x] == 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" B");

                        Console.ResetColor();
                    }
                    else { Console.Write(" 0"); }
                }
                Console.WriteLine(); //next line
            }
            Console.WriteLine("\n\n");
        }

        static void Main()
        {
            //gen uniq points(x,y) for 5x as and 5x bs
            //an array of 10 uniq points
            Pos[] points = GenRndUniqPointArray(0, 10, 0, 10, 10);

            string[] a_names = new string[5] { "Achim", "Albert", "Alex", "Anton", "August" };
            List<A> alist = new List<A>();
            //fill a_man list
            for (int i = 0; i < 5; i++)
            {
                alist.Add(new A(a_names[i], points[i].X, points[i].Y));
            }
            string[] b_names = new string[5] { "Bert", "Benjamin", "Bjoern", "Bodo", "Bruno" };
            List<B> blist = new List<B>();
            //fill b_man list
            for (int i = 5; i < 10; i++)
            {
                blist.Add(new B(b_names[i - 5], points[i].X, points[i].Y));
            }
            //setup done - print gamefield
            PrintGF(alist, blist);
            do
            {
                //first is a`s turn
                for (int i = alist.Count - 1; i >= 0; i--)
                {
                    Pos p = Move(alist[i].x, alist[i].y);
                    bool moved = false;
                    foreach (A am in alist)
                    {
                        if (am.ImSpiel && am.x == p.X && am.y == p.Y)
                        {
                            //in case a_man meets another a_man
                            alist[i].Gruessen(am);
                            //Console.WriteLine(am);
                            moved = true;
                            break;
                        }
                    }
                    if (moved)
                    {
                        alist[i].x = p.X;
                        alist[i].y = p.Y;
                        continue;
                    }
                    foreach (B bm in blist)
                    {
                        if (bm.ImSpiel && bm.x == p.X && bm.y == p.Y)
                        {
                            //a_man meets b_man = fight with random result!!!!
                            int isA_winner = rnd.Next(0, 2);
                            //if 0 a wins else b wins
                            if (isA_winner == 0)
                            {
                                alist[i].Jubeln();
                                bm.Heulen();
                                blist[blist.IndexOf(bm)].ImSpiel = false;
                                blist.RemoveAt(blist.IndexOf(bm));
                            }
                            else
                            {
                                alist[i].Heulen();
                                alist[i].ImSpiel = false;
                                alist.RemoveAt(i);
                            }
                            break;
                        }
                    }
                    if (i < alist.Count)
                    {

                        alist[i].x = p.X;
                        alist[i].y = p.Y;
                    }
                }

                //b´s turn
                for (int i = blist.Count - 1; i >= 0; i--)
                {
                    Pos p = Move(blist[i].x, blist[i].y);
                    bool moved = false;
                    foreach (B bm in blist)
                    {
                        if (bm.x == p.X && bm.y == p.Y)
                        {
                            //b_man meets another b_man
                            blist[i].Gruessen(bm);                          
                            moved = true;
                            break;
                        }
                    }
                    if (moved)
                    {
                        blist[i].x = p.X;
                        blist[i].y = p.Y;
                        continue;
                    }
                    foreach (A am in alist)
                    {
                        if (am.ImSpiel && am.x == p.X && am.y == p.Y)
                        {
                            //b_man meets a_man=fight with random result
                            int isA_winner = rnd.Next(0, 2);
                            //if n0 a wins else b wins
                            if (isA_winner == 0)
                            {
                                blist[i].Jubeln();
                                am.Heulen();
                                alist[alist.IndexOf(am)].ImSpiel = false;
                                alist.RemoveAt(alist.IndexOf(am));
                            }
                            else
                            {
                                blist[i].Heulen();
                                blist[i].ImSpiel = false;
                                blist.RemoveAt(i);
                            }
                            break;
                        }
                    }
                    if (i < blist.Count)
                    {
                        blist[i].x = p.X;
                        blist[i].y = p.Y;
                    }
                }
                Console.WriteLine($"a{alist.Count} - b{blist.Count}");
                PrintGF(alist, blist);
                System.Threading.Thread.Sleep(1000);
                if (blist.Count <= 1 || alist.Count <= 1) { break; }
            }
            while (blist.Count > 1 && alist.Count > 1);
            //done - print gamefield
            Console.WriteLine($"a{alist.Count} - b{blist.Count}");
            PrintGF(alist, blist);
            Console.WriteLine("press any key ...");
            Console.ReadKey(true);
            if (blist.Count == 1)
            {
                Console.WriteLine("team a wins!!!!!!!!!!!!! b count " + 1);
            }
            else if (alist.Count == 1)
            {
                Console.WriteLine("team b wins!!!!!!!!!!!!! a count" + 1);
            }
            Console.ReadKey();
        }
    }
}