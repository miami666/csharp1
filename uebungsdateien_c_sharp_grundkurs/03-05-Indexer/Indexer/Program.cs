using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    class MyDictionary
    {
        int[] values = new int[10];
        string[] keys = new string[10];

        public int this[string key]
        {
            get
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    if (keys[i] == key)
                    {
                        return values[i];
                    }
                }
                throw new Exception( "Schlüsssel " + key + " nicht gefunden." );
            }
            set
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    if (keys[i] == null)
                    {
                        keys[i] = key;
                        values[i] = value;
                        return;
                    }
                }
                throw new Exception( "Kein Platz mehr!" );
            }
        }
    }


    class Program
    {
        static void Main( string[] args )
        {
            MyDictionary dict = new MyDictionary();

            dict["Hallo"] = 1234;

            int hallo = dict["Hallo"];

            Console.WriteLine(hallo);

        }
    }
}
