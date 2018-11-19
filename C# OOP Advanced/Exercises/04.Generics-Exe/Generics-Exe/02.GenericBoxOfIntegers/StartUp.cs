using System;

namespace _02.GenericBoxOfIntegers
{
    public class StartUp
    {
        static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());

            for(int cnt = 1; cnt <= linesCount; cnt++)
            {
                int value = int.Parse(Console.ReadLine());

                var box = new Box<int>(value);
                Console.WriteLine(box);
            }
        }
    }
}