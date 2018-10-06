using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.RadioactiveBunnies
{
    class RadioactiveBunnies
    {
        static int rows;
        static int cols;
        static char[][] grid;
        static char[] directions;
        static int player_row;
        static int player_col;

        static void Main()
        {
            var sizes = Console.ReadLine()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            rows = int.Parse(sizes[0]);
            cols = int.Parse(sizes[1]);
            grid = new char[rows][];

            FillGrid();
            directions = Console.ReadLine()
                                .ToCharArray();
            Play();
        }

        static void FillGrid()
        {
            bool hasFoundPlayer = false;

            for (int row = 0; row < rows; row++)
            {
                grid[row] = Console.ReadLine().ToCharArray();

                if (!hasFoundPlayer)
                {
                    for (int col = 0; col < grid[row].Length; col++)
                    {
                        if (grid[row][col] == 'P')
                        {
                            player_row = row;
                            player_col = col;
                            hasFoundPlayer = true;
                            break;
                        }
                    }
                }
            }
        }

        static void Play()
        {
            int directionsCount = directions.Length;
            bool hasWon = false;
            bool hasDied = false;

            for (int index = 0; index < directionsCount; index++)
            {
                char direction = directions[index];

                switch (direction)
                {
                    case 'L':
                        {
                            // col - 1
                            bool insideGrid = MoveLeft();
                           
                            if(insideGrid == false)
                            {
                                hasWon = true;
                                break;
                            }

                            // Make Previous position a '.'
                            grid[player_row][player_col + 1] = '.';

                            if (grid[player_row][player_col] == 'B')
                            {
                                hasDied = true;
                                break;
                            }

                            grid[player_row][player_col] = 'P';

                            break;
                        }
                    case 'R':
                        {
                            // col + 1
                            bool insideGrid = MoveRight();

                            if (insideGrid == false)
                            {
                                hasWon = true;
                                break;
                            }

                            // Make Previous position a '.'
                            grid[player_row][player_col - 1] = '.';

                            if (grid[player_row][player_col] == 'B')
                            {
                                hasDied = true;
                                break;
                            }

                            grid[player_row][player_col] = 'P';
                            break;
                        }

                    case 'U':
                        {
                            // row - 1
                            bool insideGrid = MoveUp();

                            if (insideGrid == false)
                            {
                                hasWon = true;
                                break;
                            }

                            // Make Previous position a '.'
                            grid[player_row + 1][player_col] = '.';

                            if (grid[player_row][player_col] == 'B')
                            {
                                hasDied = true;
                                break;
                            }

                            grid[player_row][player_col] = 'P';
                            break;
                        }
                    case 'D':
                        {
                            // row + 1
                            bool insideGrid = MoveDown();

                            if (insideGrid == false)
                            {
                                hasWon = true;
                                break;
                            }

                            // Make Previous position a '.'
                            grid[player_row - 1][player_col] = '.';

                            if (grid[player_row][player_col] == 'B')
                            {
                                hasDied = true;
                                break;
                            }
                            
                            grid[player_row][player_col] = 'P';
                            break;
                        }
                }
                
                if (hasWon)
                {
                    grid[player_row][player_col] = '.';
                    HadRemovedPlayer();
                    Print();
                    Console.WriteLine($"won: {player_row} {player_col}");
                    break;
                }

                if(hasDied)
                {
                    HadRemovedPlayer();
                    Print();
                    Console.WriteLine($"dead: {player_row} {player_col}");
                    break;
                }

                bool removedPlayer = HadRemovedPlayer();
                if(removedPlayer)
                {
                    Print();
                    Console.WriteLine($"dead: {player_row} {player_col}");
                    break;
                }
            }
        }

        static bool HadRemovedPlayer()
        {
            var coordinatesWithBunnies = new List<int[]>();
            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < cols; col++)
                {
                    if(grid[row][col] == 'B')
                    {
                        coordinatesWithBunnies.Add(new int[] { row, col });
                    }
                }
            }

            bool hadKilled = false;

            /* HAD ERROR: 
             * -> SHOULD NOT HAVE RETURNED TRUE, 
             *    BEFORE FILLING ALL NEEDED CELLS WITH BUNNIES
             
             */
            foreach(var coordinates in coordinatesWithBunnies)
            {
                int row = coordinates[0];
                int col = coordinates[1];

                if (IsInGrid(row + 1, col))
                {
                    if (HadKilledPlayer(row + 1, col))
                    {
                        // return true;
                        hadKilled = true;
                    }
                }

                if (IsInGrid(row - 1, col))
                {
                    if (HadKilledPlayer(row - 1, col))
                    {
                        // return true;
                        hadKilled = true;
                    }
                }

                if (IsInGrid(row, col + 1))
                {
                    if (HadKilledPlayer(row, col + 1))
                    {
                        // return true;
                        hadKilled = true;
                    }
                }

                if (IsInGrid(row, col - 1))
                {
                    if (HadKilledPlayer(row, col - 1))
                    {
                        // return true;
                        hadKilled = true;
                    }
                }
            }
            return hadKilled;
        }

        static bool HadKilledPlayer(int row, int col)
        {
            if (grid[row][col] == 'P')
            {
                grid[row][col] = 'B';
                return true;
            }
            grid[row][col] = 'B';
            return false;
        }

        static bool MoveLeft()
        {
            if (IsInGrid(player_row, player_col - 1))
            {
                player_col -= 1;
                return true;
            }
            return false;
        }

        static bool MoveRight()
        {
            if (IsInGrid(player_row, player_col + 1))
            {
                player_col += 1;
                return true;
            }
            return false;
        }

        static bool MoveUp()
        {
            if(IsInGrid(player_row - 1, player_col))
            {
                player_row -= 1;
                return true;
            }
            return false;
        }

        static bool MoveDown()
        {
            if (IsInGrid(player_row + 1, player_col))
            {
                player_row += 1;
                return true;
            }
            return false;
        }

        static bool IsInGrid(int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
            {
                return false;
            }
            return true;
        }

        static void Print()
        {
            foreach(var line in grid)
            {
                Console.WriteLine(String.Join("", line));
            }
        }
    }
}