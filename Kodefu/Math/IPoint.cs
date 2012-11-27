namespace Kodefu.Math
{
    using System;

    public interface IPoint<T> : IEquatable<IPoint<T>>
    {
        T X { get; }
    }

    public interface IPoint<T, T2> : IEquatable<IPoint<T, T2>>
    {
        T X { get; }
        T2 Y { get; }
    }

    public interface IPoint<T, T2, T3> : IEquatable<IPoint<T, T2, T3>>
    {
        T X { get; }
        T2 Y { get; }
        T3 Z { get; }
    }

    public interface IPoint<T, T2, T3, T4> : IEquatable<IPoint<T, T2, T3, T4>>
    {
        T X { get; }
        T2 Y { get; }
        T3 Z { get; }
        T4 W { get; }
    }
}
