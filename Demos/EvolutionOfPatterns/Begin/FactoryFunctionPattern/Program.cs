namespace FactoryFunctionPattern
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton = Singleton.Instance;
            singleton.Write();
        }
    }
}
