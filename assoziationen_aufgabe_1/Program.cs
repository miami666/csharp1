using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Führen Sie bitte zunächst die beiden folgenden Klassen ein:
       Fach (Attribute: ID, Bezeichnung)
       Klausur (Attribute: ID, Note)
    Erzeugen Sie bitte die beiden folgenden Objekte vom Typ Fach:
       C#-Grundlagen
       Datenbankmodellierung und SQL
       (wählen Sie beliebige ID)
    Erzeugen Sie bitte die drei folgenden Objekte vom Typ Klausur:
       2 Klausuren im Fach C#
       1 Klausur im Fach DBM+SQL
       (wählen Sie beliebige ID und Noten)

    Sorgen Sie bitte für eine BIDIREKTIONALE Navigierbarkeit

    Schreiben Sie ferner bitte das folgende Programm im Main:
       In einer Endlos-Schleife wird pro Durchlauf ...
         - vom User abgefragt, ob er ...
           (1) von Klausur zum Fach navigieren, oder
           (2) von Fach zur Klausur navigieren möchte
           (Wiederholung der Abfrage, wenn weder 1, noch 2 gewählt wurde)
         - Falls 1 gewählt wurde, so wird vom User eine Klausur-ID abgefragt
             Falls die Eingabe ein Format-Fehler, wird die Abfrage wiederholt
             Falls die Eingabe vom Format OK, aber keine Klausur mit der gewählten ID existiert: Fehlermeldung + Wiederholung der Abfrage
             Falls Eingabe-Format OK UND ID existiert: Ausgabe der Fach-Bezeichnung
         - Falls 2 gewählt wurde, so wird vom User eine Fach-ID abgefragt
             Falls die Eingabe ein Format-Fehler, wird die Abfrage wiederholt
             Falls die Eingabe vom Format OK, aber kein Fach mit der gewählten ID existiert: Fehlermeldung + Wiederholung der Abfrage
             Falls Eingabe-Format OK UND ID existiert: Ausgabe aller Klausur-ID´s und Noten der Klausuren zu diesem Fach
*/
namespace assoziationen_aufgabe_1
{
    class Fach
    {
        public int id;
     
        public string bezeichnung;
        public List<Klausur> klausurliste = new List<Klausur>();
    }
    class Klausur
    {
        public int id;
        public string note;
        public Fach klausurfach;


    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Fach> Faecherliste = new List<Fach>();
            List<Klausur> Klausurenli = new List<Klausur>();

            Fach f1 = new Fach();
            Fach f2 = new Fach();
            f1.id = 1;
            f1.bezeichnung = "C# Grundlagen";
            Faecherliste.Add(f1);
            f2.id = 2;
            f2.bezeichnung = "SQL";
            Faecherliste.Add(f2);
            Klausur k1 = new Klausur();
            k1.id = 1;
            k1.note = "vier";
            k1.klausurfach = f1;
            f1.klausurliste.Add(k1);
            Klausurenli.Add(k1);
     
          
            Klausur k2 = new Klausur();
            k2.id = 2;
            k2.note = "zwei";
            k2.klausurfach = f1;
            f1.klausurliste.Add(k2);
            Klausurenli.Add(k2);
            Klausur k3 = new Klausur();
            k3.id = 3;
            k3.note = "eins";
            k3.klausurfach = f2;
            f2.klausurliste.Add(k3);
            Klausurenli.Add(k3);
            bool taste = false;
            bool gefunden = false;
            Klausur gewaehlteKlausur = null;
            Fach gewaehltesFach = null;


            do
            {
                Console.Clear();
                Console.WriteLine("(1) Klausur zum Fach\n" +
                    "(2) Fach zur Klausur");

                ConsoleKeyInfo keyReaded = Console.ReadKey();

                switch (keyReaded.Key)
                {
                    case ConsoleKey.D1: //Number 1 Key
                   
                        Console.WriteLine("Taste 1 wurde gedrückt");
                        Console.WriteLine("Klausur zum Fach");
                      
                            Console.WriteLine("Klausur Id:");
                            int kid = Convert.ToInt32(Console.ReadLine());
                            foreach(Klausur k in Klausurenli)
                        {
                            if(k.id==kid)
                            {
                                Console.WriteLine("Die Klausur mit der ID " +kid+"war im Fach  "+gewaehlteKlausur.klausurfach.bezeichnung);
                            }
                        }

                     
                       
                        
                      




                        taste = true;
                        break;

                    case ConsoleKey.D2: //Number 2 Key
                        Console.WriteLine("Taste 2 wurde gedrückt");
                        Console.WriteLine("Fach zu Klausur");
                        Console.WriteLine("Bitte Fach Id eingeben:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        if(id==1)
                        {
                            Console.WriteLine("Klausuren C#");
                            foreach (Klausur k in f1.klausurliste)
                            Console.WriteLine(k.id + k.note);

                        }
                        else if(id==2)
                        {
                            Console.WriteLine("Klausuren SQL");
                            foreach (Klausur k in f2.klausurliste)
                            Console.WriteLine(k.id + k.note);

                        }
                        else
                        {
                            Console.WriteLine("Fail!!!");
                            break;
                        }
                        



                        taste = true;
                        break;

                    default: //Not known key pressed
                        Console.WriteLine("falsche taste bitte nochmal");
                        taste = false;
                        break;
                }
            } while (!taste);
            Console.ReadKey();
        }
    }
}
