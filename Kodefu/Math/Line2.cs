namespace Kodefu.Math
{
    using System;

    public struct Line2 : IEquatable<Line2>
    {
        private readonly float slope;
        private readonly float yIntercept;

        public float Slope
        {
            get { return this.slope; }
        }

        public float YIntercept
        {
            get { return this.yIntercept; }
        }

        public Line2(float slope, float yIntercept)
        {
            this.slope = slope;
            this.yIntercept = yIntercept;
        }

        public Line2(Point2 point, Vector2 direction)
        {
            this.slope = direction.Slope();
            this.yIntercept = point.Y - this.slope * point.X;
        }

        public Line2(Vector2 left, Vector2 right)
        {
            this.slope = (left - right).Slope();
            this.yIntercept = left.Y - this.slope * left.X;
        }

        public Line2(Point2 left, Point2 right)
        {
            this.slope = left.Slope(right);
            this.yIntercept = left.Y - this.slope * left.X;
        }

        public override bool Equals(object obj)
        {
            if (obj is Line2)
            {
                Equals((Line2)obj);
            }
            return false;
        }

        public bool Equals(Line2 other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return (this.slope.GetHashCode() + this.yIntercept.GetHashCode()).GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{{put slope-intercept here}}");
        }

        public static implicit operator Tuple<float, float>(Line2 line)
        {
            return Tuple.Create(line.slope, line.yIntercept);
        }

        public static implicit operator Line2(Tuple<float, float> tuple)
        {
            return new Line2(tuple.Item1, tuple.Item2);
        }

        /// <summary>
        /// Perpendicular line at same y-intercept
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Line2 operator -(Line2 line)
        {
            return new Line2(1 / -line.slope, line.yIntercept);            
        }

        public static bool operator ==(Line2 left, Line2 right)
        {
            return left.slope == right.slope && left.yIntercept == right.yIntercept;
        }

        public static bool operator !=(Line2 left, Line2 right)
        {
            return !(left == right);
        }
    }
}