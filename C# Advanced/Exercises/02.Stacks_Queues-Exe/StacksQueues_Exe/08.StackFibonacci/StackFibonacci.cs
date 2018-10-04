using System;
using System.Collections.Generic;

namespace _08.StackFibonacci
{
    class StackFibonacci
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var fibSeq = new Stack<double>();
            int memberCounter = 1;

            fibSeq.Push(0);
            
            if (n >= 1)
            {
                fibSeq.Push(1);
            }
            
            while(memberCounter < n)
            {
                double prev = fibSeq.Pop();
                double morePrev = fibSeq.Pop();
                double next = prev + morePrev;

                fibSeq.Push(morePrev);
                fibSeq.Push(prev);
                fibSeq.Push(next);
                memberCounter++;
            }

            Console.WriteLine(fibSeq.Pop());
        }
    }
}
