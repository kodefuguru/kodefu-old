namespace Kodefu.Math
{
    using System;
    using System.Linq;
        
    public struct Segment3
    {
        private readonly Point3 a;
        private readonly Point3 b;

        public Point3 A
        {
            get { return this.a; }
        }

        public Point3 B
        {
            get { return this.b; }
        }

        public Segment3(Point3 a, Point3 b)
        {
            this.a = a;
            this.b = b;
        }

        public static Triangle3 operator +(Segment3 segment, Point3 point)
        {
            return new Triangle3(segment.a, segment.b, point);
        }

        public static Triangle3 operator +(Point3 point, Segment3 segment)
        {
            return new Triangle3(point, segment.a, segment.b);
        }
    }
}
