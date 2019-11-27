using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_01_Objektbeziehungen
{
    class KmPauschale : Kostenpunkt
    {
        public int AnzahlKm { get; set; }
        public override string Text { get => "Km-Pauschale\t"; set { } }
        public override decimal Betrag { get => AnzahlKm * .2m; set { } }
    }
}
