namespace Kodefu
{
    using System;

    /// <summary>
    /// This is an identity and a state monad.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Indexed<T>
    {
        public Indexed(int index, T value)
        {
            Index = index;
            Value = value;
        }

        public int Index { get; private set; }
        public T Value { get; private set; }

        public Indexed<U> Select<U>(Func<T, U> selector)
        {
            return Indexed.Create(Index, selector(Value));
        }
    }
}
