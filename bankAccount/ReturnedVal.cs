using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankAccount
{
    class ReturnedVal
    {
        internal string EnterIban()
        {
            Console.WriteLine("IBAN:");
            string iban = Console.ReadLine();

            return iban;
        }

        internal float AmountToDeposit()
        {
            Console.WriteLine("Type in the amount ");
            float sum = float.Parse(Console.ReadLine());

            return sum;
        }

        internal BankAccount GetAccountByName(string iban, List<BankAccount> _conturi)
        {
            BankAccount ba = _conturi.Find(c => c.IBAN == iban);

            if (ba != null)
            {
                return ba;
            }
            else
            {
                return null;
            }
        }
    }
}
