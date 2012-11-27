namespace Kodefu.Math
{
    using System;

    public struct Point3 : IPoint<float, float, float>, IEquatable<Point<float, float, float>>, IEquatable<Point3>
    {
        public static Point3 Null
        {
            get
            {
                return default(Point3);
            }
        }
        
        private readonly float x;
        private readonly float y;
        private readonly float z;

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

        public Point3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point3)
            {
                Equals((Point3)obj);
            }
            else if (obj is Point<float, float, float>)
            {
                Equals((Point<float, float, float>)obj);
            }
            else if (obj is IPoint<float, float, float>)
            {
                Equals((IPoint<float, float, float>)obj);
            }
            return false;
        }

        public bool Equals(Point<float, float, float> other)
        {
            return this.x == other.X && this.y == other.Y && this.z == other.Z;
        }
        
        public bool Equals(IPoint<float, float, float> other)
        {
            return this.x == other.X && this.y == other.Y && this.z == other.Z;
        }
        
        public bool Equals(Point3 other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return (this.X + this.Y + this.Z).GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{{X:{0} Y:{1} Z:{2}}}", this.x, this.y, this.z); 
        }

        public static implicit operator Point<float, float, float>(Point3 point)
        {
            return new Point<float, float, float>(point.x, point.y, point.z);
        }

        public static implicit operator Tuple<float, float, float>(Point3 point)
        {
            return Tuple.Create(point.x, point.y, point.z);
        }

        public static implicit operator Point3(Point<float, float, float> point)
        {
            return new Point3(point.X, point.Y, point.Z);
        }

        public static implicit operator Point3(Tuple<float, float, float> tuple)
        {
            return new Point3(tuple.Item1, tuple.Item2, tuple.Item3);
        }

        public static Point3 operator -(Point3 point)
        {
            return new Point3(-point.x, -point.y, -point.z);
        }

        public static bool operator ==(Point3 left, Point3 right)
        {
            return left.x == right.x && left.y == right.y && left.z == right.z;
        }

        public static bool operator !=(Point3 left, Point3 right)
        {
            return !(left == right);
        }

        public static Segment3 operator +(Point3 left, Point3 right)
        {
            return new Segment3(left, right);
        }       
    }
}