using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace klasse_aufgabe_3
{
    enum Sieger { ist_A_Mann, ist_B_Mann };
    class A_Mann
    {
       public string name;
       public int x, y;
       public bool ImSpiel;
        public override string ToString()
        {
            return "Name: " + name + "  x: " + x+" y: "+y;
        }
        public void Jubeln()
        {
            Console.WriteLine("Ich liebe es wenn ein Plan funktioniert");
    
        }
        public void Heulen()
        {
            Console.WriteLine("Ich hasse es wenn ein Plan scheitert");
        }
        public void Gruessen(A_Mann a)
        {
            Console.WriteLine("Hallo  "+a.name);

        }

    }
    class B_Mann
    {
        public string name;
        public int x, y;
        public bool ImSpiel;
        public override string ToString()
        {
            return "Name: " + name + "  x: " + x + " y: " + y;
        }
        public void Jubeln()
        {
            Console.WriteLine("Wir B-Männer sind Siegertypen");

        }
        public void Heulen()
        {
           
            Console.WriteLine("Pah, der A-Mann hatte nur Glück");
        }
        public void Gruessen(B_Mann b)
        {
            Console.WriteLine("Hallo  " + b.name);

        }


    }
    class Program
    {
        

        static void Main(string[] args)
        {
            int[,] spielfeld =
            {
                {1,1,1,1,1,1,1,1,1,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,1,1,1,1,1,1,1,1,1 }
            };
            for (int y = 0; y < spielfeld.GetLength(1); y++)
            {
                for (int x = 0; x < spielfeld.GetLength(0); x++)
                {
                    if (spielfeld[y, x] == 0)
                    {
                        Console.Write(" ");
                    }
                    else if(spielfeld[y,x]==1)
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();

            }
            //const int BOARD_X = 10;
            //const int BOARD_Y = 10;
            //const int SPIELER = 5;

            //List<int> positions = Enumerable.Range(0, BOARD_X * BOARD_Y).ToList();
            var rnd = new Random();
            //for (int i = 0; i < SPIELER; i++)
            //{
            //    int index = rnd.Next(positions.Count);
            //    int pos = positions[index];
            //    positions.RemoveAt(index);
            //    int x = pos % BOARD_X, y = pos / BOARD_X;
            //    Console.WriteLine("({0}, {1})", x, y);
            //}
            //List<int> possible = Enumerable.Range(0, 10).ToList();
            //List<int> listNumbers = new List<int>();
            //for (int i = 0; i < ; i++)
            //{
            //    int index = rnd.Next(0, possible.Count);
            //    listNumbers.Add(possible[index]);
            //    possible.RemoveAt(index);
            //}

            A_Mann aeins = new A_Mann();
            A_Mann azwei = new A_Mann();
            A_Mann adrei = new A_Mann();
            A_Mann avier = new A_Mann();
            A_Mann afuenf = new A_Mann();
            afuenf.name = "Fred";
            Random rand = new Random();
            List<A_Mann> aliste = new List<A_Mann>();
            aliste.Add(new A_Mann() { name = "Achim", x=rand.Next(0,spielfeld.GetLength(0)),y=rand.Next(0,spielfeld.GetLength(1)),ImSpiel=true });
            aliste.Add(new A_Mann() { name = "Albert", x = rand.Next(0, spielfeld.GetLength(0)), y = rand.Next(0, spielfeld.GetLength(1)), ImSpiel = true });
            aliste.Add(new A_Mann() { name = "Alex", x = rand.Next(0, spielfeld.GetLength(0)), y = rand.Next(0, spielfeld.GetLength(1)), ImSpiel = true });
            aliste.Add(new A_Mann() { name = "Anton", x = rand.Next(0, spielfeld.GetLength(0)), y = rand.Next(0, spielfeld.GetLength(1)), ImSpiel = true });
            aliste.Add(new A_Mann() { name = "August", x = rand.Next(0, spielfeld.GetLength(0)), y = rand.Next(0, spielfeld.GetLength(1)), ImSpiel = true });
            aliste.Add(afuenf);

            //Console.WriteLine();
            foreach (A_Mann al in aliste)
            {
                Console.WriteLine(al);
            }


            List<B_Mann> bliste = new List<B_Mann>();
            bliste.Add(new B_Mann() {name="Bert", x = rand.Next(0, spielfeld.GetLength(0)), y = rand.Next(0, spielfeld.GetLength(1)), ImSpiel=true });
            bliste.Add(new B_Mann() {name = "Benjamin", x = rand.Next(0, spielfeld.GetLength(0)), y = rand.Next(0, spielfeld.GetLength(1)), ImSpiel = true });
            bliste.Add(new B_Mann() {name = "Bjoern", x = rand.Next(0, spielfeld.GetLength(0)), y = rand.Next(0, spielfeld.GetLength(1)), ImSpiel = true });
            bliste.Add(new B_Mann() {name = "Bodo", x = rand.Next(0, spielfeld.GetLength(0)), y = rand.Next(0, spielfeld.GetLength(1)), ImSpiel = true });
            bliste.Add(new B_Mann() {name = "Bruno", x = rand.Next(0, spielfeld.GetLength(0)), y = rand.Next(0, spielfeld.GetLength(1)), ImSpiel = true });

            foreach (B_Mann bl in bliste)
            {
                Console.WriteLine(bl);
            }


            //A_Mann aeins = new A_Mann();
            //A_Mann azwei = new A_Mann();
            //A_Mann adrei = new A_Mann();
            //A_Mann avier = new A_Mann();
            //A_Mann afuenf = new A_Mann();
            Console.ReadKey();
        }
    }
}
