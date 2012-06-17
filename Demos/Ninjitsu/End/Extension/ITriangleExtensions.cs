namespace Extension
{
    using System.ComponentModel;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ITriangleExtensions
    {
        public static double Area(this ITriangle triangle)
        {
            return (triangle.Base * triangle.Height) / 2;
        }
    }
}
