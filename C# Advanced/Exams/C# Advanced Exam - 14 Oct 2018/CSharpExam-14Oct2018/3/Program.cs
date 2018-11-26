using System;
using System.Linq;

namespace _3
{
    class Program
    {
        static int size;
        static char[,] grid;
        static int minerRow = -1;
        static int minerCol = -1;
        static int coatsLeft = 0;
        static int coatsCollected = 0;
        static bool isAlive = true;

        static void Main()
        {
            size = int.Parse(Console.ReadLine());
            var directions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            grid = new char[size, size];

            for(int row = 0; row < size; row++)
            {
                var inputTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for(int col = 0; col < size; col++)
                {
                    char  currentChar = inputTokens[col];
                    grid[row, col] = currentChar;

                    if(currentChar == 'c')
                    {
                        coatsLeft++;
                        continue;
                    }

                    if(currentChar == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                }
            }
            
            foreach(var direction in directions)
            {
                switch(direction)
                {
                    case "up":
                        {
                            MoveUp();
                            break;
                        }
                    case "down":
                        {
                            MoveDown();
                            break;
                        }

                    case "left":
                        {
                            MoveLeft();
                            break;
                        }

                    case "right":
                        {
                            MoveRight();
                            break;
                        }
                }

                if(isAlive == false)
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    return;
                }

                if(coatsLeft == 0)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    return;
                }
            }

            Console.WriteLine($"{coatsLeft} coals left. ({minerRow}, {minerCol})");
        }

        static void MoveUp()
        {
            if (IsInGrid(minerRow - 1, minerCol) == false)
            {
                return;
            }

            char nextSymbol = grid[minerRow - 1, minerCol];
            minerRow--;

            if (nextSymbol == '*')
            {
                
                grid[minerRow + 1, minerCol] = '*';
                
                grid[minerRow, minerCol] = 's';
                return;
            }

            if(nextSymbol == 'c')
            {
                coatsLeft--;
                coatsCollected++;
                grid[minerRow + 1, minerCol] = '*';
                grid[minerRow, minerCol] = 's';
                return;
            }

            if(nextSymbol == 'e')
            {
                isAlive = false;
                grid[minerRow + 1, minerCol] = '*';
                grid[minerRow, minerCol] = 's';
            }

            return;
        }

        static void MoveDown()
        {
            if (IsInGrid(minerRow + 1, minerCol) == false)
            {
                return;
            }

            char nextSymbol = grid[minerRow + 1, minerCol];
            minerRow++;

            if (nextSymbol == '*')
            {

                grid[minerRow - 1, minerCol] = '*';

                grid[minerRow, minerCol] = 's';
                return;
            }

            if (nextSymbol == 'c')
            {
                coatsLeft--;
                coatsCollected++;
                grid[minerRow - 1, minerCol] = '*';
                grid[minerRow, minerCol] = 's';
                return;
            }

            if (nextSymbol == 'e')
            {
                isAlive = false;
                grid[minerRow - 1, minerCol] = '*';
                grid[minerRow, minerCol] = 's';
            }

            return;
        }

        static void MoveLeft()
        {
            if (IsInGrid(minerRow, minerCol - 1) == false)
            {
                return;
            }

            char nextSymbol = grid[minerRow, minerCol - 1];
            minerCol--;

            if (nextSymbol == '*')
            {

                grid[minerRow, minerCol + 1] = '*';

                grid[minerRow, minerCol] = 's';
                return;
            }

            if (nextSymbol == 'c')
            {
                coatsLeft--;
                coatsCollected++;
                grid[minerRow, minerCol + 1] = '*';
                grid[minerRow, minerCol] = 's';
                return;
            }

            if (nextSymbol == 'e')
            {
                isAlive = false;
                grid[minerRow, minerCol + 1] = '*';
                grid[minerRow, minerCol] = 's';
            }

            return;
        }

        static void MoveRight()
        {
            if (IsInGrid(minerRow, minerCol + 1) == false)
            {
                return;
            }

            char nextSymbol = grid[minerRow, minerCol + 1];
            minerCol++;

            if (nextSymbol == '*')
            {

                grid[minerRow, minerCol - 1] = '*';

                grid[minerRow, minerCol] = 's';
                return;
            }

            if (nextSymbol == 'c')
            {
                coatsLeft--;
                coatsCollected++;
                grid[minerRow, minerCol - 1] = '*';
                grid[minerRow, minerCol] = 's';
                return;
            }

            if (nextSymbol == 'e')
            {
                isAlive = false;
                grid[minerRow, minerCol - 1] = '*';
                grid[minerRow, minerCol] = 's';
            }

            return;
        }

        static bool IsInGrid(int row, int col)
        {
            if(row < 0 || row >= size || col < 0 || col >= size)
            {
                return false;
            }
            return true;
        }
    }
}
