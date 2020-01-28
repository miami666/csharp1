using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary2
{
    public static class Class1
    {
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
    }
}
