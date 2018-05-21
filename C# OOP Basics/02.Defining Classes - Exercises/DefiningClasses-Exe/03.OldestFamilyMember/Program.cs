using System;

namespace _03.OldestFamilyMember
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var family = new Family();

            for(int line = 1; line <= n; line++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(' ');

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                var person = new Person(name, age);
                family.AddMember(person);
            }

            var oldestPerson = family.GetOldestMember();
            Console.WriteLine("{0} {1}", oldestPerson.Name, oldestPerson.Age);
        }
    }
}
