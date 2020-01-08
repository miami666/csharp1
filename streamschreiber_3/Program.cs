using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*bung:
StreamReader/Writer  und File
Es soll eine Textdatei angelegt und über die Konsole befüllt werden.
Es sollen Eingaben über eine Schleife realisiert werden (Endekriterium festlegen)
Danach soll die Datei auf der Konsole ausgegeben werden.

Modifizierung:
Dateinamen eingeben
Auswahl Schreiben/Lesen
Prüfen, ob Datei vorhanden
Setzen der Attribute
2. 
Die Datei soll um einen Text ergänzt werden, ohne dass der alte Inhalt verloren geht

3. 
Das Programm soll über WPF laufen
*/
namespace streamschreiber_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string line="";
            string dateiName;
            string neuerDateiName;
            string docPath =
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("(N)eue Datei");
                Console.WriteLine("(T)ext an Datei anhängen");
                Console.WriteLine("Datei (a)nzeigen");
                Console.WriteLine("(s)chreibschutz setzen/aufheben");
                Console.WriteLine("(l)öschen");
                Console.WriteLine("(k)opieren");
                Console.WriteLine("(u)mbenennen");
                Console.WriteLine("(Q)uit");
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.Q) break;
                if (pressedKey.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Dateiname eingeben:");
                    dateiName = Console.ReadLine();
                    if (File.Exists(Path.Combine(docPath, dateiName)))
                    {
                        Console.WriteLine($"{dateiName} existiert bereits!");
                    }
                    else
                    {
                        Console.WriteLine("Texteingabe: ");
                        line = Console.ReadLine();
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, dateiName)))
                        {
                            outputFile.WriteLine(line);
                        }
                    }
                }
                if (pressedKey.Key == ConsoleKey.T)
                {
                    Console.WriteLine("Dateinamen eingeben:");
                    dateiName = Console.ReadLine();
                    if (!File.Exists(Path.Combine(docPath, dateiName)))
                    {
                        Console.WriteLine($"{dateiName}Datei nicht vorhanden");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Texteingabe:");
                        line = Console.ReadLine();
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, dateiName), true))
                        {
                            outputFile.WriteLine(line);
                        }
                        
                    }
                }
                if (pressedKey.Key == ConsoleKey.A)
                {
                    Console.WriteLine("Dateinamen eingeben:");
                    dateiName = Console.ReadLine();
                    if (!File.Exists(Path.Combine(docPath, dateiName)))
                    {
                        Console.WriteLine($"{dateiName}Datei nicht vorhanden");
                        return;
                    }
                    else
                    {
                        string zeile = "";
                        using (StreamReader sr = new StreamReader(Path.Combine(docPath, dateiName)))
                        {
                            while ((zeile = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(zeile);
                            }
                        }
                        Console.ReadKey();
                    }
                }
                if (pressedKey.Key == ConsoleKey.S)
                {
                    Console.WriteLine("Dateinamen eingeben:");
                    dateiName = Console.ReadLine();
                    if (!File.Exists(Path.Combine(docPath, dateiName)))
                    {
                        Console.WriteLine($"{dateiName}Datei nicht vorhanden");
                        return;
                    }
                    else
                    {
                        FileAttributes attributes = File.GetAttributes(Path.Combine(docPath, dateiName));

                        if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        {

                            attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
                            File.SetAttributes(Path.Combine(docPath, dateiName), attributes);
                            Console.WriteLine("Datei {0} nicht mehr schreibgeschuetzt.", Path.Combine(docPath, dateiName));
                        }
                        else
                        {

                            File.SetAttributes(Path.Combine(docPath,dateiName), File.GetAttributes(Path.Combine(docPath,dateiName)) | FileAttributes.ReadOnly);
                            Console.WriteLine("Datei {0} jetzt schreibgeschützt.", Path.Combine(docPath, dateiName));
                        }
                    }
                    Console.ReadKey();
                }
                if (pressedKey.Key == ConsoleKey.L)
                {
                    Console.WriteLine("Dateinamen eingeben:");
                    dateiName = Console.ReadLine();
                    if (File.Exists(Path.Combine(docPath, dateiName)))
                    {
                        try
                        {
                            File.Delete(Path.Combine(docPath, dateiName));
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine(e.Message);
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{dateiName} existiert nicht");
                    }
                }
                if (pressedKey.Key == ConsoleKey.K)
                {
                    Console.WriteLine("Dateinamen eingeben:");
                    dateiName = Console.ReadLine();
                    if (!File.Exists(Path.Combine(docPath, dateiName)))
                    {
                        Console.WriteLine($"{dateiName} existiert nicht");
                    }
                    else
                    {
                        Console.WriteLine("Neuer Dateiname:");
                        neuerDateiName = Console.ReadLine();
                        string quelle = Path.Combine(docPath, dateiName);
                        string ziel = Path.Combine(docPath, neuerDateiName);
                        File.Copy(quelle, ziel);
                    }
                }
                if (pressedKey.Key == ConsoleKey.U)
                {
                    Console.WriteLine("Dateinamen eingeben:");
                    dateiName = Console.ReadLine();
                    if (!File.Exists(Path.Combine(docPath, dateiName)))
                    {
                        Console.WriteLine($"{dateiName} existiert nicht");
                    }
                    else
                    {
                        Console.WriteLine("Neuer Dateiname:");
                        neuerDateiName = Console.ReadLine();
                        string quelle = Path.Combine(docPath, dateiName);
                        string ziel = Path.Combine(docPath, neuerDateiName);
                        File.Move(quelle, ziel);
                    }
                }
            }
        }
        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }
    }
}
