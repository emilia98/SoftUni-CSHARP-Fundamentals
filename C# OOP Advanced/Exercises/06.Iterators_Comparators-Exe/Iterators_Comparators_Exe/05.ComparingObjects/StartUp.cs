using System;
using System.Linq;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        static void Main()
        {
            PeopleCollection people = new PeopleCollection();

            string command = Console.ReadLine();

            while(command != "END")
            {
                string[] tokens = command.Split(" ").ToArray();
                people.AddPerson(GetPerson(tokens));

                command = Console.ReadLine();
            }

            GetStats(people);
        }

        public static Person GetPerson(params string[] tokens)
        {
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string town = tokens[2];

            return new Person(name, age, town);
        }

        public static void GetStats(PeopleCollection people)
        {
            int personIndex = int.Parse(Console.ReadLine()) - 1;
            Person personFound = people.FindPerson(personIndex);

            int equalPeople = 0;
            int notEqualPeople = 0;
            int totalPeople = 0;

            foreach (var person in people)
            {
                totalPeople++;

                if (person.CompareTo(personFound) == 0)
                {
                    equalPeople++;
                    continue;
                }
                notEqualPeople++;
            }

            if (equalPeople == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeople} {notEqualPeople} {totalPeople}");
            }
        }
    }
}