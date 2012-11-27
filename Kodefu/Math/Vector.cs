namespace Kodefu.Math
{
    using System;
    using System.Linq;

    public static class Vector    
    {        
        public static Vector2 Add(this Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }

        public static Vector<float, float> Add(this Vector<float, float> left, Vector<float, float> right)
        {
            return new Vector<float, float>(left.X + right.X, left.Y + right.Y);
        }

        public static Vector<float, float> Add(this IVector<float, float> left, IVector<float, float> right)
        {
            return new Vector<float, float>(left.X + right.X, left.Y + right.Y);
        }

        public static Vector<T> Create<T>(T x)
        {
            return new Vector<T>(x);
        }

        public static Vector<T, T2> Create<T, T2>(T x, T2 y)
        {
            return new Vector<T, T2>(x, y);
        }

        public static Vector<T, T2, T3> Create<T, T2, T3>(T x, T2 y, T3 z)
        {
            return new Vector<T, T2, T3>(x, y, z);
        }

        public static Vector<T, T2, T3, T4> Create<T, T2, T3, T4>(T x, T2 y, T3 z, T4 w)
        {
            return new Vector<T, T2, T3, T4>(x, y, z, w);
        }
        
        public static Vector2 CreateF(float x, float y)
        {
            return new Vector2(x, y);
        }

        public static Vector3 CreateF(float x, float y, float z)
        {
            return new Vector3(x, y, z);
        }

        public static Vector4 CreateF(float x, float y, float z, float w)
        {
            return new Vector4(x, y, z, w);
        }
        
        public static Vector2 Divide(this Vector2 left, Vector2 right)
        {
            return new Vector2(left.X / right.X, left.Y / right.Y);
        }

        public static Vector<float, float> Divide(this Vector<float, float> left, Vector<float, float> right)
        {
            return new Vector<float, float>(left.X / right.X, left.Y / right.Y);
        }

        public static Vector<float, float> Divide(this IVector<float, float> left, IVector<float, float> right)
        {
            return new Vector<float, float>(left.X / right.X, left.Y / right.Y);
        }
        
        public static float Distance(this Vector2 left, Vector2 right)
        {
            return (float)Math.Sqrt(DistanceSquared(left, right));
        }

        public static float Distance(this Vector<float, float> left, Vector<float, float> right)
        {
            return (float)Math.Sqrt(DistanceSquared(left, right));
        }

        public static float Distance(this IVector<float, float> left, IVector<float, float> right)
        {
            return (float)Math.Sqrt(DistanceSquared(left, right));
        }

        public static float Distance(this Vector<int, int> left, Vector<int, int> right)
        {
            return (float)Math.Sqrt(DistanceSquared(left, right));
        }

        public static float Distance(this IVector<int, int> left, IVector<int, int> right)
        {
            return (float)Math.Sqrt(DistanceSquared(left, right));
        }
        public static float DistanceSquared(this Vector2 left, Vector2 right)
        {
            return DistanceSquared(left.X, right.X, left.Y, right.Y);
        }

        public static float DistanceSquared(this Vector<float, float> left, Vector<float, float> right)
        {
            return DistanceSquared(left.X, right.X, left.Y, right.Y);
        }

        public static float DistanceSquared(this IVector<float, float> left, IVector<float, float> right)
        {
            return DistanceSquared(left.X, right.X, left.Y, right.Y);
        }

        public static float DistanceSquared(this Vector<int, int> left, Vector<int, int> right)
        {
            return DistanceSquared(left.X, right.X, left.Y, right.Y);
        }

        public static float DistanceSquared(this IVector<int, int> left, IVector<int, int> right)
        {
            return DistanceSquared(left.X, right.X, left.Y, right.Y);
        }

        public static float DistanceSquared(float leftX, float rightX, float leftY, float rightY)
        {
            return (leftX - rightX) * (leftX - rightX) + (leftY - rightY) * (leftY - rightY);
        }

        public static Vector2 Multiply(this Vector2 left, Vector2 right)
        {
            return new Vector2(left.X * right.X, left.Y * right.Y);
        }

        public static Vector<float, float> Multiply(this Vector<float, float> left, Vector<float, float> right)
        {
            return new Vector<float, float>(left.X * right.X, left.Y * right.Y);
        }

        public static Vector<float, float> Multiply(this IVector<float, float> left, IVector<float, float> right)
        {
            return new Vector<float, float>(left.X * right.X, left.Y * right.Y);
        }

        public static float Slope(this Vector2 vector)
        {
            return vector.X == 0 ? float.NaN : vector.Y / vector.X;
        }

        public static Vector2 Subtract(this Vector2 left, Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }

        public static Vector<float, float> Subtract(this Vector<float, float> left, Vector<float, float> right)
        {
            return new Vector<float, float>(left.X - right.X, left.Y - right.Y);
        }

        public static Vector<float, float> Subtract(this IVector<float, float> left, IVector<float, float> right)
        {
            return new Vector<float, float>(left.X - right.X, left.Y - right.Y);
        }
    }

    public struct Vector<T> : IVector<T>, IEquatable<Vector<T>>
    {
        public static Vector<T> Null
        {
            get
            {
                return default(Vector<T>);
            }
        }

        private readonly T x;

        public T X
        {
            get { return this.x; }
        }

        public Vector(T x)
        {
            this.x = x;
        }

        public override bool Equals(object obj)
        {
            {
                if (obj is Vector<T>)
                {
                    Equals((Vector<T>)obj);
                }
                else if (obj is IVector<T>)
                {
                    Equals((IVector<T>)obj);
                }
                return false;
            }
        }

        public bool Equals(IVector<T> other)
        {
            return this.X.Equals(other.X);
        }

        public bool Equals(Vector<T> other)
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

        public static implicit operator Tuple<T>(Vector<T> vector)
        {
            return Tuple.Create(vector.x);
        }

        public static implicit operator Vector<T>(Tuple<T> tuple)
        {
            return new Vector<T>(tuple.Item1);
        }
    }

    public struct Vector<T, T2> : IVector<T, T2>, IEquatable<Vector<T, T2>>
    {
        public static Vector<T, T2> Null
        {
            get
            {
                return default(Vector<T, T2>);
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

        public Vector(T x, T2 y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            {
                if (obj is Vector<T, T2>)
                {
                    Equals((Vector<T, T2>)obj);
                }
                else if (obj is IVector<T, T2>)
                {
                    Equals((IVector<T, T2>)obj);
                }
                return false;
            }
        }

        public bool Equals(IVector<T, T2> other)
        {
            return this.X.Equals(other.X) && this.Y.Equals(other.Y);
        }

        public bool Equals(Vector<T, T2> other)
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

        public static implicit operator Tuple<T, T2>(Vector<T, T2> vector)
        {
            return Tuple.Create(vector.x, vector.y);
        }

        public static implicit operator Vector<T, T2>(Tuple<T, T2> tuple)
        {
            return new Vector<T, T2>(tuple.Item1, tuple.Item2);
        }
    }

    public struct Vector<T, T2, T3> : IVector<T, T2, T3>, IEquatable<Vector<T, T2, T3>>
    {
        public static Vector<T, T2, T3> Null
        {
            get
            {
                return default(Vector<T, T2, T3>);
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

        public Vector(T x, T2 y, T3 z)
        {
            this.z = z;
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector<T, T2, T3>)
            {
                return Equals((Vector<T, T2, T3>)obj);
            }
            if (obj is IVector<T, T2, T3>)
            {
                return Equals((IVector<T, T2, T3>)obj);
            }
            return false;
        }

        public bool Equals(Vector<T, T2, T3> other)
        {
            return this.x.Equals(other.x) && this.y.Equals(other.y) && this.z.Equals(other.z);
        }
        
        public bool Equals(IVector<T, T2, T3> other)
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

        public static implicit operator Tuple<T, T2, T3>(Vector<T, T2, T3> vector)
        {
            return Tuple.Create(vector.x, vector.y, vector.z);
        }

        public static implicit operator Vector<T, T2, T3>(Tuple<T, T2, T3> tuple)
        {
            return new Vector<T, T2, T3>(tuple.Item1, tuple.Item2, tuple.Item3);
        }
    }

    public struct Vector<T, T2, T3, T4> : IVector<T, T2, T3, T4>, IEquatable<Vector<T, T2, T3, T4>>
    {
        public static Vector<T, T2, T3, T4> Null
        {
            get
            {
                return default(Vector<T, T2, T3, T4>);
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

        public Vector(T x, T2 y, T3 z, T4 w)
        {
            this.w = w;
            this.z = z;
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector<T, T2, T3, T4>)
            {
                return Equals((Vector<T, T2, T3, T4>)obj);
            } 
            if (obj is IVector<T, T2, T3, T4>)
            {
                return Equals((IVector<T, T2, T3, T4>)obj);
            }
            return false;
        }

        public bool Equals(IVector<T, T2, T3, T4> other)
        {
            return this.x.Equals(other.X) && this.y.Equals(other.Y) && this.z.Equals(other.Z) && this.w.Equals(other.W);
        }

        public bool Equals(Vector<T, T2, T3, T4> other)
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

        public static implicit operator Tuple<T, T2, T3, T4>(Vector<T, T2, T3, T4> vector)
        {
            return Tuple.Create(vector.x, vector.y, vector.z, vector.w);
        }

        public static implicit operator Vector<T, T2, T3, T4>(Tuple<T, T2, T3, T4> tuple)
        {
            return new Vector<T, T2, T3, T4>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        }
    }
}
