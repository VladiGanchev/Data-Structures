namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            CreateNodeByKey(int.Parse(input[0]));
            CreateNodeByKey(int.Parse(input[1]));

            this.AddEdge(int.Parse(input[0]), int.Parse(input[1]));

            return this.GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!nodesBykeys.ContainsKey(key))
            {
                nodesBykeys.Add(key, new Tree<int>(key));
            }

            return nodesBykeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            nodesBykeys[parent].AddChild(nodesBykeys[child]);
            nodesBykeys[child].AddParent(nodesBykeys[parent]);
        }

        private Tree<int> GetRoot()
        {
            return nodesBykeys.FirstOrDefault(x => x.Value.Parent == null).Value;
        }

    }
}
