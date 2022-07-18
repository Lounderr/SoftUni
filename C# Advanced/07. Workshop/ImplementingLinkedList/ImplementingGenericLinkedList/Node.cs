using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingGenericLinkedList
{
    public class Node<T>
    {
        public T Value = default;
        public Node<T> Next = null;
        public Node<T> Prev = null;

        public Node()
        {
        }
    }
}
