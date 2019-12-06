using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_aufgabe_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, e) =>
            {

                Console.WriteLine("Exiting...");
                Environment.Exit(0);
            };

            Console.WriteLine("Press ESC to Exit");
            var taskKeys = new Task(ReadKeys);
        

            taskKeys.Start();
        

            var tasks = new[] { taskKeys };
            Task.WaitAll(tasks);
        }
        private static void ReadKeys()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            while (!Console.KeyAvailable && key.Key != ConsoleKey.Escape)
            {

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.WriteLine("UpArrow was pressed");
                        break;
                    case ConsoleKey.DownArrow:
                        Console.WriteLine("DownArrow was pressed");
                        break;

                    case ConsoleKey.RightArrow:
                        Console.WriteLine("RightArrow was pressed");
                        break;

                    case ConsoleKey.LeftArrow:
                        Console.WriteLine("LeftArrow was pressed");
                        break;

                    case ConsoleKey.Escape:
                        break;

                    default:
                        if (Console.CapsLock && Console.NumberLock)
                        {
                            Console.WriteLine(key.KeyChar);
                        }
                        break;
                }
            }
        }
    }
}
