using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest
{
    interface IPerformance
    {
        int PerfForArray(int Anz_Durchlauf, int Anz_Elemente);
        int PerfForeachArray(int Anz_Durchlauf, int Anz_Elemente);
        int PerfForList(int Anz_Durchlauf, int Anz_Elemente);
        int PerfForeachList(int Anz_Durchlauf, int Anz_Elemente);
    }
    delegate int MyPerform(int d, int e);
    class Perform_Test : IPerformance
    {
        private static Random rd = new Random();
        public int PerfForArray(int Anz_Durchlauf, int Anz_Elemente)
        {
            int[] Perform = new int[Anz_Elemente];
            Console.WriteLine("----------------------------------------------" +
                                "\n---Performance Test For-Schleife mit Arrays---" +
                                "\n----------------------------------------------");
            Console.WriteLine("Fülle den Array");
            for (int i = 0; i < Anz_Elemente; i++)
                Perform[i] = rd.Next();
            Console.WriteLine("Füllen abgeschlossen...");
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Starte Zeitmessung");
            int temp;
            sw.Start();
            for (int i = 0; i < Anz_Durchlauf; i++)
                for (int j = 0; j < Anz_Elemente; j++)
                    temp = Perform[j];
            sw.Stop();
            Console.WriteLine("Zeitmessung Beendet");
            int ts = Convert.ToInt32(sw.Elapsed.TotalMilliseconds);
            // ts /= Anz_Durchlauf;
            return ts;
        }
        public int PerfForeachArray(int Anz_Durchlauf, int Anz_Elemente)
        {
            int[] Perform = new int[Anz_Elemente];
            int[] Durchlauf = new int[Anz_Durchlauf];
            Console.WriteLine("-------------------------------------------------" +
                            "\n---Performance Test ForEach-Schleife mit Array---" +
                            "\n-------------------------------------------------");
            Console.WriteLine("Fülle den Array");
            for (int i = 0; i < Anz_Elemente; i++)
                Perform[i] = rd.Next();
            Console.WriteLine("Füllen abgeschlossen...");
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Starte Zeitmessung");
            int temp;
            sw.Start();
            foreach (int i in Durchlauf)
                foreach (int j in Perform)
                    temp = j;
            sw.Stop();
            Console.WriteLine("Zeitmessung Beendet");
            int ts = Convert.ToInt32(sw.Elapsed.TotalMilliseconds);
            // ts /= Anz_Durchlauf;
            return ts;
        }
        public int PerfForList(int Anz_Durchlauf, int Anz_Elemente)
        {
            List<int> Perform = new List<int>();
            Console.WriteLine("----------------------------------------------" +
                            "\n---Performance Test For-Schleife mit Listen---" +
                            "\n----------------------------------------------");
            Console.WriteLine("Fülle die Liste");
            for (int i = 0; i < Anz_Elemente; i++)
                Perform.Add(rd.Next());
            Console.WriteLine("Füllen abgeschlossen...");
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Starte Zeitmessung");
            int temp;
            sw.Start();
            for (int i = 0; i < Anz_Durchlauf; i++)
                for (int j = 0; j < Anz_Elemente; j++)
                    temp = Perform[j];
            sw.Stop();
            Console.WriteLine("Zeitmessung Beendet");
            int ts = Convert.ToInt32(sw.Elapsed.TotalMilliseconds);
            // ts /= Anz_Durchlauf;
            return ts;
        }
        public int PerfForeachList(int Anz_Durchlauf, int Anz_Elemente)
        {
            List<int> Perform = new List<int>();
            List<int> Durchlauf = new List<int>();
            Console.WriteLine("--------------------------------------------------" +
                            "\n---Performance Test ForEach-Schleife mit Listen---" +
                            "\n--------------------------------------------------");
            Console.WriteLine("Fülle die Listen");
            for (int i = 0; i < Anz_Elemente; i++)
                Perform.Add(rd.Next());
            for (int i = 0; i < Anz_Durchlauf; i++)
                Durchlauf.Add(0);
            Console.WriteLine("Füllen abgeschlossen...");
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Starte Zeitmessung");
            int temp;
            sw.Start();
            foreach (int i in Durchlauf)
                foreach (int j in Perform)
                    temp = j;
            sw.Stop();
            Console.WriteLine("Zeitmessung Beendet");
            int ts = Convert.ToInt32(sw.Elapsed.TotalMilliseconds);
            // ts /= Anz_Durchlauf;       	 
            return ts;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Perform_Test pt = new Perform_Test();
            MyPerform[] PerformDelegate = { pt.PerfForArray, pt.PerfForeachArray,
            pt.PerfForList, pt.PerfForeachList };
            do
            {
                Console.Clear();
                int Durchlauf;
                do
                {
                    Console.Write("Bitte geben Sie die Anzahl der Durchläufe an:");
                    if (!Int32.TryParse(Console.ReadLine(), out Durchlauf))
                        Console.WriteLine("Falsche Eingabe...");
                    else break;
                } while (true);
                int Elemente;
                do
                {
                    Console.Write("Bitte geben Sie die Anzahl der Elemente an:");
                    if (!Int32.TryParse(Console.ReadLine(), out Elemente))
                        Console.WriteLine("Falsche Eingabe...");
                    else break;
                } while (true);
                int Zeit;
                do
                {
                    Zeit = 0;
                    try
                    {
                        foreach (MyPerform p in PerformDelegate)
                        {
                            Zeit = p(Durchlauf, Elemente);
                            Console.WriteLine($"Anzahl Durchläufe: {Durchlauf}, Anzahl Elemente {Elemente} benötigte: {RechneZeit(Zeit)}");
                        }
                        break;
                    }
                    catch (OutOfMemoryException)
                    {
                        Elemente /= 2;
                        Console.WriteLine("-----------------------------------------------------" +
                                        "\n--- Es ist ein Fehler aufgetreten:            	---" +
                                        "\n-----------------------------------------------------" +
                                        "\n--- Die angegebene Anzahl an Elemente ist zu groß ---" +
                                        $"\n--- Reduktion auf {Elemente,-10} Elemente         	---" +
                                        "\n-----------------------------------------------------\n");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("--------------------------------------" +
                                        "\n--- Es ist ein Fehler aufgetreten: ---" +
                                        "\n--------------------------------------\n" + e.Message);
                        break;
                    }
                } while (true);
                Console.WriteLine("Taste drücken... (Esc zum Beenden)");
            } while (!(Console.ReadKey(true).Key == ConsoleKey.Escape));
        }
        static string RechneZeit(int ms)
        {
            int Minute, Sekunde = 0;
            string Zeit = "", TimeStamp = "Sekunden";

            if (ms >= 60000)
            {
                Minute = ms / 60000;
                ms = ms % 60000;
                Zeit += Minute + ":";
                TimeStamp = "Minuten";
            }
            if (ms >= 1000)
            {
                Sekunde = ms / 1000;
                ms = ms % 1000;
            }
            Zeit += $"{Sekunde:#0},{ms:000} {TimeStamp}";
            return Zeit;
        }
    }
}
