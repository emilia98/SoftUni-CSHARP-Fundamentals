using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OpinionPoll
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var pollData = new Dictionary<int, Person>();

            for (int line = 1; line <= n; line++)
            {
                string info = Console.ReadLine();
                var tokens = info.Split(' ');
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                var person = new Person(name, age);
                pollData.Add(line, person);
            }

            foreach (var person in pollData.Values
                                           .Where(el => el.Age > 30)
                                           .OrderBy(el => el.Name))
            {
                Console.WriteLine("{0} - {1}", person.Name, person.Age);
            }
        }
    }
}
