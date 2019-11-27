using System;
using System.Linq;
using System.Collections.Generic;
using NDO;

namespace Persistenz
{
    /// <summary>
    /// Summary for Beleg
    /// </summary>
    [NDOPersistent]
    public partial class Beleg : Kostenpunkt
    {
        string text;
        decimal betrag;
        public override string Text { get => text; set => text = value; }
        public override decimal Betrag { get => betrag; set => betrag = value; }

        public Beleg()
        {
        }
    }
}
