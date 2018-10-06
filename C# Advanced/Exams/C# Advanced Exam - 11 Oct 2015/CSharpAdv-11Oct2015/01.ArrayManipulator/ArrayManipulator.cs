using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ArrayManipulator
{
    class ArrayManipulator
    {
        static Dictionary<string, int> extremeValues = new Dictionary<string, int>();
        static List<int> evens = new List<int>();
        static List<int> odds = new List<int>();
        static int[] array;

        static void Main()
        {
            array = Console.ReadLine()
                               .Split(new char[] { ' ' },
                                      StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            string command = Console.ReadLine();

            extremeValues.Add("maxEven", int.MinValue);
            extremeValues.Add("maxOdd", int.MinValue);
            extremeValues.Add("indexMaxEven", -1);
            extremeValues.Add("indexMaxOdd", -1);

            extremeValues.Add("minEven", int.MaxValue);
            extremeValues.Add("minOdd", int.MaxValue);
            extremeValues.Add("indexMinEven", -1);
            extremeValues.Add("indexMinOdd", -1);

            ChangeValues();
           
            while (command != "end")
            {
                var tokens = command.Split(new char[] { ' ' },
                                           StringSplitOptions.RemoveEmptyEntries);
                string commandName = tokens[0];

                switch (commandName)
                {
                    case "exchange":
                        {
                            int index = int.Parse(tokens[1]);
                            Exchange(index);
                            break;
                        }
                    case "max":
                        {
                            string type = tokens[1];
                            PrintExtremeValues("max", type);
                            break;
                        }
                    case "min":
                        {
                            string type = tokens[1];
                            PrintExtremeValues("min", type);
                            break;
                        }
                    case "first":
                        {
                            int count = int.Parse(tokens[1]);
                            string type = tokens[2];
                            PrintFirstElements(count, type);
                            break;
                        }
                    case "last":
                        {
                            int count = int.Parse(tokens[1]);
                            string type = tokens[2];
                            PrintLastElements(count, type);
                            break;
                        }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", String.Join(", ", array));
        }

        static void ChangeValues()
        {
            evens = new List<int>();
            odds = new List<int>();

            for (int index = 0; index < array.Length; index++)
            {
                int current = array[index];

                if (current % 2 == 0)
                {
                    evens.Add(current);

                    if (current >= extremeValues["maxEven"])
                    {
                        extremeValues["maxEven"] = current;
                        extremeValues["indexMaxEven"] = index;
                    }

                    if (current <= extremeValues["minEven"])
                    {
                        extremeValues["minEven"] = current;
                        extremeValues["indexMinEven"] = index;
                    }

                }
                else
                {
                    odds.Add(current);

                    if (current >= extremeValues["maxOdd"])
                    {
                        extremeValues["maxOdd"] = current;
                        extremeValues["indexMaxOdd"] = index;
                    }

                    if (current <= extremeValues["minOdd"])
                    {
                        extremeValues["minOdd"] = current;
                        extremeValues["indexMinOdd"] = index;
                    }
                }
            }
        }

        static void Exchange(int index)
        {
            if(index < 0 || index >= array.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            var queue = new Queue<int>(array);
            
            for(int i = 1; i <= index + 1; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            array = queue.ToArray();
            ChangeValues();
        }

        static void PrintExtremeValues(string extremeType, string type)
        {
            if (type == "even")
            {
                if (evens.Count == 0)
                {
                    Console.WriteLine("No matches");
                    return;
                }

                if (extremeType == "max")
                {
                    Console.WriteLine(extremeValues["indexMaxEven"]);
                    return;
                }

                if (extremeType == "min")
                {
                    Console.WriteLine(extremeValues["indexMinEven"]);
                    return;
                }
            }
            else if (type == "odd")
            {
                if (odds.Count == 0)
                {
                    Console.WriteLine("No matches");
                    return;
                }

                if (extremeType == "max")
                {
                    Console.WriteLine(extremeValues["indexMaxOdd"]);
                    return;
                }

                if (extremeType == "min")
                {
                    Console.WriteLine(extremeValues["indexMinOdd"]);
                    return;
                }
            }
        }

        static void PrintFirstElements(int count, string type)
        {
            if(count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            var result = new List<int>();
            int evenElements = evens.Count;
            int oddElements = odds.Count;

            if (type == "even")
            {
                int index = 0;
                for (int counter = 0; counter < Math.Min(count, evenElements); counter++)
                {
                    result.Add(evens[counter]);
                    index++;
                }
            }
            else if(type == "odd")
            {
                int index = 0;
                for (int counter = 0; counter < Math.Min(count, oddElements); counter++)
                {
                    result.Add(odds[counter]);
                    index++;
                }
            }

            Console.WriteLine("[{0}]", String.Join(", ", result));
        }

        static void PrintLastElements(int count, string type)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            var result = new List<int>();
            int evenElements = evens.Count;
            int oddElements = odds.Count;


            if (type == "even")
            {
                int startIndex = evenElements - count;
                int endIndex = startIndex + count;
                for (int index = Math.Max(0, startIndex); index < Math.Min(endIndex, evenElements); index++)
                {
                    result.Add(evens[index]);
                }
            }
            else if (type == "odd")
            {
                int startIndex = oddElements - count;
                int endIndex = startIndex + count;
                for (int index = Math.Max(0, startIndex); index < Math.Min(endIndex, oddElements); index++)
                {
                    result.Add(odds[index]);
                }
            }

            Console.WriteLine("[{0}]", String.Join(", ", result));
        }
    }
}