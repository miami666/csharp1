using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hense_bausteinpruefung_1
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
