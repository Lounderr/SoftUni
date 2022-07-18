using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingLinkedList
{
    public class LinkedList
    {
        public int Count { get; set; }
        private Node first;
        private Node last; 
        public void AddFirst(int value)
        {
            Node node = new Node();
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

        public void AddLast(int value)
        {
            Node node = new Node();
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

        public int RemoveFirst()
        {
            Node node = first;
            first = node.Next;
            Count--;
            return node.Value;
        }

        public int RemoveLast()
        {
            Node node = last;
            last = node.Prev;
            Count--;
            return node.Value;
        }

        public int GetFirst()
        {
            return first.Value;
        }

        public int GetLast()
        {
            return last.Value;
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            Node node = first;
            for (int i = 0; i < Count; i++)
            {
                array[i] = node.Value;
                node = node.Next;
            }

            return array;
        }

        public void ForEach(Action<int> action)
        {
            Node node = first;
            for (int i = 0; i < Count; i++)
            {
                action(node.Value);
                node = node.Next;
            }
        }

        public void ForEach(Func<int, int> func)
        {
            Node node = first;
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
