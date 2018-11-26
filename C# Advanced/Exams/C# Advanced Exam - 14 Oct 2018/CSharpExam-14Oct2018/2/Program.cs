using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2
{
    class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();
            var userData = new Dictionary<string, Dictionary<string, int>>();

            while(command != "end")
            {
                var tokens = Regex.Split(command, @"\s+\-\>\s+");

                if(tokens.Length == 1)
                {
                    string userToBan = command.Replace("ban ", "");
                    var anotherTokens = Regex.Split(command, @"\s+");

                    userData.Remove(userToBan);
                }
                else
                {
                    string username = tokens[0];
                    string tag = tokens[1];
                    int likes = int.Parse(tokens[2]);

                    if(userData.ContainsKey(username) == false)
                    {
                        userData.Add(username, new Dictionary<string, int>());
                    }
                    
                    if(userData[username].ContainsKey(tag) == false)
                    {
                        userData[username].Add(tag, 0);
                    }

                    userData[username][tag] += likes;
                }
                command = Console.ReadLine();
            }
            
            var sortUsersData = userData.OrderByDescending(x => x.Value.Sum(y => y.Value))
                .ThenBy(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            foreach(var user in sortUsersData)
            {
                string username = user.Key;
                var tags = user.Value;

                Console.WriteLine(username);
                foreach(var tagData in tags)
                {
                    Console.WriteLine($"- {tagData.Key}: {tagData.Value}");
                }
            }
        }
    }
}
