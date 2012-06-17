namespace Kodefu
{
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableSelectedExtensions
    {
        public static IEnumerable<T> SelectedValues<T>(this IEnumerable<Selectable<T>> source)
        {
            return source.Where(l => l.Selected).Select(l => l.Value);
        }
    }
}
