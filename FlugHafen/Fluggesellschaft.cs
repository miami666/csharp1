using FlugReservierung;
using System;
using System.Collections.Generic;

namespace FlugReservierung
{
    public  class Fluggesellschaft
    {
        public string kennung;
        public Fluggesellschaft(string kennung)
        {
            this.kennung = kennung;
        }
        public IFlugzeug flugzeug;

        public static List<Flug> flugListe = new List<Flug>();

        public static List<Flughafen> flughafenListe = new List<Flughafen>();
    
       
        

        internal static void Add(Flug flug)
        {
            flugListe.Add(flug);
        }
        internal static void AddHafen(Flughafen hafen)
        {
            flughafenListe.Add(hafen);
        }

        internal static void Delete(string flugId)
        {
            foreach (var flug in flugListe)
            {
                if (string.Equals(flug.flugId, flugId))
                {
                    flugListe.Remove(flug);
                    break;
                }
            }
        }
        public static new string ToString()
        {
            string result = "";
            foreach (var flug in flugListe)
            {
                result+= flug.flugId + "\n";
            }
            return result;
        }
    }
}