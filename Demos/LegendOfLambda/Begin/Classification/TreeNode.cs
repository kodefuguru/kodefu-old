namespace Classification
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