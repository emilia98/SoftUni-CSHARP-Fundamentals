using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _05.HotPotato
{
    class HotPotato
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int tosses = int.Parse(Console.ReadLine());

            var tokens = Regex.Split(input, @"\s+");
            var players = new Queue<string>();

            for(int index = 0; index < tokens.Length; index++)
            {
                players.Enqueue(tokens[index]);
            }

            int round = 1;

            while(players.Count > 1)
            {
                string currentPlayer = players.Dequeue();

                if(round == tosses)
                {
                    Console.WriteLine("Removed {0}", currentPlayer);
                    round = 1;
                    continue;
                }

                round++;
                players.Enqueue(currentPlayer);
            }

            string last = players.Dequeue();
            Console.WriteLine($"Last is {last}");
        }
    }
}
