/*
    Führen Sie bitte die folgende Enumeration ein:
        Sieger (mit den Konstanten ist_A_Mann und ist_B_Mann)

    Führen Sie bitte die beiden folgenden Klassen ein:
        A_Mann
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
        B_Mann
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
        - Führen Sie 5 Spieler vom Typ A_Mann auf der linken Seite des Spielfelds mit zufälligen Positionen ein
          (Kein Spieler darf auf ein bereits bestzes Feld)
        - Führen Sie 5 Spieler vom Typ B_Mann auf der rechten Seite des Spielfelds mit zufälligen Positionen ein
          (Kein Spieler darf auf ein bereits bestzes Feld) 
        - Jeder A_Mann wird in einer Liste namens 'aListe' abgespeichert
        - Jeder B_Mann wird in einer Liste namens 'bListe' abgespeichert 
        - Die A_Männer werden der Reihe nach "Achim", "Albert", "Anton", "August" oder "Axel" genannt
        - Die B_Männer werden der Reihe nach "Bert", "Benjamin", "Björn", "Bodo" oder "Bruno" genannt
        - Jeder Mann speichert unter x und y die ausgeloste Position und den Wert 'true' bei ImSpiel

        Es startet eine Schleife, pro Durchlauf ...
         - wandern alle Männer auf ein zufälliges Nachbarfeld (falls nicht dabei das Spielfeld verlassen werden würde) 
         - grüßen sich die beiden A_Männer, falls sie auf einem identischen Feld landen
         - grüßen sich die beiden B_Männer, falls sie auf einem identischen Feld landen
         - kämpfen A_Mann gegen B_Mann, falls sie auf einem identischen Feld landen
           + der Sieger wird ausgelost
           + der Sieger jubelt
           + der Verlierer heult
           + beim Verlierer wird ImSpiel auf 'false' gesetzt
           + der verlierer wird aus seiner Liste entfernt
        ... die Schleife endet, falls nur noch Spieler von einem Team übrig geblieben sind 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Baustein
{
    class A_Mann
    {
        public string Name;
        public int X;
        public int Y;
        public bool ImSpiel;

        public void Jubeln()
        {
            Console.WriteLine("Ich liebe es, wenn ein Plan funktioniert!");
        }

        public void Heulen()
        {
            Console.WriteLine("Ich hasse es, wenn ein Plan scheitert!");
        }

        public void Grüßen(A_Mann a)
        {
            Console.WriteLine("Hallo " + a.Name + "!");
        }
    }

    class B_Mann
    {
        public string Name;
        public int X;
        public int Y;
        public bool ImSpiel;

        public void Jubeln()
        {
            Console.WriteLine("Wir B-Männer sind Siegertypen!!");
        }

        public void Heulen()
        {
            Console.WriteLine("Pah, der A-Mann hatte nur Glück ...");
        }

        public void Grüßen(B_Mann b)
        {
            Console.WriteLine("Hallo " + b.Name + "!");
        }
    }


    class Program
    {
        enum Sieger { ist_A_Mann, ist_B_Mann };

        static void Main(string[] args)
        {
            Random zufGenerator = new Random();

            const int breite = 30;
            const int höhe = 20;
            const int startX = 5;
            const int startY = 2;
            const int anzSpieler = 5; // (pro Team)

            int infoX = 50;
            int infoY = 3;
            int infoZahl = 0;

            string[] aName = new string[5] { "Achim", "Albert", "Anton", "August", "Axel" };
            string[] bName = new string[5] { "Bert", "Benjamin", "Björn", "Bodo", "Bruno" };


            int x, y, richtung;
            bool neuesFeldGefunden;

            List<A_Mann> aListe = new List<A_Mann>();
            List<B_Mann> bListe = new List<B_Mann>();

            // LEERES BRETT **************************************************************************************
            for (int h = 0; h < höhe; h++)
            {
                for (int b = 0; b < breite; b++)
                {
                    Console.SetCursorPosition(startX + b, startY + h);
                    Console.Write(".");
                }
            }

            // ZUFALLSPOSITION **************************************************************************************
            // A-Männer:
            for (int i = 0; i < anzSpieler; i++)
            {
                do
                {
                    neuesFeldGefunden = true;
                    x = zufGenerator.Next(0, breite / 2);
                    y = zufGenerator.Next(0, höhe);
                    foreach (A_Mann a in aListe) if (a.X == x && a.Y == y) neuesFeldGefunden = false;
                    if (neuesFeldGefunden) foreach (B_Mann b in bListe) if (b.X == x && b.Y == y) neuesFeldGefunden = false;
                }
                while (!neuesFeldGefunden);
                A_Mann A = new A_Mann();
                A.Name = aName[i];
                A.X = x;
                A.Y = y;
                A.ImSpiel = true;
                aListe.Add(A);
                Console.SetCursorPosition(startX + x, startY + y);
                Console.Write("A");
            }
            // B-Männer:
            for (int i = 0; i < anzSpieler; i++)
            {
                do
                {
                    neuesFeldGefunden = true;
                    x = zufGenerator.Next(breite / 2 + 1, breite);
                    y = zufGenerator.Next(0, höhe);
                    foreach (A_Mann a in aListe) if (a.X == x && a.Y == y) neuesFeldGefunden = false;
                    if (neuesFeldGefunden) foreach (B_Mann b in bListe) if (b.X == x && b.Y == y) neuesFeldGefunden = false;
                }
                while (!neuesFeldGefunden);
                B_Mann B = new B_Mann();
                B.Name = bName[i];
                B.X = x;
                B.Y = y;
                B.ImSpiel = true;
                bListe.Add(B);
                Console.SetCursorPosition(startX + x, startY + y);
                Console.Write("B");
            }

            // ZUFALSWANDERN / TREFFEN / KÄMPFEN ******************************************************************************************
            do
            {
                // A-Männer WANDERN
                foreach (A_Mann a in aListe)
                {
                    richtung = zufGenerator.Next(0, 8);
                    Console.SetCursorPosition(startX + a.X, startY + a.Y);
                    Console.Write(".");
                    switch (richtung)
                    {
                        case 0: if (a.Y > 0) a.Y = a.Y - 1; break;
                        case 1: if (a.Y > 0 && a.X < breite - 1) { a.Y = a.Y - 1; a.X = a.X + 1; } break;
                        case 2: if (a.X < breite - 1) a.X = a.X + 1; break;
                        case 3: if (a.Y < höhe - 1 && a.X < breite - 1) { a.Y = a.Y + 1; a.X = a.X + 1; } break;
                        case 4: if (a.Y < höhe - 1) a.Y = a.Y + 1; break;
                        case 5: if (a.Y < höhe - 1 && a.X > 0) { a.Y = a.Y + 1; a.X = a.X - 1; } break;
                        case 6: if (a.X > 0) a.X = a.X - 1; break;
                        case 7: if (a.Y > 0 && a.X > 0) { a.Y = a.Y - 1; a.X = a.X - 1; } break;
                    }
                    Console.SetCursorPosition(startX + a.X, startY + a.Y);
                    Console.Write("A");
                }

                // B-Männer WANDERN
                foreach (B_Mann a in bListe)
                {
                    richtung = zufGenerator.Next(0, 8);
                    Console.SetCursorPosition(startX + a.X, startY + a.Y);
                    Console.Write(".");
                    switch (richtung)
                    {
                        case 0: if (a.Y > 0) a.Y = a.Y - 1; break;
                        case 1: if (a.Y > 0 && a.X < breite - 1) { a.Y = a.Y - 1; a.X = a.X + 1; } break;
                        case 2: if (a.X < breite - 1) a.X = a.X + 1; break;
                        case 3: if (a.Y < höhe - 1 && a.X < breite - 1) { a.Y = a.Y + 1; a.X = a.X + 1; } break;
                        case 4: if (a.Y < höhe - 1) a.Y = a.Y + 1; break;
                        case 5: if (a.Y < höhe - 1 && a.X > 0) { a.Y = a.Y + 1; a.X = a.X - 1; } break;
                        case 6: if (a.X > 0) a.X = a.X - 1; break;
                        case 7: if (a.Y > 0 && a.X > 0) { a.Y = a.Y - 1; a.X = a.X - 1; } break;
                    }
                    Console.SetCursorPosition(startX + a.X, startY + a.Y);
                    Console.Write("B");
                }

                // A-Männer TREFFEN
                foreach (A_Mann m1 in aListe)
                {
                    foreach (A_Mann m2 in aListe)
                    {
                        if (!m1.Equals(m2))
                        {
                            if (m1.X == m2.X && m1.Y == m2.Y)
                            {
                                Console.SetCursorPosition(infoX, infoY + infoZahl);
                                m1.Grüßen(m2);
                                infoZahl++;
                            }
                        }
                    }
                }

                // B-Männer TREFFEN
                foreach (B_Mann m1 in bListe)
                {
                    foreach (B_Mann m2 in bListe)
                    {
                        if (!m1.Equals(m2))
                        {
                            if (m1.X == m2.X && m1.Y == m2.Y)
                            {
                                Console.SetCursorPosition(infoX, infoY + infoZahl);
                                m1.Grüßen(m2);
                                infoZahl++;
                            }
                        }
                    }
                }

                // A<->B-KAMPF
                foreach (A_Mann a in aListe.ToList())
                {
                    foreach (B_Mann b in bListe.ToList())
                    {
                        if (a.X == b.X && a.Y == b.Y)
                        {
                            switch (zufGenerator.Next(2))
                            {
                                case (int)Sieger.ist_A_Mann:
                                    Console.SetCursorPosition(infoX, infoY + infoZahl);
                                    a.Jubeln();
                                    infoZahl++;
                                    Console.SetCursorPosition(infoX, infoY + infoZahl);
                                    b.Heulen();
                                    b.ImSpiel = false;
                                    infoZahl++;
                                    bListe.Remove(b);
                                    Console.SetCursorPosition(startX + a.X, startY + a.Y);
                                    Console.WriteLine("A");
                                    break;
                                case (int)Sieger.ist_B_Mann:
                                    Console.SetCursorPosition(infoX, infoY + infoZahl);
                                    b.Jubeln();
                                    infoZahl++;
                                    Console.SetCursorPosition(infoX, infoY + infoZahl);
                                    a.Heulen();
                                    a.ImSpiel = false;
                                    infoZahl++;
                                    aListe.Remove(a);
                                    Console.SetCursorPosition(startX + a.X, startY + a.Y);
                                    Console.WriteLine("B");
                                    break;
                            }
                        }
                    }
                }
                if (infoZahl > 30)
                {
                    infoZahl = 0;
                    infoX = infoX + 50;
                    infoY = 3;
                }
            }
            while (aListe.Count() > 0 && bListe.Count() > 0);


            Console.ReadKey();
        }
    }
}