using System.Collections.Generic;

namespace EventsInterfaceErweitert
{
    public class Einkaufzentrum
    {
        private List<IMitarbeiterBegrüßenKunde> BegrüßenKundeListe = new List<IMitarbeiterBegrüßenKunde>();

        //Der Delegate stellt einen Datentypen da, mit dem ich Event-Variablen erzeugen kann
        //Der Delegate legt die Signatur der Methoden fest, mit denen auf das Event reagiert werden kann
        public delegate void NeuerKundeEventHandler();
        //Dies ist die Event-Variable, der wir die Methoden zur Abonnierung zuweisen können
        public event NeuerKundeEventHandler NeuerKundeHatDasGebäudeBetreten;

        /// <summary>
        /// Löst das NeuerKundeHatDasGebäudeBetreten-Event aus
        /// </summary>
        public void NeuerKundeBetrittDasGebäude()
        {
            if (NeuerKundeHatDasGebäudeBetreten != null)
                NeuerKundeHatDasGebäudeBetreten();
        }

        public void BegrüßenKundeEventAbonnieren()
        {
            foreach (IMitarbeiterBegrüßenKunde m in BegrüßenKundeListe)
            {
                NeuerKundeHatDasGebäudeBetreten += m.Grüßen;
            }
        }

        public void MitarbeiterHinzufügen(IMitarbeiterBegrüßenKunde m)
        {
            BegrüßenKundeListe.Add(m);
        }

    }
}
