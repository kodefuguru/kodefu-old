namespace Kodefu
{
    using System.Collections.Generic;

    public class TreeNode<TValue> : ITreeNode<TreeNode<TValue>, TValue>
    {
        private List<TreeNode<TValue>> children = new List<TreeNode<TValue>>();

        public string Text { get; set; }
        public TValue Value { get; set; }
        public TreeNode<TValue> Parent { get; set; }

        public IEnumerable<TreeNode<TValue>> Children
        {
            get
            {
                return children;
            }
        }

        public bool Add(TreeNode<TValue> node)
        {
            if (node != null && node.IsRoot())
            {
                node.Parent = this;
                children.Add(node);
                return true;
            }

            return false;
        }

        public bool Remove(TreeNode<TValue> node)
        {
            if (node != null && node.Parent == this)
            {
                node.Parent = null;
                return children.Remove(node);
            }

            return false;
        }
    }
}
