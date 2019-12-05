using System.Collections.Generic;
namespace FlugReservierung
{
    public class Customer
    {
        public string Name;
        public Dictionary<Flug, List<string>> BookedFlights = new Dictionary<Flug, List<string>>();
        //public Dictionary<Flug, List<string>> passagiereFlug = new Dictionary<Flug, List<string>>();

        public Customer(string name)
        {
            this.Name = name;
        }

        public void BookFlight(Flug flight, string seat,string name)
        {
            if (BookedFlights.ContainsKey(flight))
            {
                BookedFlights[flight].Add(seat);
               // passagiereFlug[flight].Add(name);
            } 
            else
            {
                BookedFlights.Add(flight, new List<string>());
                BookedFlights[flight].Add(seat);
               // passagiereFlug.Add(flight, new List<string>());
                //passagiereFlug[flight].Add(name);
            }
                
            flight.gebuchteSitze.Add(seat);
            flight.Flugpassagiere.Add(name);

        }
    }
}