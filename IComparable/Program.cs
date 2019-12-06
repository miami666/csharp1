using System;
using System.Collections;


namespace ConsoleApp25
{
    class MyClass : IComparable
    {
        public int MyInt { get; set; }

        /// <summary>
        /// CompareTo wird aufgerufen, wenn ich eine Liste mit .Sort() sortieren lasse
        /// Mit den Return-Werten kann ich die Reihenfolge bei der Sortierung bestimmen
        /// </summary>
        /// <param name="obj">Das Objekt, mit dem verglichen werden soll</param>
        /// <returns>
        /// Kleiner 0 wenn das aktuelle Objekt vor dem zu vergleichendem stehen soll
        /// 0 wenn es an der gleichen Position steht
        /// Größer 0 wenn es nach dem zu vergleichendem stehen soll
        /// </returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            MyClass myOtherClass = obj as MyClass;
            if (myOtherClass != null)
                if (MyInt > myOtherClass.MyInt)
                    return -1;
                else if (MyInt < myOtherClass.MyInt)
                    return 1;
                else
                    return 0;
            else
                throw new ArgumentException("Object not MyClass");

        }
    }

    class MyClass2
    {
    }

    class Programm
    {
        static void Main(string[] args)
        {
            ArrayList liste = new ArrayList();
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                int zahl = rnd.Next(0, 100);
                MyClass myClass = new MyClass();
                myClass.MyInt = zahl;
                liste.Add(myClass);
            }

            //liste.Add(new MyClass2()); //Erzeugt die Exception

            liste.Sort();

            foreach (MyClass myClass in liste)
            {
                Console.WriteLine(myClass.MyInt);
            }

            Console.ReadKey();
        }
    }
}

