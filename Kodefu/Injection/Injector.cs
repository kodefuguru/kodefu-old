namespace Kodefu.Injection
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Kodefu.Assertion;

    public static class Injector
    {
        private static IDependencyResolver resolver;

        [DebuggerStepThrough]
        public static void InitializeWith(IDependencyResolverFactory factory)
        {
            Assert.Argument.IsNotNull(factory, "factory");
            
            resolver = factory.CreateInstance();
        }

        [DebuggerStepThrough]
        public static void Register<T>(T instance)
        {
            Assert.Argument.IsNotNull(instance, "instance");

            resolver.Register(instance);
        }

        [DebuggerStepThrough]
        public static void Inject<T>(T existing)
        {
            Assert.Argument.IsNotNull(existing, "existing");

            resolver.Inject(existing);
        }

        [DebuggerStepThrough]
        public static T Resolve<T>(Type type)
        {
            Assert.Argument.IsNotNull(type, "type");

            return resolver.Resolve<T>(type);
        }

        [DebuggerStepThrough]
        public static T Resolve<T>(Type type, string name)
        {
            Assert.Argument.IsNotNull(type, "type");
            Assert.Argument.IsNotEmpty(name, "name");

            return resolver.Resolve<T>(type, name);
        }

        [DebuggerStepThrough]
        public static T Resolve<T>()
        {
            return resolver.Resolve<T>();
        }

        [DebuggerStepThrough]
        public static T Resolve<T>(string name)
        {
            Assert.Argument.IsNotEmpty(name, "name");

            return resolver.Resolve<T>(name);
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> ResolveAll<T>()
        {
            return resolver.ResolveAll<T>();
        }

        [DebuggerStepThrough]
        public static void Reset()
        {
            if (resolver != null)
            {
                resolver.Dispose();
            }
        }
    }
}