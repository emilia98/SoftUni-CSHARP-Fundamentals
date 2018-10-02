using System;

namespace _00.TRY
{
    class TargetPractice
    {
        static string text;
        static char[,] matrix;
        static int charIndex = 0;
        static int rows;
        static int cols;

        static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            text = Console.ReadLine();
            var shotTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            rows = int.Parse(input[0]);
            cols = int.Parse(input[1]);
            int impactRow = int.Parse(shotTokens[0]);
            int impactCol = int.Parse(shotTokens[1]);
            int radius = int.Parse(shotTokens[2]);
            matrix = new char[rows, cols];

            int rowCounter = 1;
            for (int d1 = rows - 1; d1 >= 0; d1--)
            {
                int colsIndex = cols - 1;

                if (rowCounter % 2 == 1)
                {
                    MoveRightToLeft(colsIndex, d1);
                }
                else
                {
                    MoveLeftToRight(colsIndex, d1);
                }

                rowCounter++;
            }
            PrintMatrix(rows, cols);
            Console.WriteLine();
            Shot(impactRow, impactCol, radius);
            PrintMatrix(rows, cols);
            Console.WriteLine();
            Fall();
            PrintMatrix(rows, cols);
        }

        static void MoveRightToLeft(int startColIndex, int currentRow)
        {
            for (int col = startColIndex; col >= 0; col--)
            {
                matrix[currentRow, col] = text[charIndex];
                charIndex++;
                CheckCurrentCharIndex();
            }
        }

        static void MoveLeftToRight(int endColIndex, int currentRow)
        {
            for (int col = 0; col <= endColIndex; col++)
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

        static void Shot(int rowImpact, int colImpact, int radius)
        {
            int startCol = colImpact - radius;
            int endCol = colImpact + radius;
            for (int row = rowImpact; row >= Math.Max(0, rowImpact - radius); row--)
            {

                for (int col = Math.Max(startCol, 0); col <= Math.Min(cols - 1, endCol); col++)
                {
                    matrix[row, col] = ' ';
                }

                // Console.WriteLine(startCol + " => " + endCol);
                startCol++;
                endCol--;
            }

            startCol = colImpact - radius;
            endCol = colImpact + radius;
            startCol++;
            endCol--;
            // Console.WriteLine(startCol + " => " + endCol);
            for (int row = rowImpact + 1; row <= Math.Min(rows - 1, rowImpact + radius); row++)
            {
                for (int col = Math.Max(startCol, 0); col <= Math.Min(cols - 1, endCol); col++)
                {
                    matrix[row, col] = ' ';
                }
                startCol++;
                endCol--;
            }
        }

        static void Fall()
        {
            for (int col = 0; col < cols; col++)
            {
                string columnText = String.Empty;
               // char[] columnText = new char[rows];
                int index = 0;
               for(int row = rows - 1; row >= 0; row--)
                {
                    // columnText[index] = matrix[row, col];
                    columnText += matrix[row, col];
                    index++;
                }

               
                var textTokens = columnText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                // Console.WriteLine(String.Join(" => ", textTokens));
                columnText = String.Join("", textTokens);
 // Console.WriteLine(columnText);
                index = 0;
                for(int row = rows - 1; row >= 0; row--)
                {
                    // Console.WriteLine(String.Join("", textTokens[index]);
                    if(index < columnText.Length)
                    {
                        matrix[row, col] = columnText[index];
                        
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                    
                    index++;
                }

            }
        }

        static void PrintMatrix(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
