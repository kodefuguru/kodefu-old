namespace Kodefu.Math
{
    using System;
    using System.Linq;

    public struct Radian
    {
        private readonly float value;

        private Radian(float value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return this.value + " rad";
        }

        public static implicit operator Radian(float value)
        {
            return new Radian(value);
        }

        public static implicit operator Radian(Degree degree)
        {
            return new Radian(Float.Pi / 180.0f * degree);
        }
        
        public static implicit operator float(Radian radian)
        {
            return radian.value;
        }

        public static implicit operator double(Radian radian)
        {
            return radian.value;
        }

        public static explicit operator int(Radian radian)
        {
            return (int)radian.value;
        }

        public static Radian operator +(Radian left, Radian right)
        {
            return new Radian(left.value + right.value);
        }

        public static Radian operator -(Radian left, Radian right)
        {
            return new Radian(left.value - right.value);
        }

        public static Radian operator *(Radian left, Radian right)
        {
            return new Radian(left.value * right.value);
        }

        public static Radian operator /(Radian left, Radian right)
        {
            return new Radian(left.value / right.value);
        }
    }
}
