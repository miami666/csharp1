using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lotto_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] thelottery = new int[52];
            int[] usernumbers = new int[6];
            Random rnd = new Random();

            Console.Write("Please enter six numbers for the lottery: \n");
            usernumbers[0] = Convert.ToInt32(Console.ReadLine());
            usernumbers[1] = Convert.ToInt32(Console.ReadLine());
            usernumbers[2] = Convert.ToInt32(Console.ReadLine());
            usernumbers[3] = Convert.ToInt32(Console.ReadLine());
            usernumbers[4] = Convert.ToInt32(Console.ReadLine());
            usernumbers[5] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nYour numbers are: ");
            for (int i = 0; i < 6; i++)
            {
                Console.Write("{0} ", usernumbers[i]);
            }

            Console.Write("\n\nPress any key to view the results of the lottery: ");
            Console.ReadKey();

            int best_week = 0;
            int best_matches = 0;

            /* Compute lottery numbers for 52 weeks */
            for (int limit = 0; limit < 52; limit++)
            {
                /* Compute the 6 lottery numbers for this week */
                for (int weeks = 0; weeks < 6; weeks++)
                {
                    thelottery[weeks] = rnd.Next(49) + 1;
                    Console.Write("\t{0} ", thelottery[weeks]);
                }

                /* Compute the amount of matches for this week. */
                int matches = 0;
                //Check each usernumber with each lottery number for a match
                for (int i = 0; i < 6; i++)
                {
                    //e.g. for i=0, check how many times usernumbers[0] appears in thelottery[].
                    for (int j = 0; j < 6; j++)
                    {
                        if (usernumbers[i] == thelottery[j])
                            matches++;
                    }
                }

                /* Did we have more matches this week than previosuly recorded? */
                if (matches > best_matches)
                {
                    /* yes, remember the new best week and the number of matches. */
                    best_week = limit;
                    best_matches = matches;
                }

                Console.WriteLine();
            }
            Console.ReadKey();  /* Here, the result of the best week and the best matches is avaiable! */
        }
    }
}
