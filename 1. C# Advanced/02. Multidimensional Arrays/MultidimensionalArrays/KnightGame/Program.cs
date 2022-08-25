int n = int.Parse(Console.ReadLine());

char[,] board = new char[n, n];

for (int row = 0; row < n; row++)
{
    char[] line = Console.ReadLine().ToCharArray();
    for (int col = 0; col < n; col++)
    {
        board[row, col] = line[col];
    }
}


int knightsRemoved = 0;

while (true)
{
    int maxNumOfAttacks = 0;
    int[] coords = { 0, 0 };

    for (int row = 0; row < n; row++)
    {
        for (int col = 0; col < n; col++)
        {
            if (board[row, col] != 'K')
                continue;
            int numOfAttacks = GetNumOfAttacks(row, col, board);
            if (maxNumOfAttacks < numOfAttacks)
            {
                maxNumOfAttacks = numOfAttacks;
                coords[0] = row;
                coords[1] = col;
            }

        }
    }
    if (maxNumOfAttacks > 0)
    {
        board[coords[0], coords[1]] = '0';
        knightsRemoved++;
    }
    else
    {
        break;
    }
    //for (int row = 0; row < n; row++)
    //{
    //    for (int col = 0; col < n; col++)
    //    {
    //        Console.Write(board[row, col]);
    //    }
    //    Console.WriteLine();
    //}
}

Console.WriteLine(knightsRemoved);


int GetNumOfAttacks(int row, int col, char[,] board)
{
    int nOfAttacks = 0;

    bool topBoundsCheck = row > 2 && col > 0 && col < board.GetLength(1) - 2;
    if (topBoundsCheck)
    {
        if (board[row - 2, col - 1] == 'K')
            nOfAttacks++;
        if (board[row - 2, col + 1] == 'K')
            nOfAttacks++;
    }

    bool bottomBoundsCheck = row < board.GetLength(0) - 2 && col > 0 && col < board.GetLength(1) - 2;
    if (bottomBoundsCheck)
    {
        if (board[row + 2, col - 1] == 'K')
            nOfAttacks++;
        if (board[row + 2, col + 1] == 'K')
            nOfAttacks++;
    }

    bool leftBoundsCheck = col > 1 && row > 0 && row < board.GetLength(0) - 1;
    if (leftBoundsCheck)
    {
        if (board[row + 1, col - 2] == 'K')
            nOfAttacks++;
        if (board[row - 1, col - 2] == 'K')
            nOfAttacks++;
    }



    bool rightBoundsCheck = col < board.GetLength(1) - 2 && row > 0 && row < board.GetLength(0) - 1;
    if (rightBoundsCheck)
    {
        if (board[row + 1, col + 2] == 'K')
            nOfAttacks++;
        if (board[row - 1, col + 2] == 'K')
            nOfAttacks++;
    }


    return nOfAttacks;
}



// non-functional




//for (int row = 0; row < n; row++)
//{
//    for (int col = 0; col < n; col++)
//    {
//        Console.Write(board[row, col]);
//    }
//    Console.WriteLine();
//}


/*

5 
0K0K0
K000K
00K00
K000K 
0K0K0

*/



