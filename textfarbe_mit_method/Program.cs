using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textfarbe_mit_method
{
    class Program
    {
        public static void ColoredConsoleWrite(ConsoleColor color, string text)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine(text);
            //Console.Write(text+"\r");
            Console.ForegroundColor = originalColor;
        }


        static void Main(string[] args)
        {
            string input;
            Console.WriteLine("Texteingabe:");
            input = Console.ReadLine();

            while (true)
            {
                

                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
             

                if (pressedKey.Key == ConsoleKey.Q)
                {
                    break;
                }
                if (pressedKey.Key==ConsoleKey.R)
                {
                    ColoredConsoleWrite(ConsoleColor.Red, input);
                }
                if (pressedKey.Key == ConsoleKey.G)
                {
                    ColoredConsoleWrite(ConsoleColor.Yellow, input);
                }
                if (pressedKey.Key == ConsoleKey.B)
                {
                    ColoredConsoleWrite(ConsoleColor.Blue, input);
                }
            }
           
            Console.ReadKey();
        }
    }
}
