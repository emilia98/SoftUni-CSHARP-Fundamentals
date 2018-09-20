using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    class MatchingBrackets
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var opened = new Stack<int>();

            for(int index = 0; index < input.Length; index++)
            {
                char currentChar = input[index];

                if(currentChar == '(')
                {
                    opened.Push(index);
                } 
                else if(currentChar == ')')
                {
                    int openedIndex = opened.Pop();
                    Console.WriteLine(input.Substring(openedIndex, index - openedIndex + 1));
                }
            }
        }
    }
}
