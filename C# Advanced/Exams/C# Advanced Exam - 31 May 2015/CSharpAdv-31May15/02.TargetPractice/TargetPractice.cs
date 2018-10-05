using System;
using System.Collections.Generic;

namespace _02.TargetPractice
{
    class TargetPractice
    {
        static int rows;
        static int cols;
        static char[,] matrix;
        static int radius;

        static void Main()
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();
            var attackData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            rows = int.Parse(sizes[0]);
            cols = int.Parse(sizes[1]);
            matrix = new char[rows, cols];

            int impactRow = int.Parse(attackData[0]);
            int impactCol = int.Parse(attackData[1]);
            radius = int.Parse(attackData[2]);

            FillMatrix(text);
            Bomb(impactRow, impactCol);
            FallDown();
            PrintMatrix();
        }

        static void FillMatrix(string text)
        {
            int charIndex = 0;
            int currentRow = 0;
            
            for(int row = rows - 1; row >= 0; row--)
            {
                /* HAD ERROR: 
                 * -> Did not count the rows in a right way, so the matrix was filled with wrong chars
                 */
                if(currentRow % 2 == 0)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = text[charIndex];
                        charIndex++;

                        if(charIndex >= text.Length)
                        {
                            charIndex = 0;
                        }
                    }
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = text[charIndex];
                        charIndex++;

                        if (charIndex >= text.Length)
                        {
                            charIndex = 0;
                        }
                    }
                }

                currentRow++;
            }
        }

        static void PrintMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void Bomb(int impactRow, int impactCol)
        {
            int currentRow = impactRow;
            int currentCol = impactCol;

            
            for(int row = impactRow - radius; row <= impactRow + radius; row++)
            {
                for (int col = impactCol - radius; col <= impactCol + radius; col++)
                {
                    if(IsInMatrix(row, col) && IsInRange(impactRow, impactCol, row, col))
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        static void FallDown()
        {
            for(int col = 0; col < cols; col++)
            {
                var column = new Queue<char>();
                for(int row = rows - 1; row >= 0; row--)
                {
                    if(matrix[row, col] != ' ')
                    {
                        column.Enqueue(matrix[row, col]);
                    }
                }
                
                for(int charsCount = column.Count + 1; charsCount <= rows; charsCount++)
                {
                    column.Enqueue(' ');
                }
                
                for(int row = rows - 1; row >= 0; row--)
                {
                    matrix[row, col] = column.Dequeue();
                }
            }
        }


        static bool IsInMatrix(int row, int col)
        {
            if(row < 0 || row >= rows || col < 0 || col >= cols)
            {
                return false;
            }
            return true;
        }

        static bool IsInRange(int row_1, int col_1, int row_2, int col_2)
        {
            int x = row_1 - row_2;
            int y = col_1 - col_2;

            return (x * x) + (y * y) <= radius * radius;
        }
    }
}