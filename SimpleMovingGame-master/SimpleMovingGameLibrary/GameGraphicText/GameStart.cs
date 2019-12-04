using System;


namespace SimpleMovingGame
{
    public class GameStart
    {
        public void TypeWritter(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(1);

            }

        }
        public void GameOverinBlue()
        {

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Title = "ASCII Art";
            "".PrintToConsole(); // breakline
            string titleBlue =
                 @"
                                       
                           


                             _    _      _                          
                            | |  | |    | |                         
                            | |  | | ___| | ___ ___  _ __ ___   ___ 
                            | |/\| |/ _ \ |/ __/ _ \| '_ ` _ \ / _ \
                            \  /\  /  __/ | (_| (_) | | | | | |  __/
                             \/  \/ \___|_|\___\___/|_| |_| |_|\___|
                                        
                                        



                  ";

            TypeWritter(titleBlue);
            Console.WriteLine(); // breakline

            Console.ForegroundColor = ConsoleColor.Yellow;
            " Make sure the enemy does not catch you!".PrintToConsole();
            "".PrintToConsole();
            " Press \n  A to move left, \n  D to move right, \n  S to move down, \n  W to move up  ".PrintToConsole();
            "".PrintToConsole();
            " Press any key to begin".PrintToConsole();
            Console.ReadKey();
            Console.Clear();

        } // method end


    }
}
