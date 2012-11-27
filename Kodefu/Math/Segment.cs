namespace Kodefu.Math
{
    using System;
    using System.Linq;

    public static class Segment
    {
        public static Segment<T> Create<T>(Point<T> a, Point<T> b)
        {
            return new Segment<T>(a, b);
        }

        public static Segment<T, T2> Create<T, T2>(Point<T, T2> a, Point<T, T2> b)
        {
            return new Segment<T, T2>(a, b);
        }

        public static Segment<T, T2, T3> Create<T, T2, T3>(Point<T, T2, T3> a, Point<T, T2, T3> b)
        {
            return new Segment<T, T2, T3>(a, b);
        }

        public static Segment<T, T2, T3, T4> Create<T, T2, T3, T4>(Point<T, T2, T3, T4> a, Point<T, T2, T3, T4> b)
        {
            return new Segment<T, T2, T3, T4>(a, b);
        }

        public static Segment2 Create(Point2 a, Point2 b)
        {
            return new Segment2(a, b);
        }

        public static Segment3 Create(Point3 a, Point3 b)
        {
            return new Segment3(a, b);
        }

        public static Segment4 Create(Point4 a, Point4 b)
        {
            return new Segment4(a, b);
        }
    }

    public struct Segment<T>
    {
        private readonly Point<T> a;
        private readonly Point<T> b;

        public Point<T> A
        {
            get { return this.a; }
        }

        public Point<T> B
        {
            get { return this.b; }
        }

        public Segment(Point<T> a, Point<T> b)
        {
            this.a = a;
            this.b = b;
        }
    }

    public struct Segment<T, T2>
    {
        private readonly Point<T, T2> a;
        private readonly Point<T, T2> b;

        public Point<T, T2> A
        {
            get { return this.a; }
        }

        public Point<T, T2> B
        {
            get { return this.b; }
        }

        public Segment(Point<T, T2> a, Point<T, T2> b)
        {
            this.a = a;
            this.b = b;
        }
    }

    public struct Segment<T, T2, T3>
    {
        private readonly Point<T, T2, T3> a;
        private readonly Point<T, T2, T3> b;

        public Point<T, T2, T3> A
        {
            get { return this.a; }
        }

        public Point<T, T2, T3> B
        {
            get { return this.b; }
        }

        public Segment(Point<T, T2, T3> a, Point<T, T2, T3> b)
        {
            this.a = a;
            this.b = b;
        }
    }

    public struct Segment<T, T2, T3, T4>
    {
        private readonly Point<T, T2, T3, T4> a;
        private readonly Point<T, T2, T3, T4> b;

        public Point<T, T2, T3, T4> A
        {
            get { return this.a; }
        }

        public Point<T, T2, T3, T4> B
        {
            get { return this.b; }
        }

        public Segment(Point<T, T2, T3, T4> a, Point<T, T2, T3, T4> b)
        {
            this.a = a;
            this.b = b;
        }
    }
}
