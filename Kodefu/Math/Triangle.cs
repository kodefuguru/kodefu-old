namespace Kodefu.Math
{
    using System;
    using System.Linq;

    public static class Triangle
    {
        public static Triangle<T> Create<T>(Point<T> a, Point<T> b, Point<T> c)
        {
            return new Triangle<T>(a, b, c);
        }

        public static Triangle<T, T2> Create<T, T2>(Point<T, T2> a, Point<T, T2> b, Point<T, T2> c)
        {
            return new Triangle<T, T2>(a, b, c);
        }

        public static Triangle<T, T2, T3> Create<T, T2, T3>(Point<T, T2, T3> a, Point<T, T2, T3> b, Point<T, T2, T3> c)
        {
            return new Triangle<T, T2, T3>(a, b, c);
        }

        public static Triangle<T, T2, T3, T4> Create<T, T2, T3, T4>(Point<T, T2, T3, T4> a, Point<T, T2, T3, T4> b, Point<T, T2, T3, T4> c)
        {
            return new Triangle<T, T2, T3, T4>(a, b, c);
        }

        public static Triangle2 Create(Point2 a, Point2 b, Point2 c)
        {
            return new Triangle2(a, b, c);
        }

        public static Triangle3 Create(Point3 a, Point3 b, Point3 c)
        {
            return new Triangle3(a, b, c);
        }

        public static Triangle4 Create(Point4 a, Point4 b, Point4 c)
        {
            return new Triangle4(a, b, c);
        }
    }

    public struct Triangle<T>
    {
        private readonly Point<T> a;
        private readonly Point<T> b;
        private readonly Point<T> c;

        public Point<T> A
        {
            get { return this.a; }
        }

        public Point<T> B
        {
            get { return this.b; }
        }

        public Point<T> C
        {
            get { return this.c; }
        }

        public Triangle(Point<T> a, Point<T> b, Point<T> c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }

    public struct Triangle<T, T2>
    {
        private readonly Point<T, T2> a;
        private readonly Point<T, T2> b;
        private readonly Point<T, T2> c;

        public Point<T, T2> A
        {
            get { return this.a; }
        }

        public Point<T, T2> B
        {
            get { return this.b; }
        }

        public Point<T, T2> C
        {
            get { return this.c; }
        }

        public Triangle(Point<T, T2> a, Point<T, T2> b, Point<T, T2> c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }

    public struct Triangle<T, T2, T3>
    {
        private readonly Point<T, T2, T3> a;
        private readonly Point<T, T2, T3> b;
        private readonly Point<T, T2, T3> c;

        public Point<T, T2, T3> A
        {
            get { return this.a; }
        }

        public Point<T, T2, T3> B
        {
            get { return this.b; }
        }

        public Point<T, T2, T3> C
        {
            get { return this.c; }
        }

        public Triangle(Point<T, T2, T3> a, Point<T, T2, T3> b, Point<T, T2, T3> c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }

    public struct Triangle<T, T2, T3, T4>
    {
        private readonly Point<T, T2, T3, T4> a;
        private readonly Point<T, T2, T3, T4> b;
        private readonly Point<T, T2, T3, T4> c;

        public Point<T, T2, T3, T4> A
        {
            get { return this.a; }
        }

        public Point<T, T2, T3, T4> B
        {
            get { return this.b; }
        }

        public Point<T, T2, T3, T4> C
        {
            get { return this.c; }
        }

        public Triangle(Point<T, T2, T3, T4> a, Point<T, T2, T3, T4> b, Point<T, T2, T3, T4> c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }
}
