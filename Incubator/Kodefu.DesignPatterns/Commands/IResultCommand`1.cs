namespace FluentContext
{
    using System.Collections.Generic;

    public interface IResultCommand<TResult>
    {
        IEnumerable<TResult> Results { get; }
        IResultCommand<TResult> Execute();    
    }
}
