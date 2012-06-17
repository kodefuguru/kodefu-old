namespace Extension
{
    public class Triangle : Polygon, ITriangle
    {
        public double Base {get; set;}

        public double Height {get; set;}

        public override double Area()
        {
            return (this as ITriangle).Area();
        }
    }
}
