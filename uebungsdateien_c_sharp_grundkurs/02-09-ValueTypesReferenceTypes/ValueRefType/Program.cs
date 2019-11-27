using System;

namespace ValueRefType
{
    class RefPoint
    {
        public RefPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        int x;
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        int y;
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
    }

    struct ValPoint
    {
        public ValPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        int x;
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        int y;
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
    }


    class Program
    {
        static void f_byval(RefPoint rp)
        {
            rp = new RefPoint(1234, 1234);
            //rp.Y = 1234;
        }

        static void g_byval(ValPoint vp)
        {
            vp.Y = 1234;
        }

        static void f_byref(ref RefPoint rp)
        {
            rp = new RefPoint(4444, 4444);
            //rp.Y = 4444;
        }

        static void g_byref(ref ValPoint vp)
        {
            vp.Y = 4444;
        }

        static void Main(string[] args)
        {
            RefPoint rp = new RefPoint(2, 2);
            ValPoint vp = new ValPoint(2, 2);

            f_byval(rp);
            g_byval(vp);

            Console.WriteLine("Reference Type By Value: " + rp.Y);
            Console.WriteLine("Value Type By Value: " + vp.Y);

            f_byref(ref rp);
            g_byref(ref vp);

            Console.WriteLine("Reference Type By Ref: " + rp.Y);
            Console.WriteLine("Value Type By Ref: " + vp.Y);
        }
    }
}
