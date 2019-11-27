using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorUeberladung
{
    class Complex
    {
        double real;
        double imaginär;

        public Complex( double real, double img )
        {
            this.real = real;
            this.imaginär = img;
        }

        public override string ToString()
        {
            return String.Format( "{0} + i{1}", this.real, this.imaginär );
        }

        public static Complex operator +( Complex c1, Complex c2 )
        {
            return new Complex( c1.real + c2.real, c1.imaginär + c2.imaginär );
        }
    }


    class Program
    {
        static void Main( string[] args )
        {
            Complex num1 = new Complex( 2, 4 );
            Complex num2 = new Complex( 1, 3 );

            Complex summe = num1 + num2 + num2;

            Console.WriteLine( summe.ToString() );
        }
    }
}
