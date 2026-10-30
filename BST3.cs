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

public class Program
{
    private static void InOrder(Node node, List<int> result)
    {
        if (node == null) return;

        InOrder(node.Left, result);
        result.Add(node.Data);
        InOrder(node.Right, result);
    }

    public static void Main()
    {
        int[] values = { 45, 23, 67, 12, 34, 56, 89 };
        BinarySearchTree bst = new BinarySearchTree();

        foreach (int value in values)
            bst.Insert(value);

        List<int> orderedValues = new List<int>();
        InOrder(bst.Root, orderedValues);

        Console.WriteLine("EJERCICIO 3: Demostracion del recorrido Inorden");
        Console.Write("Secuencia Inorden: ");
        Console.WriteLine(string.Join(" ", orderedValues));

        bool strictlyAscending = true;
        for (int i = 1; i < orderedValues.Count; i++)
        {
            if (orderedValues[i - 1] >= orderedValues[i])
            {
                strictlyAscending = false;
                break;
            }
        }

        if (strictlyAscending)
            Console.WriteLine("Resultado: la secuencia es estrictamente ascendente.");
        else
            Console.WriteLine("Resultado: la secuencia NO es estrictamente ascendente.");

        Console.WriteLine("\nExplicacion:");
        Console.WriteLine("1. Inorden visita primero el subarbol izquierdo.");
        Console.WriteLine("2. Luego visita el nodo actual.");
        Console.WriteLine("3. Finalmente visita el subarbol derecho.");
        Console.WriteLine("En un BST, los valores del subarbol izquierdo son menores");
        Console.WriteLine("que el nodo y los del derecho son mayores. Por eso, al");
        Console.WriteLine("recorrer izquierda-nodo-derecha, los valores salen ordenados.");
    }
}
