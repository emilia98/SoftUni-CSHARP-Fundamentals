using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var tokens = Regex.Split(input, @"\s+");

            var expression = new Stack<string>();

            for(int index = tokens.Length -1; index >=0; index--)
            {
                expression.Push(tokens[index]);
            }

            while(expression.Count > 1)
            {
                int numA = int.Parse(expression.Pop());
                string sign = expression.Pop();
                int numB = int.Parse(expression.Pop());
                int result = 0;

                if(sign == "+")
                {
                    result = numA + numB;
                }
                else if(sign == "-")
                {
                    result = numA - numB;
                }

                expression.Push(result.ToString());
            }

            Console.WriteLine(expression.Pop());
        }
    }
}
