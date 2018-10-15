using System;

namespace _03.PrimaryDiagonal
{
    class PrimaryDiagonal
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double[,] matrix = new double[n, n];
            double primarySum = 0;

            for(int row = 0; row < n; row++)
            {
                var inputTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for(int col = 0; col < n; col++)
                {
                    matrix[row, col] = int.Parse(inputTokens[col]);

                    if(row == col)
                    {
                        primarySum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(primarySum);
        }
    }
}