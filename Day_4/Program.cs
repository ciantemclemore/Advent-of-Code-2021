// See https://aka.ms/new-console-template for more information


string[] input = File.ReadAllLines("day4_part1_input.txt");


int[] numbersDrawn = input[0].Split(",").Select(s => int.Parse(s)).ToArray();

var boards = CreateBoards(input);
int? result = DrawNumbers(numbersDrawn);
Console.WriteLine(result);




int? DrawNumbers(int[] numbersDrawn)
{
    List<int> solutions = new List<int>();
    List<int[,]> allwinners = new List<int[,]>();

    foreach (int number in numbersDrawn) 
    {
        var boardsToCheck = boards.Except(allwinners).ToList();
        var curWinners = MarkBoards(number, boardsToCheck);

        if (curWinners.Any()) 
        {
            solutions.AddRange(curWinners.Select(cw => cw.Item2));
            allwinners.AddRange(curWinners.Select(cw => cw.Item1));
        }
    }

    return solutions.Last();
}

List<ValueTuple<int[,], int>> MarkBoards(int number, List<int[,]> boards)
{
    List<ValueTuple<int[,], int>> winners = new(); 

    for (int i = 0; i < boards.Count; i++) 
    {
        int[,] board = boards[i];

        for (int row = 0; row < board.GetLength(0); row++) 
        {
            for (int col = 0; col < board.GetLength(1); col++) 
            {
                if (board[row, col] == number) 
                {
                    board[row, col] = -1;

                    if (CheckForBingo(board))
                    {
                        winners.Add((board, CalculateSolution(number, board)));
                    }
                }
            }
        }
    }
    return winners;
}

int CalculateSolution(int number, int[,] board)
{
    int sum = 0;

    for (int row = 0; row < board.GetLength(0); row++)
    {
        for (int col = 0; col < board.GetLength(1); col++)
        {
            if (board[row, col] != -1) 
            {
                sum += board[row, col];
            }    
        }  
    }
    return sum * number;
}

bool CheckForBingo(int[,] board)
{
    for (int row = 0; row < board.GetLength(0); row++) 
    {
        if (board[row, 0] == -1)
        {
            int bingoCount = 4;

            for (int col = 1; col < board.GetLength(1); col++)
            {
                bingoCount += board[row, col];           
            }

            if (bingoCount == 0) 
            {
                return true;
            }
        }
    }

    for (int col = 0; col < board.GetLength(1); col++)
    {
        if (board[0, col] == -1)
        {
            int bingoCount = 4;

            for (int row = 1; row < board.GetLength(0); row++)
            {
                bingoCount += board[row, col];
            }

            if (bingoCount == 0)
            {
                return true;
            }
        }
    }

    return false;
}

List<int[,]> CreateBoards(string[] input) 
{
    List<int[,]> boards = new();

    for (int i = 2; i < input.Length; i+=6) 
    {
        int[,] board = new int[5, 5];
        
        for (int j = 0; j < 5; j++) 
        {
            int[] rowNumbers = input[(i + j)].Split(" ").Where(c => !string.IsNullOrEmpty(c)).Select(c => int.Parse(c)).ToArray();

            for (int k = 0; k < rowNumbers.Length; k++) 
            {
                board[j, k] = rowNumbers[k];
            }
        }
        boards.Add(board);
    }
    return boards;
}



