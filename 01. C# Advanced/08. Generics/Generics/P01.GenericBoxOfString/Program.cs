using System;

namespace P01.GenericBoxOfString
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
            Box<string>[] boxes = new Box<string>[n];
            for (int i = 0; i < n; i++)
            {
                boxes[i] = new Box<string>(Console.ReadLine());
            }
            foreach (var box in boxes)
            {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
