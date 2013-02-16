namespace Kodefu.Injection
{
    public interface IDependencyResolverFactory
    {
        IDependencyResolver CreateInstance();
    }
}