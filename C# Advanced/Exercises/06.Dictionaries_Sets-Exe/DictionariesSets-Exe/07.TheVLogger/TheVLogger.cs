using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class TheVLogger
    {
        static Dictionary<string, Dictionary<string, List<string>>> vloggingData =
               new Dictionary<string, Dictionary<string, List<string>>>();

        static void Main()
        {
            string command = Console.ReadLine();

            while (command != "Statistics")
            {
                var tokens = command.Split(new char[] { ' ' },
                                           StringSplitOptions.RemoveEmptyEntries);
                string vloggerName = tokens[0];

                if (String.Join(" ", tokens.Skip(1)) == "joined The V-Logger")
                {
                    if (vloggingData.ContainsKey(vloggerName) == false)
                    {
                        vloggingData.Add(vloggerName, new Dictionary<string, List<string>>());
                        vloggingData[vloggerName].Add("followers", new List<string>());
                        vloggingData[vloggerName].Add("followings", new List<string>());
                    }
                }
                else if (tokens[1] == "followed")
                {
                    string toFollow = tokens[2];

                    Follow(vloggerName, toFollow);
                }
                command = Console.ReadLine();
            }

            PrintResult();
        }

        static void Follow(string firstVlogger, string secondVlogger)
        {
            if (firstVlogger == secondVlogger)
            {
                return;
            }

            if (vloggingData.ContainsKey(firstVlogger) == false ||
                vloggingData.ContainsKey(secondVlogger) == false)
            {
                return;
            }

            if (vloggingData[firstVlogger]["followings"].IndexOf(secondVlogger) > -1)
            {
                return;
            }

            vloggingData[firstVlogger]["followings"].Add(secondVlogger);
            vloggingData[secondVlogger]["followers"].Add(firstVlogger);
        }

        static void PrintResult()
        {
            var orderVloggers = vloggingData
               .OrderByDescending(x => x.Value["followers"].Count)
               .ThenBy(x => x.Value["followings"].Count)
               .ToDictionary(x => x.Key, x => x.Value);
            int place = 1;

            Console.WriteLine($"The V-Logger has a total of {vloggingData.Keys.Count} vloggers in its logs.");

            foreach (var pair in orderVloggers)
            {
                string vloggerName = pair.Key;
                var followers = orderVloggers[vloggerName]["followers"];
                int followersCount = followers.Count;
                int followingsCount = orderVloggers[vloggerName]["followings"].Count;

                Console.WriteLine($"{place}. {vloggerName} : {followersCount} followers, {followingsCount} following");

                if (place == 1)
                {
                    foreach (var follower in followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                place++;
            }
        }
    }
}