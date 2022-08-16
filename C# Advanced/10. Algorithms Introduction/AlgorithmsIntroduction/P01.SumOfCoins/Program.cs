using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.SumOfCoins
{
    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            int[] availableCoins = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var targetSum = int.Parse(Console.ReadLine());

            try
            {
                var selectedCoins = ChooseCoins(availableCoins, targetSum);

                Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
                foreach (var selectedCoin in selectedCoins)
                {
                    Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // count, coinType
        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> countByCoinTypes = new Dictionary<int, int>();

            foreach (var coin in coins.OrderByDescending(x => x))
            {
                while (targetSum - coin >= 0)
                {
                    if (countByCoinTypes.ContainsKey(coin))
                    {
                        countByCoinTypes[coin]++;
                    }
                    else
                    {
                        countByCoinTypes[coin] = 1;
                    }

                    targetSum -= coin;
                }
            }

            if (targetSum == 0)
            {
                return countByCoinTypes;
            }
            else
            {
                throw new Exception("Error");
            }
        }
    }
}