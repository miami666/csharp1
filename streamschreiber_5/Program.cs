﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClassLibrary2;

namespace streamschreiber_5
{
/*    public static class TestKlasse {
        public static void DateiSchreib(string text, string pfad, bool anhaeng)
        {
            using (StreamWriter sw = new StreamWriter(pfad, anhaeng))
            {
                sw.Write(text);
            }
        }
        public static void DateiLies(string pfad)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string zeile = "";
            using (StreamReader sr = new StreamReader(Path.Combine(docPath, pfad)))
            {
                while ((zeile = sr.ReadLine()) != null)
                {
                    Console.WriteLine(zeile);
                }
            }

        }
    }*/
    class Program
    {
        static void Main(string[] args)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = "2801.txt";
            string textToAdd = "xxx";
            Class1.DateiSchreib(textToAdd, Path.Combine(docPath,filename), true);
            Class1.DateiLies(filename);

            Console.ReadKey();
        }
    }
}
