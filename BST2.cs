using System;
using System.Collections.Generic;

public class Node
{
    public int Data;
    public Node Left;
    public Node Right;

    public Node(int data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

public class BinarySearchTree
{
    public Node Root;

    public void Insert(int data)
    {
        Root = InsertRecursive(Root, data);
    }

    private Node InsertRecursive(Node current, int data)
    {
        if (current == null)
            return new Node(data);

        if (data < current.Data)
            current.Left = InsertRecursive(current.Left, data);
        else if (data > current.Data)
            current.Right = InsertRecursive(current.Right, data);

        return current;
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

    public void LevelOrder(Node root)
    {
        if (root == null) return;

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            Console.Write(current.Data + " ");

            if (current.Left != null) queue.Enqueue(current.Left);
            if (current.Right != null) queue.Enqueue(current.Right);
        }
    }
}

public class Program
{
    public static void Main()
    {
        int[] values = { 45, 23, 67, 12, 34, 56, 89 };
        BinarySearchTree bst = new BinarySearchTree();

        foreach (int value in values)
            bst.Insert(value);

        TreeTraversals traversals = new TreeTraversals();

        Console.WriteLine("EJERCICIO 2: Recorridos del arbol BST");
        Console.Write("Preorden:  ");
        traversals.PreOrder(bst.Root);
        Console.WriteLine();

        Console.Write("Inorden:   ");
        traversals.InOrder(bst.Root);
        Console.WriteLine();

        Console.Write("Posorden:  ");
        traversals.PostOrder(bst.Root);
        Console.WriteLine();

        Console.Write("Por niveles (BFS, adicional): ");
        traversals.LevelOrder(bst.Root);
        Console.WriteLine();
    }
}
