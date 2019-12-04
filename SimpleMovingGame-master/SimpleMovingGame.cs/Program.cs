
// https://www.youtube.com/watch?v=ZD-QOSswwDI

namespace SimpleMovingGame
{


    public class Program
    {
        // main game

        static void Main()
        {
            StartGame();
            EndGame();
        }

        private static void EndGame()
        {
            GameOver.GameOverinRed();
        }

        private static void StartGame()
        {
            GameStart gameStart = new GameStart();
            gameStart.GameOverinBlue();

            MainGameRun mainGameRun = new MainGameRun();
            mainGameRun.RunTheGame();
        }
    }
}

