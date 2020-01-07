using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextdateiMitFileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            // Benutzereingabe anfordern
            Console.Write("Geben Sie die zu öffnende Datei an: "); ;
            string strFile = Console.ReadLine();

            // prüfen, ob die angegebene Datei existiert
            if (!File.Exists(strFile))
            {
                Console.WriteLine("Die Datei {0} existiert nicht!", strFile);
                Console.ReadLine();
                return;
            }

            // Datei öffnen
            FileStream fs = File.Open(strFile, FileMode.Open);

            // Byte-Array, in das die Daten aus dem Datenstrom eingelesen werden
            byte[] puffer = new Byte[fs.Length];

            // die Zeichen aus der Datei lesen und in das Array 
            // schreiben, der Lesevorgang beginnt mit dem ersten Zeichen
            fs.Read(puffer, 0, (int)fs.Length);

            // das Byte-Array elementweise einlesen und jedes 
            // Array-Element in Char konvertieren
            for (int i = 0; i < fs.Length; i++)
                Console.Write(Convert.ToChar(puffer[i]));
            Console.ReadLine();
        }
    }

}
