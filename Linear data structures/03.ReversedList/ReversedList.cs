namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return items[Count - index - 1];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                items[index] = value;

            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (Count == items.Length)
            {
                T[] arr = Resize(items);
                items = arr;
            }

            items[Count++] = item;
        }

        private T[] Resize(T[] items)
        {
            T[] arr = new T[2 * items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                arr[i] = items[i];
            }

            return arr;
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(item))
                {
                    return Count - i - 1;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            EnsureCapacity();

            for (int i = Count; i >= Count - index; i--)
            {
                items[i] = items[i - 1];
            }
            items[Count - index] = item;
            Count++;

        }
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;

        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > items.Length - 1)
            {
                throw new IndexOutOfRangeException();
            }

            int idx = Count - index - 1;
            items[idx] = default(T);

            items = MoveLeft(items, idx);
        }

        private T[] MoveLeft(T[] arr, int idx)
        {
            for (int i = idx; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }

            arr[Count] = default(T);
            Count--;

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void EnsureCapacity()
        {
            if (Count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
        }
    }
}