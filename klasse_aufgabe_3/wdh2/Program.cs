using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace wdh2
{
    class Program
    {
       // //call by value
       //public static int sum(int a,int b)
       // {
       //     a = a + b;
       //     Console.WriteLine("In sum ist a="+a);
       //    // return a + b;
       //     return a;
       // }
       // public static void sumOutInt(ref int a)
       // {
       //     a = a + a;
       // }
       // static void Main(string[] args)
       // {
       //     int a = 2;
       //     int b = 4;
       //     Console.WriteLine("summe aus {0} und {1} ist {2}",a,b, sum(a,b));
       //     Console.ReadKey();
       //     sumOutInt(ref a);
       // }
       struct mystruct
        {
            public double wert;
            public string wertname;
        }
        List<mystruct> meineListe = new List<mystruct>();
        static bool fillMyStruct(out mystruct bla)
        {
                Console.WriteLine("wert eingeben bitte: ");
                bla.wert = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Wertname: ");
                bla.wertname = Console.ReadLine();
               return true;
        }
        static bool fillMyStructList(out List<mystruct> liste)
        {
            bool ende = false;
            liste = new List<mystruct>();
            mystruct strukturtur;
            do
            {
                if(fillMyStruct(out strukturtur))
                {
                    liste.Add(strukturtur);
                }
            } while (!ende);
            return true;
        }
        static void Main(string[] args)
        {
            mystruct a;
            fillMyStruct(out a);
            List<mystruct> liste = new List<mystruct>();
            fillMyStructList(out liste);
            foreach (mystruct ms in liste)
            {
                Console.WriteLine(a.wert + a.wertname);
            };
            Console.ReadKey();
        }
    }
}
