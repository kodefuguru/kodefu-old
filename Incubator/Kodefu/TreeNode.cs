namespace Kodefu
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    
    public static class TreeNode
    {
        public static TreeNode<TValue> Create<TValue>(string text, TValue content)
        {
            return new TreeNode<TValue>
            {
                Text = text,
                Value = content
            };
        }

        public static ITreeNode<TNode, TValue> Find<TNode, TValue>(this ITreeNode<TNode, TValue> node, Func<ITreeNode<TNode, TValue>, bool> predicate) where TNode : ITreeNode<TNode, TValue>
        {
            Contract.Requires(node != null);
            Contract.Requires(predicate != null);

            if (predicate(node))
            {
                return node;
            }

            foreach (var child in node.Children)
            {
                var found = child.Find(predicate);

                if (found != null)
                {
                    return found;
                }
            }

            return null;
        }

        public static IEnumerable<ITreeNode<TNode, TValue>> FindAll<TNode, TValue>(this ITreeNode<TNode, TValue> node, Func<ITreeNode<TNode, TValue>, bool> predicate) where TNode : ITreeNode<TNode, TValue>
        {
            Contract.Requires(node != null);
            Contract.Requires(predicate != null);

            if (predicate(node))
            {
                yield return node;
            }

            foreach (var found in node.Children.Cast<ITreeNode<TNode, TValue>>().FindAll(predicate))
            {
                yield return found;
            }
        }

        public static IEnumerable<ITreeNode<TNode, TValue>> FindAll<TNode, TValue>(this IEnumerable<ITreeNode<TNode, TValue>> nodes, Func<ITreeNode<TNode, TValue>, bool> predicate) where TNode : ITreeNode<TNode, TValue>
        {
            Contract.Requires(nodes != null);
            Contract.Requires(predicate != null);

            foreach (var node in nodes)
            {
                foreach (var found in node.FindAll(predicate))
                {
                    yield return found;
                }
            }
        }

        public static bool IsRoot<TNode, TValue>(this ITreeNode<TNode, TValue> node) where TNode : ITreeNode<TNode, TValue>
        {
            Contract.Requires(node != null);

            return node.Parent == null;
        }

        public static bool HasChildren<TNode, TValue>(this ITreeNode<TNode, TValue> node) where TNode : ITreeNode<TNode, TValue>
        {
            Contract.Requires(node != null);

            return node.Children != null && node.Children.Any();
        }
    }
}
