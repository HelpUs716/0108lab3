//45
using System;
namespace BinaryTreeAddLeaf
{
    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
    class Program
    {
        public static void AddLeaf(Node node)
        {
            if (node == null)
                return;
            if (node.Left == null && node.Right == null)
            {
                Node newChild = new Node(node.Value);
                if (node.Value % 2 == 1)
                    node.Left = newChild;
                else node.Right = newChild;
            }
            else
            {
                if (node.Left != null)
                    AddLeaf(node.Left);
                if (node.Right != null)
                    AddLeaf(node.Right);
            }
        }
        public static void PrintTree(Node node, string indent = "", bool isLast = true)
        {
            if (node != null)
            {
                Console.WriteLine($"{indent}└── {node.Value}");
                indent += isLast ? "    " : "│   ";
                PrintTree(node.Left, indent, node.Right == null);
                PrintTree(node.Right, indent, node.Left == null);
            }
        }
        static void Main(string[] args)
        {
            Node root = new Node(4);
            root.Left = new Node(3);
            root.Left.Left = new Node(5);
            root.Left.Right = new Node(6);
            root.Right = new Node(8);

            Console.WriteLine("Дерево до изменения:");
            PrintTree(root);
            AddLeaf(root);
            Console.WriteLine("Дерево после изменения:");
            PrintTree(root);
        }
    }
}
