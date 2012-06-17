namespace Classification
{
    using System;
    using System.Linq;

    public static class Program
    {
        static TreeNode<string> tree;

        private static void Main(string[] args)
        {
            tree = TreeNode.Create("first").With(TreeNode.Create("second").With("third"))
                                           .With("fourth")
                                           .With(TreeNode.Create("fifth").With("sixth"));



            //Flatten();
            //FindNode();
            //FindNode(node => Console.WriteLine(node.Item));
            var node = tree.Find(n => n.Item.StartsWith("fo"));
            Console.WriteLine(node.Item);
        }

        public static void Flatten()
        {
            var strings = tree.Flatten(node => node.Item);

            foreach (var str in strings)
            {
                Console.WriteLine(str);
            }
        }

        public static void FindNode()
        {
            var found = tree.Find(node => node.Item.StartsWith("t"));

            Console.WriteLine(found.Item);
        }

        public static void FindNode(Action<TreeNode<string>> continuation)
        {
            var found = tree.Find(node => node.Item.StartsWith("t"));
            continuation(found);            
        }
    }
}
