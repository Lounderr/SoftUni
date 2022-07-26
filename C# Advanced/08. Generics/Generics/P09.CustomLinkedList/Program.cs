using System;

namespace P09.CustomLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList<double> list = new CustomLinkedList<double>();

            list.AddFirst(-1);
            list.AddLast(0);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            list.RemoveFirst();
            list.RemoveLast();
            list.RemoveAt(4);


            list.ForEach(x => Console.WriteLine(x));
            Console.WriteLine(String.Join(", ", list.ForEach(x => x + 1)));
            Console.WriteLine(String.Join(", ", list.ToArray()));
        }
    }
}
