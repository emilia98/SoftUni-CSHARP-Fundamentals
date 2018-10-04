using System;
using System.Collections.Generic;

namespace _03.DecimalToBinaryConverter
{
    class DecimalToBinaryConverter
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var binary = new Stack<int>();

            if(number == 0)
            {
                binary.Push(0);
            }

            while (number > 0)
            {
                int reminder = number % 2;
                number = (number - reminder) / 2;

                binary.Push(reminder);
            }

            Console.WriteLine(String.Join("", binary));
        }
    }
}
