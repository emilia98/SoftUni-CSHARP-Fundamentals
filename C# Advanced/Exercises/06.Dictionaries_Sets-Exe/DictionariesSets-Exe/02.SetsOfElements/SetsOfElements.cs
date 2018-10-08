using System;
using System.Collections.Generic;

namespace _02.SetsOfElements
{
    class SetsOfElements
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var set_1 = new HashSet<int>();
            var set_2 = new HashSet<int>();
            var common = new HashSet<int>();
            int n = int.Parse(nums[0]);
            int m = int.Parse(nums[1]);

            for (int cnt = 1; cnt <= n; cnt++)
            {
                int current = int.Parse(Console.ReadLine());
                set_1.Add(current);
            }

            for (int cnt = 1; cnt <= m; cnt++)
            {
                int current = int.Parse(Console.ReadLine());
                set_2.Add(current);
            }

            foreach (var element in set_1)
            {
                if (set_2.Contains(element))
                {
                    common.Add(element);
                }
            }

            Console.WriteLine(String.Join(" ", common));
        }
    }
}