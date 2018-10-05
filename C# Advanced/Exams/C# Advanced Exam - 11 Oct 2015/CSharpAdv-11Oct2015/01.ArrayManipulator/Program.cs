using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
                               .Split(new char[] { ' ' },
                                      StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            string command = Console.ReadLine();

            int maxEven = int.MinValue;
            int maxOdd = int.MinValue;
            var evens = new List<int>();
            var odds = new List<int>();

            for (int index = 0; index < array.Length; index++)
            {
                int current = command[index];

                if (current % 2 == 0)
                {
                    evens.Add(current);

                    if (current > maxEven)
                    {
                        maxEven = current;
                    }
                }
                else
                {
                    odds.Add(current);

                    if (current > maxOdd)
                    {
                        maxOdd = current;
                    }
                }
            }

            while (command != "end")
            {
                var tokens = command.Split(new char[] { ' ' },
                                           StringSplitOptions.RemoveEmptyEntries);
                string commandName = tokens[0];

                switch (commandName)
                {
                    case "exchange":
                        break;
                    case "max":
                        string type = tokens[1];
                        break;

                }

                command = Console.ReadLine();
            }

        }
    }
}
