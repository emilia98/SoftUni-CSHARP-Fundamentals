using System;
using System.Collections.Generic;

namespace _06.StrategyPattern
{
    public class StartUp
    {
        static void Main()
        {
            SortedSet<IPerson> setOne = new SortedSet<IPerson>(new NameComparer());
            SortedSet<IPerson> setTwo = new SortedSet<IPerson>(new AgeComparer());

            int linesCnt = int.Parse(Console.ReadLine());
            
            for (int cnt = 1; cnt <= linesCnt; cnt++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(" ");

                IPerson person = GetPerson(tokens);
                setOne.Add(person);
                setTwo.Add(person);
            }

            PrintSet(setOne);
            PrintSet(setTwo);
        }

        public static Person GetPerson(params string[] tokens)
        {
            string name = tokens[0];
            int age = int.Parse(tokens[1]);

            return new Person(name, age);
        }

        public static void PrintSet(SortedSet<IPerson> set)
        {
            foreach (var person in set)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
    }
}