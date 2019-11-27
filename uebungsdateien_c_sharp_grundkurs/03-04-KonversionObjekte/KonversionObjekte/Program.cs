using System;
using System.Collections;

namespace KonversionObjekte
{
    class Mitarbeiter
    {
        public Mitarbeiter(string vorname, string nachname)
        {
            this.vorname = vorname;
            this.nachname = nachname;
        }

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
        public override string ToString()
        {
            return this.vorname + " " + this.nachname;
        }
    }

    class Manager
    {
        public Manager(string vorname, string nachname)
        {
            this.vorname = vorname;
            this.nachname = nachname;
        }

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
        public override string ToString()
        {
            return this.vorname + " " + this.nachname;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();
            al.Add(new Manager("Mirko", "Matytschak"));
            al.Add(new Mitarbeiter("Erik", "Franz"));
            //Console.WriteLine(o);
            //...
            for (int i = 0; i < al.Count; i++)
            {
                object o = al[i];
                Mitarbeiter m = o as Mitarbeiter;
                if (m != null)
                {
                    Console.WriteLine(m.Vorname + " " + m.Nachname);
                }
            }
        }
    }
}
