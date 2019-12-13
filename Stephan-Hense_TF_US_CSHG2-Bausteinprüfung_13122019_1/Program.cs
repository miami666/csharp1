using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * a)	Führen Sie das das Interface IInventar ein.
•	IInventar hat eine Guid-Property Inventarnummer
•	Und eine void Methode Aufnahme()
Erzeugen Sie zusätzlich die statische Klasse Inventarverwaltung mit der öffentlichen statischen Methode Aufnahme(IInventar obj). 
Diese Methode soll der Inventarnummer des übergebenen Objektes eine neue Guid (Guid.NewGuid()) zuweisen.
Anschließend erstellen Sie die Klassen Gebrauchsgut (abstrakt), Möbel und Werkzeug. Möbel und Werkzeug erben von Gebrauchsgut.
Gebrauchsgut implementiert das Interface. Über den Konstruktor von Gebrauchsgut wird die durch das Interface implementierte Methode aufgerufen,
die dann die Methode der Inventarverwaltung aufrufen soll. In der Main erzeugen Sie je ein Objekt und geben die Inventarnummern in der Konsole aus.
*/
namespace Stephan_Hense_TF_US_CSHG2_Bausteinprüfung_13122019_1
{
    public interface IInventar
    {
        Guid Inventarnummer { get; set; }
        void Aufnahme();
    }
    static class InventarVerwaltung
    {

        public static void Aufnahme(IInventar obj)
        {
            obj.Inventarnummer = Guid.NewGuid();

        }
    }
    abstract class Gebrauchsgut : IInventar
    {
        public Guid Inventarnummer { get; set; }
        public virtual void Aufnahme()
        {
        }
        public Gebrauchsgut()
        {
            Aufnahme();
            InventarVerwaltung.Aufnahme(this);
        }

    }
    class Moebel : Gebrauchsgut
    {

    }
    class Werkzeug : Gebrauchsgut
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Werkzeug wz = new Werkzeug();
            Moebel moe = new Moebel();
            Console.WriteLine(wz.Inventarnummer);
            Console.WriteLine(moe.Inventarnummer);
            Console.ReadKey();
        }
    }
}
