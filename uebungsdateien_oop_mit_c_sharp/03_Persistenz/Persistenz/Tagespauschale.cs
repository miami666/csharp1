using System;
using System.Linq;
using System.Collections.Generic;
using NDO;

namespace Persistenz
{
    /// <summary>
    /// Summary for Tagespauschale
    /// </summary>
    [NDOPersistent]
    public partial class Tagespauschale : Kostenpunkt
    {
        public override string Text { get => "Tagespauschale\t"; set { } }
        // Bitte verwenden Sie diese Logik nicht in der Praxis.
        // Sie entspricht nicht den Regeln für die Tagespauschale, in keinem Land.
        public override decimal Betrag { get => (Datum - StartDatum).TotalHours > 8 ? 12m : 0; set { } }
        public DateTime StartDatum { get; set; }

        public Tagespauschale()
        {
        }
    }
}
