using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_01_Objektbeziehungen
     
{
    class Reise
    {
        string Zweck { get; set; }

        Mitarbeiter Mitarbeiter { get; set; }
        List<Kostenpunkt> kostenpunkte = new List<Kostenpunkt>();

        public void AddKostenpunkt(Kostenpunkt kostenpunkt)
        {
            this.kostenpunkte.Add(kostenpunkt);
        }

        public IEnumerable<Kostenpunkt> Kostenpunkte { get => this.kostenpunkte; }
    }
}
