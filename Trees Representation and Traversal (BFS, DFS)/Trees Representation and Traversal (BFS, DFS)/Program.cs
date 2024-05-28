using Trees_Representation_and_Traversal__BFS__DFS_;

var tree = new Tree<int>(7,
                    new Tree<int>(19,
                        new Tree<int>(1),
                        new Tree<int>(12),
                        new Tree<int>(31)),
                    new Tree<int>(21),
                    new Tree<int>(14,
                        new Tree<int>(23),
                        new Tree<int>(6)));
Console.Write("BFS: ");
foreach (int i in tree.OrderBfs())
{
    Console.Write(i + " ");
}
Console.WriteLine();
Console.Write("DFS: ");
foreach (int i in tree.OrderDfs())
{
    Console.Write(i + " ");
}

tree.AddChild(21, new Tree<int>(66));
Console.WriteLine();
Console.WriteLine("Added Node");
tree.Draw();

tree.RemoveNode(21);

Console.WriteLine("Removed Node");
tree.Draw();


Console.WriteLine("Swapped nodes: ");
tree.Swap(7, 19);
tree.Draw();


