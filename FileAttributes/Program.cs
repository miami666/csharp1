using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileAttribut
{
    class Program
    {
        public static void Main()
        {
            string path = @"c:\0701\test.txt";

           
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            FileAttributes attributes = File.GetAttributes(path);

            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
               
                attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
                File.SetAttributes(path, attributes);
                Console.WriteLine("Datei {0} nicht mehr schreibgeschuetzt.", path);
            }
            else
            {
            
                File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
                Console.WriteLine("Datei {0} jetzt versteckt.", path);
            }

            Console.ReadKey();
        }

        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }
    }

}


