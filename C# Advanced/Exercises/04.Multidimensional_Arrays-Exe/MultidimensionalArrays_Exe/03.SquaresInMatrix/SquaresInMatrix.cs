using System;

namespace _03.SquaresInMatrix
{
    class SquaresInMatrix
    {
        static int rows;
        static int cols;

        static void Main()
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            rows = int.Parse(sizes[0]);
            cols = int.Parse(sizes[1]);

            char[,] matrix = new char[rows, cols];
            int squareMatrices = 0;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int index = 0; index < tokens.Length; index++)
                {
                    int col = index;
                    matrix[row, col] = char.Parse(tokens[index]);
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    char upperLeft = matrix[row, col];
                    char upperRight = matrix[row, col + 1];
                    char bottomLeft = matrix[row + 1, col];
                    char bottomRight = matrix[row + 1, col + 1];

                    if ((upperLeft == upperRight) && (bottomLeft == bottomRight) && (bottomLeft == upperLeft))
                    {
                        squareMatrices++;
                    }
                }
            }

            Console.WriteLine(squareMatrices);
        }
    }
}
