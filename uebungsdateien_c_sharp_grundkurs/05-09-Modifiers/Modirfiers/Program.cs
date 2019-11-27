using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLib;

namespace Modifiers
{
    class InternalClass
    {
        protected int i;

        protected class NestedClass
        {
        }

        protected void foo()
        {
            
        }
    }


    class Program : ExternalClass
    {
        static void Main( string[] args )
        {
            Program p = new Program();

            p.i = 4;
        }
    }
}
