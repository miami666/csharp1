using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Events
{
    delegate void WorkDone();

    class Mitarbeiter
    {
        public event WorkDone WorkDoneEvent;

        public Mitarbeiter()
        {
            Mama m = new Mama();
            m.Sohn = this;
        }

        public void DoWork()
        {
            Console.WriteLine("Mitarbeiter: Ächz...");
            Thread.Sleep( 2000 );
            Console.WriteLine("Mitarbeiter: Fertig!");
            if (WorkDoneEvent != null)
                WorkDoneEvent();
        }
    }

    class Manager
    {
        public void DoWork()
        {
            Mitarbeiter m = new Mitarbeiter();

            m.WorkDoneEvent += () => Console.WriteLine("Manager: Das wurde aber auch Zeit!");

            Console.WriteLine("Manager: Mach mal hinne!");
            Task t = new Task( m.DoWork );
            t.Start();
            Console.WriteLine("Manager: Ich bin jetzt mal Golf spielen...");            
        }
    }

    class Mama
    {
        Mitarbeiter sohn;
        public Mitarbeiter Sohn
        {
            set 
            { 
                this.sohn = value;
                this.sohn.WorkDoneEvent += () => Console.WriteLine("Mama: Super, dann geh jetzt ins Bett!");
            }
        }
    }


    class Program
    {
        static void Main( string[] args )
        {
            Manager m = new Manager();
            m.DoWork();
            Console.ReadLine();
        }
    }
}
