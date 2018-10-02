using System;
using System.Collections.Generic;

namespace _05.RubiksMatrix
{
    class Program
    {
        static int rows;
        static int cols;
        static int[,] matrix;
        static Dictionary<int, int[]> cellData = new Dictionary<int, int[]>();

        static void Main()
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            rows = int.Parse(sizes[0]);
            cols = int.Parse(sizes[1]);
            matrix = new int[rows, cols];

            FillMatrix();
            RotateCube();
            Swap();
        }

        static void FillMatrix()
        {
            int num = 1;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = num;
                    num++;
                    cellData.Add(num, new int[] { row, col } );
                    cellData[num][0] = row;
                    cellData[num][1] = col;
                }
            }
        }

        static void PrintMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        static void RotateCube()
        {
            int commandCount = int.Parse(Console.ReadLine());

            for (int cnt = 1; cnt <= commandCount; cnt++)
            {
                var input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int col = -1;
                int row = -1;
                string direction = tokens[1];
                int moves = int.Parse(tokens[2]);
                int rotations = 0;

                if(direction == "left")
                {
                    row = int.Parse(tokens[0]);
                    rotations = moves % cols;
                    RotateToLeft(row, rotations);
                }
                else if(direction == "right")
                {
                    row = int.Parse(tokens[0]);
                    rotations = moves % cols;
                    RotateToRight(row, rotations);
                }
                else if(direction == "up")
                {
                    col = int.Parse(tokens[0]);
                    rotations = moves % rows;
                    RotateToUp(col, rotations);
                }
                else if(direction == "down")
                {
                    col = int.Parse(tokens[0]);
                    rotations = moves % rows;
                    RotateToDown(col, rotations);
                }
            }
        }

        static void RotateToLeft(int row, int rotations)
        {
            var queue = new Queue<int>();

            for(int col = 0; col < cols; col++)
            {
                queue.Enqueue(matrix[row, col]);
            }

            while(rotations > 0)
            {
                int element = queue.Dequeue();
                queue.Enqueue(element);
                rotations--;
            }

            for (int col = 0; col < cols; col++)
            {
                int element = queue.Dequeue();
                matrix[row, col] = element;

                cellData[element] = new int[2] { row, col };
            }

        }

        static void RotateToRight(int row, int rotations)
        {
            var queue = new Queue<int>();

            for (int col = cols - 1; col >= 0; col--)
            {
                queue.Enqueue(matrix[row, col]);
            }
            
            while (rotations > 0)
            {
                int element = queue.Dequeue();
                queue.Enqueue(element);
                rotations--;
            }

            for (int col = cols - 1; col >= 0; col--)
            {
                int element = queue.Dequeue();
                matrix[row, col] = element;

                cellData[element] = new int[2] { row, col };
            }
        }

        static void RotateToDown(int col, int rotations)
        {
            var queue = new Queue<int>();

            for (int row = rows - 1; row >= 0; row--)
            {
                queue.Enqueue(matrix[row, col]);
            }

            while(rotations > 0)
            {
                int element = queue.Dequeue();
                queue.Enqueue(element);
                rotations--;
            }

            for (int row = rows - 1; row >= 0; row--)
            {
                int element = queue.Dequeue();
                matrix[row, col] = element;

                cellData[element] = new int[2] { row, col };
            }
        }

        static void RotateToUp(int col, int rotations)
        {
            var queue = new Queue<int>();

            for (int row = 0; row < rows; row++)
            {
                queue.Enqueue(matrix[row, col]);
            }

            while (rotations > 0)
            {
                int element = queue.Dequeue();
                queue.Enqueue(element);
                rotations--;
            }

            for (int row = 0; row < rows; row++)
            {
                int element = queue.Dequeue();
                matrix[row, col] = element;

                cellData[element] = new int[2] { row, col };
            }
        }

        static void Swap()
        {
            int num = 1;
            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < cols; col++)
                {
                    if(num == matrix[row, col])
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        int moveToRow = cellData[num][0];
                        int moveToCol = cellData[num][1];
                        int toMove = matrix[row, col];
                        int current = matrix[moveToRow, moveToCol];
                        
                        matrix[row, col] = matrix[moveToRow, moveToCol];
                        matrix[moveToRow, moveToCol] = toMove;
                        Console.WriteLine($"Swap ({row}, {col}) with ({moveToRow}, {moveToCol})");
                        
                        cellData[current] = new int[] { row, col };
                        cellData[toMove] = new int[] { moveToRow, moveToCol };
                    }
                    num++;
                }
            }
        }
    }
}
