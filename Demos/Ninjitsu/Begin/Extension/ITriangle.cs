namespace Extension
{   
    public interface ITriangle
    {
        double Base { get; set; }

        double Height { get; set; }

        double Area();
    }
}
