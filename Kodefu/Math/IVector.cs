namespace Kodefu.Math
{
    using System;

    public interface IVector<T> : IEquatable<IVector<T>>
    {
        T X { get; }
    }

    public interface IVector<T, T2> : IEquatable<IVector<T, T2>>
    {
        T X { get; }
        T2 Y { get; }
    }

    public interface IVector<T, T2, T3> : IEquatable<IVector<T, T2, T3>>
    {
        T X { get; }
        T2 Y { get; }
        T3 Z { get; }
    }

    public interface IVector<T, T2, T3, T4> : IEquatable<IVector<T, T2, T3, T4>>
    {
        T X { get; }
        T2 Y { get; }
        T3 Z { get; }
        T4 W { get; }
    }
}
