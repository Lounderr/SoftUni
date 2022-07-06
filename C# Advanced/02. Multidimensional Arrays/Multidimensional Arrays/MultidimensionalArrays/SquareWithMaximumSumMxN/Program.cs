int[] dimentionSizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
int rows = dimentionSizes[0];
int cols = dimentionSizes[1];

int[,] matrix = new int[rows, cols];

for (int i = 0; i < rows; i++)
{
    int[] lineInputArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
    for (int j = 0; j < cols; j++)
    {
        matrix[i, j] = lineInputArr[j];
    }
}

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