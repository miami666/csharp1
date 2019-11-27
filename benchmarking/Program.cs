using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Schreiben Sie ein C#-Programm, welches einen Performancevergleich zw. der for-Schleife und der foreach-Schleife und einem array und einer Liste durchführt.
//Es soll dafür ein Funktionszeiger(delegate) verwendet werden auf die Methoden 'perf...xy', welche in einem gemeinsam zu bestimmenden Interface definiert sind.

//Methode perf...xy :
//Rückgabewert: int // Zeit in ms
//Parameter: 	int anzahlDurchläufe //

//            int anzahlElemente // ... in der Liste bzw. Array

//Die jeweiligen Methoden sollen den zeitlichen Durchschnittswert der einzelnen Durchläufe in ms zurück geben.
//Die Elemente sollen vom Typ int sein und zuvor mit Zufallswerten initialisiert werden.
//Es soll der lesende Zugriff gemessen werden (z.b.Werte in eine temporäre Variable schreiben).
//In allen Fällen sollen Programmabbrüche durch Fehler bei der Initialisierung durch zu wenig Speicher abgefangen werden und auf geeignetem Weg die Anzahl der Elemente reduziert werden, bis es funktioniert.Die dann konkret verwendete Elementanzahl soll natürlich angezeigt werden, zusammen mit den Ergebnisen.

//delegate int MyDelegate(int anzahlDurchläufe, int anzahlElemente);

//Interface Performance
//{
//	// Gruppe1: for mit array
//	int perfForArray(int anzahlDurchläufe, int anzahlElemente);
//	// Gruppe2: for mit liste
//	int perfForList(int anzahlDurchläufe, int anzahlElemente);
//	// Gruppe3: foreach mit array
//	int perfForeachArray(int anzahlDurchläufe, int anzahlElemente);
//	// Gruppe4: foreach mit liste
//	int perfForeachList(int anzahlDurchläufe, int anzahlElemente);
//}

namespace benchmarking
{
   interface IPerformance
    {
        TimeSpan ForArr(int anzRnd, int anzEle);
        TimeSpan ForLst(int anzRnd, int anzEle);
        TimeSpan ForEachArr(int anzRnd, int anzEle);
        TimeSpan ForEachLst(int anzRnd, int anzEle);
       
    }
    public delegate TimeSpan MyDelegate(int anzRnd, int anzEle);
    class Program
    {
        static void RC()
        {
            Console.ResetColor();
        }
      static void Main(string[] args)
        {
           
           Test t = new Test();
           var ndel = new MyDelegate(t.ForLst);
           Console.ForegroundColor = ConsoleColor.Yellow;
           Console.WriteLine("For loop auf Liste - Zeit vergangen: "+ndel(500500, 9999998));
           RC();
           ndel = t.ForEachLst;
           Console.ForegroundColor = ConsoleColor.Red;
           Console.WriteLine("Foreach loop auf Liste - Zeit vergangen: " + ndel(500500, 9999998));
           RC();
           ndel = t.ForArr;
           Console.ForegroundColor = ConsoleColor.Magenta;
           Console.WriteLine("For loop auf Array - Zeit vergangen: " + ndel(500500, 9999998));
           RC();
           ndel = t.ForEachArr;
           Console.ForegroundColor = ConsoleColor.Cyan;
           Console.WriteLine("Foreach loop auf Array - Zeit vergangen: " + ndel(500500, 9999998));
           RC();
           Console.ReadKey();
        }
   }
    class Test : IPerformance
    {
        Random r = new Random(Guid.NewGuid().GetHashCode());
        public TimeSpan ForLst(int anzRnd, int anzEle)
        {                  
            List<int> _intL = new List<int>();
            for (int i = 0; i <= anzEle; i++)
            {
                _intL.Add(i);
            }
            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i <= anzRnd; i++)
            {
                var temp = _intL[i];
                temp = 0;
            }
            watch.Stop();
            //Console.WriteLine(_intL.Count);
            return watch.Elapsed;
        }
        public TimeSpan ForEachLst(int anzRnd, int anzEle)
        {
            int c = 1;          
            List<int> _intL = new List<int>();
            for (int i = 0; i <= anzEle; i++)
            {
                _intL.Add(i);
            }
            Stopwatch watch = Stopwatch.StartNew();
            foreach (int num in _intL)
            {
                var temp = num;
                if (c++ == anzRnd) break;
           }
            watch.Stop();
            //Console.WriteLine(_intL.Count);
            return watch.Elapsed;
        }
        public TimeSpan ForArr(int anzRnd, int anzEle)
        {
            int c = 1;
            int[] fArr = new int[anzEle];
            for (int i = 0; i < fArr.Length; i++)
            {
                fArr[i] = i;
            }
            Stopwatch watch = Stopwatch.StartNew();
            for(int i = 0; i<fArr.Length;i++)
            {
                var temp = fArr[i];               
            }
            watch.Stop();
            return watch.Elapsed;
        }
        public TimeSpan ForEachArr(int anzRnd, int anzEle)
        {
            int c = 1;
            int[] feArr = new int[anzEle];
            for (int i = 0; i < anzEle; i++)
            {
                feArr[i]=i;
            }
            Stopwatch watch = Stopwatch.StartNew();
            foreach (int num in feArr)
            {
                var temp = num;
                if (c++ == anzRnd) break;
            }
            watch.Stop();
            return watch.Elapsed;
        }
    }

}