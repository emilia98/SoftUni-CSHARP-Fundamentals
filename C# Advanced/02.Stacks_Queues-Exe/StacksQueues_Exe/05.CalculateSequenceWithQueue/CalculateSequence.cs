using System;
using System.Collections.Generic;

namespace _05.CalculateSequenceWithQueue
{
    class CalculateSequence
    {
        static void Main()
        {
            double n = double.Parse(Console.ReadLine());
            var seq = new List<double>();
            var members = new Queue<double>();

            int memberCounter = 1;

            seq.Add(n);
            members.Enqueue(n);

            while (memberCounter < 50)
            {
                memberCounter++;

                double s_i = members.Peek();
                int reminder = memberCounter % 3;

                if (reminder == 2)
                {
                    double expression = s_i + 1;
                    seq.Add(expression);
                    members.Enqueue(expression);
                    continue;
                }

                if (reminder == 0)
                {
                    double expression = 2 * s_i + 1;
                    seq.Add(expression);
                    members.Enqueue(expression);
                    continue;
                }

                if (reminder == 1)
                {
                    double expression = s_i + 2;
                    seq.Add(expression);
                    members.Enqueue(expression);
                    members.Dequeue();
                }
            }

            Console.WriteLine(String.Join(' ', seq));
        }
    }
}
