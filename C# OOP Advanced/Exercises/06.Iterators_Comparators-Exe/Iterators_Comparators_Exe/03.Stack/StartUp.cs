using System;
using System.Linq;

namespace CustomStack
{
    public class StartUp
    {
        public static IStack<int> stack;
        static void Main()
        {
            string command = Console.ReadLine();
            stack = new Stack<int>();

            while (command != "END")
            {
                var tokens = command.Split(" ").ToArray();
                string commandType = tokens[0];

                if (commandType == "Push")
                {
                    var pushable = String.Join("", tokens.Skip(1));
                    int[] items = pushable.Split(new char[] { ',', ' ' })
                                          .ToArray()
                                          .Select(int.Parse)
                                          .ToArray();
                    stack.Push(items);
                }
                else if (commandType == "Pop")
                {
                    stack.Pop();
                }
                command = Console.ReadLine();
            }

            PrintStack();
            PrintStack();
        }

        static void PrintStack()
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
