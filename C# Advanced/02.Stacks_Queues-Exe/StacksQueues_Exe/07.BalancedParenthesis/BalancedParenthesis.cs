using System;
using System.Collections.Generic;

namespace _07.BalancedParenthesis
{
    class BalancedParenthesis
    {
        static void Main()
        {
            string expr = Console.ReadLine();

            bool result = isBalanced(expr);

            if (result)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        public static bool isBalanced(string s)
        {
            var opened = new Stack<char>();
            bool balanced = true;

            if (s.Length % 2 == 1)
            {
                return false;
            }

            for (int index = 0; index < s.Length; index++)
            {
                var ch = s[index];
                char? lastChar = null;

                if (opened.Count > 0)
                {
                    lastChar = opened.Peek();
                }

                if (ch == '(' || ch == '[' || ch == '{')
                {
                    opened.Push(ch);
                    continue;
                }

                if (ch == '}')
                {
                    if (lastChar == '{')
                    {
                        opened.Pop();
                    }
                    else
                    {
                        balanced = false;
                        break;
                    }
                    continue;
                }

                if (ch == ')')
                {
                    if (lastChar == '(')
                    {
                        opened.Pop();
                    }
                    else
                    {
                        balanced = false;
                        break;
                    }
                    continue;
                }

                if (ch == ']')
                {
                    if (lastChar == '[')
                    {
                        opened.Pop();
                    }
                    else
                    {
                        balanced = false;
                        break;
                    }
                    continue;
                }
            }

            if (opened.Count > 0)
            {
                balanced = false;
            }
            return balanced;
        }
    }
}
