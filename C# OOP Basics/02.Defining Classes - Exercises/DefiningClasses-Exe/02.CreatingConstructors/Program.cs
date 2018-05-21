using System;

namespace _02.CreatingConstructors
{
    class Program
    {
        static void Main()
        {
            var person1 = new Person();
            var person2 = new Person(18);
            var person3 = new Person(25, "Tosho");

            var people = new Person[]
            {
                person1, person2, person3
            };

            foreach (var person in people)
            {
                Console.WriteLine("Name: {0}, Age: {1}", person.Name, person.Age);
            }

        }
    }
}
