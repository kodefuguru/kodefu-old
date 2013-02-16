namespace Kodefu.Math
{
    using System;
    using System.Linq;

    public static class Calculate
    {
        public static float AbsMax(params float[] values)
        {
            return values.Select(f => Math.Abs(f)).Max();
        }

        public static float Max(params float[] values)
        {
            return values.Max();
        }
    }
}
