namespace Kodefu
{
    public static class Indexed
    {
        public static Indexed<T> Create<T>(int index, T item)
        {
            return new Indexed<T>(index, item);
        }
    }
}
