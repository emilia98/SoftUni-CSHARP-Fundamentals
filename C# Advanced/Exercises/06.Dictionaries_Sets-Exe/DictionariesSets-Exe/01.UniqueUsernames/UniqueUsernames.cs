using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var uniqueNames = new HashSet<string>();

            for (int cnt = 1; cnt <= n; cnt++)
            {
                string name = Console.ReadLine();
                uniqueNames.Add(name);
            }

            foreach (var name in uniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
