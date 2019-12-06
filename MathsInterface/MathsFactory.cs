using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsInterface
{
    /// <summary>
    /// Factory Design Pattern zum Kapseln der Objekt-Instanziierung
    /// </summary>
    public static class MathsFactory
    {
        public static IMaths CreateMaths()
        {
            return new MathsLibrary();
        }

        public static IMathsExtended CreateMathsExtended()
        {
            return new MathsLibrary();
        }

        public static IMathsQuadrat CreateMathsQuadrat()
        {
            return new MathsLibraryV2();
        }
    }
}
