using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable_3
{
    class PeriodicTable_3
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var elements = new List<string>();

            for (int cnt = 1; cnt <= n; cnt++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' },
                                                     StringSplitOptions.RemoveEmptyEntries);

                for (int index = 0; index < input.Length; index++)
                {
                    if(elements.Contains(input[index]) == false)
                    {
                        elements.Add(input[index]);
                    }
                }
            }
            Console.WriteLine(String.Join(" ", elements.OrderBy(x => x)));
        }
    }
}