using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.GenericSwapMethodStrings
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
        
        public static T[] Swap(T[] arr, int index1, int index2)
        {
            T temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
            return arr;
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


            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index1 = indexes[0];
            int index2 = indexes[1];

            boxes = Box<Box<string>>.Swap(boxes, index1, index2);



            foreach (var box in boxes)
            {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
