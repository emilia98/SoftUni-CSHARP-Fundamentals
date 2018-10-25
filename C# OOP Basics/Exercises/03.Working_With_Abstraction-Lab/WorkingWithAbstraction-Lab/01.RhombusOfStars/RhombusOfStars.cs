using System;

namespace _01.RhombusOfStars
{
    class RhombusOfStars
    {
        static int n;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());

            for (int line = 1; line <= n; line++)
            {
                PrintRow(line);
            }

            for (int line = n - 1; line >= 1; line--)
            {
                PrintRow(line);
            }
        }

        static void PrintRow(int symbols)
        {
            int endIntervals = n - symbols;
            int index = 0;

            PrintIntervals(endIntervals);

            while (symbols > 0)
            {
                if (index % 2 == 0)
                {
                    Console.Write('*');
                    symbols--;
                }
                else
                {
                    Console.Write(' ');
                }

                index++;
            }

            PrintIntervals(endIntervals);
            Console.WriteLine();
        }

        static void PrintIntervals(int intervalsCount)
        {
            for (int cnt = 1; cnt <= intervalsCount; cnt++)
            {
                Console.Write(" ");
            }
        }
    }
}