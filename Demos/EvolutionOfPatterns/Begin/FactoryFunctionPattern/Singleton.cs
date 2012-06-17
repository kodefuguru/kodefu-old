namespace FactoryFunctionPattern
{
    using System;

    class Singleton
    {
        private static readonly Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance
        {
            get
            {
                return instance.Value;
            }
        }

        private Singleton()
        {
        }

        public void Write()
        {
            Console.WriteLine("Singleton instance called");
        }
    }
}