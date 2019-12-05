using FlugReservierung;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugReservierung
{
   public class Flughafen
    {
        public string kennung;
        public Flughafen(string kennung)
        {
            this.kennung = kennung;
        }

        public static List<Flughafen> flughafenListe = new List<Flughafen>();






        public static List<Fluggesellschaft> flugGesellschaftListe = new List<Fluggesellschaft>();
        internal static void Add(Fluggesellschaft fluggesellschaft)
        {
            flugGesellschaftListe.Add(fluggesellschaft);
        }
        internal static void Delete(string kennung)
            {
            foreach (var item in flugGesellschaftListe)
            {
                if (string.Equals(item.kennung, kennung))
                {
                    flugGesellschaftListe.Remove(item);
                }

            }

        }
        internal static void AddHafen(Flughafen hafen)
        {
            flughafenListe.Add(hafen);
        }
    }
    }
