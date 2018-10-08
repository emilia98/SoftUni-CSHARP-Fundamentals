using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
    class EvenTimes
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var numbersData = new Dictionary<int, int>();

            for (int cnt = 1; cnt <= n; cnt++)
            {
                int num = int.Parse(Console.ReadLine());

                if (numbersData.ContainsKey(num) == false)
                {
                    numbersData.Add(num, 0);
                }

                numbersData[num] = numbersData[num] + 1;
            }

            foreach (var numberInfo in numbersData)
            {
                int number = numberInfo.Key;
                int occurs = numberInfo.Value;

                if (occurs % 2 == 0)
                {
                    Console.WriteLine(number);
                    break;
                }
            }
        }
    }
}