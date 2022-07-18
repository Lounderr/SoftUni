using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingGenericLinkedList
{
    public class LinkedList<T>
    {
        public int Count { get; set; }
        private Node<T> first;
        private Node<T> last; 
        public void AddFirst(T value)
        {
            Node<T> node = new Node<T>();
            node.Value = value;

            if (first != null)
            {
                node.Prev = null;
                node.Next = first;

                first.Prev = node;
                first = node;
            }
            else
            {
                node.Prev = null;
                node.Next = null;

                first = node;
                last = node;
            }
            Count++;
        }

        public void AddLast(T value)
        {
            Node<T> node = new Node<T>();
            node.Value = value;

            if (first != null)
            {

                node.Prev = last;
                node.Next = null;

                last.Next = node;
                last = node;
            }
            else
            {
                node.Prev = null;
                node.Next = null;

                first = node;
                last = node;
            }
            Count++;
        }

        public T RemoveFirst()
        {
            Node<T> node = first;
            first = node.Next;
            Count--;
            return node.Value;
        }

        public T RemoveLast()
        {
            Node<T> node = last;
            last = node.Prev;
            Count--;
            return node.Value;
        }

        public T GetFirst()
        {
            return first.Value;
        }

        public T GetLast()
        {
            return last.Value;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            Node<T> node = first;
            for (int i = 0; i < Count; i++)
            {
                array[i] = node.Value;
                node = node.Next;
            }

            return array;
        }

        public void ForEach(Action<T> action)
        {
            Node<T> node = first;
            for (int i = 0; i < Count; i++)
            {
                action(node.Value);
                node = node.Next;
            }
        }

        public void ForEach(Func<T, T> func)
        {
            Node<T> node = first;
            for (int i = 0; i < Count; i++)
            {
                node.Value = func(node.Value);
                node = node.Next;
            }
        }

        public LinkedList()
        {
        }
    }
}
