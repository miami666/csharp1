using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Klasse mit private struct mit 4 dim jagged double array + int id
 private Liste dieser Struktur

    public set und get Methoden oder wahlweise Properties der Liste verwenden die Get & Set Methoden für die Struktur

    get und set methoden im main testen ( mit werten füllen und wieder auslesen

     */
namespace _4dim_jagged
{
    public struct MyStruct
    {
        public readonly double Value1;
        public readonly decimal Value2;

        public MyStruct(double value1, decimal value2)
        {
            this.Value1 = value1;
            this.Value2 = value2;
        }
    }

   

class Test
    {
        private MyStruct myStruct;

        public Test()
        {
            myStruct = new MyStruct(10, 42);
        }

        public MyStruct MyStruct
        {
            get { return myStruct; }
            set { myStruct = value; }
        }
    }

    class Program
{
    static void Main(string[] args)
    {
            Test test = new Test();
            Console.WriteLine(test.MyStruct.Value1.ToString());
            Console.ReadKey();
            

    }
}
}
