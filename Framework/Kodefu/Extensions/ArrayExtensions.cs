namespace Kodefu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ArrayExtensions
    {
        public static void Fill<T>(this T[] array, Func<int, T> func)
        {
            for (int a = array.GetLowerBound(0); a < array.GetUpperBound(0); a++)
            {
                array[a] = func(a);
            }
        }

        public static void Fill<T>(this T[,] array, Func<int, int, T> func)
        {
            for (int a = array.GetLowerBound(0); a < array.GetUpperBound(0); a++)
            {
                for (int b = array.GetLowerBound(1); b < array.GetUpperBound(1); b++)
                {
                    array[a, a] = func(a, b);
                }
            }
        }
    }
}
