using System;

namespace _02.Monopoly
{
    class Monopoly
    {
        static int rows;
        static int cols;
        static char[,] grid;
        static int money = 50;
        static int turns = 0;
        static int totalHotels = 0;

        static void Main()
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ' },
                                                 StringSplitOptions.RemoveEmptyEntries);
            rows = int.Parse(sizes[0]);
            cols = int.Parse(sizes[1]);
            grid = new char[rows, cols];

            for(int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                for(int col = 0; col < cols; col++)
                {
                    grid[row, col] = input[col];
                }
            }

            for(int row = 0; row < rows; row++)
            {
                if(row % 2 == 0)
                {
                    MoveToRight(row);
                }
                else
                {
                    MoveToLeft(row);
                   
                }
            }

            PrintResult();
        }

        static void MoveToRight(int row)
        {
            for(int col = 0; col < cols; col++)
            {
                Play(row, col);
            }
        }

        static void MoveToLeft(int row)
        {
            for(int col = cols - 1; col >= 0; col--)
            {
                Play(row, col);
            }
        }

        static void Play(int row, int col)
        {
            char cell = grid[row, col];

            if(cell == 'H')
            {
                totalHotels++;
                Console.WriteLine($"Bought a hotel for {money}. Total hotels: {totalHotels}.");
                money = 0;
            }
            else if(cell == 'J')
            {
                Console.WriteLine($"Gone to jail at turn {turns}.");
                money += totalHotels * 10;
                money += totalHotels * 10;
                turns += 2;
            }
            else if(cell == 'S')
            {
                int toSpend = Math.Min(money, (row + 1) * (col + 1));
                Console.WriteLine($"Spent {toSpend} money at the shop.");
                money -= toSpend;
            } 
            else if(cell == 'F')
            {
            }

            money += totalHotels * 10;
            turns++;
        }

        static void PrintResult()
        {
            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {money}");
        }
    }
}