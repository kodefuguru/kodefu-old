namespace PostIncrement
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            i = i++;
            Console.WriteLine(i);
            
            i = 0;
            i = i++ + i--;
            Console.WriteLine(i);
        }
    }
}
