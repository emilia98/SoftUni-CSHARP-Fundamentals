using System;

namespace OldestFamilyMember
{
    public class StartUp
    {
        static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());
            var family = new Family();

            for(int cnt = 1; cnt <= linesCount; cnt++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                var person = new Person(name, age);

                family.AddMember(person);
            }

            var oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
