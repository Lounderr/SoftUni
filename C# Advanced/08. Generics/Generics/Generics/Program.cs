using System;
using System.Linq;
using System.Text;

namespace Generics
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
            where T : class
        {
            return new T[length].Select(x => x = item).ToArray();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Class (StringBuilder)
            StringBuilder[] strings = ArrayCreator.Create<StringBuilder>(5, new StringBuilder());

            // Struct (Int32)
            int[] integers = ArrayCreator.Create(10, 1); // Compiler Error CS0452
        }
    }
}
