namespace Kodefu
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class Reflect
    {
        public static AssemblyName GetAssemblyName(this Assembly assembly)
        {
            return new AssemblyName(assembly.FullName);
        }
    }
}
