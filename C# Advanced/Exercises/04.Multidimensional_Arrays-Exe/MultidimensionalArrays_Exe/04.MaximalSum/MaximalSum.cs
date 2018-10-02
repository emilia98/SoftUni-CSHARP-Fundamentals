using System;

namespace _04.MaximalSum
{
    class MaximalSum
    {
        static void Main()
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);
            int[,] matrix = new int[rows, cols];

            for(int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for(int index = 0; index < tokens.Length; index++)
                {
                    int col = index;
                    matrix[row, col] = int.Parse(tokens[index]);
                }
            }

            int maxSum = int.MinValue;
            int startRow = 0;
            int startCol = 0;

            for(int row = 0; row < rows - 2; row++)
            {
                for(int col = 0; col < cols - 2; col++)
                {
                    int currentSum =
                        matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if(currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Console.WriteLine("Sum = {0}", maxSum);

            for(int row = startRow; row <= startRow + 2; row++)
            {
                for(int col = startCol; col <= startCol + 2; col++)
                {
                    if(col < startCol + 2)
                    {
                        Console.Write($"{matrix[row, col]} ");
                        continue;
                    }
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
