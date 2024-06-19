using Tree;

public class ExcerciseTreeRepresentationAndTraversal
{
    public static void Main(string[] args)
    {
        TreeFactory factory = new TreeFactory();

        Tree<int> root = null;

        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            string[] data = Console.ReadLine().Split();

            root = factory.CreateTreeFromStrings(data);


        }

        Console.Write("Deepest leftmost node: ");
        Console.WriteLine(root.GetDeepestLeftomostNode().Key);
        Console.WriteLine(String.Join(" ", root.GetLeafKeys()));

        Console.Write("Leaf keys: ");
        Console.WriteLine(String.Join(" ", root.GetLeafKeys()));

        Console.Write($"Middle nodes: ");
        Console.WriteLine(String.Join(" ", root.GetMiddleKeys()));

        List<int> nodes = root.GetLongestPath();
        nodes.Reverse();
        Console.WriteLine("Longest Path: " + String.Join(" ", nodes));


        Console.Write("Enter number to sum path: ");
        int sum = int.Parse(Console.ReadLine());
        List<List<int>> paths = root.PathsWithGivenSum(sum);
        Console.WriteLine($"Paths with sum: {sum}");
        foreach (var item in paths)
        {
            Console.WriteLine(String.Join(" ", item));
        }

        Console.Write("Enter sum for subtrees: ");
        int sumForTrees = int.Parse(Console.ReadLine());
        List<Tree<int>> sumbtreesWithSum = root.SubTreesWithGivenSum(sumForTrees);
        foreach (var item in sumbtreesWithSum)
        {
            Console.WriteLine($"Subtrees of sum {sumForTrees}: ");

            Console.WriteLine(item.GetAsString());
        }






    }

}