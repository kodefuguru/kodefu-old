namespace IteratorPattern
{
    using System.Collections;
    using System.Collections.Generic;

    class Aggregate<T> : IAggregate<T>
    {
        private readonly List<T> items = new List<T>();

        public IIterator<T> CreateIterator()
        {
            return new Iterator<T>(this);
        }

        public int Count
        {
            get
            {
                return items.Count;
            }
        }
   
        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items.Insert(index, value);
            }
        }
    }
}