using System;
using System.Collections.Generic;
using System.Text;

namespace P09.CustomLinkedList
{
    public class Node<T>
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
    }
}