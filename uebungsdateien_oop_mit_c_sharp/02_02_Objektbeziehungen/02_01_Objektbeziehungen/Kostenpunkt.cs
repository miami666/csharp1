using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_01_Objektbeziehungen
{
    abstract class Kostenpunkt
    {
        public DateTime Datum { get; set; }
        abstract public string Text { get; set; }
        abstract public decimal Betrag { get; set; }

    }
}
