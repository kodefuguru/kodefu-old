namespace Kodefu.Math
{
    using System;
    using System.Linq;

    public struct Triangle2
    {
        private readonly Point2 a;
        private readonly Point2 b;
        private readonly Point2 c;

        public Point2 A
        {
            get { return this.a; }
        }

        public Point2 B
        {
            get { return this.b; }
        }

        public Point2 C
        {
            get { return this.c; }
        }

        public Triangle2(Point2 a, Point2 b, Point2 c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }
}
