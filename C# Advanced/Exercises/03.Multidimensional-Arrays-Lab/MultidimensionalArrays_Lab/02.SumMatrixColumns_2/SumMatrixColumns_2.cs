using System;
using System.Linq;

namespace _02.SumMatrixColumns_2
{
    class SumMatrixColumns_2
    {
        static void Main()
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ', ',' }, 
                                                 StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            double[][] matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(new char[] { ' ' }, 
                                                       StringSplitOptions.RemoveEmptyEntries)
                                                .Select(double.Parse)
                                                .ToArray();
            }

            for(int col = 0; col < cols; col++)
            {
                double colSum = 0;

                for(int row = 0; row < rows; row++)
                {
                    colSum += matrix[row][col];
                }

                Console.WriteLine(colSum);
            }
        }
    }
}