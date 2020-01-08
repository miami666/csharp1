using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dateistream
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] arr = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            byte[] arrRead = new byte[10];
            string pfad = @"C:\0801\testfile.txt";
            using (FileStream fs = new FileStream(pfad, FileMode.Create))
            {
                fs.Write(arr, 0, arr.Length);
                fs.Seek(0, SeekOrigin.Begin);
                fs.Read(arrRead, 0, 10);
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arrRead[i]);
                    

                }
                Console.ReadLine();
            }
           
        }
    }
}
