using System;

namespace _01.SumMatrixElements
{
    class SumMatrixElements
    {
        static void Main()
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ', ',' },
                                                 StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);
            
            double[,] matrix = new double[rows, cols];
            double totalSum = 0;

            for(int row = 0; row < rows; row++)
            {
                var inputTokens = Console.ReadLine().Split(new char[] { ' ', ',' },                                                                     StringSplitOptions.RemoveEmptyEntries);

                for(int col = 0; col < cols; col++)
                {
                    matrix[row, col] = double.Parse(inputTokens[col]);
                  
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    totalSum += matrix[row, col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(totalSum);
        }
    }
}