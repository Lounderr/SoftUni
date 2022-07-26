using System;

namespace P02.GenericBoxOfInteger
{
    public class Box<T>
    {
        private T value;
        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"{value.GetType()}: {value}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int>[] boxes = new Box<int>[n];
            for (int i = 0; i < n; i++)
            {
                boxes[i] = new Box<int>(int.Parse(Console.ReadLine()));
            }
            foreach (var box in boxes)
            {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
