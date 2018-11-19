using System;

namespace _01.GenericBoxOfStrings
{
    public class StartUp
    {
        static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());

            for(int cnt = 1; cnt <= linesCount; cnt++)
            {
                string value = Console.ReadLine();

                var box = new Box<string>(value);
                Console.WriteLine(box);
            }
        }
    }
}