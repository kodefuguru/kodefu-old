namespace FluentContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AggregateResultCommand<T, TResult> : IResultCommand<T, TResult>
    {
        private List<IResultCommand<T, TResult>> commands;

        public IEnumerable<TResult> Results { get; set; }

        public AggregateResultCommand()
        {
            commands = new List<IResultCommand<T, TResult>>();
            Results = Enumerable.Empty<TResult>();
        }

        public AggregateResultCommand<T, TResult> With(IResultCommand<T, TResult> command)
        {
            commands.Add(command);
            return this;
        }

        public AggregateResultCommand<T, TResult> With(IEnumerable<IResultCommand<T, TResult>> commands)
        {
            this.commands.AddRange(commands);
            return this;
        }

        public AggregateResultCommand<T, TResult> With(Func<T, IEnumerable<TResult>> func)
        {
            return With(ResultCommand.Create(func));
        }

        public IResultCommand<T, TResult> Execute(T param)
        {
            Results = commands.Do(command => command.Execute(param)).SelectMany(command => command.Results).ToArray();
            return this;
        }

        public AggregateResultCommand<T, TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
        {
            return new AggregateResultCommand<T, TResult2>()
            {
                commands = this.commands.Select(cmd => cmd.Select(selector)).ToList(),
                Results = Results.Select(selector).ToArray()
            };
        }
    }
}
