using System;
using System.Collections.Generic;

namespace _07.EqualityLogic
{
    public class StartUp
    {
        static void Main()
        {
            SortedSet<Person> sorted = new SortedSet<Person>(new CustomComparer());
            HashSet<Person> hash = new HashSet<Person>();

            int linesCount = int.Parse(Console.ReadLine());

            for (int cnt = 1; cnt <= linesCount; cnt++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(" ");

                Person person = (Person)GetPerson(tokens);
                sorted.Add(person);
                hash.Add(person);
            }

            Console.WriteLine(sorted.Count);
            Console.WriteLine(hash.Count);
        }

        public static IPerson GetPerson(params string[] tokens)
        {
            string name = tokens[0];
            int age = int.Parse(tokens[1]);

            return new Person(name, age);
        }
    }
}