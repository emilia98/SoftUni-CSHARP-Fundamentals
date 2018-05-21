using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OpinionPoll_2
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var pollData = new List<Person>();

            while(n > 0)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(' ');

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                var person = new Person();
                person.Name = name;
                person.Age = age;
                pollData.Add(person);

                n--;
            }

            foreach(var person in pollData.Where(el => el.Age > 30)
                                          .OrderBy(el => el.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
