namespace Kodefu
{
    using System;

    public struct Heyting
    {
        private readonly bool @true;
        private readonly bool @false;

        public Heyting(bool @true, bool @false)
        {
            this.@true = @true;
            this.@false = @false;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(@true) ^ Convert.ToInt32(@false);
        }

        public override bool Equals(object obj)
        {
            if (obj is Heyting)
            {
                return Equals((Heyting)obj);
            }
            else if (obj is bool)
            {
                return Equals((bool)obj);
            }

            return false;
        }

        public bool Equals(Heyting other)
        {
            return this.@true == other.@true
                && this.@false == other.@false;
        }

        public bool Equals(bool other)
        {
            if (other)
            {
                return @true;
            }
            else
            {
                return @false;
            }
        }

        public static bool operator ==(Heyting first, Heyting second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Heyting first, Heyting second)
        {
            return !first.Equals(second);
        }

        public static bool operator false(Heyting value)
        {
            return value.@false;
        }

        public static bool operator true(Heyting value)
        {
            return value.@true;
        }

        public static Heyting True
        {
            get
            {
                return new Heyting(true, false);
            }
        }

        public static Heyting False
        {
            get
            {
                return new Heyting(false, true);
            }
        }

        public static Heyting Neither
        {
            get
            {
                return new Heyting(false, false);
            }
        }

        public static Heyting Both
        {
            get
            {
                return new Heyting(true, true);
            }
        }
    }
}
