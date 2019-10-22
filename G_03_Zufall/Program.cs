using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
User Eingaben durch Zufallswerte simulieren
 */
namespace G_03_Zufall
{
    class Program
    {
        static void Main(string[] args)
        {
            // Einfuehren Zufallsgenerators

            Random zufallsGenerator = new Random();
            Console.WriteLine("eine erste Zufallszahl zwischen 0 und 4 Mrd: " + zufallsGenerator.Next());

            // im obigen Beispiel wurde der ausgeloste Wert lediglich auf der Konsole ausgegeben

            // Beispiel mit Speichern

            Int64 zufallszahl = zufallsGenerator.Next();
            Console.WriteLine("zweite Zufallszahl zwischen 0 und 4 Mrd.: " + zufallszahl);

            //Bestimmung Zufallszahl mit nach oben begrenztem, durch uns bestimmten Wert

            zufallszahl = zufallsGenerator.Next(10);
            Console.WriteLine("Zufallszahl mit nach oben begrenztem, durch uns bestimmten Wert: " + zufallszahl);

            for (int i = 0; i < 10; i++)
                Console.WriteLine((i + 1) + ".:" + zufallsGenerator.Next(3));

            //Bestimmung von Zufallszahlen die nach oben und unten begrenzt ist

            do
            {
                zufallszahl = zufallsGenerator.Next(1, 6);
                Console.WriteLine("Ergebnis: " + zufallszahl);
            } while (zufallszahl != 5);
            //Uwaga: Bei Zufahlszahl !=6 in der Abbruchbedingung würde eine Endlosschleife entstehen, weil Obergrenze explizit des zweiten Parameters zufallsGenerator.Next(1,6)

            //Auslosen einer Zufallszahl  Double zw. selbstgewählten Grenzen
            double untereGrenze = 2.5;
            double obereGrenze = 11.3;
            double zufDouble;

            /*
             * 1.Teillösung: Wenn ich zu allen ausgelosten Zahlen immer untereGrenze addiere, dann ist der kleinste Wert nicht mehr 0 sondern 0+untere Grenze,in diesem Fall also 2.5
             * 2.Teillösung: wenn ich alle ausgelosten Zahlen mit dem Faktor(obereGrenze-untereGrenze) multipliziere, dann verbreitere ich die möglichen Lösungen
             */
            zufDouble = (obereGrenze - untereGrenze) * zufallsGenerator.NextDouble() + untereGrenze;
            Console.WriteLine("Eine Zufallszahl zwischen {0} und {1}: {2}", untereGrenze, obereGrenze, zufDouble);

            //nur in der Ausgabe runden
            Console.WriteLine($"{zufDouble:F2}");
            //um den Zufallswert auf eine Fließkommazahl mit bestimmter Anzahl von Nachkommastellen zu begrenzen
            //verwenden wir die round Methode aus der Math Klasse
            zufDouble = Math.Round(zufDouble, 2);
            Console.WriteLine(zufDouble);

            Console.ReadKey();
        }
    }
}
