using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy
{
    public class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int[] tokens = input.Split(", ")
                                .Select(int.Parse)
                                .ToArray();

            Lake lake = new Lake(tokens);
            var stones = new List<int>();

            foreach(var stone in lake)
            {
                stones.Add(stone);
            }

            Console.WriteLine(String.Join(", ", stones));
        }
    }
}