using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface Base
    {
        void foo();
    }

    interface Middle1 : Base
    {
        void bar();
    }

    interface Middle2 : Base
    {
        void baz();
    }


    class End : Middle1, Middle2
    {
        public void bar()
        {
            throw new NotImplementedException();
        }

        public void baz()
        {
            throw new NotImplementedException();
        }

        public void foo()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {            
        static void Main(string[] args)
        {
        }
    }
}
