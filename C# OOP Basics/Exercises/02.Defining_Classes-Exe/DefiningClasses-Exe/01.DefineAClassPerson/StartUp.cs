using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var personA = new Person();
            personA.Name = "Pesho";
            personA.Age = 20;

            var personB = new Person();
            personB.Name = "Gosho";
            personB.Age = 18;

            var personC = new Person();
            personC.Name = "Stamat";
            personC.Age = 43;

            Console.WriteLine($"{personA.Name} -> {personA.Age}");
            Console.WriteLine($"{personB.Name} -> {personB.Age}");
            Console.WriteLine($"{personC.Name} -> {personC.Age}");
        }
    }
}
