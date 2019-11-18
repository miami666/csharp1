using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bausteinpruefung_15112019_teil2
{
    class Computer
    {
        public static List<Computer> pcliste = new List<Computer>();
        public List<Peripherie> pliste = new List<Peripherie>();
        public string Betriebssystem;
        public int Ram;
        public string gfx;
        public string cpu;
        int[] hd = new int[3];
        public Computer(string Betriebsystem, int Ram, string gfx, string cpu, int hd1, int hd2, int hd3) {
            Betriebssystem = Betriebsystem;
            Ram = this.Ram;
            gfx = this.gfx;
            cpu = this.cpu;
            hd[0] = hd1;
            hd[1] = hd2;
            hd[2] = hd3;
            foreach (Computer item in pcliste)
            {
                pcliste.Add(this);


            }

        }
        public static void ZeigeAlle() {
            foreach (Computer item in pcliste)
            {
                Console.WriteLine(item.Betriebssystem+" "+item.Ram+" GB " + item.cpu+" " + item.hd[0]+" " + item.hd[1]+ " " + item.hd[2]);
            }
    }

    }
    class Peripherie {
        public string Bezeichnung;
        public string Anschluss;

    }
    class Program
    {
        static void Main(string[] args)
        {
            Computer a = new Computer("Win 10",16,"GTX1060" ,"Intel i7",1000,2000,3000);
            Computer.ZeigeAlle();
            Console.ReadKey();
        }
    }
}
