namespace Kodefu.Assertion
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public static class Assert
    {
        public static void IsTrue(Func<bool> predicate)
        {
            if (!predicate())
            {
                throw new Exception("Assertion failed");
            }
        }

        public static void IsTrue(bool predicate)
        {
            if (!predicate)
            {
                throw new Exception("Assertion failed");
            }
        }

        public static class Variable
        {
            [DebuggerStepThrough]
            public static void IsNotNull(object variable, string variableName)
            {
                if (variable == null)
                {
                    throw new NullReferenceException(variableName);
                }
            }
        }

        public static class Argument
        {
            [DebuggerStepThrough]
            public static void IsNotNull(object parameter, string parameterName)
            {
                if (parameter == null)
                {
                    throw new ArgumentNullException(parameterName, TextMessages.ArgumentCannotBeNull.FormatWith(parameterName));
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNullOrEmpty(string parameter, string parameterName)
            {
                if (string.IsNullOrWhiteSpace(parameter))
                {
                    throw new ArgumentException(TextMessages.ArgumentCannotBeNullOrEmpty.FormatWith(parameterName), parameterName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotEmpty<T>(ICollection<T> argument, string argumentName)
            {
                IsNotNull(argument, argumentName);

                if (argument.Count == 0)
                {
                    throw new ArgumentException("Collection cannot be empty.", argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotEmpty(Guid argument, string argumentName)
            {
                if (argument == Guid.Empty)
                {
                    throw new ArgumentException("\"{0}\" cannot be empty guid.".FormatWith(argumentName), argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotEmpty(string argument, string argumentName)
            {
                if (string.IsNullOrEmpty((argument ?? string.Empty).Trim()))
                {
                    throw new ArgumentException("\"{0}\" cannot be blank.".FormatWith(argumentName), argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotOutOfLength(string argument, int length, string argumentName)
            {
                if (argument.Trim().Length > length)
                {
                    throw new ArgumentException("\"{0}\" cannot be more than {1} character.".FormatWith(argumentName, length), argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotZeroOrNegative(int parameter, string parameterName)
            {
                if (parameter <= 0)
                {
                    throw new ArgumentOutOfRangeException(parameterName, TextMessages.ArgumentCannotBeNegativeOrZero.FormatWith(parameterName));
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegative(int parameter, string parameterName)
            {
                if (parameter < 0)
                {
                    throw new ArgumentOutOfRangeException(parameterName, TextMessages.ArgumentCannotBeNegative.FormatWith(parameterName));
                }
            }

            [DebuggerStepThrough]
            public static void IsNotZeroOrNegative(long parameter, string parameterName)
            {
                if (parameter <= 0)
                {
                    throw new ArgumentOutOfRangeException(parameterName, TextMessages.ArgumentCannotBeNegativeOrZero.FormatWith(parameterName));
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegative(long parameter, string parameterName)
            {
                if (parameter < 0)
                {
                    throw new ArgumentOutOfRangeException(parameterName, TextMessages.ArgumentCannotBeNegative.FormatWith(parameterName));
                }
            }

            [DebuggerStepThrough]
            public static void IsNotZeroOrNegative(float parameter, string parameterName)
            {
                if (parameter <= 0)
                {
                    throw new ArgumentOutOfRangeException(parameterName, TextMessages.ArgumentCannotBeNegativeOrZero.FormatWith(parameterName));
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegative(float parameter, string parameterName)
            {
                if (parameter < 0)
                {
                    throw new ArgumentOutOfRangeException(parameterName, TextMessages.ArgumentCannotBeNegative.FormatWith(parameterName));
                }
            }

            [DebuggerStepThrough]
            public static void IsNotZeroOrNegative(decimal parameter, string parameterName)
            {
                if (parameter <= 0)
                {
                    throw new ArgumentOutOfRangeException(parameterName, TextMessages.ArgumentCannotBeNegativeOrZero.FormatWith(parameterName));
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegative(decimal parameter, string parameterName)
            {
                if (parameter < 0)
                {
                    throw new ArgumentOutOfRangeException(parameterName, TextMessages.ArgumentCannotBeNegative.FormatWith(parameterName));
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegative(TimeSpan argument, string argumentName)
            {
                if (argument < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotZeroOrNegative(TimeSpan argument, string argumentName)
            {
                if (argument <= TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotInvalidDate(DateTime argument, string argumentName)
            {
                if (!argument.IsValid())
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotInPast(DateTime argument, string argumentName)
            {
                if (argument < SystemTime.Now())
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotInFuture(DateTime argument, string argumentName)
            {
                if (argument > SystemTime.Now())
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotOutOfRange(int argument, int min, int max, string argumentName)
            {
                if ((argument < min) || (argument > max))
                {
                    throw new ArgumentOutOfRangeException(argumentName, "{0} must be between \"{1}\"-\"{2}\".".FormatWith(argumentName, min, max));
                }
            }
        }
    }
}
