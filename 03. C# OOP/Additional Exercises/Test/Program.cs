using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    internal class Program
    {

        static void Main(string[] args)
        {
            /*
            Recursion
            - pre-actions
            - post-actions
            - void
            - return
                - modifying and passing 
                - passing
                - backtracking
            */

            string v = "456123";

            //PrePostActionsRecursion(v);

            for (int i = 0; i < v.Length; i++)
            {
                v = OrderNumber(v);
            }
            Console.WriteLine(v);
        }

        private static void PrePostActionsRecursion(string v)
        {
            if (v.Length <= 1)
            {
                return;
            }

            Console.WriteLine(v); // v == v below
            PrePostActionsRecursion(v.Substring(1));
            Console.WriteLine(v); // v == v above
        }

        private static string OrderNumber(string v)
        {
            int curr = v[0] - '0';
            int next = v[1] - '0';

            if (curr > next)
            {
                char[] vArr = v.ToCharArray();

                vArr[0] = (char)(next + '0');
                vArr[1] = (char)(curr + '0');

                v = new string(vArr);
            }

            if (v.Length <= 2)
            {
                return v;
            }

            return v[0] + OrderNumber(v.Substring(1)); // Problematic - returning values after manipulation
        }
    }
}
