namespace Kodefu
{
    using System;
    using System.Linq;

    public interface ICoalesce<T>
    {
        T Coalesce();
        T Coalesce(T defaultValue);
        T Coalesce(Func<T> factory);
    }
}
