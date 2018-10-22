using System;
using System.Collections.Generic;
using System.Linq;

namespace OpinionPoll_2
{
    public class StartUp
    {
        static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());
            var peopleData = new List<Person>();

            for (int cnt = 1; cnt <= linesCount; cnt++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' },
                                         StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                var person = new Person();

                person.Name = name;
                person.Age = age;
                peopleData.Add(person);
            }

            var sortedData = peopleData.OrderBy(x => x.Name);

            foreach (var person in sortedData)
            {
                if(person.Age > 30)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }
        }
    }
}
