namespace Kodefu
{
    public interface IGeneratable<out T>
    {
        IGenerator<T> GetGenerator();
    }
}