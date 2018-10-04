using System;
using System.Collections.Generic;

namespace _01.CommandInterpreter
{
    class CommandInterpreter
    {
        static string[] array;

        static void Main()
        {
            array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = Console.ReadLine();

            while (command != "end")
            {
                var tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string commandName = tokens[0];
                
                int start;
                int count;

                switch (commandName)
                {
                    case "reverse":
                        start = int.Parse(tokens[2]);
                        count = int.Parse(tokens[4]);
                        Reverse(start, count);
                        break;
                    case "sort":
                        start = int.Parse(tokens[2]);
                        count = int.Parse(tokens[4]);
                        Sort(start, count);
                        break;
                    case "rollLeft":
                        count = int.Parse(tokens[1]);
                        RollLeft(count);
                        break;
                    case "rollRight":
                        count = int.Parse(tokens[1]);
                        RollRight(count);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("[" + String.Join(", ", array) + "]");
        }

        static void Reverse(int start, int count)
        {
            if (IsStartPositionInArray(start) == false)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            if (IsEndPositionInArray(start, count) == false)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            var toReverse = new List<string>();
            int endIndex = start + count - 1;

            for (int index = start; index <= endIndex; index++)
            {
                toReverse.Add(array[index]);
            }

            int arrayIndex = start;
            for (int index = count - 1; index >= 0; index--)
            {
                array[arrayIndex] = toReverse[index];
                arrayIndex++;
            }
        }

        static void Sort(int start, int count)
        {
            if (IsStartPositionInArray(start) == false)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            if (IsEndPositionInArray(start, count) == false)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            var toSort = new List<string>();
            int endIndex = start + count - 1;

            for (int index = start; index <= endIndex; index++)
            {
                toSort.Add(array[index]);
            }
            
            toSort.Sort((s1, s2) => s1.CompareTo(s2));

            int arrayIndex = start;
            for (int index = 0; index < count; index++)
            {
                array[arrayIndex] = toSort[index];
                arrayIndex++;
            }
        }

        static void RollLeft(int count)
        {
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }
            int rotations = count % array.Length;
            var queue = new Queue<string>();

            for (int index = 0; index < array.Length; index++)
            {
                queue.Enqueue(array[index]);
            }

            for (int cnt = 1; cnt <= rotations; cnt++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            for (int index = 0; index < array.Length; index++)
            {
                array[index] = queue.Dequeue();
            }
        }

        static void RollRight(int count)
        {
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            int rotations = count % array.Length;
            var queue = new Queue<string>();

            for(int index = array.Length - 1; index >= 0; index--)
            {
                queue.Enqueue(array[index]);
            }

            for (int cnt = 1; cnt <= rotations; cnt++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            for (int index = array.Length - 1; index >= 0; index--)
            {
                array[index] = queue.Dequeue();
            }
        }

        static bool IsStartPositionInArray(int start)
        {
            if (start >= 0 && start < array.Length)
            {
                return true;
            }
            return false;
        }

        static bool IsEndPositionInArray(int start, int count)
        {
            // ERROR WAS HERE:
            // start + count >= array.Length
            if (count < 0 || start + count > array.Length)
            {
                return false;
            }
            return true;
        }
    }
}
