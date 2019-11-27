using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Static
{

    public static class MyStringExtensions
    {
        public static int IndexOfReg( this string s, string expression )
        {
            Regex regex = new Regex( expression );
            Match match = regex.Match( s );

            if (!match.Success)
                return -1;

            return match.Index;
        }
    }

    class Program
    {
        public static void Main()
        {
            string s = "dkdkdkdk4dkd";

            int i = s.IndexOfReg( @"\d" );

            Console.WriteLine( i );
        }
    }
}
