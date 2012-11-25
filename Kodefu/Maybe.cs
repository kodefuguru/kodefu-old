namespace Kodefu
{
    using System;
    using System.Linq;
    
    public static class Maybe
    {
        public static Maybe<T> Create<T>()
        {
            return new Maybe<T>();
        }
        
        public static Maybe<T> Create<T>(T value)
        {
            return new Maybe<T>(value);
        }

        public static Maybe<T> Create<T>(Func<T> thunk)
        {
            return new Maybe<T>(thunk);
        }

        public static Maybe<T> Create<T>(T value, bool predicate)
        {
            return new Maybe<T>(value, predicate);
        }

        public static Maybe<T> Create<T>(Func<T> thunk, bool predicate)
        {
            return new Maybe<T>(thunk, predicate);
        }

        public static Maybe<T> Create<T>(T value, Func<bool> predicate)
        {
            return new Maybe<T>(value, predicate);
        }

        public static Maybe<T> Create<T>(Func<T> thunk, Func<bool> predicate)
        {
            return new Maybe<T>(thunk, predicate);
        }
    }

    public class Maybe<T>
    {
        private readonly Func<bool> predicate;
        private readonly Func<T> thunk;

        public Maybe()
            : this(() => default(T), () => false)
        {
        }

        public Maybe(T value)
            : this(() => value)
        {
        }

        public Maybe(Func<T> thunk)
            : this(thunk, () => true)
        {
        }

        public Maybe(T value, bool predicate)
            : this(() => value, () => predicate)
        {
        }

        public Maybe(Func<T> thunk, bool predicate)
            : this(thunk, () => predicate)
        {
        }

        public Maybe(T value, Func<bool> predicate)
            : this(() => value, predicate)
        {
        }

        public Maybe(Func<T> thunk, Func<bool> predicate)
        {
            this.predicate = predicate;
            this.thunk = thunk;
        }

        public bool HasValue
        {
            get
            {
                return predicate();
            }
        }

        public static Maybe<T> Nothing
        {
            get
            {
                return new Maybe<T>();
            }
        }

        public Maybe<TResult> And<T2, TResult>(Maybe<T2> other, Func<T, T2, TResult> selector )
        {
            return new Maybe<TResult>(() => selector(this.thunk(), other.thunk()), () => this.predicate() && other.predicate()); 
        }

        public T Coalesce()
        {
            return HasValue ? thunk() : default(T);
        }

        public T Coalesce(T value)
        {
            return HasValue ? thunk() : value;
        }

        public T Coalesce(Func<T> factory)
        {
            return HasValue ? thunk() : factory();
        }

        public Maybe<T> Do(Action<T> action)
        {
            return Maybe.Create(() =>
                {
                    T value = thunk();
                    action(value);
                    return value;
                }, 
                this.predicate);
        }

        public Maybe<TResult> Or<T2, TResult>(Maybe<T2> other, Func<T, T2, TResult> selector)
        {
            return new Maybe<TResult>(() => selector(this.thunk(), other.thunk()), () => this.predicate() || other.predicate());
        }

        public void Run(Action<T> action)
        {
            if (HasValue)
            {
                action(thunk());
            }
        }

        public Maybe<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            return new Maybe<TResult>(() => selector(this.thunk()), this.predicate);
        }

        public Maybe<TResult> SelectMany<T2, TResult>(Maybe<T2> other, Func<T, T2, TResult> selector)
        {
            return this.And(other, selector);
        }

        public Maybe<T> Where(Func<T, bool> predicate)
        {
            return new Maybe<T>(this.thunk, () => this.predicate() && predicate(this.thunk()));
        }
    }
}
