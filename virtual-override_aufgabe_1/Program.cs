using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Offene Aufgabenstellung:
        Betrachten Sie bitte zunächst den Screenshot und berücksichtigen hierzu folgende Informationen:
        a) Ein Mitarbeiter erhält ausschließlich ein Grundgehalt (Zufallszahl zwischen 1900 und 2100)
        b) Ein Vorgesetzter erhält ein Grundgehalt (zwischen 3700 und 4300) sowie ein Bonus (zwischen 450 und 550)
        c) Ein Vorstandsvorsitzender erhält ein Grundgehalt (zwischen 7500 und 8500) ein Bonus (2500 bis 3100) + prozentualer Aufschlag (5% bis 15%) 
        d) Es gibt 20 Mitarbeiter, 5 Vorgesetzte und 2 Vorstandvorsitzende
        e) Der Umsatz soll frei gewählt werden können
		f) Der Gewinn ergibt sich aus Umsatz - Löhne
    Zielsetzung:
        Entwickeln Sie bitte ein Programm-Design und implementieren Sie dieses, wobei folgende Qualitätsmerkmale angestrebt werden sollen:
        a) Versuchen Sie möglichst viele Felder und Methoden abzukapseln (* siehe Hinweis)
        b) Bemühen Sie sich bitte um eine konsequente Vererbungshierarchie, um Redundanzen zu vermeiden
        c) Lassen Sie die gesamte Konsolenausgabe durch eine einzige Methode ausgeben
    Hinweis:
        Tatsächlich ist eine Lösung möglich, in der praktisch alle Member private oder mindestens protected sind ...
        ... lediglich die Konstruktoren und die Methode zur Konsolenausgabe werden ("natürlich") public sein
*/
namespace virtual_override_aufgabe_1
{
    class U
    {
        private static int umsatz;
        private static int loehne;
        private static int gewinn;
        public int Gewinn { get; set; }
        public static void displayErg(int u, int l)
        {
            gewinn = umsatz - loehne;
            Console.WriteLine("Das Betriebsergebnis ist : " + gewinn + "Indonesische Rupiah");

        }
    }
    class M
    {
        int grundgehalt;
        public  int Grundgehalt
        {
            get => grundgehalt; set { }
        }
        string name;
        public string Name { get => name; set { } }
        public M()
        {
        }
        public M(string n,int grundgehalt)
        {
            name = n;
            this.grundgehalt = grundgehalt;
        }
        public static void Zeige(List<M> ML)
        {
            foreach (M m in ML)
            {
                Console.WriteLine("Lohn des Mitarbeiters: "+m.name+"  "+m.grundgehalt);
            }
        }
}
    class V : M
    {

        protected int bonus;
        public V(string n, int gg, int boni) : base( n,gg)
        {
            bonus = boni;
            Grundgehalt = gg;
           
        }
        public static void Zeige(List<V> VL)
        {
            foreach (V m in VL)
            {
                Console.WriteLine("Gehalt des Vorgesetzten: "+m.Name + "  " + m.Grundgehalt);
            }
        }
    }
    class Vstd : V
    {
        protected int bonzenBoni;
       // public static List<Vstd> VstdL = new List<Vstd>();
        public Vstd(string n,int gg, int boni, int bonzenboni) : base(n,gg,boni)
        {
          bonzenBoni = bonzenboni;
            Grundgehalt = gg;
            // VstdL.Add(this);
        }
        public static void Zeige(List<Vstd> VstdL)
        {
            foreach (Vstd m in VstdL)
            {
                Console.WriteLine("Bonzengehalt Vorstand: " + m.Name + "  " + m.Grundgehalt);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            List<V> VL = new List<V>();
            List<Vstd> VstdL = new List<Vstd>();
            List<M> ML = new List<M>();
            int uInput;
            string[] m_names = new string[20] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t" };
            string[] vstd_names = new string[2] { "King", "Kong" };
            string[] v_names = new string[5] { "Pearl Scott Habel", "Cartman", "Chuck Norris", "Uschi Glas", "Roy Black" };
            int Min = 1900;
            int Max = 2101;
            int MinBoni = 450;
            int MaxBoni = 550;
            int[] zufallsgehaltM = new int[20];
            int[] zufallsgehaltV = new int[5];
            int[] zufallsgehaltboni = new int[5];
            int[] zufallsgehaltVstd = new int[2];
            int[] zufallsBonzen = new int[2];
            for (int i = 0; i < zufallsgehaltM.Length; i++)
            {
                zufallsgehaltM[i] = r.Next(Min, Max);
            }
            for (int i = 0; i < 20; i++)
            {
                ML.Add(new M(m_names[i], zufallsgehaltM[i]));
            }
            Min = 3700;
            Max = 4301;
            for (int i = 0; i < zufallsgehaltV.Length; i++)
            {
                zufallsgehaltV[i] = r.Next(Min, Max);
                zufallsgehaltboni[i] = r.Next(MinBoni, MaxBoni);
            }
            for (int i = 0; i < v_names.Length; i++)
            {
                VL.Add(new V(v_names[i], zufallsgehaltV[i],zufallsgehaltboni[i]));
            }
            Min = 7500;
            Max = 8501;
            MinBoni = 2500;
            MaxBoni = 3101;
            for (int i = 0; i < zufallsgehaltVstd.Length; i++)
            {
                zufallsgehaltVstd[i] = r.Next(Min, Max);
                zufallsgehaltboni[i] = r.Next(MinBoni, MaxBoni);
            }
            for (int i=0;i<vstd_names.Length;i++)
            {
                VstdL.Add(new Vstd(vstd_names[i], zufallsgehaltVstd[i], zufallsgehaltboni[i], zufallsBonzen[i]));
            }
            M.Zeige(ML);
            V.Zeige(VL);
            Vstd.Zeige(VstdL);

            Console.ReadKey();
        }
    }
}
