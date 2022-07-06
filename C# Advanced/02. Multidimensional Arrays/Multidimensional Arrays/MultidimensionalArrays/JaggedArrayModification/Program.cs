int nRows = int.Parse(Console.ReadLine());

int[][] jArr = new int[nRows][];

for (int e = 0; e < nRows; e++)
{
    int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
    jArr[e] = row;
}


while (true)
{
    string[] cmd = Console.ReadLine().Split().ToArray();

    if (cmd[0] == "End")
    {
        foreach (var arr in jArr)
        {
            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }
        break;
    }

    int row = int.Parse(cmd[1]);
    int col = int.Parse(cmd[2]);
    int value = int.Parse(cmd[3]);

    if (row > jArr.Length || col > jArr[row].Length || row < 0 || col < 0)
    {
        Console.WriteLine("Invalid coordinates");
    }

    else if (cmd[0] == "Add")
    {
        jArr[row][col] += value;
    }

    else if (cmd[0] == "Subtract")
    {
        jArr[row][col] -= value;
    }
}