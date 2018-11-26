using System;

namespace Constructors
{
    abstract class Animal
    {
        public Animal(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public virtual void Move()
        {
            Console.WriteLine("MOVING");
        }

        public static void Eat()
        {
            Console.WriteLine("Eating");
        }
    }
}