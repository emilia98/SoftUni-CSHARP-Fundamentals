using System;

namespace _06.TargetPractice
{
    class TargetPractice
    {
        static string text;
        static char[,] matrix;
        static int charIndex = 0;
        static int rows;
        static int cols;
        static int impactRow;
        static int impactCol;
        static int radius;

        static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            text = Console.ReadLine();
            var shotTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            rows = int.Parse(input[0]);
            cols = int.Parse(input[1]);
            impactRow = int.Parse(shotTokens[0]);
            impactCol = int.Parse(shotTokens[1]);
            radius = int.Parse(shotTokens[2]);
            matrix = new char[rows, cols];

            int rowCounter = 1;
            for(int d1 = rows - 1; d1 >= 0; d1--)
            {
                int colsIndex = cols - 1;

                if(rowCounter % 2 == 1)
                {
                    MoveRightToLeft(colsIndex, d1);
                }
                else
                {
                    MoveLeftToRight(colsIndex, d1);
                }

                rowCounter++;
            }


            Shot(impactRow, impactCol, radius);
            Fall();
            PrintMatrix(rows, cols);
        }

        static void MoveRightToLeft(int startColIndex, int currentRow)
        {
            for(int col = startColIndex; col >= 0; col--)
            {
                matrix[currentRow, col] = text[charIndex];
                charIndex++;
                CheckCurrentCharIndex();
            }
        }

        static void MoveLeftToRight(int endColIndex, int currentRow)
        {
            for(int col = 0; col <= endColIndex; col++)
            {
                matrix[currentRow, col] = text[charIndex];
                charIndex++;
                CheckCurrentCharIndex();
            }
        }

        static void CheckCurrentCharIndex()
        {
            if (charIndex >= text.Length)
            {
                charIndex = 0;
            }
        }

        static void Shot(int rowImpact, int colImpact,  int radius)
        {
            int startCol = colImpact - radius;
            int endCol = colImpact + radius;
            
            for(int row = rowImpact; row >= Math.Max(0, rowImpact - radius); row--)
            {
                for(int col = Math.Max(startCol, 0); col <= Math.Min(cols - 1, endCol); col++)
                {
                    if (IsInBombTarget(row, col))
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
            
            for (int row = Math.Min(rows - 1, rowImpact + 1); row <= Math.Min(rows - 1, rowImpact + radius); row++)
            {
                for (int col = Math.Max(startCol, 0); col <= Math.Min(cols - 1, endCol); col++)
                {
                    if (IsInBombTarget(row, col))
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
            
        }

        static void Fall()
        {
            for(int col = 0; col < cols; col++)
            {
                for (int row = rows - 1; row >= 0; row--)
                {
                    char currentChar = matrix[row, col];
                    int currentRow = row;
                    bool isEmpty = false;
                    
                    while(currentChar == ' ' && currentRow > -1)
                    {
currentChar = matrix[currentRow, col];
                        isEmpty = true;
                        currentRow--;
                    }

                    currentRow++;
                    if (isEmpty && currentRow >= 0)
                    {
                        matrix[row, col] = matrix[currentRow, col];
                        matrix[currentRow, col] = ' ';
                    }
                }
               
            }
        }

        static bool IsInBombTarget(int currentRow, int currentCol)
        {
            int rowDistance = impactRow - currentRow;
            int colDistance = impactCol - currentCol;
            var hypotenuse = Math.Sqrt(rowDistance * rowDistance + colDistance * colDistance);

            return hypotenuse <= radius ? true : false;
        }

        static bool IsInMatrix(int row, int col)
        {
            if(row < 0 || row >= rows || col < 0 || col >= cols)
            {
                return false;
            }
            return true;
        }


        static void PrintMatrix(int rows, int cols)
        {
            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row,col]}");
                }
                Console.WriteLine();
            }
        }
    }
}