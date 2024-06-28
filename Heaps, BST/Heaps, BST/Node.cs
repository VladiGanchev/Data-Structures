using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps__BST
{
    public class Node<T>
    {
        public Node(T value, Node<T> leftChild= null, Node<T> rightChild = null)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public T Value { get; set; }
        public Node<T> RightChild { get; set; }
        public Node<T> LeftChild { get; set; }
    }
}
