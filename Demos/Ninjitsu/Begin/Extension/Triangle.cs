namespace Extension
{
    public class Triangle : Polygon, ITriangle
    {
        public double Base {get; set;}

        public double Height {get; set;}

        public double Area()
        {
            return (Base * Height) / 2;
        }
    }
}
