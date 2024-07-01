using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps__BST
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinarySearchTree(Node<T> root = null)
        {
            Root = root;
        }

        public Node<T> Root { get; set; }

        public void Insert(T value, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(value);
                Root = node;
                return;
            }

            if (node.Value.CompareTo(value) > 0)
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new Node<T>(value);
                    return;
                }

                Insert(value, node.RightChild);
            }
            else
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new Node<T>(value);
                    return;
                }
                Insert(value, node.LeftChild);
            }

        }

        public bool Contains(T value, Node<T> node)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value.CompareTo(value) == 0)
            {
                return true;
            }

            if (node.Value.CompareTo(value) > 0)
            {
                return Contains(value, node.RightChild);
            }
            else
            {
                return Contains(value, node.LeftChild);
            }
        }

        public Node<T> Search(T value, Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.CompareTo(value) == 0)
            {
                return node;
            }

            if (node.Value.CompareTo(value) > 0)
            {
                return Search(value, node.RightChild);
            }
            else
            {
                return Search(value, node.LeftChild);
            }
        }

        public string DFSInOrder(Node<T> node, int indent)
        {

            string result = "";

            if (node.LeftChild != null)
            {
                result += DFSInOrder(node.LeftChild, indent + 2);
            }

            result += $"{new string(' ', indent)}{node.Value}\n";

            if (node.RightChild != null)
            {
                result += DFSInOrder(node.RightChild, indent + 2);
            }

            return result;
        }
    }
}
