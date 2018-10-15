using System;

namespace _04.SymbolInMatrix_2
{
    class SymbolInMatrix_2
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            char toFind = char.Parse(Console.ReadLine());
            bool hasFound = false;
            int rowIndex = 0;

            foreach(var row in matrix)
            {
                int index = Array.IndexOf(row, toFind);

                if(index > -1)
                {
                    hasFound = true;
                    Console.WriteLine($"({rowIndex}, {index})");
                    break;
                }
                rowIndex++;
            }

            if (!hasFound)
            {
                 Console.WriteLine($"{toFind} does not occur in the matrix");
            }
        }
    }
}