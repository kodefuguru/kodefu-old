namespace Kodefu
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public static class StringExtensions
    {
        private static Dictionary<Type, Func<string, ValueType>> maybe = new Dictionary<Type, Func<string, ValueType>>
        {
                { typeof(BigInteger), s => Kodefu.Maybe.ToBigInteger(s) },
                { typeof(Boolean), s => Kodefu.Maybe.ToBoolean(s) },
                { typeof(Byte), s => Kodefu.Maybe.ToByte(s) },
                { typeof(DateTime), s => Kodefu.Maybe.ToDateTime(s) },
                { typeof(Decimal), s => Kodefu.Maybe.ToDecimal(s) },
                { typeof(Double), s => Kodefu.Maybe.ToDouble(s) },
                { typeof(Guid), s => Kodefu.Maybe.ToGuid(s) },
                { typeof(Int16), s => Kodefu.Maybe.ToInt16(s) },
                { typeof(Int32), s => Kodefu.Maybe.ToInt32(s) },
                { typeof(Int64), s => Kodefu.Maybe.ToInt64(s) },
                { typeof(SByte), s => Kodefu.Maybe.ToSByte(s) },
                { typeof(Single), s => Kodefu.Maybe.ToSingle(s) },
                { typeof(TimeSpan), s => Kodefu.Maybe.ToTimeSpan(s) },
                { typeof(UInt16), s => Kodefu.Maybe.ToUInt16(s) },
                { typeof(UInt32), s => Kodefu.Maybe.ToUInt32(s) },
                { typeof(UInt64), s => Kodefu.Maybe.ToUInt64(s) },
        };

        public static Nullable<T> Maybe<T>(this string value) where T : struct
        {
            Type type = typeof(T);

            if (maybe.ContainsKey(type))
            {
                return maybe[type](value) as Nullable<T>;
            }

            if (type.IsEnum)
            {
                return Kodefu.Maybe.ToEnum<T>(value);
            }

            return null;
        }
    }
}
