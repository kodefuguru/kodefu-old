namespace Kodefu.Math
{
    using System;
    using System.Linq;
        
    public struct Segment2
    {
        private readonly Point2 a;
        private readonly Point2 b;

        public Point2 A
        {
            get { return this.a; }
        }

        public Point2 B
        {
            get { return this.b; }
        }

        public Segment2(Point2 a, Point2 b)
        {
            this.a = a;
            this.b = b;
        }

        public static Triangle2 operator +(Segment2 segment, Point2 point)
        {
            return new Triangle2(segment.a, segment.b, point);
        }

        public static Triangle2 operator +(Point2 point, Segment2 segment)
        {
            return new Triangle2(point, segment.a, segment.b);
        }
    }
}
