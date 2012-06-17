namespace IteratorPattern
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var a = new Aggregate<string>();

            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";

            var i = new Iterator<string>(a);

            var item = i.First();

            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }

            var infinite = Infinite.FromValue("hello world!");

            foreach (string str in infinite)
                Console.WriteLine(str);
        }
    }
}
