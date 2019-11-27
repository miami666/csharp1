using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_01_Objektbeziehungen
{
    class Beleg : Kostenpunkt
    {
        string text;
        decimal betrag;
        public override string Text { get => text; set => text = value; }
        public override decimal Betrag { get => betrag; set => betrag = value; }
    }
}
