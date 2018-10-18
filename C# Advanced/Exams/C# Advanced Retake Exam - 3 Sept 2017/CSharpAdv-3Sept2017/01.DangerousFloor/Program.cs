using System;
using System.Linq;

namespace _01.DangerousFloor
{
    class Program
    {
        static char[][] chessboard = new char[8][];

        static void Main(string[] args)
        {
            for (int row = 0; row < 8; row++)
            {
                chessboard[row] = Console.ReadLine().Split(new char[] { ',' },
                                                     StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(char.Parse)
                                                    .ToArray();
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                var tokens = command.Split(new char[] { '-' },
                                          StringSplitOptions.RemoveEmptyEntries);
                string firstPart = tokens[0];
                string secondPart = tokens[1];

                char figure = firstPart[0];
                int currentRow = (int)firstPart[1] - 48;
                int currentCol = (int)firstPart[2] - 48;
                int finalRow = int.Parse(secondPart[0].ToString());
                int finalCol = int.Parse(secondPart[1].ToString());

                if (figure != chessboard[currentRow][currentCol])
                {
                    Console.WriteLine("There is no such a piece!");
                }
                else
                {
                    if (IsInMatrix(finalRow, finalCol) == false)
                    {
                        Console.WriteLine("Move go out of board!");
                    }
                    else
                    {
                        switch (figure)
                        {
                            case 'K':
                                {
                                    MoveKing()
                                    break;
                                }
                        }
                    }
                }
                Console.WriteLine(currentRow);
                Console.WriteLine(finalRow);
                command = Console.ReadLine();
            }
        }

        static bool IsInMatrix(int row, int col)
        {
            if (row < 0 || row >= 8 || col < 0 || col >= 8)
            {
                return false;
            }
            return true;
        }

        static bool MoveKing(int currentRow, int currentCol, int finalRow, int finalCol)
        {
            if ((finalRow >= currentRow - 1 && finalRow <= currentRow + 1)
                && (finalCol >= currentCol - 1 && finalCol <= currentCol + 1))
            {
                if (chessboard[finalRow][finalCol] == 'x')
                {
                    chessboard[finalRow][finalCol] = 'K';
                    chessboard[currentRow][currentCol] = 'x';
                    return true;
                }
            }
            return false;
        }

        static bool MovePawn(int currentRow, int currentCol, int finalRow, int finalCol)
        {
            if (finalRow == currentRow - 1 && finalCol == currentCol)
            {
                if (chessboard[finalRow][finalCol] == 'x')
                {
                    chessboard[finalRow][finalCol] = 'P';
                    chessboard[currentRow][currentCol] = 'x';
                    return true;
                }
            }
            return false;
        }

        static bool MoveRook(int currentRow, int currentCol, int finalRow, int finalCol)
        {
            int upperRow = -1;
            int bottomRow = -1;
            int leftCol = -1;
            int rightCol = -1;

            bool isFree = chessboard[finalRow][finalCol] == 'x';

            if (currentRow == finalRow)
            {
                for (int col = currentCol; col >= 0; col--)
                {
                    if (chessboard[currentRow][col] == 'x')
                    {
                        leftCol = col;
                    }
                    else
                    {
                        break;
                    }
                }

                for (int col = currentCol; col < 8; col++)
                {
                    if (chessboard[currentRow][col] == 'x')
                    {
                        rightCol = col;
                    }
                    else
                    {
                        break;
                    }
                }

                if (finalCol >= leftCol && finalCol <= rightCol)
                {
                    chessboard[finalRow][finalCol] = 'R';
                    chessboard[currentRow][currentCol] = 'x';
                    return true;
                }
            }

            else if(currentCol == finalCol)
            {
                for (int row = currentRow; row >= 0; row--)
                {
                    if (chessboard[row][currentCol] == 'x')
                    {
                        upperRow = row;
                    }
                    else
                    {
                        break;
                    }
                }

                for (int row = currentRow; row < 8; row++)
                {
                    if (chessboard[row][currentCol] == 'x')
                    {
                        bottomRow = row;
                    }
                    else
                    {
                        break;
                    }
                }

                if (finalRow >= upperRow && finalRow <= bottomRow)
                {
                    chessboard[finalRow][finalCol] = 'R';
                    chessboard[currentRow][currentCol] = 'x';
                    return true;
                }
            }

            return false;
        }


        static bool MoveBishop(int currentRow, int currentCol, int finalRow, int finalCol)
        {
            int upRightRow = currentRow;
            int upRightCol = currentCol;
            int upLeftRow = currentRow;
            int upLeftCol = currentCol;
            int bottomLeftRow = currentRow;
            int bottomLeftCol = currentCol;
            int bottomRightRow = currentRow;
            int bottomRightCol = currentCol;

            while ((upRightRow >= 0 && upRightCol < 8))
            {
                if(chessboard[upRightRow][upRightCol] != 'x')
                {
                    break;
                }
                
                if(finalRow == upRightRow && finalCol == upRightCol)
                {
                    return true;
                }
                upRightCol++;
                upRightRow--;
            }

            while ((upLeftRow >= 0 && upLeftCol >= 0))
            {
                if (chessboard[upLeftRow][upLeftCol] != 'x')
                {
                    break;
                }

                if (finalRow == upLeftRow && finalCol == upLeftCol)
                {
                    return true;
                }
                upLeftRow--;
                upLeftCol--;
            }

            while ((bottomLeftRow < 8 && bottomLeftCol >= 0))
            {
                if (chessboard[bottomLeftRow][bottomLeftCol] != 'x')
                {
                    break;
                }

                if (finalRow == bottomLeftRow && finalCol == bottomLeftCol)
                {
                    return true;
                }
                bottomLeftRow++;
                bottomLeftCol--;
            }

            while ((bottomRightRow < 8 && bottomRightCol < 8))
            {
                if (chessboard[bottomRightRow][bottomRightCol] != 'x')
                {
                    break;
                }

                if (finalRow == bottomRightRow && finalCol == bottomRightCol)
                {
                    return true;
                }
                bottomRightRow++;
                bottomRightCol++;
            }
        }
    }
}