using System.Collections;
using System.Collections.Generic;

namespace P04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private readonly List<int> stones; // 13, 23*, 1, -8*, 4, 9* | * = even

        public Lake(List<int> stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    yield return stones[i];
                }
            }

            for (int i = stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
