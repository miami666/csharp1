using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flugreservierung
{
    class Program
    {
        class Flug
        {
            public string flugId { get; private set; }
            public string author { get; private set; }
            public DateTime flugDatum { get; private set; }
            public int seats { get; private set; }

            public Flug(string id, int seats, DateTime flugDatum)
            {
                this.flugId = id;
                
                this.seats = seats;
                this.flugDatum = DateTime.Now;
            }
        }

        class Airline
        {
            List<Flug> f = new List<Flug>();

            public void Add(Flug f book)
            {
                books.Add(book);
            }

            public Book GetBookByAuthor(string search)
            {
                // What to do over here?
            }
        }
        static void Main(string[] args)
        {
        }
    }
}



