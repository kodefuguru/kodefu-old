namespace Kodefu
{
    using System;
    using System.Linq;

    public interface IIdentity<T>
    {
        T Value { get; }
    }
}
