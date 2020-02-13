using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClassLib;
/*
 * Als Klassenbibliothek!
Statische Klasse "Textfile"
- Öffentliche Void Methode "Write"
     Diese Methode soll einen übergebenen Text in eine Datei an dem übergebenen Pfad schreiben. Der Benutzer soll die Möglichkeit haben, über Parameter der Methode zu entscheiden, ob der Text an bereits vorhandenen angehängt und ob er mit einem abschließenden NewLine geschrieben werden soll.
- Öffentliche String Methode "Read"
     Diese Methode liest einen Text aus einer Datei, dessen Pfad der Methode übergeben wird. Die Datei wird komplett gelesen und der String zurückgegeben.
Achten Sie darauf, dass die Klassenbibliothek nicht mit der Konsole interagiert. 
Aus-/Eingabe wird von Funktionalität getrennt.

Als C# Konsolenanwendung:
Testen Sie im Main die Klasse.
Dazu binden Sie die Klassenbibliothek als Verweis auf die DLL in das Programm ein,
schreiben einen Text in eine Datei und lesen den Text dann wieder aus.

 */
namespace hense_bausteinpruefung_31012020_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = "3001.txt";
            string textToAdd = "xxx";
            Textfile.Write(textToAdd, Path.Combine(docPath, filename), true,true);
            Textfile.Read(filename);

            Console.ReadKey();
        }
    }
}
