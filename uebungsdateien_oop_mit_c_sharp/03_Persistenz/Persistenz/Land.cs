using System;
using System.Linq;
using System.Collections.Generic;
using NDO;

namespace Persistenz
{
    /// <summary>
    /// Summary for Land
    /// </summary>
    [NDOPersistent]
    public partial class Land
    {
        string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public Land()
        {
        }
    }
}
