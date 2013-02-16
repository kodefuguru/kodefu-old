namespace Kodefu.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
   
    public interface IRepository<TEntity> : ICollection<TEntity>, IQueryable<TEntity> 
        where TEntity : class
    {
        void Save();
        void Cancel();
        IUnitOfWork StartTransaction();
    }
}
