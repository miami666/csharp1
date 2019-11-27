using System;
using System.Linq;
using System.Collections.Generic;
using NDO;

namespace Persistenz
{
    /// <summary>
    /// Summary for Reise
    /// </summary>
    [NDOPersistent]
    public partial class Reise
    {
        [NDORelation]
        Mitarbeiter mitarbeiter;

        [NDORelation(RelationInfo.Composite)]
        List<Kostenpunkt> kostenpunkte = new List<Kostenpunkt>();

        [NDORelation]
        Land land;

        string zweck;

        public Land Land
        {
            get { return this.land; }
            set { this.land = value; }
        }

        public string Zweck
        {
            get { return this.zweck; }
            set { this.zweck = value; }
        }

        public IEnumerable<Kostenpunkt> Kostenpunkte
        {
            get { return this.kostenpunkte; }
            set { this.kostenpunkte = value.ToList(); }
        }
        public Kostenpunkt AddKostenpunkt(Kostenpunkt k)
        {        	
        	this.kostenpunkte.Add(k);
        	return k;
        }
        public void RemoveKostenpunkt(Kostenpunkt k)
        {
        	if (this.kostenpunkte.Contains(k))
        		this.kostenpunkte.Remove(k);
        }

        public Mitarbeiter Mitarbeiter
        {
            get { return this.mitarbeiter; }
            set { this.mitarbeiter = value; }
        }

        public Reise()
        {
        }
    }
}
