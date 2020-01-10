using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Emma_Uebung
{
   public class emmasFilialen
    {
        public string Id { get; set; }
        public int TageskasseStart { get; set; }
        private int _tageskasseEnde;
        public int TageskasseEnde
        {
            get
            {
                return _tageskasseEnde;
            }
            set
            {
                _tageskasseEnde = value;
                Tagesumsatz = _tageskasseEnde - TageskasseStart;
            }
        }
        private int Tagesumsatz;
        public int Umsatz { get { return Tagesumsatz; } }
    }
}
