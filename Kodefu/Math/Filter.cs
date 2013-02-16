namespace Kodefu.Math
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Filter
    {
        public static IMovingAverage<float> MovingAverage(this IEnumerable<float> sequence)
        {
            return new FloatMovingAverage(sequence);
        }
    }
}
