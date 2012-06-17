namespace IteratorPattern
{
    class Iterator : IIterator
    {
        private readonly Aggregate aggregate;
        private int current = 0;

        public Iterator(Aggregate aggregate)
        {
            this.aggregate = aggregate;
        }
   
        public object First()
        {
            return aggregate[0];
        }

        public object Next()
        {
            object ret = null;
   
            if (current < aggregate.Count - 1)
            {
                ret = aggregate[++current];
            }
   
            return ret;
        }
   
        public object CurrentItem()
        {
            return aggregate[current];
        }
   
        public bool IsDone()
        {
            return current >= aggregate.Count;
        }
    }
}