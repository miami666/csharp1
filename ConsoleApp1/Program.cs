using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*
 Erstellen sie ein Programm das eine datei erstellt. 
 Die Datei soll mit einem einzugebendem Text befüllt werden. 
 es soll geprüft werden ob die Datei excistiert und dazu soll eine Meldung ausgegeben werden.
 weitere Funktionen:
 Text an Datei anhängen, Datei löschen, Datei kopieren, Datei umbenennen
     */
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
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
                        line = Console.ReadLine();
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, dateiName),true))
                        {
                            outputFile.WriteLine(line);
                        }
                    }
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
    }
}
