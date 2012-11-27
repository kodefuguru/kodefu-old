namespace Kodefu
{
    public interface ITransform<T>
    {
        T Transform(T value);
    }
}
