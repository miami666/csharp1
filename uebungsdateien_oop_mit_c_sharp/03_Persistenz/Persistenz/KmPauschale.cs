using System;
using System.Linq;
using System.Collections.Generic;
using NDO;

namespace Persistenz
{
    /// <summary>
    /// Summary for KmPauschale
    /// </summary>
    [NDOPersistent]
    public partial class KmPauschale : Kostenpunkt
    {
        public int AnzahlKm { get; set; }
        public override string Text { get => "Km-Pauschale\t"; set { } }
        public override decimal Betrag { get => AnzahlKm * .2m; set { } }

        public KmPauschale()
        {
        }
    }
}
