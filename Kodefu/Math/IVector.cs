namespace Kodefu.Math
{
    using System;

    public interface IVector
    {
    }

    public interface IVector<T> : IVector
    {
        T X { get; }
    }

    public interface IVector<T, T2> : IVector<T>
    {
        T2 Y { get; }
    }

    public interface IVector<T, T2, T3> : IVector<T, T2>
    {
        T3 Z { get; }
    }

    public interface IVector<T, T2, T3, T4> : IVector<T, T2, T3>
    {
        T4 W { get; }
    }
}
