namespace FluentContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DelegateResultCommand<T, TResult> : IResultCommand<T, TResult>
    {
        private Func<T, IEnumerable<TResult>> func;

        public IEnumerable<TResult> Results { get; private set; }
        
        public DelegateResultCommand(Func<T, IEnumerable<TResult>> func)
        {
            this.func = func;
            this.Results = Enumerable.Empty<TResult>();
        }

        public IResultCommand<T, TResult> Execute(T param)
        {
            Results = func(param);
            return this;
        }

        public DelegateResultCommand<T, TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
        {
            return new DelegateResultCommand<T, TResult2>(param => func(param).Select(selector))
            {
                Results = this.Results.Select(selector).ToArray()
            };
        }
    }
}
