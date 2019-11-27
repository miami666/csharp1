using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ausdrücke
{
    class MyMath
    {
        // Klasse mit bedeutungslosen Methoden
        // um die Operatorrangfolge zu testen
        public int f(int i) { return 2; }
        public int g(int i) { return 2; }
        public int h() { return 2; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyMath math = new MyMath();
            // = oder #=,-=,*=,/*,%=,<<=,<<= haben immer den geringsten Vorrang.
            // Die . und () Operatoren sind gleichwertig 
            // und werden von links nach rechts ausgeführt.
            int i = math.f(5);
            // ist gleichwertig mit
            //  i = (math.f)(5); Die Klammer um math.f wäre syntaktisch natürlich falsch.

            // Unäre Operatoren haben den höchsten Vorrang, liegen jedoch unter . und ()
            int j = -math.f(4);  // - wird als letztes ausgeführt
            int k = -math.g(i) + 2;  // unäres - wird vor binärem + ausgeführt.

            // Binäres + und - sind gleichrangig.
            // + wird zuerst ausgeführt (wegen Zusammenfassung von links)
            int l = math.f(3) + math.g(i) - math.h(); 

            // * hat einen geringeren Vorrang als . und *
            // + hat einen geringeren Vorrang, als *
            int m = math.f(i) + math.g(i) * math.h();
            // ist Äquivalent zu
                j = math.f(i) + (math.g(i) * math.h());

            // >= und <= haben geringeren Vorrang, als . und ()
            // && hat einen geringeren Vorrang, als >= und die anderen Vergleichsoperatoren
            // || hat einen geringeren Vorrang, als &&
            bool b = math.f(i) >= 0 && i <= 0 || j >= math.f(i);

            // Assignment wird von rechts nach links zusammengefasst.
            int n = k *= l += m;
            // ist äquivalent zu den drei Zeilen:
            l = l + m;
            k = k * l;
            n = k;

            // ? und : der konditionalen Zuweisung haben einen höheren Rang
            // als die Zuweisung, sonst aber den geringsten Rang aller Operatoren.
            b = i < 4 ? i > math.f(i) || i < 3 : i < math.g(i);
            // ist äquivalent zu:
            b = ( (i < 4) ? ( (i > math.f(i)) || (i < 3) ) : ( i < math.g(i) ) );
            // Tipp: stellen Sie den Cursor vor eine öffnende oder hinter eine schließende Klammer.
            // Visual Studio zeigt Ihnen dann die korrespondierende Klammer an.
        }
    }
}
