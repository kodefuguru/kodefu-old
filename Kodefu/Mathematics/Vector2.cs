namespace Kodefu.Mathematics
{
    using System;

    public struct Vector2 : IVector<float, float>, IEquatable<Vector<float, float>>, IEquatable<Vector2>
    {
        public static Vector2 Null
        {
            get
            {
                return default(Vector2);
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
            get { return this.Distance(Vector2.Null); }
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2)
            {
                Equals((Vector2)obj);
            }
            else if (obj is Vector<float, float>)
            {
                Equals((Vector<float, float>)obj);
            }
            else if (obj is IVector<float, float>)
            {
                Equals((IVector<float, float>)obj);
            }
            return false;
        }

        public bool Equals(Vector<float, float> other)
        {
            return this.x == other.X && this.y == other.Y;
        }
        
        public bool Equals(IVector<float, float> other)
        {
            return this.x == other.X && this.y == other.Y;
        }

        public bool Equals(Vector2 other)
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

        public static implicit operator Vector<float, float>(Vector2 vector)
        {
            return new Vector<float, float>(vector.X, vector.Y);
        }

        public static implicit operator Tuple<float, float>(Vector2 vector)
        {
            return Tuple.Create(vector.X, vector.Y);
        }

        public static implicit operator Vector2(Vector<float, float> vector)
        {
            return new Vector2(vector.X, vector.Y);
        }

        public static implicit operator Vector2(Tuple<float, float> tuple)
        {
            return new Vector2(tuple.Item1, tuple.Item2);
        }

        public static Vector2 operator -(Vector2 vector)
        {
            return new Vector2(-vector.X, -vector.Y);
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return left.x != right.x || left.y != right.y;
        }

        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x + right.x, left.y + right.y);
        }
        
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x - right.x, left.y - right.y);
        }

        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x * right.x, left.y * right.y);
        }

        public static Vector2 operator *(Vector2 vector, float scale)
        {
            return new Vector2(vector.x * scale, vector.y * scale);
        }

        public static Vector2 operator *(float scale, Vector2 vector)
        {
            return vector * scale;
        }

        public static Vector2 operator /(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x / right.x, left.y / right.y);
        }

        public static Vector2 operator /(Vector2 vector, float scale)
        {
            return 1 / scale * vector;
        }

        public static Vector2 operator /(float scale, Vector2 vector)
        {
            return vector / scale;
        }
    }
}