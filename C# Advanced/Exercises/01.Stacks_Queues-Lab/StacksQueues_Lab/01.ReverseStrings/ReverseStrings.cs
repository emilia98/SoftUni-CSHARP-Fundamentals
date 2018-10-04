using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    class ReverseStrings
    {
        static void Main()
        {
            Stack<char> reversed = new Stack<char>();
            string input = Console.ReadLine();

            for (int index = 0; index < input.Length; index++)
            {
                reversed.Push(input[index]);
            }

            Console.WriteLine(String.Join("", reversed.ToArray()));
        }
    }
}
