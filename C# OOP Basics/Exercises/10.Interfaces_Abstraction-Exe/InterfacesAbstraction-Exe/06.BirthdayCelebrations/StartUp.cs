using System;
using System.Collections.Generic;
using System.Globalization;

namespace _06.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var birthdaters = new List<Birthdater>();
            var robots = new List<Robot>();
            
            while(input != "End")
            {
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if(tokens[0] == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    DateTime birthday = ParseToDate(tokens[4]);

                    Birthdater citizen = new Citizen(name, age, id, birthday);
                    birthdaters.Add(citizen);
                }
                else if(tokens[0] == "Robot")
                {
                    string model = tokens[1];
                    string id = tokens[2];

                    Robot robot = new Robot(model, id);
                    robots.Add(robot);
                }
                else if(tokens[0] == "Pet")
                {
                    string name = tokens[1];
                    DateTime birthday = ParseToDate(tokens[2]);

                    Birthdater pet = new Pet(name, birthday);
                    birthdaters.Add(pet);
                }

                input = Console.ReadLine();
            }

            int givenYear = int.Parse(Console.ReadLine());

            foreach(var birthdater in birthdaters)
            {
                if(birthdater.IsBornInThatYear(givenYear))
                {
                    var birthday = birthdater.Birthday.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    Console.WriteLine(birthday);
                }
            }
        }

        static DateTime ParseToDate(string dateAsString)
        {
            var dateTokens = dateAsString.Split('/');
            
            int day = int.Parse(dateTokens[0]);
            int month = int.Parse(dateTokens[1]);
            int year = int.Parse(dateTokens[2]);
            
            return new DateTime(year, month, day);
        }
    }
}