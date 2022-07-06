int size = int.Parse(Console.ReadLine());
int[][] triangle = new int[size][];

//Filling
int rows = triangle.Length;
for (int row = 0; row < rows; row++)
{
    triangle[row] = new int[row + 1];
    int cols = triangle[row].Length;

    triangle[row][0] = 1;
    triangle[row][cols - 1] = 1;

    for (int col = 1; col < cols - 1; col++)
    {
        triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
    }
}

foreach (var arr in triangle)
{
    Console.WriteLine(String.Join(' ', arr));
}
