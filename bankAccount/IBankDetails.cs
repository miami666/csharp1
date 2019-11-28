using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankAccount
{
    interface IBankDetails
    {
        float Balance();
        void CreateAccount(string name);
        float Deposit();
        float Withdraw();
    }
}
