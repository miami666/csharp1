
using System;
using System.Collections.Generic;

namespace Test
{
    class MyClass
    {
        //Standardmäßig sind alle Member (Felder und Methoden) private!
        private int global = 10; //Globale Variable innerhalb der Klasse <- Nennt man "Feld"

        //Zugriff  Datentyp    Name  Parameterliste
        private int MyMethod()  //Der Datentyp der Methode bestimmt den Datentyp der Rückgabe
        {
            Console.WriteLine("MyMethod");
            return 1234; //Methoden / Funktionen mit Datentyp haben IMMER eine Rückgabe
        }

        //Zugriff   Datentyp   Name   Parameterliste
        protected void MyVoidMethod() //Bei Void gibt es kein Return
        {
            Console.WriteLine("Methoden / Funktionen mit Void haben keine Rückgabe!");
        }

        public void MyVoidMethod2(string s) //Parameter haben immer einen Datentyp und einen Bezeichner
        {
            Console.WriteLine(s); //Parameter bilden LOKALE VARIABLEN, die in dem Funktionskörper gültig sind
        }

        //Zugriff   Datentyp    Name    Parameterliste
        public double MyDoubleMethod(double d)
        {
            double d2 = d + global;
            return d2;
        }

    }


    class Program
    {
        static void Main()
        {
            int i = new int();

            MyClass myClass = new MyClass();

            double d = 5.9; //Lokale Variable
            //Funktionsaufruf / Aufruf der Methode
            //(Objekt.)  Name der Methode    Parameter / Argumente
            myClass.MyDoubleMethod(d); //Der Wert der Variable d hier wird der Variable d in der Methode zugewiesen

            myClass.MyVoidMethod2("Hello World!"); //Literal


            //Objekt / Klasse bei Static    Name der Methode    Parameter / Argumente
            Console.WriteLine(i);


            Console.ReadKey();
        }
    }
}
