namespace Kodefu
{
    using System.Collections.Generic;
    
    public interface ITreeNode<TNode, TValue> where TNode : ITreeNode<TNode, TValue>
    {
        string Text { get; set; }
        TValue Value { get; set; }
        TNode Parent { get; set; }
        IEnumerable<TNode> Children { get; }
        bool Add(TNode node);
        bool Remove(TNode node);
    }
}
