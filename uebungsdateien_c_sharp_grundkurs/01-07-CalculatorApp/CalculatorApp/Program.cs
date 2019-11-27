using System;
using CalcLib;

namespace HelloWorld
{
	class Program
	{
		static void Main( string[] args )
		{
			int v1 = 3;
			int v2 = 5;
			int i = Calculator.Add(3, 5);
			Console.WriteLine( $"{v1} + {v2} = {i}");
		}
	}
}
