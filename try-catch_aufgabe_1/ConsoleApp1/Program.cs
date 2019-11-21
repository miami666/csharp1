using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
	Schreiben Sie bitte ein C#-Programm, in dem ...
	- zunächst folgende Variablen eingeführt werden:
		+ String sLänge und sIndex
		+ 32-Bit-Integer länge und index
		+ Boolean LängeIstOk und indexIstOk
	- anschließend eine (erste) do-while-Schleife gestartet wird (Ende der Schleife, falls längeIstOk==true), in der ...
		+ eine (Text-Eingabe) sLänge abfragt
		+ in einem try versucht wird, sLänge in länge zu konvertieren, folgende Exceptions sollen berücksichtigt werden:
			++ FormatException (Eingabe sLänge besteht nicht nur aus Ziffern)
			++ OverflowException (Anzahl der Ziffern für 32-Bit-Integer zu groß)
			++ allgemeine Exception (für alle anderen Fehler)
		+ in einem try versucht wird, ein Double-Array der Form ArrayName[länge] zu deklarieren, folgende Exceptions sollen berücksichtigt werden:
			++ OutOfMemoryException (länge ist als Anzahl der Array-Felder ist zu groß)
			++ OverflowException (hier nur für den Fall: länge ist negativ)
			++ allgemeine Exception (für alle anderen Fehler)
	- daraufhin (also nach der ersten do-while-Schleife) tatsächlich ein entsprechendes Double-Array deklariert wird (siehe "Hinweis")
	- schließlich eine (zweite) do-while-Schleife gestartet wird (Ende der Schleife, falls indexIstOk==true), in der ...
		+ eine (Text-Eingabe) sIndex abfragt
		+ in einem try versucht wird, sIndex in index zu konvertieren, folgende Exceptions sollen berücksichtigt werden:
			++ FormatException (Eingabe sIndex besteht nicht nur aus Ziffern)
			++ OverflowException (Anzahl der Ziffern für 32-Bit-Integer zu groß)
			++ allgemeine Exception (für alle anderen Fehler)
		+ in einem try versucht wird, das Double-Array für das Feld=index mit dem Wert 4711 zu füllen, folgende Exceptions werden berücksichtigt:
			++ IndexOutOfRangeException (Index negativ, oder zu groß)
			++ allgemeine Exception (für alle anderen Fehler)
	- am Ende zur Kontrolle der Inhalt von DoubleArray[index] auf der Konsole ausgegeben wird

Hinweis:
	Im try deklarierte Variablen/Arrays sind außerhalb des try-Blockes unbekannt.
	Daher kann im try nur getestet werden, ob die Deklaration für ein (Dummy)Array (vom selben Typ) funktionieren würde ...
	... nach dem try-Block muss daher erneut ein Array des selben Typs deklariert werden (aber mit anderem Namen, als der des Dummy-Arrays)
*/

namespace ConsoleApp1
{
    class Program
    {
        static void tcInput(string s)
        {
            Int32 laenge, index;
            laenge = Convert.ToInt32(s);
            if (s== null)
            {
                throw new ArgumentNullException();

            }
        }
        static void Main(string[] args)
        {
            string sLaenge, sIndex;
            Int32 laenge, index;
            bool laengeOk=false, indexOk=false;
            do
            {
                Console.WriteLine("Eingabe slänge(string): ");
                sLaenge = Console.ReadLine();
                try
                {
                    tcInput(sLaenge);
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);

                }
           

            } while (!laengeOk);

        }
    }
}
