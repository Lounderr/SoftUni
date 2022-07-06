int[] dimentionSizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
int rows = dimentionSizes[0];
int cols = dimentionSizes[1];

int[,] matrix = new int[rows, cols];

for (int i = 0; i < rows; i++)
{
    int[] lineInputArr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
    for (int j = 0; j < cols; j++)
    {
        matrix[i, j] = lineInputArr[j];
    }
}

Console.WriteLine(matrix.GetLength(0));
Console.WriteLine(matrix.GetLength(1));

int sum = 0;
foreach (var e in matrix)
{
    sum += e;
}

Console.WriteLine(sum);