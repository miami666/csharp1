using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class SpezialfallException : Exception
    {
        public SpezialfallException(string msg, int zusatz)
            : base(msg)
        {
            this.zusatz = zusatz;
        }

        int zusatz;
        public int Zusatz
        {
            get { return this.zusatz; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = 5;
                int b = 0;

                throw new SpezialfallException("Mein Text", 4711);
            }
            catch (SpezialfallException se)
            {
                Console.WriteLine("Eine Spezialexception ist passiert: " + se.Zusatz);
            }
            catch (Exception ex)
            {
                throw;
            }
            Console.WriteLine("Das Programm terminiert ganz normal");
        }
    }
}
