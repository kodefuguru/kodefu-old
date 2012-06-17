namespace IteratorPattern
{
    using System.Collections.Generic;

    class Infinite<T>
    {
        private readonly T value;

        public Infinite(T value)
        {
            this.value = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                yield return value;
            }
        }
    }
    static class Infinite
    {
        public static Infinite<T> FromValue<T>(T value)
        {
            return new Infinite<T>(value);
        }
    }
}