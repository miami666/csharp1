using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business
{
    interface IStoreInventory
    {
        long ID { get; set; }
        string Flugziel { get; set; }
        decimal Preis { get; set; }
        string FlugDatum { get; set; }
        DateTime AbflugsZeit { get; set; }
        DateTime AnkunftsZeit { get; set; }
        int FreiePlaetze { get; set; }
    }
}

namespace FlugOrder
{
    public sealed class FlugEntity : Business.IStoreInventory
    {
        private long id;
        private string flugziel;
        private decimal preis;
        private string flugDatum;
        private DateTime abflugsZeit;
        private DateTime ankunftsZeit;
        private int freiePlaetze;

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Flugziel
        {
            get { return flugziel; }
            set { flugziel = value; }
        }

        public decimal Preis
        {
            get { return (preis < 0) ? 0.00M : preis; }
            set { preis = value; }
        }
        public string FlugDatum
        {
            get { return flugDatum; }
            set { flugDatum = value; }
        }
        public DateTime AbflugsZeit
        {
            get { return abflugsZeit; }
            set { abflugsZeit = value; }
        }
        public DateTime AnkunftsZeit
        {
            get { return ankunftsZeit; }
            set { ankunftsZeit = value; }
        }
        public int FreiePlaetze
        {
            get { return freiePlaetze; }
            set { freiePlaetze = value; }
        }
 /*       public FlugEntity()
        {
            this.id = 0;
            this.flugziel = "Unknown";
            this.preis = 0.00M;
            this.flugDatum = "18/11/2017";
        }
*/
        public FlugEntity(long Nbr, string nm, decimal pr, string dt, DateTime abflugZeit, DateTime ankuftZeit, int freiePlaetze)
        {
            this.id = Nbr;
            this.flugziel = nm;
            this.preis = pr;
            this.flugDatum = dt;
            this.abflugsZeit = abflugZeit;
            this.ankunftsZeit = ankuftZeit;
            this.freiePlaetze = freiePlaetze;
        }
    }
}

