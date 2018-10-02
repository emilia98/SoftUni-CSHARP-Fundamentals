using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Crossfire
{
    class Program
    {
        static long rows;
        static long cols;
        static string[,] matrix;

        static void Main()
        {
            var sizes = Console.ReadLine()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(long.Parse)
                               .ToArray();
            matrix = new string[sizes[0], sizes[1]];
            rows = sizes[0];
            cols = sizes[1];
            
            for (long row = 0; row < rows; row++)
            {
                for(long col = 0; col < cols; col++)
                {
                    matrix[row, col] = ((row * 1) * cols + (col + 1)).ToString();
                }
            }

            string command = Console.ReadLine();

            while(command != "Nuke it from orbit")
            {
                var tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                long attackRow = long.Parse(tokens[0]);
                long attackCol = long.Parse(tokens[1]);
                long radius = long.Parse(tokens[2]);

                Destroy(attackRow, attackCol, radius);
                MoveElements();
                command = Console.ReadLine();
            }


            for (long row = 0; row < rows; row++)
            {
                var list = new List<string>();
                for (long col = 0; col < cols; col++)
                {
                    //if (matrix[row, col] != null)
                    //{
                        list.Add(matrix[row, col]);
                    //}
                    
                }

                //if(list.Count > 0)
                //{
                    Console.WriteLine(String.Join(" ", list));
                //}
            }
        }
        
        static void Destroy(long attackRow, long attackCol, long radius)
        {
            long highestRow = attackRow - radius;
            long lowestRow = attackRow + radius;
            long leftMostCol = attackCol - radius;
            long rightMostCol = attackCol + radius;
            
            if(attackRow < 0 || attackRow >= rows || attackCol < 0 || attackCol >= cols)
            {
                return;
            }

            for (long col = attackCol; col >= Math.Max(0, leftMostCol); col--)
            {
                matrix[attackRow, col] = null;
            }

            for (long col = attackCol + 1; col <= Math.Min(cols - 1, rightMostCol); col++)
            {
                matrix[attackRow, col] = null;
            }

            for (long row = attackRow; row >= Math.Max(0, highestRow); row--)
            {
                matrix[row, attackCol] = null;
            }

            for (long row = attackRow + 1; row <= Math.Min(rows - 1, lowestRow); row++)
            {
                matrix[row, attackCol] = null;
            }

        }

        static void MoveElements()
        {
            for(long row = 0; row < rows; row++)
            {
                for (long col = 0; col < cols; col++)
                {
                    string currentElement;
                    long currentCol = col;
                    bool hasFoundNonNullable = false;

                    while (currentCol <= cols - 1)
                    {
                        currentElement = matrix[row, currentCol];

                        if(currentElement != null)
                        {
                            hasFoundNonNullable = true;
                            break;
                        }
                        currentCol++;
                    }

                    if(hasFoundNonNullable)
                    {
                        string temp = matrix[row, col]; // is always null
                        
                        matrix[row, col] = matrix[row, currentCol];
                        matrix[row, currentCol] = temp;
                        Console.WriteLine(String.ReferenceEquals(temp, matrix[row, currentCol]));
                    }
                }
            }
        }
    }
}
