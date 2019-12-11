using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
/*Schreiben Sie ein Konsolenprogramm, welches bei Drücken bestimmter Tasten einen
vorher einzugebenden Text in verschiedenen Farben (an der selben Position) anzeigt.
Taste r -> Schrift in Rot, Hintergrund Schwarz
Taste g -> Schrift in Gelb, Hintergrund Blau
Taste b -> Schrift in Blau, Hintergrund Weiß
Taste e -> Ende Programm
Optional: Umsetzung mit EventHandler
*/
namespace textfarbe_mit_event
{
    public delegate void KeyEventHandler(object sender, KeyEventArgs e);

    public class KeyEventArgs : EventArgs
    {
        public ConsoleKeyInfo KeyInfo { get; private set; }
        public bool Cancel { get; set; }

        public KeyEventArgs(ConsoleKeyInfo cki)
        {
            KeyInfo = cki;
            Cancel = false;

        }
    }

    public class FarbText
    {
        public event KeyEventHandler KeyPressed;
        public string Text { get; set; }

        public FarbText()
        {
        }

        public string GetTextInteractive(string prompt = null)
        {
            Console.Write(prompt ?? "Bitte Text eingeben: ");
            Text = Console.ReadLine();
            return Text;
                
        }
        public void KeyScan()
        {
            while(true)
            {
                if (!OnKeyPressed(Console.ReadKey())) break;
            }
        }
        public bool OnKeyPressed(ConsoleKeyInfo cki)
        {
            KeyEventArgs e = new KeyEventArgs(cki);
            KeyPressed?.Invoke(this,e);
            return !e.Cancel;
        }
    }
    class Program
    {
        static void TextHandler(object sender,KeyEventArgs e)
        {
            if (sender is FarbText ft)
            {
                ConsoleColor fg, bg;
                switch(e.KeyInfo.Key)
                {
                    case ConsoleKey.R:
                        fg = ConsoleColor.Red;
                        bg = ConsoleColor.Black;
                        break;
                    case ConsoleKey.G:
                        fg = ConsoleColor.Yellow;
                        bg = ConsoleColor.Blue;
                        break;
                    case ConsoleKey.B:
                        fg = ConsoleColor.Blue;
                        bg = ConsoleColor.White;
                        break;
                    case ConsoleKey.E:
                        e.Cancel = true;
                        return;
                    default:
                        return;
                }
                PrintText(ft.Text, fg, bg);
            }
        }
        static void PrintText(string text, ConsoleColor fg, ConsoleColor bg)
        {
            ConsoleColor fgold = Console.ForegroundColor;
            ConsoleColor bgold = Console.BackgroundColor;
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
            int x = (text.Length <= Console.WindowWidth) ?
                (Console.WindowWidth - text.Length) / 2 : 0;
            int y = Console.WindowHeight / 2;
            Console.SetCursorPosition(x, y);

            Console.WriteLine(text);
            Console.ForegroundColor = fgold;
            Console.BackgroundColor = bgold;
        }
        static void Main(string[] args)
        {
            FarbText ft = new FarbText();
            ft.KeyPressed += TextHandler;
            ft.GetTextInteractive();

            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Console.WriteLine("R - Text Rot/Hintergrund Schwarz\n"+
                               "G - Text gelb/Hintergrund Blau\n"+
                               "B - text Blau/Hintergrund Weiss\n"+
                               "E - Exit");
            ft.KeyScan();
            Console.CursorVisible = true;
            Console.WriteLine("Any key to continue...");
            Console.ReadKey(true);
        }
    }
}
