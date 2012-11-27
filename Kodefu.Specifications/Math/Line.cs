namespace Kodefu.Math
{
    using System;
    using Machine.Specifications;

    public class When_Verticle_Line2_Is_Created_With_Point_And_Direction
    {
        protected static Point2 point;
        protected static Line2 line;
        protected static Vector2 direction;

        Establish that = () =>
            {
                point = new Point2(3, 0);
                direction = new Vector2(0, 1);
            };

        Because of = () => line = new Line2(point, direction);

        It should_have_NaN_for_YIntercept = () => line.YIntercept.ShouldEqual(float.NaN);
        It should_have_NaN_for_Slope = () => line.Slope.ShouldEqual(float.NaN);
    }

    public class When_Verticle_Line2_Is_Created_With_Two_Points
    {
        protected static Point2 pointA;
        protected static Point2 pointB;
        protected static Line2 line;

        Establish that = () =>
        {
            pointA = new Point2(3, 0);
            pointB = new Point2(3, 3);
        };

        Because of = () => line = new Line2(pointA, pointB);

        It should_have_NaN_for_YIntercept = () => line.YIntercept.ShouldEqual(float.NaN);
        It should_have_NaN_for_Slope = () => line.Slope.ShouldEqual(float.NaN);
    }
}
