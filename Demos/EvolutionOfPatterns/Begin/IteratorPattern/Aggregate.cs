namespace IteratorPattern
{
    using System.Collections;

    class Aggregate : IAggregate
    {
        private readonly ArrayList items = new ArrayList();

        public IIterator CreateIterator()
        {
            return new Iterator(this);
        }

        public int Count
        {
            get
            {
                return items.Count;
            }
        }
   
        public object this[int index]
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