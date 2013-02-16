namespace Kodefu.Math
{
    using System.Collections.Generic;
    using System.Linq;
    using Kodefu.Collections;

    public class FloatMovingAverage : IMovingAverage<float>
    {
        private readonly IEnumerable<float> sequence;

        public FloatMovingAverage(IEnumerable<float> sequence)
        {
            this.sequence = sequence;
        }

        public IEnumerable<float> Exponential(float degree)
        {
            if (sequence.Empty())
                yield break;

            float previous = sequence.First();
            yield return previous;

            foreach (var item in sequence)
            {
                yield return previous = degree * item + (1 - degree) * previous;
            }
        }

        public IEnumerable<float> Simple(int subsetSize)
        {
            var queue = new Queue<float>();
            foreach (var item in sequence)
            {
                if (queue.Count >= subsetSize)
                    queue.Dequeue();

                queue.Enqueue(item);
                yield return queue.Sum() / queue.Count;
            }
        }

        public IEnumerable<float> Rolling(int subsetSize)
        {
            var queue = new Queue<float>();
            foreach (var item in sequence)
            {
                queue.Enqueue(item);
                if (queue.Count >= subsetSize)
                {
                    yield return queue.Sum() / queue.Count;
                    queue.Dequeue();
                }
            }
            while (queue.Count > 0)
            {
                yield return queue.Sum() / queue.Count;
                queue.Dequeue();
            }
        }
    }
}