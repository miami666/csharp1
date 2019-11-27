using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateStart
{
	class Program
	{
        delegate bool StringTester(string s);

		static void Main( string[] args )
		{
			new Program().DoIt();
		}

		void DoIt()
		{
            StringTester stringTester = new StringTester(ContainsDigit);

            Console.WriteLine(stringTester("a bc")); 
		}

		bool ContainsWhiteSpace(string s)
		{
			for ( int i = 0; i < s.Length; i++ )
			{
				if ( Char.IsWhiteSpace( s[i] ) )
					return true;
			}

			return false;
		}

        bool ContainsDigit(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsDigit(s[i]))
                    return true;
            }

            return false;
        }
	}
}
