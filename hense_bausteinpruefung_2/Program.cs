using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hense_bausteinpruefung_2
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
        public void UserInput()
        {
            while (true)
            {
                if (!OnKeyPressed(Console.ReadKey())) break;
            }
        }
        public bool OnKeyPressed(ConsoleKeyInfo cki)
        {
            KeyEventArgs e = new KeyEventArgs(cki);
            KeyPressed?.Invoke(this, e);
            return !e.Cancel;
        }
    }
    public class ColorChanger
    {
        ConsoleColor fgold = Console.ForegroundColor;
        ConsoleColor fg;
        public ColorChanger()
        {
            ConsoleColor fgold = Console.ForegroundColor;
        }
        public void SetColor(object sender, KeyEventArgs e)
        {
            if (sender is FarbText ft)
            {
                switch (e.KeyInfo.Key)
                {
                    case ConsoleKey.C:
                        fg = ConsoleColor.Cyan;
                        break;
                    case ConsoleKey.G:
                        fg = ConsoleColor.Green;
                        break;
                    case ConsoleKey.B:
                        fg = ConsoleColor.Blue;
                        break;
                    case ConsoleKey.M:
                        fg = ConsoleColor.Magenta;
                        break;
                    case ConsoleKey.E:
                        e.Cancel = true;
                        return;
                    default:
                        fg = fgold;
                        break;
                }
                PrintText(ft.Text, fg);
            }
        }
        public void PrintText(string text, ConsoleColor fg)
        {
            ConsoleColor fgold = Console.ForegroundColor;
            Console.ForegroundColor = fg;
            int x = (text.Length <= Console.WindowWidth) ?
                (Console.WindowWidth - text.Length) / 2 : 0;
            int y = Console.WindowHeight / 2;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
            Console.ForegroundColor = fgold;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FarbText ft = new FarbText();
            ColorChanger cc = new ColorChanger();
            ft.KeyPressed += cc.SetColor;
            ft.GetTextInteractive();
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("B - Blau\n" +
                               "C - Cyan\n" +
                               "G - Green\n" +
                               "M - Magenta\n" +
                               "E - Exit");
            ft.UserInput();
            Console.CursorVisible = true;
            Console.WriteLine("Any key to exit...");
            Console.ReadKey(true);
        }
    }
}
