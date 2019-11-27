using System;
using System.Linq;
using System.Collections.Generic;
using NDO;

namespace Persistenz
{
    /// <summary>
    /// Summary for Mitarbeiter
    /// </summary>
    [NDOPersistent]
    public partial class Mitarbeiter
    {
        string vorname;
        string nachname;

        [NDORelation(RelationInfo.Composite)]
        List<Reise> reisen = new List<Reise>();
        public IEnumerable<Reise> Reisen
        {
            get { return this.reisen; }
            set { this.reisen = value.ToList(); }
        }
        public Reise NewReise()
        {
        	Reise r = new Reise();
        	this.reisen.Add(r);
        	return r;
        }
        public void RemoveReise(Reise r)
        {
        	if (this.reisen.Contains(r))
        		this.reisen.Remove(r);
        }

        public string Vorname
        {
            get { return this.vorname; }
            set { this.vorname = value; }
        }
        public string Nachname
        {
            get { return this.nachname; }
            set { this.nachname = value; }
        }

        public Mitarbeiter()
        {
        }
    }
}
