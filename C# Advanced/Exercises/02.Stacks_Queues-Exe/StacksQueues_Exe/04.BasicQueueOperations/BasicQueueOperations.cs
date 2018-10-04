using System;
using System.Collections.Generic;

namespace _04.BasicQueueOperations
{
    class BasicQueueOperations
    {
        static Queue<int> queue = new Queue<int>();

        static void Main()
        {
            var commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(commands[0]);
            int s = int.Parse(commands[1]);
            int x = int.Parse(commands[2]);

            AddElements(tokens, n);
            RemoveElements(s);

            var result = GetResult(x);
            bool hasResult = result.Item1;
            int min = result.Item2;

            if(hasResult)
            {
                Console.WriteLine("true");
                return;
            }

            Console.WriteLine(min);
        }

        static void AddElements(string[] tokens, int n)
        {
            for(int cnt = 1; cnt <= n; cnt++)
            {
                queue.Enqueue(int.Parse(tokens[cnt - 1]));
            }
        }

        static void RemoveElements(int s)
        {
            int removed = 1;

            while(removed <= s)
            {
                queue.Dequeue();
                removed++;
            }
        }

        static Tuple<bool, int> GetResult(int x)
        {
            bool hasResult = false;
            int min = int.MaxValue;
            var asArray = queue.ToArray();

            for (int index = 0; index < asArray.Length; index++)
            {
                int element = asArray[index];

                if(element == x)
                {
                    hasResult = true;
                    break;
                }

                if (element < min)
                {
                    min = element;
                }
            }

            if (queue.Count == 0)
            {
                min = 0;
            }

            return new Tuple<bool, int>(hasResult, min);
        }
    }
}
