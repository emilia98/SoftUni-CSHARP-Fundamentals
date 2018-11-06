using System;
using System.Collections.Generic;

namespace _07.FoodShortage
{
    public class StartUp
    {
        static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());

            //var members = new Dictionary<string, IBuyer>();
            var citizens = new Dictionary<string, Citizen>();
            var rebels = new Dictionary<string, Rebel>();

            for(int cnt = 1; cnt <= peopleCount; cnt++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if(tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthdate = tokens[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);

                    if(citizens.ContainsKey(name) == false)
                    {
                        citizens.Add(name, citizen);
                    }
                }
                else if(tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];

                    Rebel rebel = new Rebel(name, age, group);

                    if (rebels.ContainsKey(name) == false)
                    {
                        rebels.Add(name, rebel);
                    }
                }
            }

            string command = Console.ReadLine();
            int foodPurchased = 0;

            while(command != "End")
            {
                string nameToFind = command.Trim();

                if(citizens.ContainsKey(nameToFind))
                {
                    var member = citizens[nameToFind];

                    int oldValue = member.Food;
                    int newValue = -1;
                    citizens[nameToFind].BuyFood();
                    
                    newValue = member.Food;
                    foodPurchased += newValue - oldValue;
                }
                else if (rebels.ContainsKey(nameToFind))
                {
                    var member = rebels[nameToFind];

                    int oldValue = member.Food;
                    int newValue = -1;
                    rebels[nameToFind].BuyFood();

                    newValue = member.Food;
                    foodPurchased += newValue - oldValue;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(foodPurchased);
        }
    }
}