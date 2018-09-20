using System;
using System.Collections.Generic;

namespace _03.DecimalToBinaryConverter_2
{
    class DecimalToBinaryConverter_2
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var binary = new Stack<int>();

            if (number == 0)
            {
                binary.Push(0);
            }

            while (number > 0)
            {
                int reminder = number % 2;
                number = (number - reminder) / 2;

                binary.Push(reminder);
            }

            while(binary.Count > 0)
            {
                Console.Write(binary.Pop());
            }

            Console.WriteLine();
        }
    }
}
