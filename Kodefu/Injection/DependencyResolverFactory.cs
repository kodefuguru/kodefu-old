namespace Kodefu.Injection
{
    using System;
    using Kodefu.Assertion;

    public class DependencyResolverFactory : IDependencyResolverFactory
    {
        private readonly Type resolverType;

        public DependencyResolverFactory(string resolverTypeName)
        {
            Assert.Argument.IsNotEmpty(resolverTypeName, "resolverTypeName");

            this.resolverType = Type.GetType(resolverTypeName, true);
        }

        public IDependencyResolver CreateInstance()
        {
            return Activator.CreateInstance(this.resolverType) as IDependencyResolver;
        }
    }
}