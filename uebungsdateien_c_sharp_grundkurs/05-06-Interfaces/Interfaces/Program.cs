using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrakteBasisklassen
{
    interface IZugangskontrolle
    {
        bool HatZugang(Area area);
    }

    abstract class Person : IZugangskontrolle
    {
        public Person(string vorname, string nachname)
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

        abstract public bool HatZugang(Area area);
    }

    class Area
    {
        string name;
        bool isPublic;
        bool isRestricted;
        public Area(string name, bool isPublic, bool isRestricted)
        {
            this.name = name;
            this.isPublic = isPublic;
            this.isRestricted = isRestricted;
        }

        public string Name
        {
            get { return this.name; }
        }

        public bool IsPublic
        {
            get { return this.isPublic; }
        }

        public bool IsRestricted
        {
            get { return this.isRestricted; }
        }
    }

    class Kunde : Person
    {
        public Kunde(string vorname, string nachname)
            : base(vorname, nachname)
        {
        }

        public override bool HatZugang(Area area)
        {
            return area.IsPublic;
        }
    }

    class Mitarbeiter : Person
    {
        public Mitarbeiter(string vorname, string nachname, decimal gehalt)
            : base(vorname, nachname)
        {
            this.gehalt = gehalt;
        }

        decimal gehalt;
        virtual public decimal Gehalt
        {
            get 
            { 
                return this.gehalt; 
            }
        }

        virtual public void DoWork()
        {
            Console.WriteLine("Ich mach's selber");
        }

        Mitarbeiter chef;
        public Mitarbeiter Chef
        {
            get { return this.chef; }
            set { this.chef = value; }
        }

        List<Mitarbeiter> untergebene = new List<Mitarbeiter>();
        public List<Mitarbeiter> Untergebene
        {
            get { return this.untergebene; }
        }

        public override bool HatZugang(Area area)
        {
            return !area.IsRestricted;
        }
    }

    class Manager : Mitarbeiter
    {
        public Manager(string vorname, string nachname, decimal gehalt, decimal bonus)
            : base(vorname, nachname, gehalt)
        {
            this.bonus = bonus;
        }


        decimal bonus;
        public decimal Bonus
        {
            get { return this.bonus; }
            set { this.bonus = value; }
        }

        override public decimal Gehalt
        {
            get
            {
                return base.Gehalt + this.bonus;
            }
        }

        override public void DoWork()
        {
            Console.WriteLine("Ich such einen, der's macht.");
        }

        public override bool HatZugang(Area area)
        {
            return true;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Mitarbeiter> mitarbeiter = new List<Mitarbeiter>();
            Mitarbeiter m = new Mitarbeiter("Mirko", "Matytschak", 24000m);
            mitarbeiter.Add(m);
            Manager manager = new Manager("Hans", "Protz", 1234993m, 292929);
            mitarbeiter.Add(manager);

            foreach (Mitarbeiter m2 in mitarbeiter)
            {
                Console.WriteLine(m2.Vorname + " " + m2.Nachname + " " + m2.Gehalt);
            }

            foreach (Mitarbeiter m2 in mitarbeiter)
            {
                Console.WriteLine(m2.Vorname + " " + m2.Nachname);
                m2.DoWork();
            }
        }
    }
}
