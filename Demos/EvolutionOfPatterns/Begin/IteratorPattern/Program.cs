namespace IteratorPattern
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Aggregate a = new Aggregate();

            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";

            Iterator i = new Iterator(a);

            object item = i.First();

            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }
        }
    }
}
