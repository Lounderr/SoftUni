using System;
using System.Collections.Generic;

namespace L01.BoxOfT
{
    public class Box<T>
    {
        List<T> list = new List<T>();
        public void Add(T element)
        {
            list.Add(element);
            Count++;
        }
        public T Remove()
        {
            list.RemoveAt(list.Count - 1); 
            Count--;
            return list[list.Count - 1];
        }
        public int Count { get; private set; }
    }
    internal class Program
    {
        static void Main()
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove());
            box.Add(4);
            box.Add(5);
            Console.WriteLine(box.Remove());

        }
    }
}
