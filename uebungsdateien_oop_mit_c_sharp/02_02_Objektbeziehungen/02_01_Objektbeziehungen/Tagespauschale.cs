using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_01_Objektbeziehungen
{
    class Tagespauschale : Kostenpunkt
    {
        public override string Text { get => "Tagespauschale\t"; set { } }
        public override decimal Betrag { get => (Datum - StartDatum).TotalHours > 8 ? 12m : 0; set { } }
        public DateTime StartDatum { get; set; }

    }
}
