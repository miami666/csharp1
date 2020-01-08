using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace streeamschreiber_2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo myFile = new FileInfo(@"c:\0801\neueDatei.txt");
            if (0 != (myFile.Attributes & FileAttributes.ReadOnly))
            {
                myFile.Attributes = (myFile.Attributes ^ FileAttributes.ReadOnly);
            }
            using (StreamWriter sw = new StreamWriter(@"c:\0801\neueDatei.txt"))
            {
                sw.WriteLine("Eat my shorts");
                sw.WriteLine("Eat my shorts!!!!");
            }
            myFile.Attributes = (myFile.Attributes ^ FileAttributes.ReadOnly);
            string line = "";
            using (StreamReader sr = new StreamReader(@"c:\0801\neueDatei.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.ReadKey();
        }
    }
}
