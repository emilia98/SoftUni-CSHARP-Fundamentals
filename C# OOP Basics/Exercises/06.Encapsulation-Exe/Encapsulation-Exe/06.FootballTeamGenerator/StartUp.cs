using System;
using System.Collections.Generic;

namespace _06.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main()
        {
            var teamsData = new Dictionary<string, Team>();

            string input;

            while((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(new char[] { ';' });
                string command = tokens[0];

                if(command == "Team")
                {
                    string teamName = tokens[1];

                    if (teamsData.ContainsKey(teamName))
                    {
                        continue;
                    }

                    try
                    {
                        var team = new Team(teamName);
                        teamsData.Add(teamName, team);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if(command == "Add")
                {
                    string teamName = tokens[1];

                    if(teamsData.ContainsKey(teamName) == false)
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        continue;
                    }

                    string playerName = tokens[2];
                    int endurance = int.Parse(tokens[3]);
                    int sprint = int.Parse(tokens[4]);
                    int dribble = int.Parse(tokens[5]);
                    int passing = int.Parse(tokens[6]);
                    int shooting = int.Parse(tokens[7]);

                    Player player = null;

                    try
                    {
                        var stats = new Stats(endurance, sprint, dribble, passing, shooting);
                        player = new Player(playerName, stats);

                        var team = teamsData[teamName];
                        team.AddPlayer(player);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if(command == "Remove")
                {
                    string teamName = tokens[1];
                    string playerName = tokens[2];

                     var team = teamsData[teamName];
                     team.RemovePlayer(playerName);

                     if (teamsData.ContainsKey(teamName) == false)
                     {
                         //Console.WriteLine($"Team {teamName} does not exist.");
                         //continue;
                     }
                     /*else
                     {
                         var team = teamsData[teamName];
                         team.RemovePlayer(playerName);
                     }*/
                }
                else if(command == "Rating")
                {
                    string teamName = tokens[1];

                    if (teamsData.ContainsKey(teamName) == false)
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        continue;
                        // return;
                    }

                    var team = teamsData[teamName];
                    Console.WriteLine($"{team.Name} - {Math.Round(team.Rating)}");
                }
                // input = Console.ReadLine();
            }
        }
    }
}