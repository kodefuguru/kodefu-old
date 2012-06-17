namespace LegendOfLambda
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        private readonly List<TreeNode<T>> children = new List<TreeNode<T>>();

        public IEnumerable<TreeNode<T>> Children
        {
            get
            {
                return children;
            }
        }

        public T Item { get; private set; }

        public TreeNode(T item)
        {
            this.Item = item;
        }

        public IEnumerable<TResult> Flatten<TResult>(Func<TreeNode<T>, TResult> selector)
        {
            yield return selector(this);

            foreach (TreeNode<T> node in children)
            {
                foreach (var item in node.Flatten(selector))
                {
                    yield return item;
                }
            }
        }

        public TreeNode<T> Find(Func<TreeNode<T>, bool> predicate)
        {
            if (predicate(this))
            {
                return this;
            }

            foreach (TreeNode<T> node in children)
            {
                TreeNode<T> found = node.Find(predicate);
                if (found != null)
                {
                    return found;
                }
            }

            return null;
        }

        public TreeNode<T> With(T item)
        {
            return this.With(new TreeNode<T>(item));
        }

        public TreeNode<T> With(TreeNode<T> node)
        {
            children.Add(node);
            return this;
        }

        public TreeNode<T> With(IEnumerable<TreeNode<T>> nodes)
        {
            children.AddRange(nodes);
            return this;
        }
    }

    public static class TreeNode
    {
        public static TreeNode<T> Create<T>(T item)
        {
            return new TreeNode<T>(item);
        }
    }
}