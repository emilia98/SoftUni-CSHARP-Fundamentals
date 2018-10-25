using System;

namespace _01.RhombusOfStars_3
{
    class RhombusOfStars_3
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int line = 1; line <= n; line++)
            {
                PrintRow(n, line);
            }

            for (int line = n - 1; line >= 1; line--)
            {
                PrintRow(n, line);
            }
        }

        static void PrintRow(int figuresCount, int starsCount)
        {
            for(int index = 0; index < figuresCount - starsCount; index++)
            {
                Console.Write(" ");
            }
            
            for(int cnt = 1; cnt < starsCount; cnt++)
            {
                Console.Write("* ");
            }
            Console.WriteLine("*");
        }
    }
}