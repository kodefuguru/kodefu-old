namespace Kodefu.Data
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}