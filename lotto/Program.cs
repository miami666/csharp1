//Example Lottery program to generate a set of unique pseudo random numbers
//Written in C# with Microsoft .NET beta 2
//Shows use of Random and Stack class.
//J O'Donnell 29/06/01
//wincepro@hotmail.com //only change needed from beta 1 to beta 2 was to use Convert class.
namespace Lottery
{
    using System;
    using System.Collections;
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Lottery
    {
        public static int Numbers, EndRange;
        //Displays titles and gets start values
        public static void DisplayTitles()
        {
            EndRange = 0;
            Numbers = 1;
            while (EndRange < Numbers)
            {
                System.Console.WriteLine("=============================");
                System.Console.WriteLine("Lottery number generator");
                System.Console.WriteLine("=============================");
                System.Console.Write("How many unique numbers? : ");
                Numbers = Convert.ToInt32(System.Console.ReadLine());
                System.Console.Write("Enter end range : ");
                EndRange = Convert.ToInt32(System.Console.ReadLine());
            }
        }
        //Generate our unique numbers and push them onto stack
        public static void GenerateNumbers(Stack s, Dice d)
        {
            bool exists = true;
            int i;
            int val;
            for (i = 1; i <= Numbers; i++)
            {
                val = d.RollDice(EndRange); //Roll EM!
                exists = s.Contains(val);
                while (exists == true) //Reroll if we already
                {
                    //have that number
                    val = d.RollDice(EndRange);
                    exists = s.Contains(val);
                }
                s.Push(val);
            }
        }
        //Retrieve all values from the stack and output to console
        public static void DisplayResults(Stack s)
        {
            for (int i = 1; i <= Numbers; i++)
            {
                System.Console.WriteLine(s.Pop());
               
            }
        }
        //Entry point for program
        public static int Main(string[] args)
        {
            Stack s = new Stack();
            Dice d = new Dice();
            DisplayTitles();
            GenerateNumbers(s, d);
            DisplayResults(s);
            Console.ReadKey();
            return 0;

        }
    }
    //Class to simulate a dice
    public class Dice
    {
        public int RollDice(int sides)
        {
            Random r = new Random();
            int i = 0;
            while (i == 0)
            {
                i = r.Next(sides + 1);
            } //discard zero values
            return i;
        }
    }
}