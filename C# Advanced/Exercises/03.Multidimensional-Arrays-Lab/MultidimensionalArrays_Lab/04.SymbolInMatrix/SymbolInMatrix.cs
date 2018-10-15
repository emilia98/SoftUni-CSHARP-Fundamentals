using System;

namespace _04.SymbolInMatrix
{
    class SymbolInMatrix
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for(int row = 0; row < n; row++)
            {
                var inputTokens = Console.ReadLine();

                for(int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputTokens[col];
                }
            }

            char toFind = char.Parse(Console.ReadLine());

            for(int row = 0; row < n; row++)
            {
                for(int col = 0; col < n; col++)
                {
                    if(matrix[row, col] == toFind)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{toFind} does not occur in the matrix");
        }
    }
}