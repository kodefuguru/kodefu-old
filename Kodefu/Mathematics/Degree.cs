namespace Kodefu.Mathematics
{
    using System;

    public struct Degree
    {
        private readonly float value;

        private Degree(float value)
        {
            this.value = value % 360;
        }

        public static implicit operator Degree(float value)
        {
            return new Degree(value);
        }

        public static implicit operator Degree(Radian radian)
        {
            return new Degree(radian * (180.0f / Constants.Pi));
        }

        public static Degree operator +(Degree left, Degree right)
        {
            return new Degree(left.value + right.value);
        }

        public static Degree operator -(Degree left, Degree right)
        {
            return new Degree(left.value - right.value);
        }

        public static implicit operator float(Degree degree)
        {
            return degree.value;
        }

        public static implicit operator double(Degree degree)
        {
            return degree.value;
        }

        public static explicit operator int(Degree degree)
        {
            return (int)degree.value;
        }

        public override string ToString()
        {
            return this.value + "°";
        }
    }
}
