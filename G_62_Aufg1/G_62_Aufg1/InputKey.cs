using System;

namespace G_62_Aufg1
{
    class InputKey
    {
        public delegate void InputEventHandler(char c);
        public event InputEventHandler InputEvent;

        public delegate void EscapeEventHandler();
        public event EscapeEventHandler EscapeEvent;

        public void startInput()
        {
            while (true)
            {
                char c = Console.ReadKey(true).KeyChar;
                if ((ConsoleKey)c == ConsoleKey.Escape)
                    return;
                InputEvent?.Invoke(c);
            }
        }
    }
}
