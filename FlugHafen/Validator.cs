using System;

namespace FlugReservierung
{
    public static class Validator
    {


        public static bool CheckIfInteger(string input)
        {
            int number;
            if (!int.TryParse(input, out number))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CheckIfDouble(string input)
        {
            double number;
            if (!double.TryParse(input, out number))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CheckIfNumeric(string test)
        {
            int i;
            return int.TryParse(test, out i);
        }

        public static bool CheckIfEmptyString(string test)
        {
            return test == "" ? true : false;
        }

        internal static bool PruefSitzSchonBelegt(string input, Flug flight)
        {
            int sitzReihe = int.Parse(input.Substring(1, input.Length - 1));
            string sitzAbk = input.Substring(0, 1);
            if (!flight.flugzeug.BelegteSitze().ContainsKey(sitzReihe))
            {
                return false;
            } 
            else
            {
                if (flight.flugzeug.BelegteSitze()[sitzReihe].Contains(sitzAbk))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}