using System;
using System.Collections.Generic;

namespace _03.PeriodicTable_2
{
    class PeriodicTable_2
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var elements = new SortedSet<string>();

            for (int cnt = 1; cnt <= n; cnt++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' },
                                                     StringSplitOptions.RemoveEmptyEntries);

                for (int index = 0; index < input.Length; index++)
                {
                    elements.Add(input[index]);
                }
            }
            Console.WriteLine(String.Join(" ", elements));
        }
    }
}