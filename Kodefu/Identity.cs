namespace Kodefu
{
    using System;
    using System.Linq;

    public struct Identity<T> : IIdentity<T>
    {
        private readonly T value;

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public bool Equals(Identity<T> other)
        {
            if (this.value == null)
            {
                return other.value == null;
            }
            return this.value.Equals(other.value);
        }

        public bool Equals(T other)
        {
            if (this.value == null)
            {
                return other == null;
            }
            return this.value.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (obj is Identity<T>)
            {
                return this.Equals((Identity<T>)obj);
            }
            if (obj is T)
            {
                return this.Equals((T)obj);
            }
            if (this.value != null)
            {
                return this.value.Equals(obj);
            }
            return false;
        }

        public T Value
        {
            get { return this.value; }
        }

        public Identity(T value)
        {
            this.value = value;
        }

        public TResult Select<TResult>(Func<T, TResult> selector)
        {
            return selector(this.value);
        }

        public static implicit operator Identity<T>(T value)
        {
            return new Identity<T>(value);
        }

        public static implicit operator T(Identity<T> identity)
        {
            return identity.value;
        }
    }

    public static class Identity
    {
        public static Identity<T> Create<T>(T value)
        {
            return new Identity<T>(value);
        }
    }
}
