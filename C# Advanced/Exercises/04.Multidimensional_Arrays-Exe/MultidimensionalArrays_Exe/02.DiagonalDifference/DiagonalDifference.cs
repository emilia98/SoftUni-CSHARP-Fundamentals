using System;

namespace _02.DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for(int row = 0; row < n; row++)
            {
                var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for(int index = 0; index < tokens.Length; index++)
                {
                    int col = index;
                    matrix[row, col] = int.Parse(tokens[index]);
                }
            }

            int primarySum = 0;
            int secondarySum = 0;

            for(int row = 0; row < n; row++)
            {
                for(int col = 0; col < n; col++)
                {
                    int element = matrix[row, col];

                    if (row == col)
                    {
                        primarySum += element;
                    }

                    if((row + col) == n - 1)
                    {
                        secondarySum += element;
                    }
                }
            }
            
            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
