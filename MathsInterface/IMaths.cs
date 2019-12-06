using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsInterface
{
    public interface IMaths
    {
        int Addieren(int a, int b);
        int Subtrahieren(int a, int b);

    }

    public interface IMathsExtended : IMaths
    {
        int Multiplizieren(int a, int b);

        /// <summary>
        /// Teilt a durch b, wirft ArgumentException wenn b = 0.
        /// </summary>
        /// <param name="a">Dividend</param>
        /// <param name="b">Divisor</param>
        /// <returns>Ergebnis der Division</returns>
        double Dividieren(int a, int b);
    }

    public interface IMathsQuadrat
    {
        int Quadrieren(int a);
    }
}
