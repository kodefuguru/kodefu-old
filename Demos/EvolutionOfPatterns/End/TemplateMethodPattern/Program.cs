namespace TemplateMethodPattern
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            DelegateTemplate template = new DelegateTemplate(() => Console.WriteLine("first"), () => Console.WriteLine("second"));
            template.TemplateMethod();
        }
    }
}
