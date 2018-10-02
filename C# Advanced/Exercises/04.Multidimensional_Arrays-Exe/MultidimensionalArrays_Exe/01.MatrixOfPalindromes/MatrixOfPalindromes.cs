using System;

namespace _01.MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main()
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);
            string[,] matrix = new string[rows, cols];

            char endChar = 'a';

            for(int row = 0; row < rows; row++)
            {
                char middleChar = endChar;
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = "" + endChar + middleChar + endChar;
                    middleChar = (char)((int)middleChar + 1);
                }
                endChar = (char)((int)endChar + 1);
            }

            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < cols; col++)
                {
                    if(col < cols - 1)
                    {
                        Console.Write($"{matrix[row, col]} ");
                        continue;
                    }
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
