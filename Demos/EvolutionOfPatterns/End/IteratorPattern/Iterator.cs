namespace IteratorPattern
{
    class Iterator<T> : IIterator<T>
    {
        private readonly Aggregate<T> aggregate;
        private int current = 0;

        public Iterator(Aggregate<T> aggregate)
        {
            this.aggregate = aggregate;
        }
   
        public T First()
        {
            return aggregate[0];
        }

        public T Next()
        {
            T ret = default(T);
   
            if (current < aggregate.Count - 1)
            {
                ret = aggregate[++current];
            }
   
            return ret;
        }
   
        public T CurrentItem()
        {
            return aggregate[current];
        }
   
        public bool IsDone()
        {
            return current >= aggregate.Count;
        }
    }
}