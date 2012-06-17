namespace FluentContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AggregateResultCommand<TResult> : IResultCommand<TResult>
    {
        private List<IResultCommand<TResult>> commands;

        public IEnumerable<TResult> Results { get; set; }

        public AggregateResultCommand()
        {
            commands = new List<IResultCommand<TResult>>();
            Results = Enumerable.Empty<TResult>();
        }

        public AggregateResultCommand<TResult> With(IResultCommand<TResult> command)
        {
            commands.Add(command);
            return this;
        }

        public AggregateResultCommand<TResult> With(IEnumerable<IResultCommand<TResult>> commands)
        {
            this.commands.AddRange(commands);
            return this;
        }

        public AggregateResultCommand<TResult> With(Func<IEnumerable<TResult>> func)
        {
            return With(ResultCommand.Create(func));
        }

        public IResultCommand<TResult> Execute()
        {
            Results = commands.Do(command => command.Execute()).SelectMany(command => command.Results).ToArray();
            return this;
        }

        public AggregateResultCommand<TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
        {
            return new AggregateResultCommand<TResult2>()
            {
                commands = this.commands.Select(cmd => cmd.Select(selector)).ToList(),
                Results = Results.Select(selector).ToArray()
            };
        }
    }
}
