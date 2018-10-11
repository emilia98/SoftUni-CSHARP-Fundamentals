using System;

namespace _02.Sneaking
{
    class Sneaking
    {
        static int rows;
        static char[][] matrix;
        static int sam_row = -1;
        static int sam_col = -1;
        static int niko_row = -1;
        static int niko_col = -1;
        static bool isNikoDead = false;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            rows = n;
            matrix = new char[rows][];

            for(int row = 0; row < rows; row++)
            {
                var charsLine = Console.ReadLine();
                matrix[row] = new char[charsLine.Length];

                for(int col = 0; col < charsLine.Length; col++)
                {
                    if (charsLine[col] == 'S')
                    {
                        sam_row = row;
                        sam_col = col;
                    }
                    else if(charsLine[col] == 'N')
                    {
                        niko_row = row;
                        niko_col = col;
                    }
                    matrix[row][col] = charsLine[col];
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();

            for(int index = 0; index < directions.Length; index++)
            {
                char direction = directions[index];

                bool moveAndSearch = MoveAllEnemies();

                if (moveAndSearch == false)
                {
                    Console.WriteLine($"Sam died at {sam_row}, {sam_col}");
                    PrintMatrix();
                    break;
                }

                MoveSam(direction);

                if(isNikoDead)
                {
                    Console.WriteLine("Nikoladze killed!");
                    PrintMatrix();
                    return;
                }
            }
        }

        static void PrintMatrix()
        {
            for(int row = 0; row < rows; row++)
            {
                Console.WriteLine(String.Join("", matrix[row]));
            }
        }

        static bool MoveAllEnemies()
        {
            bool isSamAlive = true;
            for(int row = 0; row < rows; row++)
            {
                int cols = matrix[row].Length;

                for (int col = 0; col < cols; col++)
                {
                    bool isEnemy = false;
                    int enemyCol = -1;
                    char enemyChar = ' ';

                    if(matrix[row][col] == 'd')
                    {
                        if(col == 0)
                        {
                            matrix[row][col] = 'b';
                            enemyCol = col;
                            enemyChar = 'b';
                        }
                        else
                        {
                            matrix[row][col] = '.';
                            matrix[row][col - 1] = 'd';
                            enemyCol = col - 1;
                            enemyChar = 'd';
                        }

                        isEnemy = true;
                    }
                    else if(matrix[row][col] == 'b')
                    {
                        if(col == cols - 1)
                        {
                            matrix[row][col] = 'd';
                            enemyCol = col;
                            enemyChar = 'd';
                        }
                        else
                        {
                            matrix[row][col] = '.';
                            matrix[row][col + 1] = 'b';
                            enemyCol = col + 1;
                            enemyChar = 'b';
                        }

                        isEnemy = true;
                    }

                    if(isEnemy)
                    {
                        bool isSam = CheckForSam(row, enemyCol, enemyChar);

                        if(isSam)
                        {
                            matrix[sam_row][sam_col] = 'X';
                            isSamAlive = false;
                        }
                        break;
                    }
                }
            }
            return isSamAlive;
        }

        static void MoveSam(char direction)
        {
            int prev_row = sam_row;
            int prev_col = sam_col;

            switch(direction)
            {
                case 'U':
                    {
                        sam_row--;
                        break;
                    }
                case 'D':
                    {
                        sam_row++;
                        break;
                    }
                case 'L':
                    {
                        sam_col--;
                        break;
                    }
                case 'R':
                    {
                        sam_col++;
                        break;
                    }
                case 'W':
                    {
                        break;
                    }
            }
            
            if (matrix[sam_row][sam_col] == 'b' || matrix[sam_row][sam_col] == 'd')
            {
                matrix[sam_row][sam_col] = 'S';
                matrix[prev_row][prev_col] = '.';
            }

            matrix[sam_row][sam_col] = 'S';
            matrix[prev_row][prev_col] = '.';
            
            // SHOULD I CHECK FOR ENEMY AND SAM AND THEIR POSITIONS
            // is possible for enemy to kill Sam?

            if (sam_row == niko_row)
            {
                matrix[niko_row][niko_col] = 'X';
                isNikoDead = true;
            }
        }

        static bool CheckForSam(int row, int col, char type)
        {
            if(type == 'd')
            {
                if(sam_row == row && sam_col <= col)
                {
                    return true;
                }
                return false;
            }

            if(type == 'b')
            {
                if(sam_row == row && sam_col >= col)
                {
                    return true;
                }

                return false;
            }

            return false;
        }
    }
}