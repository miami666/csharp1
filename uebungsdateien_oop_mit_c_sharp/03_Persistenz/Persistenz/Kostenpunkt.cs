using System;
using System.Linq;
using System.Collections.Generic;
using NDO;

namespace Persistenz
{
    /// <summary>
    /// Summary for Kostenpunkt
    /// </summary>
    [NDOPersistent]
    public abstract partial class Kostenpunkt
    {
        public DateTime Datum { get; set; }
        abstract public string Text { get; set; }
        abstract public decimal Betrag { get; set; }

        public Kostenpunkt()
        {
        }

        public override string ToString()
        {
            return $"{Datum.ToShortDateString()}\t{Text}\t{Betrag}";
        }
    }
}
