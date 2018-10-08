using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Ranking
    {
        static Dictionary<string, string> contestsData = new Dictionary<string, string>();
        static Dictionary<string, Dictionary<string, int>> usersData = new Dictionary<string, Dictionary<string, int>>();
        static Dictionary<string, int> usersByPoints = new Dictionary<string, int>();

        static void Main()
        {
            string contest = Console.ReadLine();

            while (contest != "end of contests")
            {
                var tokens = contest.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                string contestName = tokens[0];
                string contestPassword = tokens[1];

                // There will be no case with two equal contests
                if (contestsData.ContainsKey(contestName) == false)
                {
                    contestsData.Add(contestName, contestPassword);
                }

                contest = Console.ReadLine();
            }

            string submission = Console.ReadLine();


            while (submission != "end of submissions")
            {
                var tokens = submission.Split(new char[] { '=', '>' },
                                              StringSplitOptions.RemoveEmptyEntries);
                string contestName = tokens[0];
                string contestPassword = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                FillUserData(contestName, contestPassword, username, points);
                submission = Console.ReadLine();
            }

            PrintResult();
        }

        static void FillUserData(string contest, string password, string username, int points)
        {
            if (contestsData.ContainsKey(contest) == false)
            {
                return;
            }

            if (contestsData[contest] != password)
            {
                return;
            }

            if (usersData.ContainsKey(username) == false)
            {
                usersData.Add(username, new Dictionary<string, int>());
                usersByPoints.Add(username, 0);
            }

            if (usersData[username].ContainsKey(contest) == false)
            {
                usersData[username].Add(contest, points);
                usersByPoints[username] += points;
            }
            else
            {
                int oldPoints = usersData[username][contest];

                if (oldPoints < points)
                {
                    usersData[username][contest] = points;
                    usersByPoints[username] = usersByPoints[username] - oldPoints + points;
                }
            }
        }

        static void PrintResult()
        {
            var bestCandidate = usersByPoints.OrderByDescending(x => x.Value)
                                    .Take(1)
                                    .ToDictionary(x => x.Key, x => x.Value);
            var orderedUsersData = usersData.OrderBy(x => x.Key)
                                           .ToDictionary(x => x.Key, x => x.Value);

            foreach (var pair in bestCandidate)
            {
                Console.WriteLine($"Best candidate is {pair.Key} with total {pair.Value} points.");
            }

            Console.WriteLine("Ranking:");

            foreach (var userInfo in orderedUsersData)
            {
                string username = userInfo.Key;
                var compets = userInfo.Value;

                Console.WriteLine(username);
                foreach (var competInfo in compets.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {competInfo.Key} -> {competInfo.Value}");
                }
            }
        }
    }
}