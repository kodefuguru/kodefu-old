namespace Kodefu
{
    using System;
    using System.Diagnostics;

    public static class SystemTime
    {
        private static Func<DateTime> now = () => DateTime.UtcNow;

        public static Func<DateTime> Now
        {
            [DebuggerStepThrough]
            get
            {
                return now;
            }

            [DebuggerStepThrough]
            set
            {
                now = value;
            }
        }
    }
}