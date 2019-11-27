using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
	delegate bool IntTest(int value);

	class Program
	{
		List<int> list = new List<int>() { 6, 1, 23, 9, 4 };

		static void Main( string[] args )
		{
			new Program().DoIt();
		}

		void DoIt()
		{
            list.Sort(Ascending); 

			foreach ( int i in list )
			{
				Console.WriteLine( i );
			}
		}

        int Ascending(int i1, int i2)
        {
            return i1 - i2;
        }

        int Descending(int i1, int i2)
        {
            return i2 - i1;
        }

	}
}
