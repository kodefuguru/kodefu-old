namespace Kodefu
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    public static class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> Without<TKey, TValue>(this IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> other)
        {
            Contract.Requires(source != null);
            Contract.Requires(other != null);

            var result = new Dictionary<TKey, TValue>();
            
            foreach (var kvp in source)
            {
                if (!other.ContainsKey(kvp.Key))
                {
                    result.Add(kvp.Key, kvp.Value);
                }
            }

            return result;
        }

        public static IDictionary<TKey, TValue> Zip<TKey, TValue>(this IDictionary<TKey, TValue> source, IEnumerable<TValue> values)
        {
            var result = new Dictionary<TKey, TValue>();

            using (var enumerator = values.GetEnumerator())
            {
                bool hasValue = true;
                foreach (var kvp in source)
                {
                    if (hasValue)
                    {
                        hasValue = enumerator.MoveNext();
                    }

                    if (hasValue)
                    {
                        result.Add(kvp.Key, enumerator.Current);
                    }
                    else
                    {
                        result.Add(kvp.Key, kvp.Value);
                    }
                }
            }

            return result;
        }
    }
}
