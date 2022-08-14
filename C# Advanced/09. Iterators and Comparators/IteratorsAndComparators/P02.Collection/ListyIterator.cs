using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace P02.Collection
{
    public partial class ListyIterator<T>
    {
        private readonly List<T> items;

        private int index;

        public ListyIterator(List<T> items)
        {
            this.items = items;
            index = 0;
        }

        public bool Move()
        {
            if (index + 1 < items.Count)
            {
                index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasNext()
        {
            if (index + 1 < items.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            if (items.Count > 0)
            {
                Console.WriteLine(items[index]);
            }
            else
            {
                throw new Exception("Invalid Operation!");
            }
        }
    }
}