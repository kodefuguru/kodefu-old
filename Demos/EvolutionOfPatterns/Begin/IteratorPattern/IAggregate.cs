namespace IteratorPattern
{
    interface IAggregate
    {
        IIterator CreateIterator();
    }
}