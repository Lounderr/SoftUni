using System;

namespace ImplementingGenericLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            linkedList.AddLast("Hello World!");

            Console.WriteLine(String.Join(" ", linkedList.ToArray()));
            linkedList.ForEach(x => x + x);
            linkedList.ForEach(x => Console.WriteLine(x));
        }
    }
}
