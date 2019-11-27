using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    enum Job
    {
        CheckStructure = 1,
        GetNewData = 2,
        ReRenderPages = 4
    }

    class Program
    {
        static void Main( string[] args )
        {
            Job job = Job.ReRenderPages | Job.GetNewData;

            Console.WriteLine((int)job);

            if ((job & Job.GetNewData) == Job.GetNewData)
                Console.WriteLine("GetNewData");
            if (( job & Job.CheckStructure ) == Job.CheckStructure)
                Console.WriteLine( "CheckStructure" );
            if (( job & Job.ReRenderPages) == Job.ReRenderPages)
                Console.WriteLine( "ReRenderPages" );
            
        }
    }
}
