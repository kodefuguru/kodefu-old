namespace SingletonPattern
{
    using System;

    class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        public static Singleton Instance
        {
            get
            {
                return instance;
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