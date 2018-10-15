using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.SumMatrixElements_2
{
    class SumMatrixElements_2
    {
        static void Main()
        {
            
            var sizes = Regex.Split(Console.ReadLine(), @"\s*,\s*").Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            double[][] matrix = new double[rows][];
            double totalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = Regex.Split(Console.ReadLine(), @"\s*,\s*").Select(double.Parse).ToArray();
            }
            
            foreach(var row in matrix)
            {
                foreach(var el in row)
                {
                    totalSum += el;
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(totalSum);
        }
    }
}