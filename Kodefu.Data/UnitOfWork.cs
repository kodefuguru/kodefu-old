namespace Kodefu.Data
{
    using System.Diagnostics;
    using Kodefu.Injection;

    public static class UnitOfWork
    {
        [DebuggerStepThrough]
        public static IUnitOfWork Begin()
        {
            return Injector.Resolve<IUnitOfWork>();
        }
    }
}