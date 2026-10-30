
using System;

public class Node
{
    public int Data;
    public Node Left;
    public Node Right;

    public Node(int value)
    {
        Data = value;
        Left = null;
        Right = null;
    }
}

public class BinarySearchTree
{
    public Node Root;

    public void Insert(int data)
    {
        Root = InsertRec(Root, data);
    }

    private Node InsertRec(Node root, int data)
    {
        if (root == null)
            return new Node(data);

        if (data < root.Data)
            root.Left = InsertRec(root.Left, data);
        else if (data > root.Data)
            root.Right = InsertRec(root.Right, data);

        return root;
    }
}

public class TreeTraversals
{
    public void PreOrder(Node node)
    {
        if (node == null) return;
        Console.Write(node.Data + " ");
        PreOrder(node.Left);
        PreOrder(node.Right);
    }

    public void InOrder(Node node)
    {
        if (node == null) return;
        InOrder(node.Left);
        Console.Write(node.Data + " ");
        InOrder(node.Right);
    }

    public void PostOrder(Node node)
    {
        if (node == null) return;
        PostOrder(node.Left);
        PostOrder(node.Right);
        Console.Write(node.Data + " ");
    }
}

public class Program
{
    public static void Main()
    {
        BinarySearchTree tree = new BinarySearchTree();

        int[] numbers = { 45, 23, 67, 12, 34, 56, 89 };

        foreach (int number in numbers)
            tree.Insert(number);

        TreeTraversals traversal = new TreeTraversals();

        Console.Write("Preorden: ");
        traversal.PreOrder(tree.Root);

        Console.Write("\nInorden: ");
        traversal.InOrder(tree.Root);

        Console.Write("\nPosorden: ");
        traversal.PostOrder(tree.Root);

        Console.WriteLine();
    }
}
