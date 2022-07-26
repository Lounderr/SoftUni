using System;

namespace CustomStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList customList = new CustomList();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            customList.Add(4);
            customList.Add(5);
            customList.Add(6);
            customList.RemoveAt(1);

            customList.InsertAt(1, 9);
            customList.Contains(9);
            customList.Swap(0, 5)
        }
    }
}
