using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * in eigener (extra) Datei einen eigenen namespace für
{
- eine abstrakte Klasse "Kunde"
	* mit abstrakter Methode Login (Ausgabe reicht)
		(Optional: mit PIN)
	* mit protected ctor
- eine public Klasse PrivatKunde, die von Kunde erbt
- eine public Klasse Geschäftskunde, die von Kunde erbt
}
 * */
namespace my_namespace
{
   public abstract class Kunde
    {
        public abstract void Login(string pin);

        protected Kunde()
        {

        }
    }
    public class Privatkunde : Kunde
    {
        public override void Login(string pin)
        {
            throw new NotImplementedException();
        }

    }
    public class Geschaeftskunde:Kunde
    {
        public override void Login(string pin)
        {
            throw new NotImplementedException();
        }

    }

}
