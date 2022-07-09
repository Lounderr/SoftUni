//Initialization 

int size = int.Parse(Console.ReadLine());

int[][] triangle = new int[size][];

int rows = triangle.Length;

//Filling
for (int row = 0; row < rows; row++)
{
    triangle[row] = new int[row + 1];
    int cols = triangle[row].Length;

    for (int col = 0; col < cols; col++)
    {
        if (row >= 1 && col >= 1 && col < cols - 1)
        {
            triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
        }
        else
        {
            triangle[row][col] = 1;
        }
    }
}

foreach (var arr in triangle)
{
    Console.WriteLine(String.Join(' ', arr));
}
