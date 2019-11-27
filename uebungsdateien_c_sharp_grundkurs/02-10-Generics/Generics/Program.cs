using System;
using System.Collections.Generic;

namespace Generics
{
    class Mitarbeiter //: ITest
    {
        string vorname;
        public string Vorname
        {
            get { return this.vorname; }
            set { this.vorname = value; }
        }
        string nachname;
        public string Nachname
        {
            get { return this.nachname; }
            set { this.nachname = value; }
        }

        void foo()
        {
        }
    }


    interface ITest
    {
        void foo();
    }

    class PersisistenceManager<T>
        where T:/*ITest,*/ new()
    {
        public T Query(string criteria)
        {
            //....
            return new T();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PersisistenceManager<Mitarbeiter> f = new PersisistenceManager<Mitarbeiter>();
            Mitarbeiter m = f.Query("....");
            Console.WriteLine(m.Vorname);
        }
    }
}
