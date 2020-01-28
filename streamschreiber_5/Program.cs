using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace streamschreiber_5
{
    public static class TestKlasse {
        public static void DateiSchreib(string text, string pfad, bool anhaeng)
        {
            using (StreamWriter sw = new StreamWriter(pfad, anhaeng))
            {
                sw.Write(text);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = "2801.txt";
            string textToAdd = "xxx";
            TestKlasse.DateiSchreib(textToAdd, Path.Combine(docPath,filename), true);
        }
    }
}
