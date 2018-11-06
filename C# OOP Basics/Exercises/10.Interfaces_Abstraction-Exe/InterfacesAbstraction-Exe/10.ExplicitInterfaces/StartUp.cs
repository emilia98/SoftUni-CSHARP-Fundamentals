using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();

            while(input != "End")
            {
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                Citizen citizen = new Citizen(name, country, age);

                IResident resident = citizen;
                IPerson person = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                input = Console.ReadLine();
            }
        }
    }
}