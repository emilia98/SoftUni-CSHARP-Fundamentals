using System;
using System.Collections.Generic;

namespace _02.BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main()
        {
            var commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(commands[0]);
            int s = int.Parse(commands[1]);
            int x = int.Parse(commands[2]);

            var stack = new Stack<int>();   
            stack = PushElements(tokens, n);
            stack = RemoveElements(stack, s);

            var result = GetResult(stack, x);
            bool hasElement = result.Item1;
            int min = result.Item2;

            if(hasElement)
            {
                Console.WriteLine("true");
                return;
            }

            Console.WriteLine(min);
        }

        static Stack<int> PushElements(string[] tokens, int n)
        {
            var stack = new Stack<int>();

            for (int cnt = 1; cnt <= n; cnt++)
            {
                int element = int.Parse(tokens[cnt - 1]);
                stack.Push(element);
            }

            return stack;
        }

        static Stack<int> RemoveElements(Stack<int> stack, int s)
        {
            int popped = 1;

            while (popped <= s)
            {
                stack.Pop();
                popped++;
            }

            return stack;
        }

        static Tuple<bool, int> GetResult(Stack<int> stack, int x)
        {
            bool hasElement = false;
            int min = int.MaxValue;
            var asArray = stack.ToArray();

            for (int index = 0; index < asArray.Length; index++)
            {
                int element = asArray[index];

                if (element == x)
                {
                    hasElement = true;
                    continue;
                }

                if (element < min)
                {
                    min = element;
                }
            }

            if(stack.Count == 0)
            {
                min = 0;
            }

            return new Tuple<bool, int>(hasElement, min);
        }
    }
}
