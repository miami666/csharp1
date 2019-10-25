using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conversion
{
    class Program
    {
        // To return value of a char.  
        // For example, 2 is returned 
        // for '2'. 10 is returned  
        // for 'A', 11 for 'B' 
        static int val(char c)
        {
            if (c >= '0' && c <= '9')
                return (int)c - '0';
            else
                return (int)c - 'A' + 10;
        }

        // Function to convert a  
        // number from given base  
        // 'b' to decimal 
        static int toDeci(string str,
                          int b_ase)
        {
            int len = str.Length;
            int power = 1; // Initialize  
                           // power of base 
            int num = 0; // Initialize result 
            int i;

            // Decimal equivalent is  
            // str[len-1]*1 + str[len-1] * 
            // base + str[len-1]*(base^2) + ... 
            for (i = len - 1; i >= 0; i--)
            {
                // A digit in input number  
                // must be less than  
                // number's base 
                if (val(str[i]) >= b_ase)
                {
                    Console.WriteLine("Invalid Number");
                    return -1;
                }

                num += val(str[i]) * power;
                power = power * b_ase;
            }

            return num;
        }
        static void Main(string[] args)
        {



            string str = "11A";
            int b_ase = 16;
            Console.WriteLine("Decimal equivalent of " +
                             str + " in base " + b_ase +
                          " is " + toDeci(str, b_ase));
          
        }
        }

    
}






