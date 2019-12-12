/* Klasse Universitätsgebäude - Attribute: Adresse, Name, Liste der Räume
 * Klasse Vorlesungsraum - Attribute: Liste der Kurse, Nummer, AnzahlStühle
 * Klasse Kurs - Attribute: Name, Semester, Liste der Professoren, Liste der Studenten
 * Klasse Person - Attribute: Name
 * Klasse Professor - Attribute: Liste der Kurse, Personalnummer
 * Klasse Student - Attribute: Liste der Kurse, Immatrikulationsnummer
 * Implementieren Sie die Klassen, denken Sie sich Daten aus. 
 * Stellen Sie zwischen Kurs - Professor und Kurs - Student eine bidirektionale Navigierbarkeit über Aggregation her
 * Erstellen Sie zwischen Universitätsgebäude und Vorlesungsraum eine Komposition 
 * Vorlesungsraum und Kurs ergeben eine Aggregation
 * Professor und Student erben von Person, Person ist dabei Abstrakt.
 * Zusatz: Erstellen Sie ein Klassendiagramm
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AggregationKomposition
{
    public class Universitätsgebäude
    {
        public string Adresse { get; private set; }
        public string Name { get; set; }
        public List<Vorlesungsraum> Räume { get; set; }

        public Universitätsgebäude(string adresse, string name)
        {
            Adresse = adresse;
            Name = name;

            Räume = new List<Vorlesungsraum>();
        }

        //Finalizer / Destruktor
        ~Universitätsgebäude()
        {
            Console.WriteLine("Das Gebäude wird abgerissen");
            Räume.Clear();
        }
    }

    public class Vorlesungsraum
    {
        public string Nummer { get; set; }
        public int AnzahlStühle { get; set; }
        public List<Kurs> Kurse { get; set; }

        public Vorlesungsraum(string nummer, int anzahlStühle)
        {
            Nummer = nummer;
            AnzahlStühle = anzahlStühle;

            Kurse = new List<Kurs>();
        }

        ~Vorlesungsraum()
        {
            Console.WriteLine("Der Raum {0} wird entfernt", Nummer);
        }
    }

    public class Kurs
    {
        public string Name { get; set; }
        public string Semester { get; set; }
        public List<Professor> Professoren { get; set; }
        public List<Student> Studenten { get; set; }

        public Kurs(string name, string semester)
        {
            Name = name;
            Semester = semester;

            Professoren = new List<Professor>();
            Studenten = new List<Student>();
        }

        public void AddPerson(Person person)
        {
            if (person is Student)
            {
                Studenten.Add(person as Student);
            }
            if (person is Professor)
            {
                Professoren.Add(person as Professor);
            }
            person.Kurse.Add(this);
        }


        ~Kurs()
        {
            Console.WriteLine("Der Kurs {0} wird nicht länger angeboten", Name);
        }
    }

    public abstract class Person
    {
        public string Name { get; set; }
        public List<Kurs> Kurse;

        protected Person(string name)
        {
            Name = name;
            Kurse = new List<Kurs>();
        }
    }

    public class Professor : Person
    {
        
        public string Personalnummer { get; set; }

        public Professor(string personalnummer, string name) : base(name)
        {
            Personalnummer = personalnummer;
        }

        //Beispiel für die Überschreibung der ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(" ");
            sb.Append("PNR: " + Personalnummer);
            
            foreach(Kurs kurs in Kurse)
            {
                sb.Append("\n");
                sb.Append(kurs.Name);
            }
            return sb.ToString();
        }

        ~Professor()
        {
            Console.WriteLine("Der Professor {0} arbeitet nicht länger hier", Name);
        }
    }

    public class Student : Person
    {
        public string Immatrikulationsnummer { get; set; }

        public Student(string immatrikulationsnummer, string name) : base(name)
        {
            Immatrikulationsnummer = immatrikulationsnummer;
        }

        ~Student()
        {
            Console.WriteLine("Der Student {0} hat aufgehört zu studieren", Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Universitätsgebäude uni = new Universitätsgebäude("Universitätsstraße 1", "C# Universität");
            uni.Räume.Add(new Vorlesungsraum("001", 100));
            uni.Räume.Add(new Vorlesungsraum("101", 100));          

            Kurs csharpGrundlagen = new Kurs("C# Grundlagen", "W18");
            Kurs csharpAufbau = new Kurs("C# Aufbau", "S19");
            Kurs csharpVertiefung = new Kurs("C# Vertiefung", "W20");

            uni.Räume[0].Kurse.Add(csharpGrundlagen);
            uni.Räume[0].Kurse.Add(csharpAufbau);
            uni.Räume[1].Kurse.Add(csharpVertiefung);

            Professor p1 = new Professor("P123", "Dr. Dr. Prof. Herr von C Sharp");

            csharpGrundlagen.AddPerson(p1);
            csharpAufbau.AddPerson(p1);
            csharpVertiefung.AddPerson(p1);

            Student s1 = new Student("S123", "Max Mustermann");

            csharpGrundlagen.AddPerson(new Student("S456", "Marie Musterfrau"));

            csharpGrundlagen.AddPerson(s1);
            csharpAufbau.AddPerson(s1);


            foreach (Vorlesungsraum raum in uni.Räume)
            {
                Console.WriteLine($"Der Raum {raum.Nummer} befindet sich in Gebäude {uni.Name}");
                foreach (Kurs kurs in raum.Kurse)
                {
                    Console.WriteLine($"Der Kurs {kurs.Name} findet in Raum {raum.Nummer} statt");
                    foreach (Professor p in kurs.Professoren)
                    {
                        Console.WriteLine($"{p.Name} unterrichtet {kurs.Name}");
                    }
                    foreach (Student s in kurs.Studenten)
                    {
                        Console.WriteLine($"{s.Name} studiert {kurs.Name}");
                    }

                }
            }

            Console.WriteLine(p1.ToString());

            uni = null;

            Console.ReadKey();
        }
    }
}
