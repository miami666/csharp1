using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;

/*
 Binäre Serialisierung

    - Hilft Objekte in ihrem aktuellem Zustand zu speichern und wiederherzustellen
    
    #############
    Voraussetzung
    #############
    
    - Objekte und ihre Eigenschaften müssen eindeutig zugeordnet sein
 */

namespace binaere_serialisierung
{
    [Serializable()]
    public class MyObject
    {
        public int n1 = 0;
        public int n2 = 0;
        public String str = null;
    }
    [Serializable()]
    class Person
    {
        private int _Alter;
        public int Alter
        {
            get { return _Alter; }
        }
        public string Name { get; set; }
        /*Konstruktor*/
        public Person(int alter, string name)
        {
            Name = name;
            _Alter = alter;

        }
    }
    class Program
    {
        static FileStream stream2;
        static IFormatter formatter2 = new BinaryFormatter();


        static void Main(string[] args)
        {
            MyObject obj = new MyObject();
            obj.n1 = 1;
            obj.n2 = 24;
            obj.str = "Some String";
            string path = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.MyDoc‌​uments), "MyFile.bin");           
            Console.WriteLine(path);                    
            IFormatter formatter = new BinaryFormatter(); /*Static BinaryFormatter formatter;*/
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);/*static FileStream stream;*/
            formatter.Serialize(stream, obj);
            stream.Close();

            Person person = new Person(67, "Fischer");
           
            SerializeObj(person);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Alter);
            person.Name = "Uschi";
            Console.WriteLine("Ausgabe nach Namensänderung");
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Alter);

            Console.ReadKey();
        }
        /*Methode Objektserialisierung*/
        public static void SerializeObj(Object obj)
        {
            string path2 = Path.Combine(Environment.GetFolderPath(
   Environment.SpecialFolder.MyDoc‌​uments), "MyFile2.bin");
            stream2 = new FileStream(path2, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter2.Serialize(stream2, obj);
            stream2.Close();
            
        }
        /*Methode Objektdeserialisierung*/
        public static Person DeserializeObj()
        {
            string path2 = Path.Combine(Environment.GetFolderPath(
  Environment.SpecialFolder.MyDoc‌​uments), "MyFile2.bin");
            Stream stream = new FileStream(path2, FileMode.Open);
            return (Person)formatter2.Deserialize(stream);

        }
    }
}
