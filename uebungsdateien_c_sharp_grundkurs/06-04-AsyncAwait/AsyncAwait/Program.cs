using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
	class Program
	{
		static void Main( string[] args )
		{
			new Program().DoIt();
		}

		void DoIt()
		{
			string s = ReadAll().Result;
			Console.WriteLine(s);
		}

		async Task<string> ReadAll()
		{
			StreamReader sr1 = new StreamReader("File A.txt");
			StreamReader sr2 = new StreamReader("File B.txt");
			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			string s1 = await sr1.ReadToEndAsync();
			Console.WriteLine( Thread.CurrentThread.ManagedThreadId );
			string s2 = await sr2.ReadToEndAsync();
			Console.WriteLine( Thread.CurrentThread.ManagedThreadId );
			return s1 + s2;
		}
	}
}
