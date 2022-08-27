using System;
using System.Collections;
using System.Collections.Generic;

namespace P02.Collection
{
    public partial class ListyIterator<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return items[i]; 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void PrintAll()
        {
            if (items.Count == 0)
            {
                throw new Exception("Invalid Operation!");
            }

            foreach (var item in this)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
