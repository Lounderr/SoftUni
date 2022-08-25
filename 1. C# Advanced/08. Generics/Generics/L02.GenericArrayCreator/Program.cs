using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace L02.GenericArrayCreator
{
    public class Animal  // Base class (parent) 
    {
        public void animalSound()
        {
            Console.WriteLine("The animal makes a sound");
        }
    }

    public class Pig : Animal  // Derived class (child) 
    {
        public void animalSound()
        {
            Console.WriteLine("The pig says: wee wee");
        }
    }
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
            StringBuilder[] strings = ArrayCreator.Create(5, new StringBuilder());
            int[] integers = ArrayCreator.Create(10, 1);
        }
    }
}
