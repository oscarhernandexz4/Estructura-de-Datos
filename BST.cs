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
    // Inserción Recursiva Preservando Propiedad BST
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
    // Búsqueda de un Elemento O(log N)
    public bool Search(Node root, int key)
    {
        if (root == null) return false;
        if (root.Data == key) return true;
        return key < root.Data
            ? Search(root.Left, key)
            : Search(root.Right, key);
    }
    public class Program
    {
        public static void Main()
        {
            BinarySearchTree tree = new BinarySearchTree();

            int[] numbers = { 45, 23, 67, 12, 34, 56, 89 };

            foreach (int number in numbers)
            {
                tree.Insert(number);
            }

            Console.WriteLine("Raiz del arbol: " + tree.Root.Data);
            Console.WriteLine("Hojas del arbol: 12, 34, 56, 89");

            Console.WriteLine("Buscar 34: " + tree.Search(tree.Root, 34));
            Console.WriteLine("Buscar 50: " + tree.Search(tree.Root, 50));
        }
    }
}
