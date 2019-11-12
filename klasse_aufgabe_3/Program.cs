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
         Random r = new Random(Guid.NewGuid().GetHashCode());
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
        public int GetX(B_Mann b)
            {
                return b.x;
            }
        public void zufallsAktion(B_Mann b)
        {
           
            int actions = r.Next(0, 3);
            switch (actions)
            {
                case 0:
                    if (b.x > 0)
                    {
                        b.x = x - 1;//nach oben (rows)
                    }
                    else
                    {
                        b.x = x + 1;
                    }

                    break;
                case 1:
                    if(b.x<10)
                    {
                        b.x = x + 1; //nachunten (rows)
                    }
                    else
                    {
                        b.x = x - 1;
                    }
                    
                    break;
                case 2:
                    if(b.y>0)
                    {
                        b.y = y - 1; //nach links
                    }
                    else
                    {
                        b.y = y + 1;
                    }
                   
                    
                    break;
                case 3:
                    if(b.y<10)
                    {
                        b.y = y + 1;

                    }
                    else
                    {
                        b.y = y - 1;
                    }
                   
                    break;

                default:
                    //do nothing
                    break;

            }
 
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
            //var rand = new Random();
            //for (int i = 0; i < SPIELER; i++)
            //{
            //    int index = rand.Next(positions.Count);
            //Console.WriteLine(index);
            //   int pos = positions[index];
            //    positions.RemoveAt(index);
            //   int x = pos % BOARD_X, y = pos / BOARD_X;
            //    Console.WriteLine("({0}, {1})", x, y);
            //}
            //List<int> possible = Enumerable.Range(0, 10).ToList();
            //List<int> listNumbers = new List<int>();
            //for (int i = 0; i <5 ; i++)
            //{
            //    int index = rnd.Next(0, possible.Count);
            //    listNumbers.Add(possible[index]);
            //    possible.RemoveAt(index);
            //}
            //Mögliche Koordinaten und mehrdimensionales Array
            int[] PosX = new int[] { 1,2,3,4,5,6,7,8,9,10 };
            int[] PosY = new int[] {1,2,3,4,5,6,7,8,9,10 };
            int[,] savedPos = new int[5, 2];
//Schleifen zur Auswahl von 5 zufälligen X und Y Werten und befüllen des mehrdim. Arrays
            int n = 1;
            int posx = 0;   
                Random rnd = new Random();
            while (n < 6)
            {
                int ix = rnd.Next(0, 10);
                savedPos[posx, 0] = PosX[ix];
                posx++;
                n++;
            }
            posx = 0;
            n = 1;
            while (n < 6)
            {
                int iy = rnd.Next(0, 10);
                 savedPos[posx, 1] = PosY[iy];
                 posx++;
                n++;
            }
            var a1 = new A_Mann() { name = "Achim", x = savedPos[0, 0], y = savedPos[0, 1], ImSpiel = true };
            var a2 = new A_Mann() { name = "Albert", x = savedPos[1, 0], y = savedPos[1, 1], ImSpiel = true };
            var a3 = new A_Mann() { name = "Alex", x = savedPos[2, 0], y = savedPos[2, 1], ImSpiel = true };
            var a4 = new A_Mann() { name = "Anton", x = savedPos[3, 0], y = savedPos[3, 1], ImSpiel = true };
            var a5 = new A_Mann() { name = "August", x = savedPos[4, 0], y = savedPos[4, 1], ImSpiel = true };

            List<A_Mann> aliste = new List<A_Mann>();
            aliste.Add(a1);
            aliste.Add(a2);
            aliste.Add(a3);
            aliste.Add(a4);
            aliste.Add(a5);
   
         
            foreach (A_Mann al in aliste)
            {
                Console.WriteLine(al);
            }
     
            var nums = Enumerable.Range(0, 10).ToArray();
            var rannd = new Random();

            // Shuffle the array
            for (int i = 0; i < 5; ++i)
            {
                int randomIndex = rannd.Next(nums.Length);
                int temp = nums[randomIndex];
                nums[randomIndex] = nums[i];
                nums[i] = temp;
            }

            // Now your array is randomized and you can simply print them in order
            for (int i = 0; i < 5; ++i)
                Console.WriteLine(nums[i]);

            var b1 = new B_Mann() { name = "Bert", x = nums[0], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            var b2 = new B_Mann() { name = "Benjamin", x = nums[1], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            var b3 = new B_Mann() { name = "Bjoern", x = nums[2], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            var b4 = new B_Mann() { name = "Bodo", x = nums[3], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            var b5 = new B_Mann() { name = "Bruno", x = nums[4], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            List<B_Mann> bliste = new List<B_Mann>();
            bliste.Add(b1);
            bliste.Add(b2);
            bliste.Add(b3);
            bliste.Add(b4);
            bliste.Add(b5);

           

            foreach (B_Mann bl in bliste)
            {
                Console.WriteLine(bl);
                    
                
            }
            b1.zufallsAktion(b1);
            b2.zufallsAktion(b2);
            b3.zufallsAktion(b3);
            b4.zufallsAktion(b4);
            b5.zufallsAktion(b5);
            foreach (B_Mann bl in bliste)
            {
                Console.WriteLine(bl);


            }
            Console.ReadKey();


        }
    }
}
