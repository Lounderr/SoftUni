int[,] matrix = {
// 0  1  2  3  4  5
  {7, 1, 3, 3, 2, 1}, // 0
  {1, 3, 9, 8, 5, 6}, // 1
  {4, 6, 7, 9, 1, 0}, // 2
};

// 9 8
// 7 9
// 33

int[] maxSumValues = new int[4];

int maxSum = int.MinValue;
for (int col = 0; col < matrix.GetLength(0) - 1; col++)
{
    for (int row = 0; row < matrix.GetLength(1) - 1; row++)
    {
        int sum =
            matrix[col, row]
            + matrix[col, row + 1]
            + matrix[col + 1, row]
            + matrix[col + 1, row + 1];

        if (sum > maxSum)
        {
            maxSum = sum;
            maxSumValues = new int[4] {
                matrix[col, row], matrix[col, row + 1],
                matrix[col + 1, row], matrix[col + 1, row + 1],
            };
        }
    }
}

Console.WriteLine($"{maxSumValues[0]} {maxSumValues[1]}");
Console.WriteLine($"{maxSumValues[2]} {maxSumValues[3]}");
Console.WriteLine(maxSum);