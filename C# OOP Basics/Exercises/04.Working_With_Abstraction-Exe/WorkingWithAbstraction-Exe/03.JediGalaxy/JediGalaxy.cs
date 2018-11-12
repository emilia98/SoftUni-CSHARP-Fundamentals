using System;
using System.Linq;

namespace _03.JediGalaxy
{
    class JediGalaxy
    {
        static int rows;
        static int cols;

        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            rows = dimestions[0];
            cols = dimestions[1];

            int[,] matrix = new int[rows, cols];

            int value = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = value++;
                }
            }

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] coordinates_Ivo = command.Split(new string[] { " " },
                                          StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " },
                                                      StringSplitOptions.RemoveEmptyEntries)
                                               .Select(int.Parse)
                                               .ToArray();
                int evil_X = evil[0];
                int evil_Y = evil[1];

                while (evil_X >= 0 && evil_Y >= 0)
                {
                    if (IsInMatrix(evil_X, evil_Y))
                    {
                        matrix[evil_X, evil_Y] = 0;
                    }
                    evil_X--;
                    evil_Y--;
                }

                int ivo_X = coordinates_Ivo[0];
                int ivo_Y = coordinates_Ivo[1];

                while (ivo_X >= 0 && ivo_Y < matrix.GetLength(1))
                {
                    if (IsInMatrix(ivo_X, ivo_Y))
                    {
                        sum += matrix[ivo_X, ivo_Y];
                    }

                    ivo_Y++;
                    ivo_X--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        static bool IsInMatrix(int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
            {
                return false;
            }
            return true;
        }
    }
}