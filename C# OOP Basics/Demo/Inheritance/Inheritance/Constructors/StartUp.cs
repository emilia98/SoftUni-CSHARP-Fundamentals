using System;

namespace Constructors
{
    class StartUp
    {
        static void Main()
        {
            var dog = new Dog("Sharo");
            var puppy = new Puppy("Malcho", 3);

            Console.WriteLine(dog.Name);
            Console.WriteLine(puppy.Name);
            Console.WriteLine(puppy.CanGoOut);
        }
    }
}
