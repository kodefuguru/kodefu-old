namespace RemoveOutParameters
{
    using System;
    using System.Collections.Generic;

    public struct DivResult
    {
        private readonly int quotient;
        private readonly int remainder;

        public int Quotient
        {
            get { return quotient; }
        }

        public int Remainder
        {
            get { return remainder; }
        }

        public DivResult(int quotient, int remainder)
        {
            this.quotient = quotient;
            this.remainder = remainder;
        }

        public override string  ToString()
        {
 	            return Quotient + "R" + Remainder;
        }

        public override int GetHashCode()
        {
            return quotient ^ remainder;
        }

        public override bool  Equals(object obj)
        {
            if (obj is DivResult)
            {
                return Equals((DivResult)obj);
            }

            return false;
        }

        public bool Equals(DivResult other)
        {
            return this.Quotient == other.Quotient 
                && this.Remainder == other.Remainder;
        }

        public static bool operator ==(DivResult first, DivResult second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(DivResult first, DivResult second)
        {
            return !first.Equals(second);
        }

        public IEnumerable<Tuple<int, int>> ValidForResult()
        {
            for (int i = Remainder + 1; i < int.MaxValue; i++)
            {
                int dividend = i * Quotient + Remainder;
                
                if (dividend < 0)
                {
                    yield break;
                }

                yield return Tuple.Create(dividend, i);
            }
        }
    }
}
