namespace FluentContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class ResultCommand
    {
        public static IResultCommand<TResult> Create<TResult>(Func<IEnumerable<TResult>> func)
        {
            return new DelegateResultCommand<TResult>(func);
        }

        public static IResultCommand<T, TResult> Create<T, TResult>(Func<T, IEnumerable<TResult>> func)
        {
            return new DelegateResultCommand<T, TResult>(func);
        }

        public static AggregateResultCommand<TResult> Create<TCommand, TResult>() where TCommand : IResultCommand<TResult>
        {
            Type type = typeof(TCommand);
            var types = Assembly.GetCallingAssembly().GetTypes().Where(t => type.IsAssignableFrom(t));
            return new AggregateResultCommand<TResult>().With(types.Select(t => Activator.CreateInstance(t) as IResultCommand<TResult>));
        }

        public static AggregateResultCommand<T, TResult> Create<TCommand, T, TResult>() where TCommand : IResultCommand<T, TResult>
        {
            Type type = typeof(TCommand);
            var types = Assembly.GetCallingAssembly().GetTypes().Where(t => type.IsAssignableFrom(t));
            return new AggregateResultCommand<T, TResult>().With(types.Select(t => Activator.CreateInstance(t) as IResultCommand<T, TResult>));
        }

        public static AggregateResultCommand<TResult> With<TResult>(this IResultCommand<TResult> command, IResultCommand<TResult> withCommand)
        {
            return new AggregateResultCommand<TResult>().With(command).With(withCommand);
        }

        public static AggregateResultCommand<TResult> With<TResult>(this IResultCommand<TResult> command, Func<IEnumerable<TResult>> func)
        {
            return new AggregateResultCommand<TResult>().With(command).With(func);
        }

        public static AggregateResultCommand<T, TResult> With<T, TResult>(this IResultCommand<T, TResult> command, IResultCommand<T, TResult> withCommand)
        {
            return new AggregateResultCommand<T, TResult>().With(command).With(withCommand);
        }

        public static AggregateResultCommand<T, TResult> With<T, TResult>(this IResultCommand<T, TResult> command, Func<T, IEnumerable<TResult>> func)
        {
            return new AggregateResultCommand<T, TResult>().With(command).With(func);
        }

        public static IResultCommand<TResult2> Select<TResult, TResult2>(this IResultCommand<TResult> command, Func<TResult, TResult2> selector)
        {
            if (command is AggregateResultCommand<TResult>)
            {
                return (command as AggregateResultCommand<TResult>).Select(selector);
            }

            if (command is DelegateResultCommand<TResult>)
            {
                return (command as DelegateResultCommand<TResult>).Select(selector);
            }

            return Create<TResult2>(() => command.Results.Select(selector));
        }

        public static IResultCommand<T, TResult2> Select<T, TResult, TResult2>(this IResultCommand<T, TResult> command, Func<TResult, TResult2> selector)
        {
            if (command is AggregateResultCommand<T, TResult>)
            {
                return (command as AggregateResultCommand<T, TResult>).Select(selector);
            }

            if (command is DelegateResultCommand<T, TResult>)
            {
                return (command as DelegateResultCommand<T, TResult>).Select(selector);
            }

            return Create<T, TResult2>(param => command.Results.Select(selector));
        }
    }
}
