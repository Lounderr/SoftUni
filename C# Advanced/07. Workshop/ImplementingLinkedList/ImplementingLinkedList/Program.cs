using System;

namespace ImplementingLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();


            Console.WriteLine(String.Join(" ", linkedList.ToArray()));
            linkedList.ForEach(x => x * 10);
            linkedList.ForEach(x => Console.WriteLine(x));
        }
    }
}
