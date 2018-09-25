using System;
using System.Collections.Generic;

namespace _01.ReverseNumbersWithStack
{
    class ReverseNumbers
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var tokens = input.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<int>();

            for(int index = 0; index < tokens.Length; index++)
            {
                stack.Push(int.Parse(tokens[index]));
            }

            Console.WriteLine(String.Join(' ', stack.ToArray()));
        }
    }
}
