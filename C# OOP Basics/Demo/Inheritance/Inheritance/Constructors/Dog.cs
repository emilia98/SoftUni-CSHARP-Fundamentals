using System;

namespace Constructors
{
    class Dog : Animal
    {
        public Dog(string name) :base(name)
        {
        }

        public void Bark()
        {
            Console.WriteLine("Barking...");
        }

        // We can override method Move() here, but stop child class of this class
        // to ovveride the same method, becuase of sealed
        public sealed override void Move()
        {
            Console.WriteLine("Running...");
        }
    }
}