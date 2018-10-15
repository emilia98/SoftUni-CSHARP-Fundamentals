using System;
using System.Linq;

namespace _03.PrimaryDiagonal_2
{
    class PrimaryDiagonal_2
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine()
                                     .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(double.Parse)
                                     .ToArray();
            }

            int rowIndex = 0;
            int colIndex = 0;
            double primarySum = 0;

            foreach(var row in matrix)
            {
                foreach(var el in row)
                {
                    if(colIndex == rowIndex)
                    {
                        primarySum += el;
                        break;
                    }
                    colIndex++;
                }

                colIndex = 0;
                rowIndex++;
            }

            Console.WriteLine(primarySum);
        }
    }
}