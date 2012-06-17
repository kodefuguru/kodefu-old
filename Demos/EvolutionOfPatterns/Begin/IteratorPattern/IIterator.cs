namespace IteratorPattern
{
    interface IIterator
    {
        object First();
        object Next();
        bool IsDone();
        object CurrentItem();
    }
}