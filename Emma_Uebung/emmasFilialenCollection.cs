using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Emma_Uebung
{
    public class emmasFilialenCollection : Dictionary<string, emmasFilialen>
    {
        public void Add(string _Id, int Start)
        {
            this.Add(_Id, new emmasFilialen() { Id = _Id, TageskasseStart = Start });
        }
        public void Add(string _Id, int KasseStart, int KasseEnde)
        {
            this.Add(_Id, new emmasFilialen() { Id = _Id, TageskasseStart = KasseStart, TageskasseEnde = KasseEnde });
        }
        public emmasFilialen UmsatzTop()
        {
            object[] max = new object[2];
            foreach (var valueKey in this)
            {
                if (max[1] == null)
                {
                    max[0] = valueKey.Key;
                    max[1] = valueKey.Value.Umsatz;
                }
                else if ((int)max[1] < valueKey.Value.Umsatz)
                {
                    max[0] = valueKey.Key;
                    max[1] = valueKey.Value.Umsatz;
                }
            }
            return this[max[0].ToString()];
        }
        public emmasFilialen UmsatzMin()
        {
            object[] min = new object[2];
            foreach (var valueKey in this)
            {
                if (min[1] == null)
                {
                    min[0] = valueKey.Key;
                    min[1] = valueKey.Value.Umsatz;
                }
                else if ((int)min[1] > valueKey.Value.Umsatz)
                {
                    min[0] = valueKey.Key;
                    min[1] = valueKey.Value.Umsatz;
                }
            }
            return this[min[0].ToString()];
        }
    }
}
