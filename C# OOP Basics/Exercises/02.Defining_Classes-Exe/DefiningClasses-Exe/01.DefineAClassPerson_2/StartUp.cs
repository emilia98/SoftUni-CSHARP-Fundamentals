using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var personA = new Person("Pesho", 20);
            var personB = new Person("Gosho", 18);
            var personC = new Person("Stamat", 43);

            Console.WriteLine($"{personA.Name} -> {personA.Age}");
            Console.WriteLine($"{personB.Name} -> {personB.Age}");
            Console.WriteLine($"{personC.Name} -> {personC.Age}");
        }
    }
}
