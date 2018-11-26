using System;
using System.Collections.Generic;
using System.Linq;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            var cupsCap = Console.ReadLine().Split(new char[] { ' ' },
                                                   StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();
            var bottlesValues = Console.ReadLine().Split(new char[] { ' ' }, 
                                                   StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(int.Parse).ToArray();

            // var cups = new Queue<int>(cupsCap);
            var bottles = new Stack<int>(bottlesValues);
            var cups = new Stack<int>(cupsCap.Reverse());

            int cupsCount = cups.Count();
            int bottlesCount = bottles.Count();
            int wastedWater = 0;
            bool hasFilledAllCups = false;

            while(cupsCount > 0 && bottlesCount > 0)
            {
                int currentCup = cups.Pop();
                int currentBottle = bottles.Pop();
                bottlesCount--;
                cupsCount--;
                if (currentBottle >= currentCup)
                {
                    int diff = currentBottle - currentCup;
                    wastedWater += diff;
                }
                else
                {
                    currentCup -= currentBottle;
                    cups.Push(currentCup);
                    cupsCount++;
                }

                if(cupsCount == 0)
                {
                    hasFilledAllCups = true;
                    break;
                }
            }

            if (hasFilledAllCups)
            {
                Console.WriteLine($"Bottles: {String.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {String.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
