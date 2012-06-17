namespace Kodefu
{
    using System;
    using System.Numerics;
    using System.Globalization;

    public static class Maybe
    {
        public static BigInteger? ToBigInteger(string value, NumberStyles style = NumberStyles.Integer, NumberFormatInfo info = null)
        {
            info = info ?? NumberFormatInfo.CurrentInfo;
            BigInteger result;

            if (BigInteger.TryParse(value, style, info, out result))
            {
                return result;
            }

            return null;
        }        

        public static Boolean? ToBoolean(string value)
        {
            Boolean result;

            if (Boolean.TryParse(value, out result))
            {
                return result;
            }

            return null;
        }

        public static Byte? ToByte(string value, NumberStyles style = NumberStyles.Integer, NumberFormatInfo info = null)
        {
            info = info ?? NumberFormatInfo.CurrentInfo;
            Byte result;

            if (Byte.TryParse(value, style, info, out result))
            {
                return result;
            }

            return null;
        }

        public static DateTime? ToDateTime(string value, DateTimeFormatInfo info = null, DateTimeStyles style = DateTimeStyles.None)
        {
            info = info ?? DateTimeFormatInfo.CurrentInfo;
            DateTime result;

            if (DateTime.TryParse(value, info, style, out result))
            {
                return result;
            }

            return null;
        }

        public static Decimal? ToDecimal(string value, NumberStyles style = NumberStyles.Number, NumberFormatInfo info = null)
        {
            info = info ?? NumberFormatInfo.CurrentInfo;
            Decimal result;

            if (Decimal.TryParse(value, style, info, out result))
            {
                return result;
            }

            return null;
        }

        public static Double? ToDouble(string value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo info = null)
        {
            info = info ?? NumberFormatInfo.CurrentInfo;
            Double result;

            if (Double.TryParse(value, style, info, out result))
            {
                return result;
            }

            return null;
        }

        public static TEnum? ToEnum<TEnum>(string value, bool ignoreCase = false) where TEnum: struct
        {
            TEnum result;

            if (Enum.TryParse<TEnum>(value, ignoreCase, out result))
            {
                return result;
            }

            return null;
        }

        public static Guid? ToGuid(string value)
        {
            Guid result;
            
            if (Guid.TryParse(value, out result))
            {
                return result;
            }

            return null;
        }

        public static Int16? ToInt16(string value, NumberStyles style = NumberStyles.Integer, NumberFormatInfo info = null)
        {
            info = info ?? NumberFormatInfo.CurrentInfo;
            Int16 result;

            if (Int16.TryParse(value, style, info, out result))
            {
                return result;
            }

            return null;
        }

        public static Int32? ToInt32(string value, NumberStyles style = NumberStyles.Integer, NumberFormatInfo info = null)
        {
            info = info ?? NumberFormatInfo.CurrentInfo;
            Int32 result;

            if (Int32.TryParse(value, style, info, out result))
            {
                return result;
            }

            return null;
        }

        public static Int64? ToInt64(string value, NumberStyles style = NumberStyles.Integer, NumberFormatInfo info = null)
        {
            info = info ?? NumberFormatInfo.CurrentInfo;
            Int64 result;

            if (Int64.TryParse(value, style, info, out result))
            {
                return result;
            }

            return null;
        }

        public static SByte? ToSByte(string value, NumberStyles style = NumberStyles.Integer, NumberFormatInfo info = null)
        {
            info = info ?? NumberFormatInfo.CurrentInfo;
            SByte result;

            if (SByte.TryParse(value, style, info, out result))
            {
                return result;
            }

            return null;
        }

        public static Single? ToSingle(string value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo info = null)
        {
            info = info ?? NumberFormatInfo.CurrentInfo;
            Single result;

            if (Single.TryParse(value, style, info, out result))
            {
                return result;
            }

            return null;
        }

        public static TimeSpan? ToTimeSpan(string value, IFormatProvider provider = null)
        {
            TimeSpan result;

            if (TimeSpan.TryParse(value, provider, out result))
            {
                return result;
            }

            return null;
        }

        public static UInt16? ToUInt16(string value, NumberStyles style = NumberStyles.Integer, NumberFormatInfo info = null)
        {
            info = info ?? NumberFormatInfo.CurrentInfo;
            UInt16 result;

            if (UInt16.TryParse(value, style, info, out result))
            {
                return result;
            }

            return null;
        }

        public static UInt32? ToUInt32(string value, NumberStyles style = NumberStyles.Integer, NumberFormatInfo info = null)
        {
            info = info ?? NumberFormatInfo.CurrentInfo;
            UInt32 result;

            if (UInt32.TryParse(value, style, info, out result))
            {
                return result;
            }

            return null;
        }

        public static UInt64? ToUInt64(string value, NumberStyles style = NumberStyles.Integer, NumberFormatInfo info = null)
        {
            info = info ?? NumberFormatInfo.CurrentInfo;
            UInt64 result;

            if (UInt64.TryParse(value, style, info, out result))
            {
                return result;
            }

            return null;
        }

    }
}
