namespace Kodefu.Mathematics
{
    using System;

    public struct Vector4 : IVector<float, float, float, float>, IEquatable<Vector<float, float, float, float>>, IEquatable<Vector4>
    {
        public static Vector4 Null
        {
            get
            {
                return default(Vector4);
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

        public Vector4(float x, float y, float z, float w)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector4)
            {
                Equals((Vector4)obj);
            }
            else if (obj is Vector<float, float, float, float>)
            {
                Equals((Vector<float, float, float, float>)obj);
            }
            else if (obj is IVector<float, float, float, float>)
            {
                Equals((IVector<float, float, float, float>)obj);
            }
            return false;
        }

        public bool Equals(IVector<float, float, float, float> other)
        {
            return this.x == other.X && this.y == other.Y && this.z == other.Z;
        }

        public bool Equals(Vector<float, float, float, float> other)
        {
            return this.x == other.X && this.y == other.Y && this.z == other.Z;
        }
        
        public bool Equals(Vector4 other)
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

        public static implicit operator Vector<float, float, float>(Vector4 vector)
        {
            return new Vector<float, float, float>(vector.x, vector.y, vector.z);
        }

        public static implicit operator Tuple<float, float, float>(Vector4 vector)
        {
            return Tuple.Create(vector.x, vector.y, vector.z);
        }

        public static implicit operator Vector4(Vector<float, float, float, float> vector)
        {
            return new Vector4(vector.X, vector.Y, vector.Z, vector.W);
        }

        public static implicit operator Vector4(Tuple<float, float, float, float> tuple)
        {
            return new Vector4(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        }

        public static Vector4 operator -(Vector4 vector)
        {
            return new Vector4(-vector.x, -vector.y, -vector.z, -vector.w);
        }

        public static bool operator ==(Vector4 left, Vector4 right)
        {
            return left.x == right.x && left.y == right.y && left.z == right.z && left.w == right.w;
        }

        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return !(left == right);
        }

        public static Vector4 operator +(Vector4 left, Vector4 right)
        {
            return new Vector4(left.x + right.x, left.y + right.y, left.z + right.z, left.w + right.w);
        }
        
        public static Vector4 operator -(Vector4 left, Vector4 right)
        {
            return new Vector4(left.x - right.x, left.Y - right.y, left.z - right.z, left.w - right.w);
        }

        public static Vector4 operator *(Vector4 left, Vector4 right)
        {
            return new Vector4(left.x * right.x, left.y * right.y, left.z * right.z, left.w * right.w);
        }

        public static Vector4 operator *(Vector4 vector, float scale)
        {
            return new Vector4(vector.x * scale, vector.y * scale, vector.z * scale, vector.w * scale);
        }

        public static Vector4 operator *(float scale, Vector4 vector)
        {
            return vector * scale;
        }

        public static Vector4 operator /(Vector4 left, Vector4 right)
        {
            return new Vector4(left.x / right.x, left.y / right.y, left.z / right.z, left.w / right.w);
        }

        public static Vector4 operator /(Vector4 vector, float scale)
        {
            return 1 / scale * vector;
        }

        public static Vector4 operator /(float scale, Vector4 vector)
        {
            return vector / scale;
        }
    }
}