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
        }

        //public static void Flatten()
        //{
        //    var strings = tree.Flatten(node => node.Item);

        //    foreach (var str in strings)
        //    {
        //        Console.WriteLine(str);
        //    }
        //}

        //public static void FindNode()
        //{
        //    var found = tree.Find(node => node.Item.StartsWith("t"));

        //    Console.WriteLine(found.Item);
        //}
    }
}
