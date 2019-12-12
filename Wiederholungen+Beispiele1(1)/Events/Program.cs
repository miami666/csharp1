using System;
//https://www.codeproject.com/Articles/4773/Events-and-Delegates-simplified

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Zufall z1 = new Zufall();

            // Ereignisse abonnieren
            z1.Gerade += z1_Gerade; //Das bedeutet hier, dass wir der Variable den Namen einer Methode zuweisen
            z1.Größer50 += z1_Größer50; //Diese Zuweisung sollte immer mit += erfolgen!

            for (int i = 1; i < 10; i++)
            {
                z1.Zufallszahlen();
                z1.Zufallszahlen();
            }

            Console.ReadKey();
        }

        //Dies hier sind die Methoden, die durch den Delegate aufgerufen werden können
        static void z1_Größer50(int zahl)
        {
            Console.WriteLine("Ereignis: {0} ist größer als 50!", zahl);
        }

        static void z1_Gerade(int zahl)
        {
            Console.WriteLine("Ereignis: {0} ist gerade!", zahl);
        }
    }

    class Zufall
    {
        // Delegate für EventHandler
        public delegate void ZufallEventHandler(int zahl);
        //Ein Delegate ist quasi ein Platzhalter für eine Methode
        //Darum müssen die Parameter des Delegates mit denen der Methode,
        //die durch den Delegate aufgerufen werden sollen, übereinstimmen


        Random zufall = new Random();
        
        // Ereignisse
        public event ZufallEventHandler Gerade; 
        public event ZufallEventHandler Größer50;
        //Dies stellt eine Variable vom Typ des Delegates dar.
        //Das heißt, dass dieser public Variable nun eine Methode zugewiesen werden kann,
        //Die dem Typ und den Parametern des Delegaten entspricht.
        //Der Unterschied zu normalen Delegate-Variablen hier ist, 
        //dass wir das Schlüsselwort event dazu schreiben, um es als solches zu kennzeichnen


        public void Zufallszahlen()
        {
            int z = zufall.Next(1, 100);
            // Ereignis auslösen, wenn Zufallszahl durch 2 teilbar ist
            if (z % 2 == 0 && Gerade != null)
                Gerade(z);
                //Hier wird nun die Variable des Delegaten aufgerufen
                //Um sicherzustellen, dass der Aufruf erfolgen kann, prüfen wir,
                //ob der Variable ein Wert (in diesem Fall eine Methode) zugewiesen wurde

            // Ereignis auslösen, wenn Zufallszahl größer als 50 ist
            if (z > 50 && Größer50 != null)
                Größer50(z);
        }
    }
}
