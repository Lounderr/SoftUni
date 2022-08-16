using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace P07.CustomLinkedList
{
    public class Node<T> : IComparable<Node<T>>
    {
        public T Value;
        public Node<T> Prev;
        public Node<T> Next;

        public Node()
        {
            Value = default(T);
            Prev = null;
            Next = null;
        }
        public int CompareTo([AllowNull] Node<T> other)
        {
            return Comparer<T>.Default.Compare(Value, other.Value);
        }
    }
}