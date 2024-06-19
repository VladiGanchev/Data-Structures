namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            _children = new List<Tree<T>>();
            Key = key;

            foreach (var item in children)
            {
                this.AddChild(item);
                item.AddParent(this);
            }

            
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            _children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            Parent = parent;
        }

        public string GetAsString()
        {
            return Draw(0);
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            Tree<T> current = null;

            while (queue.Count > 0)
            {
                current = queue.Dequeue();

                // Enqueue children from right to left
                for (int i = current.Children.Count - 1; i >= 0; i--)
                {
                    queue.Enqueue(current.Children.ElementAt(i));
                }
            }

            return current;
        }

        public List<T> GetLeafKeys()
        {
            var leafKeys = GetLeafNodes();

            return leafKeys.Select(x => x.Key).ToList();
        }

        private List<Tree<T>> GetLeafNodes()
        {
            var leafNodes = new List<Tree<T>>();

            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.Children.Count == 0)
                {
                    leafNodes.Add(node);
                }

                foreach (var item in node.Children)
                {
                    queue.Enqueue(item);
                }
            }

            return leafNodes;
        }

        public List<T> GetMiddleKeys()
        {
            var nodes = new List<T>();

            GetMiddleNodes(this, nodes);

            return nodes;
        }

        private List<T> GetMiddleNodes(Tree<T> root, List<T> nodes)
        {
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.Parent != null && node.Children.Count > 0)
                {
                    nodes.Add(node.Key);
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return nodes;
        }

        public List<T> GetLongestPath()
        {
            var node = GetDeepestLeftomostNode();

            var nodes = new List<T>();


            while (node != null)
            {
                nodes.Add(node.Key);
                node = node.Parent;
            }

            return nodes;
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var leafNodes = GetLeafNodes();

            var result = new List<List<T>>();

            foreach (var leaf in leafNodes)
            {
                var node = leaf;
                int currSum = 0;
                var currentNodes = new List<T>();

                while (node != null)
                {
                    currentNodes.Add(node.Key);
                    currSum += int.Parse(node.Key.ToString());
                    node = node.Parent;
                }

                if (currSum == sum)
                {
                    currentNodes.Reverse();
                    result.Add(currentNodes);
                }
            }

            return result;

        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var nodes = new List<Tree<T>>();

            SubTreeSumDfs(this, sum, nodes);

            return nodes;
        }

        private int SubTreeSumDfs(Tree<T> node, int targetSum, List<Tree<T>> roots)
        {
            int currentSum = int.Parse(node.Key.ToString());

            foreach (var item in node.Children)
            {
                currentSum += SubTreeSumDfs(item, targetSum, roots);
            }

            if (currentSum == targetSum)
            {
                roots.Add(node);
            }

            return currentSum;
        }

        private string Draw(int indent = 0)
        {
            var result = new string(' ', indent) + this.Key + Environment.NewLine;

            foreach (var child in this._children)
            {
                result += child.Draw(indent + 2);
            }

            return result;
        }
    }
}
