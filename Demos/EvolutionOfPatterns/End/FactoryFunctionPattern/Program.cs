namespace FactoryFunctionPattern
{
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton = Singleton.Instance;
            singleton.Write();

            var strings = Enumerable.Empty<string>();

            var val = strings.FirstOrDefault().IfNull(() => "hello world!");

            System.Console.WriteLine(val);
        }
    }
}
