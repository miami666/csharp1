using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Überschreiben
{
	class Program
	{
		class Mitarbeiter
		{
			public string Vorname { get; set; }
			public string Nachname { get; set; }
			public decimal Gehalt { get; set; }

			public virtual decimal Einkommen()
			{
				return Gehalt;
			}
		}

		class Manager : Mitarbeiter
		{
			public decimal Bonus { get; set; }
			public override decimal Einkommen()
			{ 
				return Gehalt + Bonus;
			}
		}
		static void Main( string[] args )
		{
			List<Mitarbeiter>list = new List<Mitarbeiter>();
			list.Add( new Mitarbeiter { Gehalt = 20000, Vorname = "Hans", Nachname = "Müller" } );
			list.Add( new Manager { Gehalt = 100000, Vorname = "Max", Nachname = "Protz", Bonus = 50000 } );

			//...

			foreach (var mitarbeiter in list)
			{
				Console.WriteLine($"{mitarbeiter.Vorname} {mitarbeiter.Nachname} {mitarbeiter.Einkommen()}");
			}
		}
	}
}
