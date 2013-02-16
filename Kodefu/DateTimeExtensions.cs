namespace Kodefu
{
    using System;
    using System.Diagnostics;

    public static class DateTimeExtensions
    {
        private static readonly DateTime minDate = new DateTime(1900, 1, 1);
        private static readonly DateTime maxDate = new DateTime(9999, 12, 31, 23, 59, 59, 999);
        
        [DebuggerStepThrough]
        //TODO: This looks useless, check whether this is really a good class to include
        public static bool IsValid(this DateTime target)
        {
            return (target >= minDate) && (target <= maxDate);
        }
    }
}