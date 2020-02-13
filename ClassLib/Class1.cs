using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLib
{
    public static class Textfile
    {
   
            public static void Write(string text, string pfad, bool anhaeng, bool newline)
            {
                using (StreamWriter sw = new StreamWriter(pfad, anhaeng))
                {
                    if (newline == true)
                    {
                    sw.WriteLine(text);
                    }
                    else
                    {
                    sw.Write(text);
                    }
                }
            }
            public static void Read(string pfad)
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

