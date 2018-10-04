using System;

namespace PrintMatrix
{
    class Program
    {
        static void Main()
        {
            int[,] matrix =
            {
                {  1, 2, 3, 4, 5 },
                {  6, 7, 8, 9, 10 },
                {  11, 12, 13, 14, 15 }
            };

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(col == (matrix.GetLength(1) - 1))
                    {
                        Console.Write($"{matrix[row, col]}");
                    }
                    else
                    {
                        Console.Write($"{matrix[row, col]}, ");
                    }
                }
                Console.WriteLine();
            }
            
            // We have no access to the rows and cols
            foreach (var element in matrix)
            {
                Console.WriteLine(element);
            }
        }
    }
}
