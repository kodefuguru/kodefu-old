namespace Kodefu.Math
{
    using System.Collections.Generic;

    public interface IMovingAverage<T>
    {
        IEnumerable<T> Exponential(float degree);

        IEnumerable<T> Simple(int subsetSize);

        IEnumerable<T> Rolling(int subsetSize);
    }
}