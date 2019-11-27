using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class ExternalClass
    {
        internal protected int i;

        protected void foo()
        {
        }
    }

    class Test : ExternalClass
    {
        void meth()
        {
            this.i = 4;
        }
    }
}
