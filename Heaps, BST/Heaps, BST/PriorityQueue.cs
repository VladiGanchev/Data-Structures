using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps__BST
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Heaps__BST
    {
        public class PriorityQueue<T> where T : IComparable<T>
        {

            private List<T> heap;

            public PriorityQueue()
            {
                heap = new List<T>();
            }

            public int Size { get { return heap.Count; } }

            public void Add(T item)
            {
                heap.Add(item);

                Heapify(heap.Count - 1);
            }

            public T Peek()
            {
                return heap[0];
            }

            public T Dequeue()
            {
                T top = heap[0];
                heap[0] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);

                HeapifyDown(0);

                return top;
            }

            private void HeapifyDown(int index)
            {
                int leftIndex = index * 2 + 1;
                int rightIndex = index * 2 + 2;
                int maxChildIndex = leftIndex;

                if (leftIndex >= heap.Count)
                {
                    return;
                }

                if ((rightIndex < heap.Count) && heap[leftIndex].CompareTo(heap[rightIndex]) < 0)
                {
                    maxChildIndex = rightIndex;
                }

                if (heap[index].CompareTo(heap[maxChildIndex]) < 0)
                {
                    T temp = heap[index];
                    heap[index] = heap[maxChildIndex];
                    heap[maxChildIndex] = temp;
                    HeapifyDown(maxChildIndex);
                }


            }

            private void Heapify(int index)
            {

                if (index == 0)
                {
                    return;
                }

                int parentIndex = (index - 1) / 2;

                if (heap[index].CompareTo(heap[parentIndex]) > 0)
                {
                    T temp = heap[index];
                    heap[index] = heap[parentIndex];
                    heap[parentIndex] = temp;

                    Heapify(parentIndex);
                }
            }

            public string DFSInOrder(int index, int indent)
            {

                string result = "";
                int leftChild = 2 * index + 1;
                int rightChild = 2 * index + 2;

                if (leftChild < heap.Count)
                {
                    result += DFSInOrder(leftChild, indent + 2);
                }

                result += $"{new string(' ', indent)}{heap[index]}\n";

                if (rightChild < heap.Count)
                {
                    result += DFSInOrder(rightChild, indent + 2);
                }

                return result;
            }
        }
    }

}
