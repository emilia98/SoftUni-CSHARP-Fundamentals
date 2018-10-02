using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Crossfire
{
    class Program
    {
        static int rows;
        static int cols;
        static int[,] matrix;

        static void Main()
        {
            var sizes = Console.ReadLine()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            matrix = new int[sizes[0], sizes[1]];
            rows = sizes[0];
            cols = sizes[1];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = (row * 1) * cols + (col + 1);
                }
            }

            string command = Console.ReadLine();

            while (command != "Nuke it from orbit")
            {
                var tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int attackRow = int.Parse(tokens[0]);
                int attackCol = int.Parse(tokens[1]);
                int radius = int.Parse(tokens[2]);

                Destroy(attackRow, attackCol, radius);
                MoveElements();
                command = Console.ReadLine();
            }


            PrintMatrix();
        }

        static void PrintMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                var list = new List<int>();
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] != -1)
                    {
                        list.Add(matrix[row, col]);
                    }
                }

                if (list.Count > 0)
                {
                    Console.WriteLine(String.Join(" ", list));
                }
            }
        }

        static void Destroy(int attackRow, int attackCol, int radius)
        {
            int highestRow = attackRow - radius;
            int lowestRow = attackRow + radius;
            int leftMostCol = attackCol - radius;
            int rightMostCol = attackCol + radius;

            /*
            if (attackRow < 0 || attackRow >= rows || attackCol < 0 || attackCol >= cols)
            {
                return;
            }
            */

            for (int col = attackCol; col >= Math.Max(0, leftMostCol); col--)
            {
                if(attackRow >= 0 && attackRow < rows)
                {
                    matrix[attackRow, col] = -1;
                }
                
            }

            for (int col = attackCol; col <= Math.Min(cols - 1, rightMostCol); col++)
            {
                if (attackRow >= 0 && attackRow < rows)
                {
                    matrix[attackRow, col] = -1;
                }
                
            }

            for (int row = attackRow; row >= Math.Max(0, highestRow); row--)
            {
                if (attackCol >= 0 && attackCol < cols)
                {
                    matrix[row, attackCol] = -1;
                }
                
            }

            for (int row = attackRow + 1; row <= Math.Min(rows - 1, lowestRow); row++)
            {
                if (attackCol >= 0 && attackCol < cols)
                {
                    matrix[row, attackCol] = -1;
                }
                
            }

        }

        static void MoveElements()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int currentElement;
                    int currentCol = col;
                    bool isEmpty = true;

                    while (currentCol <= cols - 1)
                    {
                        currentElement = matrix[row, currentCol];

                        if (currentElement != -1)
                        {
                            isEmpty = false;
                            break;
                        }
                        currentCol++;
                    }

                    if (!isEmpty)
                    {
                        int temp = matrix[row, col]; // is always null
                        matrix[row, col] = matrix[row, currentCol];
                        matrix[row, currentCol] = temp;
                    }
                }
            }
        }
    }
}
