using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace lottoSuperSechs
{
    class Program
    {
        static void Main(string[] args)
        {
            Random zufall = new Random();
            int[] zahlen = new int[6];
            List<int> ranZahlen = new List<int>();
            while (ranZahlen.Count != zahlen.Length)
            {
                int z = ((zufall.Next(1, 50) + zufall.Next(1, 50)) % 49) + 1;
                if (!ranZahlen.Contains(z)) ranZahlen.Add(z);
            }
            foreach (var item in ranZahlen)
            {
                Console.WriteLine(item);
            }
            zahlen = ranZahlen.ToArray();
            Lotto loto = new Lotto(zahlen);
            loto.run();
            //Console.WriteLine("0 Richtige: " + ((double)loto.richtigeZahlen[0] / (double)loto.richtigeZahlen.Sum() * 100f).ToString("00.00") + "%");
            //Console.WriteLine("1 Richtige: " + ((double)loto.richtigeZahlen[1] / (double)loto.richtigeZahlen.Sum() * 100f).ToString("00.00") + "%");
            //Console.WriteLine("2 Richtige: " + ((double)loto.richtigeZahlen[2] / (double)loto.richtigeZahlen.Sum() * 100f).ToString("00.00") + "%");
            //Console.WriteLine("3 Richtige: " + ((double)loto.richtigeZahlen[3] / (double)loto.richtigeZahlen.Sum() * 100f).ToString("00.00") + "%");
            //Console.WriteLine("4 Richtige: " + ((double)loto.richtigeZahlen[4] / (double)loto.richtigeZahlen.Sum() * 100f).ToString("00.00") + "%");
            //Console.WriteLine("5 Richtige: " + ((double)loto.richtigeZahlen[5] / (double)loto.richtigeZahlen.Sum() * 100f).ToString("00.00") + "%");
            //Console.WriteLine("6 Richtige: " + ((double)loto.richtigeZahlen[6] / (double)loto.richtigeZahlen.Sum() * 100f).ToString("00.00") + "%");
            Console.ReadKey();
        }
    }
    class Lotto
    {
        private int[] zahlen;
        private long count;
        public int[] richtigeZahlen;
        public Lotto(int[] zahlen)
        {
            this.zahlen = zahlen;
        }
        public void run()
        {
            Random zufall = new Random();
            count = 0;
            int richtig = 0;
            richtigeZahlen = new int[zahlen.Length + 1];
            while (richtig != zahlen.Length && count != 1)
            {
                List<int> ranZahlen = new List<int>();
                while (ranZahlen.Count != zahlen.Length)
                {
                    int z = zufall.Next(1, 50);
                    if (!ranZahlen.Contains(z)) ranZahlen.Add(z);
                }
                count++;
                richtig = richtige(ranZahlen.ToArray());
                richtigeZahlen[richtig]++;
                foreach (var item in ranZahlen)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine("Finished");
        }
        private int richtige(int[] lottoZahlen)
        {
            return lottoZahlen.Where(x => zahlen.Contains(x)).Count();
        }
    }
}
