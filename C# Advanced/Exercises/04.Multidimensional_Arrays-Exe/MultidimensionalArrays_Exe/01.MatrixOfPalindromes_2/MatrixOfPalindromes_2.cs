using System;

namespace _01.MatrixOfPalindromes_2
{
    class MatrixOfPalindromes_2
    {
        static void Main()
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);
            string[][] matrix = new string[rows][];
            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for(int row = 0; row < rows; row++)
            {
                matrix[row] = new string[cols];

                for(int col = 0; col < cols; col++)
                {
                    matrix[row][col] = "" + letters[row] + letters[row + col] + letters[row];
                }
            }

            foreach(var line in matrix)
            {
                Console.WriteLine(String.Join(" ", line));
            }
        }
    }
}
