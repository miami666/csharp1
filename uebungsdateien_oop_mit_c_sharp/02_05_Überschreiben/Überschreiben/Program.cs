using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Überschreiben
{
    class BaseClass
    {
        public virtual void DoSomeWork()
        {
            Console.WriteLine("BaseClass");
        }
    }

    class DerivedClass : BaseClass
    {
        public override void DoSomeWork()
        {
            Console.WriteLine("DerivedClass");
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            List<BaseClass> list = new List<BaseClass>();
            list.Add(new BaseClass());
            list.Add(new DerivedClass());

            foreach (var item in list)
            {
                item.DoSomeWork();
            }

        }
    }
}
