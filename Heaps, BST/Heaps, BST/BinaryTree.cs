using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps__BST
{
    public class BinaryTree<T>
    {
        public BinaryTree(Node<T> root)
        {
            Root = root;
        }

        public Node<T> Root{ get; set; }

        public string DFSPreOrder(Node<T> node, int indent)
        {
            string result = $"{new string(' ', indent)}{node.Value}\n";

            if(node.LeftChild != null)
            {
                result += DFSPreOrder(node.LeftChild, indent + 2);
            }

            if (node.RightChild != null)
            {
                result += DFSPreOrder(node.RightChild, indent + 2);
            }

            return result;
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

        public string DFSPostOrder(Node<T> node, int indent)
        {

            string result = "";

            if (node.LeftChild != null)
            {
                result += DFSPostOrder(node.LeftChild, indent + 2);
            }


            if (node.RightChild != null)
            {
                result += DFSPostOrder(node.RightChild, indent + 2);
            }

            result += $"{new string(' ', indent)}{node.Value}\n";

            return result;
        }
    }
}
