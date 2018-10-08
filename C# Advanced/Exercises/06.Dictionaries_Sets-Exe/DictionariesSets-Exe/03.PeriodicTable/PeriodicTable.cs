using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class PeriodicTable
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var elements = new HashSet<string>();

            for (int cnt = 1; cnt <= n; cnt++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, 
                                                     StringSplitOptions.RemoveEmptyEntries);

                for (int index = 0; index < input.Length; index++)
                {
                    elements.Add(input[index]);
                }
            }
            Console.WriteLine(String.Join(" ", elements.OrderBy(x => x).ToHashSet()));
        }
    }
}