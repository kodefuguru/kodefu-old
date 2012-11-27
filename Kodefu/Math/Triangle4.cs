namespace Kodefu.Math
{
    using System;
    using System.Linq;

    public struct Triangle4
    {
        private readonly Point4 a;
        private readonly Point4 b;
        private readonly Point4 c;

        public Point4 A
        {
            get { return this.a; }
        }

        public Point4 B
        {
            get { return this.b; }
        }

        public Point4 C
        {
            get { return this.c; }
        }

        public Triangle4(Point4 a, Point4 b, Point4 c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }
}
