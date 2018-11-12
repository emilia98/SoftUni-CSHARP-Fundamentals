using System;

namespace _03.OldestFamilyMember_3
{
    public class StartUp
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            var family = new Family();
            
            while(lines > 0)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(' ');

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                var person = new Person();
                person.Name = name;
                person.Age = age;
                family.Members.Add(person);

                lines--;
            }
            var oldestPerson = family.GetOldestMember();
            Console.WriteLine("{0} {1}", oldestPerson.Name, oldestPerson.Age);
        }
    }
}