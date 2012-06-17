namespace Extension
{
    using System;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            ITriangle triangle = new Triangle { Base = 2, Height = 2 };
            Console.WriteLine(triangle.Area());
        }
    }
}
