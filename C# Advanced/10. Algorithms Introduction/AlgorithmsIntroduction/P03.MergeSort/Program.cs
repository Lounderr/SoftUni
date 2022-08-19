using System;
using System.Diagnostics;
using System.Linq;

namespace P03.MergeSort
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stopwatch sw = new Stopwatch();

            sw.Start();
            Mergesort<int>.Sort(nums);

            sw.Stop();
            Console.WriteLine(String.Join(' ', Mergesort<int>.Sort(nums)));
        }
    }


    public class Mergesort<T> where T : IComparable
    {
        public static T[] Sort(T[] arr)
        {
            return Split(arr);
        }

        private static T[] Split(T[] arr)
        {
            if (arr.Length == 1)
                return arr;

            T[] left = new T[arr.Length / 2];
            T[] right = new T[arr.Length - arr.Length / 2];

            for (int i = 0, j = 0; j < arr.Length; j++)
            {
                if (j < arr.Length / 2)
                {
                    left[j] = arr[j];
                }
                else
                {
                    right[i] = arr[j];
                    i++;
                }
            }

            return Merge(Split(left), Split(right));
        }

        private static T[] Merge(T[] arr, T[] aux)
        {
            T[] sortedArr = new T[arr.Length + aux.Length];

            int i = 0;
            int j = 0;
            while (i + j < sortedArr.Length)
            {
                if (i < arr.Length && j < aux.Length)
                {
                    if (arr[i].CompareTo(aux[j]) < 0)
                    {
                        sortedArr[i + j] = arr[i];
                        i++;
                    }
                    else
                    {
                        sortedArr[i + j] = aux[j];
                        j++;
                    }
                }
                else
                {
                    if (i < arr.Length)
                    {
                        sortedArr[i + j] = arr[i];
                        i++;
                    }
                    else if (j < aux.Length)
                    {
                        sortedArr[i + j] = aux[j];
                        j++;
                    }
                }
            }

            return sortedArr;
        }
    }
}