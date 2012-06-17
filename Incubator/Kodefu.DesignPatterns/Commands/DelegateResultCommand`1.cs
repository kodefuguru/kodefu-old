namespace FluentContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DelegateResultCommand<T> : IResultCommand<T>
    {
        private Func<IEnumerable<T>> func;

        public IEnumerable<T> Results { get; private set; }
        
        public DelegateResultCommand(Func<IEnumerable<T>> func)
        {
            this.func = func;
            this.Results = Enumerable.Empty<T>();
        }

        public IResultCommand<T> Execute()
        {
            Results = func();
            return this;
        }

        public DelegateResultCommand<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            return new DelegateResultCommand<TResult>(() => func().Select(selector))
            {
                Results = this.Results.Select(selector).ToArray()
            };
        }
    }
}
