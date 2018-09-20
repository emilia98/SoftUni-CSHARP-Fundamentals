using System;
using System.Collections.Generic;

namespace _01.ReverseStrings_2
{
    class ReverseStrings_2
    {
        static void Main()
        {
            Stack<char> reversed = new Stack<char>();
            string input = Console.ReadLine();

            for (int index = 0; index < input.Length; index++)
            {
                reversed.Push(input[index]);
            }

            while(reversed.Count > 0)
            {
                Console.Write(reversed.Pop());
            }

            Console.WriteLine();
        }
    }
}
