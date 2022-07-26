using System;

namespace CustomStructures
{
    /// <summary>
    /// Custom Queue Implementation
    /// </summary>
    public class CustomQueue
    {
        /// <summary>
        /// Default size of internal array
        /// </summary>
        private const int InitialCapacity = 4;
        private const int FirstElementIndex = 0;

        /// <summary>
        /// Internal array
        /// </summary>
        private int[] items;
        private int count;

        /// <summary>
        /// Number of elements in the queue
        /// </summary>
        public int Count => count;


        /// <summary>
        /// Set the initial count to 0
        /// Creates stack with default size of the inner array
        /// </summary>
        public CustomQueue()
        {
            count = 0;
            items = new int[InitialCapacity];
        }

        /// <summary>
        /// Adds element to the top of the queue
        /// </summary>
        /// <param name="item">Element to add</param>
        public void Enqueue(int item)
        {
            if (items.Length == count)
            {
                IncreaseSize();
            }

            items[count] = item;
            count++;
        }

        /// <summary>
        /// Returns the first element of the queue and removes it
        /// </summary>
        /// <returns></returns>
        public int Dequeue()
        {
            IsEmpty();
            count--;
            var firstElement = items[FirstElementIndex];
            SwitchElements();
            return firstElement;
        }

        /// <summary>
        /// Checks the element in the beginning od queue,
        /// without removing it
        /// </summary>
        /// <returns></returns>
        public int Peek()
        {
            IsEmpty();
            return items[FirstElementIndex];
        }

        /// <summary>
        /// Remove all elements in the queue, by setting them to 0
        /// </summary>
        /// <returns></returns>
        public void Clear()
        {
            IsEmpty();
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = default;
            }
        }

        /// <summary>
        /// Iterates through the custom queue
        /// </summary>
        /// <param name="action">Action to execute on each element</param>
        public void ForEach(Action<int> action)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                action(items[i]);
            }
        }

        private void IncreaseSize()
        {
            int[] tempArr = new int[items.Length * 2];
            items.CopyTo(tempArr, 0);
            items = tempArr;
        }

        private void IsEmpty()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
        }

        private void SwitchElements()
        {
            items[FirstElementIndex] = default;

            for (int i = 1; i < items.Length; i++)
            {
                items[i - 1] = items[i];
            }

            items[items.Length - 1] = default;
        }
    }
}
