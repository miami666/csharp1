using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankAccount
{
    public class BankAccount
    {
        public string Name { get; set; }
        public string IBAN { get; set; }
        public float Sum { get; set; }

        public delegate float Comision(float comission);

    }
}
