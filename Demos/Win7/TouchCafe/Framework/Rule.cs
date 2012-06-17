using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TouchCafe
{

    public class Rule<T>
    {
        private Func<T, bool> predicate;
        private Action<T> action;
        private bool terminateOnSuccess;

        public Rule(Func<T, bool> predicate, Action<T> action) : this(predicate, action, true) { }

        public Rule(Func<T, bool> predicate, Action<T> action, bool terminateOnSuccess)
        {
            this.predicate = predicate;
            this.action = action;
            this.terminateOnSuccess = terminateOnSuccess;
        }

        public Rule<T> Next { get; private set; }


        public Rule<T> Add(Func<T, bool> predicate, Action<T> action)
        {
            return Add(predicate, action, true);
        }

        public Rule<T> Add(Func<T, bool> predicate, Action<T> action, bool terminateOnSuccess)
        {
            if (Next != null)
            {
                Next.Add(predicate, action, terminateOnSuccess);
                return this;
            }

            Next = new Rule<T>(predicate, action, terminateOnSuccess);
            return this;
        }

        public void Execute(T item)
        {
            if (predicate(item))
            {
                action(item);
                if (terminateOnSuccess)
                {
                    return;
                }
            }
            if (Next != null)
            {
                Next.Execute(item);
            }
        }
    }

    public static class Rule
    {
        public static Rule<T> Create<T>(Func<T, bool> predicate, Action<T> action)
        {
            return new Rule<T>(predicate, action);
        }

        public static Rule<T> Create<T>(Func<T, bool> predicate, Action<T> action, bool terminateOnSuccess)
        {
            return new Rule<T>(predicate, action, terminateOnSuccess);
        }

    }       
}
