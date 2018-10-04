using System;
using System.Linq;

namespace _01.BunkerBuster
{
    class BunkerBuster
    {
        static int rows;
        static int cols;
        static int[][] grid;
        static int destroyed = 0;

        static void Main()
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            rows = int.Parse(sizes[0]);
            cols = int.Parse(sizes[1]);
            grid = new int[rows][];

            for(int row = 0; row < rows; row++)
            {
                grid[row] = Console.ReadLine()
                                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray(); 
            }

            string input = Console.ReadLine();


            while(input != "cease fire!")
            {
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int impactRow = int.Parse(tokens[0]);
                int impactCol = int.Parse(tokens[1]);
                int power = (int)tokens[2][0];

                Bomb(impactRow, impactCol, power);
                input = Console.ReadLine();
            }

            /* HAD ERROR: The error was in rounding
             * -> damagePercent - should be double number
             * -> should not use Math.Round() // NOT CORRECT: Math.Round(destroyed * 100m / totalCells, 1)
             */
            int totalCells = rows * cols;
            var damagePercent = destroyed * 100.0 / totalCells;
            Console.WriteLine($"Destroyed bunkers: {destroyed}");
            Console.WriteLine($"Damage done: {damagePercent:f1} %");
        }

        static void Bomb(int impactRow, int impactCol, int power)
        {
            int halfPower = (int)Math.Ceiling(power / 2.0);

            for(int row = impactRow - 1; row <= impactRow + 1; row++)
            {
                for (int col = impactCol - 1; col <= impactCol + 1; col++)
                {
                    if (IsInMatrix(row, col) == false)
                    {
                        continue;
                    }

                    if (grid[row][col] <= 0)
                    {
                        continue;
                    }

                    if(row == impactRow && col == impactCol)
                    {
                        grid[row][col] -= power;
                    }
                    else
                    {
                        grid[row][col] -= halfPower;
                    }

                    if(grid[row][col] <= 0)
                    {
                        destroyed++;
                    }
                }
            }
        }

        static bool IsInMatrix(int row, int col)
        {
            if(row < 0 || row >= rows || col < 0 || col >= cols)
            {
                return false;
            }
            return true;
        }
    }
}