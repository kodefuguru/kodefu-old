namespace Kodefu
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Generator<T> : IGenerator<T>
    {
        private readonly Func<int, T> factory;
        private int index = default(int);

        public Generator(Func<int, T> factory)
        {
            this.factory = factory;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        public T Generate()
        {
            return factory(index++);
        }

        /// <summary>
        /// For lazy loading, use this instance as IEnumerable<typeparamref name="T"/> instead of calling Generate.
        /// </summary>
        /// <param name="count">The number of items to generate.</param>
        /// <returns>A sequence of generated items.</returns>
        public IEnumerable<T> Generate(int count)
        {
            return this.Take(count).ToArray();
        }

        private class Enumerator : IEnumerator<T>
        {
            private Generator<T> generator;
            private T value = default(T);

            public Enumerator(Generator<T> generator)
            {
                this.generator = generator;
            }

            public void Dispose()
            {
                this.generator = default(Generator<T>);
            }

            /// <summary>
            /// Generates a new element.
            /// </summary>
            /// <returns>Always true, even if the index overflows.</returns>
            /// <remarks>An overflowing index may be desired behavior.</remarks>
            public bool MoveNext()
            {
                this.value = generator.Generate();
                return true;
            }

            public void Reset()
            {
                this.value = default(T);
            }

            object IEnumerator.Current { get { return this.value; } }
            public T Current { get { return this.value; } }
        }
    }

    public static class Generator
    {
        public static IGenerator<T> Create<T>(IGeneratable<T> generatable)
        {
            return generatable.GetGenerator();
        }

        public static IGenerator<T> Create<T>(T item)
        {
            return new Generator<T>(i => item);
        }

        public static IGenerator<T> Create<T>(Func<T> factory)
        {
            return new Generator<T>(i => factory());
        }

        public static IGenerator<T> Create<T>(Func<int, T> factory)
        {
            return new Generator<T>(factory);
        }
    }
}
