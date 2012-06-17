namespace ThisAssignment
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    struct Test<T>
    {
        private readonly T value;
        public Test(T value)
        {
            this.value = value;
        }

        public void Inc()
        {
            this = new Test<T>();
        }
    }
}
