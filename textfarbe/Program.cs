using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Schreiben Sie ein Konsolenprogramm, welches bei Drücken bestimmter Tasten einen 
vorher einzugebenden Text in verschiedenen Farben (an der selben Position) anzeigt.
Taste r -> Schrift in Rot, Hintergrund Schwarz
Taste g -> Schrift in Gelb, Hintergrund Blau
Taste b -> Schrift in Blau, Hintergrund Weiß
Taste e -> Ende Programm*/
namespace textfarbe
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
               // Console.TreatControlCAsInput = true;
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.Q)
                {
                    break;
                }
              /*  if ((pressedKey.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
                Console.WriteLine(pressedKey.Key.ToString());*/
                OnKeyDown(pressedKey.KeyChar);

            }
        }
        private static void OnKeyDown(char key)
        {
            if (key == 'r')
            {
                ChangeTextColor(ConsoleColor.Red, key.ToString());
            }
            if (key == 'g')
            {
                ChangeTextColor(ConsoleColor.Yellow, key.ToString());
            }
        }
        private static void ChangeTextColor(ConsoleColor color, string originalValue)
        {      
            ConsoleColor originalColor = Console.ForegroundColor;
           // Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.ForegroundColor = color;

 
            Console.Write(originalValue);


           // Console.ForegroundColor = originalColor;
        }
    }
}
    

