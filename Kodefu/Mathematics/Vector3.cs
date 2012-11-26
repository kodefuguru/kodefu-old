namespace Kodefu.Mathematics
{
    using System;

    public struct Vector3 : IVector<float, float, float>, IEquatable<Vector<float, float, float>>, IEquatable<Vector3>
    {
        public static Vector3 Null
        {
            get
            {
                return default(Vector3);
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

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3)
            {
                Equals((Vector3)obj);
            }
            else if (obj is Vector<float, float, float>)
            {
                Equals((Vector<float, float, float>)obj);
            }
            else if (obj is IVector<float, float, float>)
            {
                Equals((IVector<float, float, float>)obj);
            }
            return false;
        }

        public bool Equals(Vector<float, float, float> other)
        {
            return this.x == other.X && this.y == other.Y && this.z == other.Z;
        }
        
        public bool Equals(IVector<float, float, float> other)
        {
            return this.x == other.X && this.y == other.Y && this.z == other.Z;
        }
        
        public bool Equals(Vector3 other)
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

        public static implicit operator Vector<float, float, float>(Vector3 vector)
        {
            return new Vector<float, float, float>(vector.x, vector.y, vector.z);
        }

        public static implicit operator Tuple<float, float, float>(Vector3 vector)
        {
            return Tuple.Create(vector.x, vector.y, vector.z);
        }

        public static implicit operator Vector3(Vector<float, float, float> vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }

        public static implicit operator Vector3(Tuple<float, float, float> tuple)
        {
            return new Vector3(tuple.Item1, tuple.Item2, tuple.Item3);
        }

        public static Vector3 operator -(Vector3 vector)
        {
            return new Vector3(-vector.x, -vector.y, -vector.z);
        }

        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.x == right.x && left.y == right.y && left.z == right.z;
        }

        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !(left == right);
        }

        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x + right.x, left.y + right.y, left.z + right.z);
        }
        
        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x - right.x, left.Y - right.y, left.z - right.z);
        }

        public static Vector3 operator *(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x * right.x, left.y * right.y, left.z * right.z);
        }

        public static Vector3 operator *(Vector3 vector, float scale)
        {
            return new Vector3(vector.x * scale, vector.y * scale, vector.z * scale);
        }

        public static Vector3 operator *(float scale, Vector3 vector)
        {
            return vector * scale;
        }

        public static Vector3 operator /(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x / right.x, left.y / right.y, left.z / right.z);
        }

        public static Vector3 operator /(Vector3 vector, float scale)
        {
            return 1 / scale * vector;
        }

        public static Vector3 operator /(float scale, Vector3 vector)
        {
            return vector / scale;
        }
    }
}