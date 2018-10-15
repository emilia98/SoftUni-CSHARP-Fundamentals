using System;

namespace _02.SumMatrixColumns
{
    class SumMatrixColumns
    {
        static void Main()
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ', ',' },           StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);

            double[,] matrix = new double[rows, cols];
            double[] sumsByCols = new double[cols];

            for(int row = 0; row < rows; row++)
            {
                var inputTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for(int col = 0; col < cols; col++)
                {
                    matrix[row, col] = double.Parse(inputTokens[col]);
                    sumsByCols[col] += matrix[row, col];
                }
            }

            foreach(var sum in sumsByCols)
            {
                Console.WriteLine(sum);
            }
        }
    }
}