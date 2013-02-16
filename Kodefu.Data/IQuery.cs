namespace Kodefu.Data
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IQuery<TEntity>
        where TEntity : class
    {
        int Take { get; set; }
        int Skip { get; set; }
        int Page { get; set; }
        Expression<Func<TEntity, bool>> FindByKey { get; set; }
    }
}
