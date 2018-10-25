using System;
using System.Text;

namespace _01.RhombusOfStars_2
{
    class RhombusOfStars_2
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
            StringBuilder result = new StringBuilder();
            int endIntervals = n - symbols;

            result.Append(new string(' ', endIntervals));

            StringBuilder main = new StringBuilder();
            for (int index = 1; index <= symbols; index++)
            {
                main.Append("* ");
            }

            result.Append(main.ToString().Trim());
            result.Append(new string(' ', endIntervals));
            Console.WriteLine(result.ToString());
        }
    }
}