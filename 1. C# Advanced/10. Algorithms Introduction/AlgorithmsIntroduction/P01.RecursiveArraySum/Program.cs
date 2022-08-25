using System;

namespace P01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
        }

        public static int SumArrayElements(int[] array, int index) 
        {
            // (((((0 + 1) + 2) + 3) + 4) + 5)

            if (index <= 0)
            {
                return 0;
            }

            return SumArrayElements(array, index - 1) + array[index];
        }
    }
}
