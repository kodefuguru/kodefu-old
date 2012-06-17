namespace FluentContext
{
    using System.Collections.Generic;

    public interface IResultCommand<T, TResult>
    {
        IEnumerable<TResult> Results { get; }
        IResultCommand<T, TResult> Execute(T param);    
    }
}
