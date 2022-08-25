int[][] jaggedArr = new int[10][];
//jaggedArr[0] = new int[3];
//jaggedArr[1] = new int[7];
//jaggedArr[2] = null;

for (int i = 0; i < jaggedArr.Length; i++)
{
    jaggedArr[i] = new int[100];
    for (int j = 0; j < jaggedArr[i].Length; j++)
    {
        jaggedArr[i][j] = j;
    }
}

foreach (var arr in jaggedArr)
{
    foreach (var e in arr)
    {
        Console.WriteLine(e);
    }
}