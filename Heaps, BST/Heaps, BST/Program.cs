using Heaps__BST;

public class Program
{
    public static void Main(string[] args)
    {
        Node<int> root = new Node<int>(1, 
            new Node<int>(5,
                new Node<int>(2),
                new Node<int>(3)), 
            new Node<int>(7,
                new Node<int>(9),
                new Node<int>(11)));

        BinaryTree<int> tree = new BinaryTree<int>(root);

        Console.WriteLine(tree.DFSPreOrder(tree.Root, 0));
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(tree.DFSInOrder(tree.Root, 0));
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(tree.DFSPostOrder(tree.Root, 0));



        //Heap

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        var integerHeap = new Heap<int>();
        var elements = new List<int>() { 15, 6, 9, 5, 25, 8, 17, 16 };

        foreach (var item in elements)
        {
            integerHeap.Add(item);
        }

        Console.WriteLine(integerHeap.DFSInOrder(0,0));
    }
}
