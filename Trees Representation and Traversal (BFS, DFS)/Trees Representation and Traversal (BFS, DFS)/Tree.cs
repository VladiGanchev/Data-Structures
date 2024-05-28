using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees_Representation_and_Traversal__BFS__DFS_
{
    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T value)
        {
            Value = value;
            Parent = null;
            children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                child.Parent = this;
                this.children.Add(child);

            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            var list = new List<T>();

            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count != 0)
            {

                var element = queue.Dequeue();

                list.Add(element.Value);

                foreach (var child in element.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return list;
        }

        public ICollection<T> OrderDfs()
        {
            var result = new List<T>();

            Dfs(this, result);

            return result;
        }

        private void Dfs(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree.Children)
            {
                Dfs(child, result);
            }

            result.Add(tree.Value);
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> searchedNode = FindBfs(parentKey);

            if (searchedNode == null)
            {
                throw new ArgumentException();
            }

            searchedNode.children.Add(child);
            child.Parent = searchedNode;
        }

        private Tree<T> FindBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Value.Equals(parentKey))
                {
                    return current;
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;

        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> nodeToRemove = FindBfs(nodeKey);

            if (nodeToRemove == null)
            {
                throw new ArgumentException("Node not found");
            }

            if (nodeToRemove.Parent == null)
            {
                // Clear the entire tree if removing the root
                this.Value = default(T);
                this.children.Clear();
                return;
            }

            // Remove the node from its parent's children list
            nodeToRemove.Parent.children.Remove(nodeToRemove);

            // Clear the removed node's parent and children
            nodeToRemove.Parent = null;
            ClearSubtree(nodeToRemove);
        }

        private void ClearSubtree(Tree<T> node)
        {
            foreach (var child in node.children)
            {
                ClearSubtree(child);
            }

            node.children.Clear();
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstNode = FindBfs(firstKey);
            Tree<T> secondNode = FindBfs(secondKey);

            if (firstNode == null || secondNode == null)
            {
                throw new ArgumentException("Both nodes need to exist in the tree.");
            }

            if (firstNode.Parent == null)
            {
                // First node is the root
                SwapRoot(secondNode);
            }
            else if (secondNode.Parent == null)
            {
                // Second node is the root
                SwapRoot(firstNode);
            }
            else
            {
                // Both nodes are non-root nodes
                var firstParent = firstNode.Parent;
                var secondParent = secondNode.Parent;

                int firstIndex = firstParent.children.IndexOf(firstNode);
                int secondIndex = secondParent.children.IndexOf(secondNode);

                firstParent.children[firstIndex] = secondNode;
                secondNode.Parent = firstParent;

                secondParent.children[secondIndex] = firstNode;
                firstNode.Parent = secondParent;
            }
        }

        private void SwapRoot(Tree<T> otherNode)
        {
            var otherParent = otherNode.Parent;
            int otherIndex = otherParent.children.IndexOf(otherNode);

            otherParent.children[otherIndex] = this;

            // Swap children
            var tempChildren = this.children.ToList();
            this.children.Clear();
            this.children.AddRange(otherNode.children);
            foreach (var child in this.children)
            {
                child.Parent = this;
            }

            otherNode.children.Clear();
            otherNode.children.AddRange(tempChildren);
            foreach (var child in otherNode.children)
            {
                child.Parent = otherNode;
            }

            // Swap values
            T tempValue = this.Value;
            this.Value = otherNode.Value;
            otherNode.Value = tempValue;
        }

        public void Draw(int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + this.Value);

            foreach (var child in this.children)
            {
                child.Draw(indent + 2);
            }
        }

    }
}
