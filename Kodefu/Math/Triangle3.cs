namespace Kodefu.Math
{
    using System;
    using System.Linq;

    public struct Triangle3
    {
        private readonly Point3 a;
        private readonly Point3 b;
        private readonly Point3 c;

        public Point3 A
        {
            get { return this.a; }
        }

        public Point3 B
        {
            get { return this.b; }
        }

        public Point3 C
        {
            get { return this.c; }
        }

        public Triangle3(Point3 a, Point3 b, Point3 c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }
}
