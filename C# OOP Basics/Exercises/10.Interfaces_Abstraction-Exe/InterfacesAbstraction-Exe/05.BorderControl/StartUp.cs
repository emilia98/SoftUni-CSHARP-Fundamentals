using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BorderControl
{
    public class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var members = new List<Member>();
            var detained = new List<Member>();

            while(input != "End")
            {
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if(tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    Citizen citizen = new Citizen(name, age, id);

                    members.Add(citizen);
                    citizen.ShouldBeDetained("420");
                }
                else if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    string id = tokens[1];

                    Robot robot = new Robot(model, id);

                    members.Add(robot);
                    robot.ShouldBeDetained("420");
                }
                input = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();

            detained = members.Where(x => x.ShouldBeDetained(fakeId)).ToList();

            foreach(var p in detained)
            {
                Console.WriteLine(p.Id);
            }
        }
    }
}