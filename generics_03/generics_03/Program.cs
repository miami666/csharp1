using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generics_03
{
	public abstract class Getreide { }

	public class Gerste : Getreide
	{
		public string Abnehmer { get; set; }
		public Gerste(string abnehmer) { Abnehmer = abnehmer; }
	}

	public class Hafer : Getreide
	{
		public string Herkunft { get; set; }
		public Hafer(string herkunft) { Herkunft = herkunft; }
	}

	public class Sack<T> where T : Getreide
	{
		public bool IsEmpty { get; set; } = true;
		public void Fill() { IsEmpty = false; }
		public void Empty() { IsEmpty = true; }
	}

	internal class Program
	{
		private static void Main()
		{
			Gerste g = new Gerste("Lidl");
			Hafer h = new Hafer("Deutschland");

			Sack<Gerste> gSack = new Sack<Gerste>();
			Sack<Hafer> hSack = new Sack<Hafer>();

			if (gSack.IsEmpty) { gSack.Fill(); } else { gSack.Empty(); }

			if (hSack.IsEmpty) { hSack.Fill(); } else { hSack.Empty(); }

			Console.WriteLine("Hello World!");
			Console.ReadKey();
		}
	}
}
