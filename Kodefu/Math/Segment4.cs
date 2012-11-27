namespace Kodefu.Math
{
    using System;
    using System.Linq;
        
    public struct Segment4
    {
        private readonly Point4 a;
        private readonly Point4 b;

        public Point4 A
        {
            get { return this.a; }
        }

        public Point4 B
        {
            get { return this.b; }
        }

        public Segment4(Point4 a, Point4 b)
        {
            this.a = a;
            this.b = b;
        }

        public static Triangle4 operator +(Segment4 segment, Point4 point)
        {
            return new Triangle4(segment.a, segment.b, point);
        }

        public static Triangle4 operator +(Point4 point, Segment4 segment)
        {
            return new Triangle4(point, segment.a, segment.b);
        }
    }
}
