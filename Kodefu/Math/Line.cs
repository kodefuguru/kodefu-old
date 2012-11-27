namespace Kodefu.Math
{
    using System;
    using System.Linq;

    public static class Line    
    {
        public static Line2 Create(float slope, float yIntercept)
        {
            return new Line2(slope, yIntercept);
        }

        public static float Slope(this Point2 left, Point2 right)
        {
            var x = left.X - right.X;
            return x == 0 ? float.NaN : (left.Y - right.Y) / x;
        }
    }
}
