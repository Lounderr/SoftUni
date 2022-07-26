using System;

namespace L03.GenericScale
{
    public class EqualityScale<T>
        where T : class
    {
        private T left;
        private T right;

        public bool AreEqual()
        {
            return left.Equals(right);
        }

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
