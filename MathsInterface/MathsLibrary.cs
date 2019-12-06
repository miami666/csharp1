using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsInterface
{
    public class MathsLibrary : IMaths, IMathsExtended
    {
        public int Addieren(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Teilt a durch b, wirft ArgumentException wenn b = 0.
        /// </summary>
        /// <param name="a">Dividend</param>
        /// <param name="b">Divisor</param>
        /// <returns>Ergebnis der Division</returns>
        public double Dividieren(int a, int b)
        {
            if (b == 0)
                throw new ArgumentException("Divisor darf nicht 0 sein!");
            return a / b;
        }

        public int Multiplizieren(int a, int b)
        {
            return a * b;
        }

        public int Subtrahieren(int a, int b)
        {
            return a - b;
        }
    }

    public class MathsLibraryV2 : IMaths, IMathsQuadrat
    {
        public int Addieren(int a, int b)
        {
            throw new NotImplementedException();
        }

        public int Quadrieren(int a)
        {
            throw new NotImplementedException();
        }

        public int Subtrahieren(int a, int b)
        {
            throw new NotImplementedException();
        }
    }

   
}
