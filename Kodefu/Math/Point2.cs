namespace Kodefu.Math
{
    using System;

    public struct Point2 : IPoint<float, float>, IEquatable<Point<float, float>>, IEquatable<Point2>
    {
        public static Point2 Null
        {
            get
            {
                return default(Point2);
            }
        }

        private readonly float x;
        private readonly float y;

        public float X
        {
            get { return this.x; }
        }

        public float Y
        {
            get { return this.y; }
        }

        public float Length
        {
            get { return this.Distance(Point2.Null); }
        }

        public Point2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point2)
            {
                Equals((Point2)obj);
            }
            else if (obj is Point<float, float>)
            {
                Equals((Point<float, float>)obj);
            }
            else if (obj is IPoint<float, float>)
            {
                Equals((IPoint<float, float>)obj);
            }
            return false;
        }

        public bool Equals(Point<float, float> other)
        {
            return this.x == other.X && this.y == other.Y;
        }

        public bool Equals(IPoint<float, float> other)
        {
            return this.x == other.X && this.y == other.Y;
        }

        public bool Equals(Point2 other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return (this.X + this.Y).GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{{X:{0} Y:{1}}}", this.x, this.y);
        }

        public static implicit operator Point<float, float>(Point2 point)
        {
            return new Point<float, float>(point.x, point.y);
        }

        public static implicit operator Tuple<float, float>(Point2 point)
        {
            return Tuple.Create(point.x, point.y);
        }

        public static implicit operator Point2(Point<float, float> point)
        {
            return new Point2(point.X, point.Y);
        }

        public static implicit operator Point2(Tuple<float, float> tuple)
        {
            return new Point2(tuple.Item1, tuple.Item2);
        }

        public static implicit operator Point2(Vector2 vector)
        {
            return new Point2(vector.X, vector.Y);
        }

        public static Point2 operator -(Point2 point)
        {
            return new Point2(-point.x, -point.y);
        }

        public static bool operator ==(Point2 left, Point2 right)
        {
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(Point2 left, Point2 right)
        {
            return left.x != right.x || left.y != right.y;
        }

        public static Segment2 operator +(Point2 left, Point2 right)
        {
            return new Segment2(left, right);
        }
    }
}