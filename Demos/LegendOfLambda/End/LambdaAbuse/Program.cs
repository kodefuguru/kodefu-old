namespace LambdaAbuse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        private static void Main(string[] args)
        {
            var element = HtmlElement.Input().Attributes(t => "button", a => "Click Me", v => 1);
            Console.WriteLine(element);
        }
    }
}
