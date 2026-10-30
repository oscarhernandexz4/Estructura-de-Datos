using System.Xml.Linq;

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

public class BST
{
    public Node Root;

    public void Insert(int value)
    {
        Root = InsertRec(Root, value);
    }

    private Node InsertRec(Node root, int value)
    {
        if (root == null)
            return new Node(value);

        if (value < root.Data)
            root.Left = InsertRec(root.Left, value);
        else if (value > root.Data)
            root.Right = InsertRec(root.Right, value);

        return root;
    }

    public void InOrder(Node node)
    {
        if (node == null)
            return;

        InOrder(node.Left);
        Console.Write(node.Data + " ");
        InOrder(node.Right);
    }
}

public class Program
{
    public static void Main()
    {
        BST tree = new BST();

        int[] numbers = { 45, 23, 67, 12, 34, 56, 89 };

        foreach (int number in numbers)
            tree.Insert(number);

        Console.Write("Recorrido Inorden: ");
        tree.InOrder(tree.Root);
        Console.WriteLine();
    }
}
