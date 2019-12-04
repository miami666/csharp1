using System;


namespace SimpleMovingGame
{
    public class MainGameRun
    {
        // variables
        int playerPosX = 1, playerPosY = 1; // instantion on 1 line
        int enemyPosX, enemyPosY;
        int itemPosX, itemPosY;
        int score, highScore;
        private readonly int length = 10;
        private int height = 10;
        private readonly string player = " O";
        private string space = " |";
        private string enemy = " X";
        private string item = " $";
        static Random random = new Random();

        private int PlayerPosX { get => playerPosX; set => playerPosX = value; }
        private int EnemyPosX { get => enemyPosX; set => enemyPosX = value; }
        private int ItemPosX { get => itemPosX; set => itemPosX = value; }
        private int Score { get => score; set => score = value; }

        // main game
        public void RunTheGame()
        {
            bool playingGame = true;

            while (playingGame)
            {

                MainGamePlay(); // main game logic

                // game is over
                if (Score > highScore) highScore = Score;
                Console.WriteLine($" \n GAME OVER \n High Score: {highScore}");
                Console.Beep(3000, 50);
                Console.Beep(2500, 50);
                Console.Beep(3000, 50);
                Console.Beep(2000, 50);
                Console.Beep(3000, 50);
                Console.Beep(1500, 50);


                // check to restart to game

                Console.Write(" Do you want to play again? (Y/N): ");
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.N) playingGame = false;


            }
        }

        // play game
        public void MainGamePlay()
        {


            PlayerPosX = 1;
            playerPosY = 1;
            EnemyPosX = length;
            enemyPosY = height;
            CreateItem();

            while (true)
            {

                DrawGameboard();
                Console.WriteLine();
                $" Score: {Score}".PrintToConsole();
                if (PlayerCollideWithEnemy()) break;
                if (PlayerCollideWithItem())
                {
                    ++Score;
                    Console.Beep(3000, 50);
                    CreateItem();
                    DrawGameboard();
                }


                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;

                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if ((keyPressed.Key == ConsoleKey.W && playerPosY != 1) || (keyPressed.Key == ConsoleKey.S && playerPosY != height))
                {
                    playerPosY += (keyPressed.Key == ConsoleKey.S) ? 1 : -1;
                }

                if ((keyPressed.Key == ConsoleKey.A && PlayerPosX != 1) || (keyPressed.Key == ConsoleKey.D && PlayerPosX != length))
                {
                    PlayerPosX += (keyPressed.Key == ConsoleKey.D) ? 1 : -1;
                }
                MoveEnemey();

            }
        }

        public void MoveEnemey()
        {
            if (random.Next(0, 11) < 3) return;
            if (random.Next(0, 11) > 5 && PlayerPosX != EnemyPosX || playerPosY == enemyPosY) // X
            {
                if (PlayerPosX < EnemyPosX) --EnemyPosX;
                else if (PlayerPosX > EnemyPosX) ++EnemyPosX;
            }
            else // Y
            {
                if (playerPosY < enemyPosY) --enemyPosY;
                else if (playerPosY > enemyPosY) ++enemyPosY;
            }
        }

        // check if enemy has caught the player

        public bool PlayerCollideWithEnemy()
        {
            if (PlayerPosX == EnemyPosX && playerPosY == enemyPosY) return true;
            return false;

        }

        // check if the player has collected an item

        public bool PlayerCollideWithItem()
        {
            if (PlayerPosX == ItemPosX && playerPosY == itemPosY) return true;
            return false;
        }

        // create a new item

        public void CreateItem()
        {
            int itemX = random.Next(1, length + 1), itemY = playerPosY;

            while (itemY > playerPosY - 2 && itemY < playerPosY + 2)
            {
                itemY = random.Next(1, height);
            }

            ItemPosX = itemX;
            itemPosY = itemY;
        }

        // draw the game
        public void DrawGameboard()
        {
            Console.Clear();
            "".PrintToConsole();
            $" Player's position {PlayerPosX}, {playerPosY}".PrintToConsole();
            Console.ForegroundColor = ConsoleColor.Red;
            $" Enemy's position  {EnemyPosX}, {enemyPosY}".PrintToConsole();
            Console.ForegroundColor = ConsoleColor.Yellow;
            "".PrintToConsole();

            for (int y = 1; y <= height; ++y)
            {
                for (int x = 1; x <= length; ++x)
                {
                    if (x == EnemyPosX && y == enemyPosY) Console.Write(enemy);
                    else if (x == PlayerPosX && y == playerPosY) Console.Write(player);
                    else if (x == ItemPosX && y == itemPosY) Console.Write(item);
                    else Console.Write(space);
                }
                "".PrintToConsole();
            }




        }


    }
}

