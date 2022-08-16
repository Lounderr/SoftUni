using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace P07.CustomLinkedList
{
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        public Node<T> First;
        public Node<T> Last;
        public int Count;

        public void AddFirst(T value)
        {
            Node<T> node = new Node<T>();

            if (Count > 0)
            {
                node.Value = value;
                node.Next = First;
                First.Prev = node;
                First = node;
            }
            else
            {
                node.Value = value;
                Last = node;
                First = node;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            Node<T> node = new Node<T>();

            if (Count > 0)
            {
                node.Value = value;
                node.Prev = Last;
                Last.Next = node;
                Last = node;
            }
            else
            {
                node.Value = value;
                Last = node;
                First = node;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            Node<T> node = First;

            First.Next.Prev = null;
            First = First.Next;

            Count--;

            return node.Value;
        }

        public T RemoveLast()
        {
            Node<T> node = Last;

            Last.Prev.Next = null;
            Last = Last.Prev;

            Count--;

            return node.Value;
        }

        public T RemoveAt(int index)
        {
            Node<T> node = First;
            for (int i = 0; i < index; i++, node = node.Next)
            {


            }

            if (node.Next != null && node.Prev != null)
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
            }
            else if (node.Prev == null)
            {
                return RemoveFirst();
            }
            else
            {
                return RemoveLast();
            }


            Count--;

            return node.Value;
        }

        public List<T> ForEach(Func<T, T> func)
        {
            List<T> list = new List<T>();

            Node<T> node = First;
            for (int i = 0; i < Count; i++, node = node.Next)
            {
                list.Add(func(node.Value));
            }

            return list;
        }

        public void ForEach(Action<T> action)
        {
            Node<T> node = First;

            for (int i = 0; i < Count; i++, node = node.Next)
            {
                action(node.Value);
            }
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];

            Node<T> node = First;
            for (int i = 0; i < Count; i++, node = node.Next)
            {
                arr[i] = node.Value;
            }

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = First;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }   
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public CustomLinkedList()
        {
            First = null;
            Last = null;
            Count = 0;
        }
    }
}
