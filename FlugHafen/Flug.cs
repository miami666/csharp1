using FlugReservierung;
using System;
using System.Collections.Generic;

namespace FlugReservierung
{
    public class Flug
    {
        private DateTime startZeit;
        private DateTime ankunftZeit;
        private float distanz;
        public string von;
        public string ziel;
        public string flugId;
        public IFlugzeug flugzeug;
        public List<string> gebuchteSitze = new List<string>();
        public List<string> Flugpassagiere = new List<string>();

        public Flug(string von, string ziel, DateTime start, DateTime ankunft, float distanz, IFlugzeug flugzeug)
        {
            this.startZeit = start;
            this.ankunftZeit = ankunft;
            this.distanz = distanz;
            this.von = von;
            this.ziel = ziel;
            this.flugzeug = flugzeug;
            this.flugId = $"{von}:{ziel}-{start.ToString("ddMMyyyyHHmmss")}";
        }
    }
}