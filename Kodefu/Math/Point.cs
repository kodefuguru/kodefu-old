namespace Kodefu.Math
{
    using System;
    using System.Linq;

    public static class Point    
    {        
        public static Point2 Add(this Point2 left, Point2 right)
        {
            return new Point2(left.X + right.X, left.Y + right.Y);
        }

        public static Point<float, float> Add(this Point<float, float> left, Point<float, float> right)
        {
            return new Point<float, float>(left.X + right.X, left.Y + right.Y);
        }

        public static Point<float, float> Add(this IPoint<float, float> left, IPoint<float, float> right)
        {
            return new Point<float, float>(left.X + right.X, left.Y + right.Y);
        }

        public static Point<T, T2> Create<T, T2>(T x, T2 y)
        {
            return new Point<T, T2>(x, y);
        }

        public static Point<T, T2, T3> Create<T, T2, T3>(T x, T2 y, T3 z)
        {
            return new Point<T, T2, T3>(x, y, z);
        }

        public static Point<T, T2, T3, T4> Create<T, T2, T3, T4>(T x, T2 y, T3 z, T4 w)
        {
            return new Point<T, T2, T3, T4>(x, y, z, w);
        }
        
        public static Point2 CreateF(float x, float y)
        {
            return new Point2(x, y);
        }

        public static Point3 CreateF(float x, float y, float z)
        {
            return new Point3(x, y, z);
        }

        public static Point4 CreateF(float x, float y, float z, float w)
        {
            return new Point4(x, y, z, w);
        }
        
        public static Point2 Divide(this Point2 left, Point2 right)
        {
            return new Point2(left.X / right.X, left.Y / right.Y);
        }

        public static Point<float, float> Divide(this Point<float, float> left, Point<float, float> right)
        {
            return new Point<float, float>(left.X / right.X, left.Y / right.Y);
        }

        public static Point<float, float> Divide(this IPoint<float, float> left, IPoint<float, float> right)
        {
            return new Point<float, float>(left.X / right.X, left.Y / right.Y);
        }
        
        public static float Distance(this Point2 left, Point2 right)
        {
            return (float)Math.Sqrt(DistanceSquared(left, right));
        }

        public static float Distance(this Point<float, float> left, Point<float, float> right)
        {
            return (float)Math.Sqrt(DistanceSquared(left, right));
        }

        public static float Distance(this IPoint<float, float> left, IPoint<float, float> right)
        {
            return (float)Math.Sqrt(DistanceSquared(left, right));
        }

        public static float Distance(this Point<int, int> left, Point<int, int> right)
        {
            return (float)Math.Sqrt(DistanceSquared(left, right));
        }

        public static float Distance(this IPoint<int, int> left, IPoint<int, int> right)
        {
            return (float)Math.Sqrt(DistanceSquared(left, right));
        }
        public static float DistanceSquared(this Point2 left, Point2 right)
        {
            return DistanceSquared(left.X, right.X, left.Y, right.Y);
        }

        public static float DistanceSquared(this Point<float, float> left, Point<float, float> right)
        {
            return DistanceSquared(left.X, right.X, left.Y, right.Y);
        }

        public static float DistanceSquared(this IPoint<float, float> left, IPoint<float, float> right)
        {
            return DistanceSquared(left.X, right.X, left.Y, right.Y);
        }

        public static float DistanceSquared(this Point<int, int> left, Point<int, int> right)
        {
            return DistanceSquared(left.X, right.X, left.Y, right.Y);
        }

        public static float DistanceSquared(this IPoint<int, int> left, IPoint<int, int> right)
        {
            return DistanceSquared(left.X, right.X, left.Y, right.Y);
        }

        public static float DistanceSquared(float leftX, float rightX, float leftY, float rightY)
        {
            return (leftX - rightX) * (leftX - rightX) + (leftY - rightY) * (leftY - rightY);
        }

        public static Point2 Multiply(this Point2 left, Point2 right)
        {
            return new Point2(left.X * right.X, left.Y * right.Y);
        }

        public static Point<float, float> Multiply(this Point<float, float> left, Point<float, float> right)
        {
            return new Point<float, float>(left.X * right.X, left.Y * right.Y);
        }

        public static Point<float, float> Multiply(this IPoint<float, float> left, IPoint<float, float> right)
        {
            return new Point<float, float>(left.X * right.X, left.Y * right.Y);
        }

        public static Point2 Subtract(this Point2 left, Point2 right)
        {
            return new Point2(left.X - right.X, left.Y - right.Y);
        }

        public static Point<float, float> Subtract(this Point<float, float> left, Point<float, float> right)
        {
            return new Point<float, float>(left.X - right.X, left.Y - right.Y);
        }

        public static Point<float, float> Subtract(this IPoint<float, float> left, IPoint<float, float> right)
        {
            return new Point<float, float>(left.X - right.X, left.Y - right.Y);
        }
    }

    public struct Point<T> : IPoint<T>, IEquatable<Point<T>>
    {
        public static Point<T> Null
        {
            get
            {
                return default(Point<T>);
            }
        }

        private readonly T x;

        public T X
        {
            get { return this.x; }
        }

        public Point(T x)
        {
            this.x = x;
        }

        public override bool Equals(object obj)
        {
            {
                if (obj is Point<T>)
                {
                    Equals((Point<T>)obj);
                }
                else if (obj is IPoint<T>)
                {
                    Equals((IPoint<T>)obj);
                }
                return false;
            }
        }

        public bool Equals(IPoint<T> other)
        {
            return this.X.Equals(other.X);
        }

        public bool Equals(Point<T> other)
        {
            return this.x.Equals(other.x);
        }

        public override int GetHashCode()
        {
            return this.x.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{{X:{0}}}", this.x);
        }

        public static implicit operator Tuple<T>(Point<T> point)
        {
            return Tuple.Create(point.x);
        }

        public static implicit operator Point<T>(Tuple<T> tuple)
        {
            return new Point<T>(tuple.Item1);
        }
    }

    public struct Point<T, T2> : IPoint<T, T2>, IEquatable<Point<T, T2>>
    {
        public static Point<T, T2> Null
        {
            get
            {
                return default(Point<T, T2>);
            }
        }
        
        private readonly T x;
        private readonly T2 y;

        public T X
        {
            get { return this.x; }
        }

        public T2 Y
        {
            get { return this.y; }
        }

        public Point(T x, T2 y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            {
                if (obj is Point<T, T2>)
                {
                    Equals((Point<T, T2>)obj);
                }
                else if (obj is IPoint<T, T2>)
                {
                    Equals((IPoint<T, T2>)obj);
                }
                return false;
            }
        }

        public bool Equals(IPoint<T, T2> other)
        {
            return this.X.Equals(other.X) && this.Y.Equals(other.Y);
        }

        public bool Equals(Point<T, T2> other)
        {
            return this.x.Equals(other.x) && this.y.Equals(other.y);
        }

        public override int GetHashCode()
        {
            return (this.x.GetHashCode() + this.x.GetHashCode()).GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{{X:{0} Y:{1}}}", this.x, this.y);
        }

        public static implicit operator Tuple<T, T2>(Point<T, T2> point)
        {
            return Tuple.Create(point.x, point.y);
        }

        public static implicit operator Point<T, T2>(Tuple<T, T2> tuple)
        {
            return new Point<T, T2>(tuple.Item1, tuple.Item2);
        }

        public static Segment<T, T2> operator +(Point<T, T2> left, Point<T, T2> right)
        {
            return new Segment<T, T2>(left, right);
        }
    }

    public struct Point<T, T2, T3> : IPoint<T, T2, T3>, IEquatable<Point<T, T2, T3>>
    {
        public static Point<T, T2, T3> Null
        {
            get
            {
                return default(Point<T, T2, T3>);
            }
        }
        
        private readonly T x;
        private readonly T2 y;
        private readonly T3 z;

        public T X
        {
            get { return this.x; }
        }

        public T2 Y
        {
            get { return this.y; }
        }

        public T3 Z
        {
            get { return this.z; }
        }

        public Point(T x, T2 y, T3 z)
        {
            this.z = z;
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point<T, T2, T3>)
            {
                return Equals((Point<T, T2, T3>)obj);
            }
            if (obj is IPoint<T, T2, T3>)
            {
                return Equals((IPoint<T, T2, T3>)obj);
            }
            return false;
        }

        public bool Equals(Point<T, T2, T3> other)
        {
            return this.x.Equals(other.x) && this.y.Equals(other.y) && this.z.Equals(other.z);
        }
        
        public bool Equals(IPoint<T, T2, T3> other)
        {
            return this.x.Equals(other.X) && this.y.Equals(other.Y) && this.z.Equals(other.Z);
        }

        public override int GetHashCode()
        {
            return (this.x.GetHashCode() + this.y.GetHashCode() + this.z.GetHashCode()).GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{{X:{0} Y:{1} Z:{2}}}", this.x, this.y, this.z);
        }

        public static implicit operator Tuple<T, T2, T3>(Point<T, T2, T3> point)
        {
            return Tuple.Create(point.x, point.y, point.z);
        }

        public static implicit operator Point<T, T2, T3>(Tuple<T, T2, T3> tuple)
        {
            return new Point<T, T2, T3>(tuple.Item1, tuple.Item2, tuple.Item3);
        }

        public static Segment<T, T2, T3> operator +(Point<T, T2, T3> left, Point<T, T2, T3> right)
        {
            return new Segment<T, T2, T3>(left, right);
        }
    }

    public struct Point<T, T2, T3, T4> : IPoint<T, T2, T3, T4>, IEquatable<Point<T, T2, T3, T4>>
    {
        public static Point<T, T2, T3, T4> Null
        {
            get
            {
                return default(Point<T, T2, T3, T4>);
            }
        }
        
        private readonly T x;
        private readonly T2 y;
        private readonly T3 z;
        private readonly T4 w;

        public T4 W
        {
            get { return this.w; }
        }

        public T X
        {
            get { return this.x; }
        }

        public T2 Y
        {
            get { return this.y; }
        }

        public T3 Z
        {
            get { return this.z; }
        }

        public Point(T x, T2 y, T3 z, T4 w)
        {
            this.w = w;
            this.z = z;
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point<T, T2, T3, T4>)
            {
                return Equals((Point<T, T2, T3, T4>)obj);
            } 
            if (obj is IPoint<T, T2, T3, T4>)
            {
                return Equals((IPoint<T, T2, T3, T4>)obj);
            }
            return false;
        }

        public bool Equals(IPoint<T, T2, T3, T4> other)
        {
            return this.x.Equals(other.X) && this.y.Equals(other.Y) && this.z.Equals(other.Z) && this.w.Equals(other.W);
        }

        public bool Equals(Point<T, T2, T3, T4> other)
        {
            return this.x.Equals(other.x) && this.y.Equals(other.y) && this.z.Equals(other.z) && this.w.Equals(other.w);
        }

        public override int GetHashCode()
        {
            return (this.x.GetHashCode() + this.y.GetHashCode() + this.z.GetHashCode() + this.w.GetHashCode()).GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{{X:{0} Y:{1} Z:{2} W:{3}}}", this.x, this.y, this.z, this.w);
        }

        public static implicit operator Tuple<T, T2, T3, T4>(Point<T, T2, T3, T4> point)
        {
            return Tuple.Create(point.x, point.y, point.z, point.w);
        }

        public static implicit operator Point<T, T2, T3, T4>(Tuple<T, T2, T3, T4> tuple)
        {
            return new Point<T, T2, T3, T4>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        }

        public static Segment<T, T2, T3, T4> operator +(Point<T, T2, T3, T4> left, Point<T, T2, T3, T4> right)
        {
            return new Segment<T, T2, T3, T4>(left, right);
        }              
    }
}
