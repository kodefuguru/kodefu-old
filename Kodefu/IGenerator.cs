namespace Kodefu
{
    using System.Collections.Generic;

    public interface IGenerator<out T> : IEnumerable<T>
    {
        T Generate();
        IEnumerable<T> Generate(int count);
    }
}