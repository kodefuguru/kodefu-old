namespace IteratorPattern
{
    interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }
}