namespace Kodefu
{
    public static class Selectable
    {
        public static Selectable<T> Create<T>(T value)
        {
            return new Selectable<T>(value);
        }

        public static Selectable<T> Create<T>(T value, bool selected)
        {
            return new Selectable<T>(value, selected);
        }
    }
}
