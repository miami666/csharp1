using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Zugriffsmodus "protected" (bisher kannten wir nur die Zugriffsmodi "public" und "private")
        
Motivation:
    Wir hatten bereits zu Beginn festgestellt (ohne dies aber weiter zu problematisieren), 
    dass auf "private" Felder in der Subklasse nicht zugegriffen werden kann.
    Dies war aus einer Reihe von Gründen oft kein Problem:
    1.) Falls es zu den entsprechenden privaten Feldern Properties gibt (die ja public sind), 
        so kann über diese auf die Felder zugegriffen werden.
    2.) Eine private Variable besitzt zwar keine Property (ist also außerhalb der Klasse tatsächlich nicht verwendbar) wird aber als Wert
        innerhalb einer öffentlichen Methode der selben Klasse verwendet => die öffentliche Methode wird mit vererbt, kann dann (da sie ja
        Mitglied der selben Klasse ist, wie die private Variable) auf diese zugreifen und mit ihr arbeiten, so dass wir erneut kein Problem
        damit haben, dass dieses Feld privat ist.
    ABER:
    natürlich könnte es sein, dass eine private Variable innerhalb der Basisklasse für eine Methode bereitsteht und innerhalb der Subklasse
    für eine andere (nicht geerbte) aber öffentliche Methode verwendet werden soll => die ebende Klasse würde gerne auf diese private Variable zugreifen
    können, OHNE den Zugriffsmodus von außen zu ändern. (Methoden einer Klasse können ja auf alle Felder der selben Klasse zugreifen, auch wenn diese
    privat sind, und genau dies sollte "doch eigentlich" auch für die geerbten Felder gelten)

    Zudem (und das soll Gegenstand des folgenden Beispielcodes sein) können wir auch den Wunsch verspüren, dass eine Basisklasse KEINE Instanzen
    erzeugen kann, aber die Subklasse den entsprechenden Konstruktor (indirekt über base) aufrufen kann.

Lösung des Problems:
    Wir führen mit dem Zugriffsmodus "protected" einen Modus ein, der a) von außen wie private wirkt und b) aus Sicht der Subklasse wie public 
        
*/
namespace @protected
{
    class MyClass_protected
    {
        protected MyClass_protected(string s)
        {
            Console.WriteLine(s);
        }
    }
    class B3:MyClass_protected
    {
        public B3(string s):base(s)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B3 b = new B3("Yoghtze");
            Console.ReadKey();  
        }
    }
}
