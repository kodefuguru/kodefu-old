namespace Kodefu.Math
{
    using System;

    public struct Point4 : IPoint<float, float, float, float>, IEquatable<Point<float, float, float, float>>, IEquatable<Point4>
    {
        public static Point4 Null
        {
            get
            {
                return default(Point4);
            }
        }
        
        private readonly float x;
        private readonly float y;
        private readonly float z;
        private readonly float w;

        public float W
        {
            get { return this.w; }
        }

        public float X
        {
            get { return this.x; }
        }

        public float Y
        {
            get { return this.y; }
        }

        public float Z
        {
            get { return this.z; }
        }

        public Point4(float x, float y, float z, float w)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point4)
            {
                Equals((Point4)obj);
            }
            else if (obj is Point<float, float, float, float>)
            {
                Equals((Point<float, float, float, float>)obj);
            }
            else if (obj is IPoint<float, float, float, float>)
            {
                Equals((IPoint<float, float, float, float>)obj);
            }
            return false;
        }

        public bool Equals(IPoint<float, float, float, float> other)
        {
            return this.x == other.X && this.y == other.Y && this.z == other.Z;
        }

        public bool Equals(Point<float, float, float, float> other)
        {
            return this.x == other.X && this.y == other.Y && this.z == other.Z;
        }
        
        public bool Equals(Point4 other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return (this.X + this.Y + this.Z + this.W).GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{{X:{0} Y:{1} Z:{2}}}", this.x, this.y, this.z); 
        }

        public static implicit operator Point<float, float, float>(Point4 point)
        {
            return new Point<float, float, float>(point.x, point.y, point.z);
        }

        public static implicit operator Tuple<float, float, float>(Point4 point)
        {
            return Tuple.Create(point.x, point.y, point.z);
        }

        public static implicit operator Point4(Point<float, float, float, float> point)
        {
            return new Point4(point.X, point.Y, point.Z, point.W);
        }

        public static implicit operator Point4(Tuple<float, float, float, float> tuple)
        {
            return new Point4(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        }

        public static Point4 operator -(Point4 point)
        {
            return new Point4(-point.x, -point.y, -point.z, -point.w);
        }

        public static bool operator ==(Point4 left, Point4 right)
        {
            return left.x == right.x && left.y == right.y && left.z == right.z && left.w == right.w;
        }

        public static bool operator !=(Point4 left, Point4 right)
        {
            return !(left == right);
        }

        public static Segment4 operator +(Point4 left, Point4 right)
        {
            return new Segment4(left, right); ;
        }              
    }
}