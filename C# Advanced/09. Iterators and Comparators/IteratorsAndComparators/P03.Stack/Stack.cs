using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P03.Stack
{
    internal class Stack : IEnumerable<int>
    {
        int head;
        int[] stack;

        public Stack()
        {
            head = -1;
            stack = new int[2];
        }

        public void Push(int[] items)
        {
            foreach (var item in items)
            {
                head++;
                stack[head] = item;
                Resize();
            }
        }

        public int Pop()
        {
            if (head < 0)
            {
                throw new Exception("No elements");
            }

            int element = stack[head];

            head--;
            Resize();

            return element;
        }

        public void Resize()
        {
            int occupiedCount = head + 1;
            if (occupiedCount == stack.Length)
            {
                int[] arr = new int[stack.Length];
                stack.CopyTo(arr, 0);

                stack = new int[stack.Length * 2];
                Array.Copy(arr, 0, stack, 0, occupiedCount);
            }
            else if (occupiedCount < stack.Length / 2)
            {
                int[] arr = new int[stack.Length];
                stack.CopyTo(arr, 0);

                stack = new int[stack.Length / 2];
                Array.Copy(arr, 0, stack, 0, occupiedCount);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = head; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this)
            {
                sb.AppendLine(item.ToString());
            }

            foreach (var item in this)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
